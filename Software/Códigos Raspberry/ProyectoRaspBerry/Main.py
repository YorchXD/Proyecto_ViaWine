from Caja import Caja
from OrdenPlanificada import OrdenPlanificada
from Botella import Botella
import os
import time
import pyodbc
from datetime import date
from datetime import datetime
import RPi.GPIO as GPIO

#Variables globales
conn = pyodbc.connect('Driver={ODBC Driver 17 for SQL Server};SERVER=190.171.160.83;PORT=1433;DATABASE=Automatizacion_ViaWines2.0;UID=sa;PWD=J1h4m3b012*;TDS_Version=4.2;')

GPIO.setmode(GPIO.BCM)
GPIO.setwarnings(False)

TRIG1= 18
TRIG2= 12
TRIG3= 4

GPIO.setup(TRIG1, GPIO.IN,pull_up_down=GPIO.PUD_UP)     #CONFIGURACION DEL SENSOR FOTOELECTRICO 1 MODO PULL_UP
GPIO.setup(TRIG2, GPIO.IN,pull_up_down=GPIO.PUD_UP)     #CONFIGURACION DEL SENSOR FOTOELECTRICO 2 MODO PULL_UP
GPIO.setup(TRIG3, GPIO.IN,pull_up_down=GPIO.PUD_UP)     #CONFIGURACION DEL SENSOR CAPACITIVO MODO PULL_UP
    

#Obtiene una orden que se encuentre iniciada en la base de datos
def obtenerOrdenIniciada():
    try:
        cursor = conn.cursor()
        cursor.execute("SELECT * FROM OrdenPlanificada WHERE fechaFabricacion = '2020-05-13'")
        for row in cursor.fetchall():
            if(row[9]==1):
                orden = OrdenPlanificada(row[0],row[1],row[2],row[3],row[4],row[5],row[6],row[9],row[10])
                return orden
        return None
    except Exception as e:
        print("Ocurrio un error en la funcion procesoOrden: " + str(e))

#Consulta si una orden se encuentra iniciada. Para ello depende de la funcion obtenerOrdenIniciada
def esIniciada(orden):
    ordenTemp = obtenerOrdenIniciada()
    if(ordenTemp is not None and orden.getId()==ordenTemp.getId()):
        return True
    return False

#Obtiene la cantidad de botellas que se encuentran registrada en la base de datos
def obtenerNumeroBotellas(refOrdenPlan):
    try:
        cursor = conn.cursor()
        #cursor.execute("SELECT count(*) FROM Botellas WHERE fecha = '2020-05-13' and refOrdenPlan = '" + str(refOrdenPlan) + "'")
        cursor.execute("SELECT count(*) FROM Botellas WHERE refOrdenPlan = '" + str(refOrdenPlan) + "'")
        contBotellas = 1
        for row in cursor.fetchall():
            contBotellas = row[0]+1
            #print("Botellas: " + str(row[0]) + " refOrdenPlan: " + str(refOrdenPlan))
        return contBotellas, contBotellas
    except Exception as e:
        print("Ocurrio un error en la funcion obtenerNumeroBotellas: " + str(e))

#Obtiene la cantidad de cajas que se encuentran registrada en la base de datos
def obtenerNumeroCajas(refOrdenPlan):
    try:
        cursor = conn.cursor()
        #cursor.execute("SELECT count(*) FROM Cajas WHERE fecha = '2020-05-13' and refOrdenPlan = '" + str(refOrdenPlan) + "'")
        cursor.execute("SELECT count(*) FROM Cajas WHERE refOrdenPlan = '" + str(refOrdenPlan) + "'")
        contCajas = 1
        for row in cursor.fetchall():
            contCajas = row[0]+1
            #print("Cajas: " + str(row[0]) + " refOrdenPlan: " + str(refOrdenPlan))
        return contCajas
    except Exception as e:
        print("Ocurrio un error en la funcion obtenerNumeroCajas: " + str(e))

#Registra algun evento realizado por la RPI (ejecucion del script, un error, etc)
def registrarLog(evento):
    try:
        fechaHora = datetime.now()  
        fecha = fechaHora.strftime('%Y-%m-%d')  
        hora = fechaHora.strftime("%H:%M:%S")
        cursor6 = conn.cursor()
        cursor6.execute("INSERT INTO LogsRPI(fecha, hora, evento) VALUES (?,?,?)", fecha, hora, evento)
        cursor6.close()
    except Exception as e:
        print("Ocurrio un error en la funcion registrarLog: " + str(e))
    
#Se dedica a ejecutar el proceso de una orden en particular
def procesoOrden(orden):
    try:
        contBotellas1, contBotellas2 = obtenerNumeroBotellas(orden.getId())
        
        contCajas = obtenerNumeroCajas(orden.getId())
        botellas=[]
        botellaEnSensor1 = False
        botellaEnSensor2 = False
        cajaEnSensor3 = False
        fecha  =  time.strftime('%Y-%m-%d') 
        
        #orden.imprimirOrden()
        while(esIniciada(orden)):
            #print("Orden Numero "+str(orden.getRefOrden())+" en ejecucion")
            ############## SENSOR 1: BOTELLAS ##############
            if(GPIO.input(TRIG1)==False):
                #Guarda una botella temporal en la lista botellas
                if(botellaEnSensor1 == False):  
                    horaInicio = time.strftime("%H:%M:%S")
                    botella = Botella(contBotellas1, fecha, horaInicio, orden.getId()) 
                    botellas.append(botella) 
                    contBotellas1+=1                               
                    botellaEnSensor1 = True
            elif(GPIO.input(TRIG1)):
                #Prepara la proxima lectura de botella
                botellaEnSensor1 = False
                
            ############## SENSOR 2: BOTELLAS ##############
            if(GPIO.input(TRIG2) == False):
                #Valida que la botella este etiquetada y la registra en la BD. Ademas se debe borrar el registro de la lista temporal
                if(botellaEnSensor2==False and contBotellas2<contBotellas1):  
                    horaTermino = time.strftime("%H:%M:%S")
                    
                    for botellaTemp in botellas: 
                        if(botellaTemp.getId()==contBotellas2):
                            botellaTemp.setHoraTermino(horaTermino)
                            botellaTemp.registrarBD(conn)
                    
                    contBotellas2+=1                               
                    botellaEnSensor2 = True
            elif(GPIO.input(TRIG2)):
                #Prepara la proxima lectura de botella
                botellaEnSensor2 = False
                
            ############## SENSOR 3: CAJAS #################
            if(GPIO.input(TRIG3)==False):
                #Registra una caja en la BD
                if(cajaEnSensor3==False):
                    hora = time.strftime("%H:%M:%S")
                    caja = Caja(contCajas, fecha, hora, orden.getId()) 
                    caja.registrarBD(conn)
                    cajaEnSensor3 = True
                    contCajas+=1
 
            elif(GPIO.input(TRIG3)):
                #Prepara la proxima lectura de botella
                cajaEnSensor3 = False
                
            time.sleep(0.3)
            
        print("Orden Numero "+str(orden.getRefOrden())+" dejo de ejecutarse")
        
    except Exception as e:
        print("Ocurrio un error en la funcion procesoOrden: " + str(e))
    except KeyboardInterrupt:
        print("Se ha interrumpido el proceso en la funcion main desde teclado Ctrl+c")
    
    
#Funcion principal para ejecutar una orden iniciada
def main():
    try:
        while True:
            orden = obtenerOrdenIniciada()
            if(orden is not None):
                print("\nOrden Numero " + str(orden.getRefOrden()) + " iniciada\n")
                procesoOrden(orden)
            else:
                print("\nNo hay ordenes iniciadas\n")
            time.sleep(0.3)
    except Exception as e:
        print("Ocurrio un error en la funcion main: " + str(e))
    except KeyboardInterrupt:
        print("Se ha interrumpido el proceso en la funcion main desde teclado Ctrl+c")
        
#Ejecuta la funcion principal
main()