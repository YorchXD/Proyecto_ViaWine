
import time
from datetime import datetime
from threading import Lock, Thread
import threading
from time import sleep

try:
   import queue
except ImportError:
   import Queue as queue
   
         
class Proceso(threading.Thread):
    ############## SENSOR 1: BOTELLAS ##############
    def registro_botella_sensor1(self):
        try:
            while (self.contBotellas1<=self.botellasPlan):
                #Crea el registro de la botella
                horaInicio = time.strftime("%H:%M:%S")
                
                #Registra la botella en la cola de prioridad del sensor 1
                self.lockSensor1.acquire()
                self.botellas_sensor1.put(horaInicio)
                self.lockSensor1.release() 
                #print("contBotellas1: " + str(contBotellas1) + "\n") 
                self.contBotellas1+=1
                sleep(0.3) #Lo que demora en pasar la botella  
                sleep(0.2) #El espacio entre botellas   
                
        except Exception as e:
            evento = "Ocurrio un error en la funcion registro_botella_sensor1: " + str(e)
            print(evento)


    ############## SENSOR 2: BOTELLAS ##############
    def registro_botella_sensor2(self):
        try:
            sleep(10) #cuando pasa la primera botella en el segundo sensor
            while (self.contBotellas2<=self.botellasPlan):

                #Valida que la botella este etiquetada y la registra en la BD. Ademas se debe borrar el registro de la lista temporal
                
                if(self.contBotellas2<self.contBotellas1 and not self.botellas_sensor1.empty()):  
                    
                    #Se procede a setear la hora de termino de la botella pasada por el sensor 1 ya que paso por el sensor 2
                    horaTermino = time.strftime("%H:%M:%S")
                    
                    #Registra la botella finalizada en la cola de prioridad del sensor 2
                    self.lockSensor2.acquire()
                    self.botellas_sensor2.put(horaTermino)
                    self.lockSensor2.release()
                    
                    self.contBotellas2+=1
                    #print("contBotellas2: " + str(contBotellas2) + "\n")  
                    sleep(0.3) #Lo que demora en pasar la botella  
                sleep(0.2) #El espacio entre botellas                            
                    
        except Exception as e:
            evento = "Ocurrio un error en la funcion registro_botella_sensor2: " + str(e)
            print(evento)

    #Registra los datos de la botellas en la base de datos
    def cargar_registro_botella(self):
        try:
            while (self.contImpresionBotella<=self.botellasPlan):
                if(not self.botellas_sensor1.empty() and not self.botellas_sensor2.empty()):
                    
                    #obtener primero los datos, luego eliminarlo y por ultimo enviarlo
                    self.lockSensor1.acquire()
                    self.botella1=self.botellas_sensor1.get()
                    self.lockSensor1.release()
                    
                    self.lockSensor2.acquire()
                    self.botella2=self.botellas_sensor2.get()
                    self.lockSensor2.release()
                    
                    print("------------------------PROCESO " + str(self.numProceso) + "------------------------")
                    print("Botella " + str(self.contImpresionBotella) + ": "  + str(self.botella1) + " | " + str(self.botella2))
                    self.contImpresionBotella+=1
                
        except Exception as e:
            evento = "Ocurrio un error en la funcion cargar_registro_botella: " + str(e)
            print(evento)

    ############## SENSOR 3: CAJAS ##############
    def registro_cajas_sensor3(self):
        try:
            sleep(16)
            while (self.contCajas<=self.cajasPlan):
                #Crea el registro de la botella
                hora = time.strftime("%H:%M:%S")
                
                #Registra la botella en la cola de prioridad del sensor 1
                self.lockSensor3.acquire()
                self.cajas_sensor3.put(hora)
                self.lockSensor3.release() 
                
                self.contCajas+=1
                #print("contCajas: " + str(contCajas) + "\n")   
                sleep(1) #Lo que demora en pasar 1 caja
                sleep(4) #Espacio entre cajas
                                            
        except Exception as e:
            evento = "Ocurrio un error en la funcion registro_cajas_sensor3: " + str(e)
            print(evento)

    #Registra los datos de la botellas en la base de datos
    def cargar_registro_caja(self):
        try:
            while (self.contImpresionCaja<=self.cajasPlan):
                if(not self.cajas_sensor3.empty()):
                    #obtener primero los datos, luego eliminarlo y por ultimo enviarlo
                    self.lockSensor3.acquire()
                    self.caja=self.cajas_sensor3.get()
                    self.lockSensor3.release()
                    
                    print("------------------------PROCESO " + str(self.numProceso) + "------------------------")
                    print("Caja " + str(self.contImpresionCaja) + ": " + str(self.caja) )
                    self.contImpresionCaja+=1
                    
        except Exception as e:
            evento = "Ocurrio un error en la funcion cargar_registro_caja: " + str(e)
            print(evento)
    
    def __init__(self):
        threading.Thread.__init__(self)
        #Datos monitoreo de sensores
        self.lockSensor1 = Lock()
        self.lockSensor2 = Lock()
        self.lockSensor3 = Lock()
        self.botellas_sensor1 = queue.Queue()
        self.botellas_sensor2 = queue.Queue()
        self.cajas_sensor3 = queue.Queue()
        self.contBotellas1 = 1
        self.contBotellas2 = 1
        self.contCajas = 1
        self.contImpresionBotella=1
        self.contImpresionCaja=1
        self.numProceso = -1

        self.cajasPlan = 15
        self.botellasPlan = 6 * self.cajasPlan 
        
    def run(self):
        self.numProceso = threading.currentThread().getName()
        #print("Hello, I am the thread %s" % numProceso)
        
        #Ejecuta la funcion principal
        evento = "Se comienza a ejecutar el script para procesar datos" + str(self.numProceso)
        print(evento)
        #Comienza a crear los hilos de ejecucion
        listaThreads = []
        for func in [self.registro_botella_sensor1, self.registro_botella_sensor2, self.cargar_registro_botella, self.registro_cajas_sensor3, self.cargar_registro_caja]:
            listaThreads.append(Thread(target=func))
            listaThreads[-1].start()
        