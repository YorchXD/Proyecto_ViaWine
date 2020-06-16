from Caja import Caja
from OrdenPlanificada import OrdenPlanificada
from Botella import Botella
#import os
import time
import pyodbc
#import serial
#from datetime import date
from datetime import datetime
import RPi.GPIO as GPIO

from threading import Lock, Thread
from time import sleep
from datetime import datetime
import queue


#Variables globales

#Datos base de datos
datosBD = 'Driver={freetds};SERVER=190.171.160.83;PORT=1433;DATABASE=Automatizacion_ViaWines2.0;UID=sa;PWD=J1h4m3b012*;TDS_Version=4.2;'
#conn = pyodbc.connect(datosBD)

#Datos conectores de los sensores
GPIO.setmode(GPIO.BCM)
GPIO.setwarnings(False)

TRIG1= 18
TRIG2= 12
TRIG3= 4

GPIO.setup(TRIG1, GPIO.IN,pull_up_down=GPIO.PUD_UP)     #CONFIGURACION DEL SENSOR FOTOELECTRICO 1 MODO PULL_UP
GPIO.setup(TRIG2, GPIO.IN,pull_up_down=GPIO.PUD_UP)     #CONFIGURACION DEL SENSOR FOTOELECTRICO 2 MODO PULL_UP
GPIO.setup(TRIG3, GPIO.IN,pull_up_down=GPIO.PUD_UP)     #CONFIGURACION DEL SENSOR CAPACITIVO MODO PULL_UP

#Datos monitoreo de sensores
lockSensor1 = Lock()
lockSensor2 = Lock()
lockSensor3 = Lock()
lockOrdenIniciada = Lock()
botellas_sensor1 = queue.Queue()
botellas_sensor2 = queue.Queue()
cajas_sensor3 = queue.Queue()
contBotellas1 = 0
contBotellas2 = 0
contCajas = 0
ordenIniciada = False
orden = None

#Registra algun evento realizado por la RPI (ejecucion del script, un error, etc)
def registrarLog(evento):
    try:
        fechaHora = datetime.now()  
        fecha = fechaHora.strftime('%Y-%m-%d')  
        hora = fechaHora.strftime("%H:%M:%S")
        #cursor = conn.cursor()
        cursor = pyodbc.connect(datosBD).cursor()
        cursor.execute("INSERT INTO [dbo].[LogsRPI](fecha, hora, evento) VALUES (?,?,?)", fecha, hora, evento)
        cursor.commit()
        cursor.close()
    except Exception as e:
        print("Error: " + str(e))

#Obtiene una orden que se encuentre iniciada en la base de datos
def obtenerOrdenIniciada():
    try:
        #cursor = conn.cursor()
        #fecha = datetime.now().strftime('%Y-%m-%d')
        fecha = "2020-05-12"
        cursor = pyodbc.connect(datosBD).cursor()
        
        cursor.execute("SELECT * FROM OrdenPlanificada WHERE fechaFabricacion = '"+fecha+"'")
        
 
        for row in cursor.fetchall():
            if(row[9]==1):
                orden = OrdenPlanificada(row[0],row[1],row[2],row[3],row[4],row[5],row[6],row[9],row[10], row[11])
                cursor.close()
                return orden
        cursor.close()
        return None
        
    except Exception as e:
        evento = "Ocurrio un error en la funcion obtenerOrdenIniciada: " + str(e)
        registrarLog(evento)
        print(evento)

#Obtiene la cantidad de botellas que se encuentran registrada en la base de datos
def obtenerNumeroBotellas(refOrdenPlan):
    try:
        #cursor = conn.cursor()
        cursor = pyodbc.connect(datosBD).cursor()
        #cursor.execute("SELECT count(*) FROM Botellas WHERE fecha = '2020-05-13' and refOrdenPlan = '" + str(refOrdenPlan) + "'")
        cursor.execute("SELECT count(*) FROM Botellas WHERE refOrdenPlan = '" + str(refOrdenPlan) + "'")
        contBotellas = 1
        for row in cursor.fetchall():
            contBotellas = row[0]+1
            #print("Botellas: " + str(row[0]) + " refOrdenPlan: " + str(refOrdenPlan))
        cursor.close()
        return contBotellas
        
    except Exception as e:
        evento = "Ocurrio un error en la funcion obtenerNumeroBotellas: " + str(e)
        registrarLog(evento)
        print(evento)

#Obtiene la cantidad de cajas que se encuentran registrada en la base de datos
def obtenerNumeroCajas(refOrdenPlan):
    try:
        #cursor = conn.cursor()
        cursor = pyodbc.connect(datosBD).cursor()
        #cursor.execute("SELECT count(*) FROM Cajas WHERE fecha = '2020-05-13' and refOrdenPlan = '" + str(refOrdenPlan) + "'")
        cursor.execute("SELECT count(*) FROM Cajas WHERE refOrdenPlan = '" + str(refOrdenPlan) + "'")
        contCajas = 1
        for row in cursor.fetchall():
            contCajas = row[0]+1
            #print("Cajas: " + str(row[0]) + " refOrdenPlan: " + str(refOrdenPlan))
        cursor.close()
        return contCajas
        
    except Exception as e:
        evento = "Ocurrio un error en la funcion obtenerNumeroCajas: " + str(e)
        registrarLog(evento)
        print(evento)

#Consulta si una orden se encuentra iniciada. Para ello depende de la funcion obtenerOrdenIniciada
def esIniciada():
    global ordenIniciada, orden
    validar = True
    while validar:
        ordenTemp = obtenerOrdenIniciada()
        if(ordenTemp!=None and orden.getId()==ordenTemp.getId()):
            ordenIniciada = True
        else:
           ordenIniciada = False 
           validar = False
        sleep(0.15)

############## SENSOR 1: BOTELLAS ##############
def registro_botella_sensor1():
    global botellas_sensor1, TRIG1, contBotellas1, ordenIniciada, orden
    botellaEnSensor1 = False
    fecha  =  time.strftime('%Y-%m-%d') 
    
    while(ordenIniciada):
        if(GPIO.input(TRIG1) == True):
            #Guarda una botella temporal en la lista botellas
            if(botellaEnSensor1 == False):  
                #Crea el registro de la botella
                horaInicio = time.strftime("%H:%M:%S")
                botella = Botella(contBotellas1, fecha, horaInicio, orden.getId())
                
                #Registra la botella en la cola de prioridad del sensor 1
                lockSensor1.acquire()
                botellas_sensor1.put(botella)
                lockSensor1.release() 
                
                contBotellas1+=1
                print("contBotellas1: " + str(contBotellas1))                               
                botellaEnSensor1 = True
                    
            elif(GPIO.input(TRIG1) == False):
                #Prepara la proxima lectura de botella
                botellaEnSensor1 = False
        sleep(0.1)

############## SENSOR 2: BOTELLAS ##############
def registro_botella_sensor2():
    global botellas_sensor1, botellas_sensor2, TRIG2, contBotellas1, contBotellas2, ordenIniciada, orden
    botellaEnSensor2 = False
    
    while(ordenIniciada):
        if(GPIO.input(TRIG2) == True):
            #Valida que la botella este etiquetada y la registra en la BD. Ademas se debe borrar el registro de la lista temporal
            if(botellaEnSensor2 == False and contBotellas2<contBotellas1 and not botellas_sensor1.empty()):  
                #Se obtiene el dato registrado por el sensor 1
                lockSensor1.acquire()
                botellaAux=botellas_sensor1.get()
                lockSensor1.release()
                
                #Se procede a setear la hora de termino de la botella pasada por el sensor 1 ya que paso por el sensor 2
                horaTermino = time.strftime("%H:%M:%S")
                botellaAux.setHoraTermino(horaTermino)
                
                #Registra la botella finalizada en la cola de prioridad del sensor 2
                lockSensor2.acquire()
                botellas_sensor2.put(botellaAux)
                lockSensor2.release()
                
                contBotellas2+=1
                print("contBotellas2: " + str(contBotellas2))                                 
                botellaEnSensor2 = True
                    
            elif(GPIO.input(TRIG2) == False):
                #Prepara la proxima lectura de botella
                botellaEnSensor2 = False
        sleep(0.1)

#Registra los datos de la botellas en la base de datos
def cargar_registro_botella():
    global botellas_sensor2, datosBD

    while ordenIniciada or not botellas_sensor2.empty():
        if(not botellas_sensor2.empty()):
            
            #obtener primero los datos, luego eliminarlo y por ultimo enviarlo
            t1 = datetime.now()
            lockSensor2.acquire()
            botella=botellas_sensor2.get()
            lockSensor2.release()
            t2 = datetime.now()
            #print("t1: " + str(t1.microsecond))
            #print("t2: " + str(t2.microsecond))
            latencia = t2.microsecond-t1.microsecond
            print("Latencia obtener botella a registrar: " + str(latencia))
            
            botella.registrarBD(datosBD)
            print("Registra botella " + str(botella.getId()))
        sleep(0.15)


############## SENSOR 3: CAJAS ##############
def registro_cajas_sensor3():
    global cajas_sensor3, TRIG3, ordenIniciada, contCajas, orden
    
    cajaEnSensor3 = False
    fecha  =  time.strftime('%Y-%m-%d') 
    
    while(ordenIniciada):
        if(GPIO.input(TRIG3) == True):
            #Guarda una botella temporal en la lista botellas
            if(cajaEnSensor3 == False):  
                #Crea el registro de la botella
                hora = time.strftime("%H:%M:%S")
                caja = Caja(contCajas, fecha, hora, orden.getId()) 
                
                #Registra la botella en la cola de prioridad del sensor 1
                lockSensor3.acquire()
                cajas_sensor3.put(caja)
                lockSensor3.release() 
                
                contCajas+=1
                print("contCajas: " + str(contCajas))                               
                cajaEnSensor3 = True
                    
            elif(GPIO.input(TRIG3) == False):
                #Prepara la proxima lectura de botella
                cajaEnSensor3 = False
        sleep(0.1)

#Registra los datos de la botellas en la base de datos
def cargar_registro_caja():
    global cajas_sensor3, datosBD, ordenIniciada

    while (not cajas_sensor3.empty() or ordenIniciada):
        if(not cajas_sensor3.empty()):
            
            #obtener primero los datos, luego eliminarlo y por ultimo enviarlo
            t1 = datetime.now()
            lockSensor3.acquire()
            caja=cajas_sensor3.get()
            lockSensor3.release()
            t2 = datetime.now()
            latencia = t2.microsecond-t1.microsecond
            print("Latencia obtener caja a registrar: " + str(latencia))
            
            caja.registrarBD(datosBD)
            print("Registra caja " + str(caja.getId()))
        sleep(0.15)
 
   
#Se dedica a ejecutar el proceso de una orden en particular
def procesoOrden(ordenAux):
    try:
        global ordenIniciada, contBotellas1, contBotellas2, contCajas, orden
        
        #Se inicializan los contadores de las botellas y de las cajas
        contBotellas1 = obtenerNumeroBotellas(orden.getId())
        contBotellas2 = contBotellas1
        contCajas = obtenerNumeroCajas(orden.getId())
        orden = ordenAux
        ordenIniciada = True
        
        #Comienza a crear los hilos de ejecucion
        listaThreads = []
        for func in [esIniciada, registro_botella_sensor1, registro_botella_sensor2, cargar_registro_botella, registro_cajas_sensor3, cargar_registro_caja]:
            listaThreads.append(Thread(target=func))
            listaThreads[-1].start()
        
        #Esto ayuda a que no se sigan creando hilos de ejecución hasta que se termine la orden
        validador = True
        while(validador):
            if(ordenIniciada==False):
                validador=False
            
    except Exception as e:
        evento = "Ocurrio un error en la funcion procesoOrden: " + str(e)
        registrarLog(evento)
        print(evento)
    except KeyboardInterrupt:
        evento = "Se ha interrumpido el proceso en la funcion procesoOrden desde teclado Ctrl+c"
        registrarLog(evento)
        print(evento)
    
    
#Funcion principal para ejecutar una orden iniciada
def main():
    try:
        while True:
            orden = obtenerOrdenIniciada()
            if(orden!=None):
                print("\nOrden Nro " + str(orden.getRefOrden()) + " iniciada\n")
                
                procesoOrden(orden)
            else:
                print("\nNo hay ordenes iniciadas\n")
            time.sleep(0.3)
    except Exception as e:
        evento = "Ocurrio un error en la funcion main: " + str(e)
        registrarLog(evento)
        print(evento)
        
    except KeyboardInterrupt:
        evento = "Se ha interrumpido el proceso en la funcion main desde teclado Ctrl+c"
        registrarLog(evento)
        print(evento)
        
#Ejecuta la funcion principal
evento = "Se comienza a ejecutar el script para procesar datos"
registrarLog(evento)
print(evento)
main()