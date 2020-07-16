from OrdenPlanificada import OrdenPlanificada
from Material import Material
from ConexionBD import ConexionBD
from datetime import datetime
from threading import Lock, Thread

import RPi.GPIO as GPIO

try:
   import queue
except ImportError:
   import Queue as queue
   
class Sensor(object):
    
    def __init__(self, tipoMaterial, orden, TRIG, contMaterial, bouncetime=None):
        self.tipoMaterial = tipoMaterial
        self.orden = orden
        self.TRIG = TRIG
        self.contMaterial = contMaterial
        self.lockSensor = Lock()
        self.materiales = queue.Queue()
        GPIO.setmode(GPIO.BCM)
        GPIO.setup(self.TRIG, GPIO.IN,pull_up_down=GPIO.PUD_DOWN)     #CONFIGURACION DEL SENSOR FOTOELECTRICO 1 MODO PULL_UP
        
        if(tipoMaterial=="Botella"):
            GPIO.add_event_detect(self.TRIG, GPIO.RISING, bouncetime= bouncetime)
    
    #Obtiene el objeto en donde se encuentran los datos de la orden en ejecuciion
    def getOrden(self):
        return self.orden
    
    #Obtiene el contador del material que se esta procesando
    def getContMaterial(self):
        return self.contMaterial
    
    #Registra algun evento realizado por la RPI (ejecucion del script, un error, etc)
    def registrarLog(self, evento):
        fechaHora = datetime.now()  
        fecha = fechaHora.strftime('%Y-%m-%d')  
        hora = fechaHora.strftime("%H:%M:%S")
        conexion = ConexionBD()
        with conexion:
            conexion.conn.cursor().execute("INSERT INTO LogsRPI(fecha, hora, evento) VALUES (?,?,?)", fecha, hora, evento)
            conexion.conn.commit()
        
    ############## SENSOR  ##############
    def registro(self):
        try:
            while (self.orden.getEstado()==1 or self.orden.getEstado()==2):
                if(self.orden.getEstado()==1 and GPIO.event_detected(self.TRIG)):                    
                    
                    #Crea el registro del material
                    fechaHora = datetime.now()  
                    botella = Material(self.contMaterial, fechaHora, self.orden.getId(), self.tipoMaterial)                    
                    
                    #Registra la botella en la cola de prioridad del sensor 1
                    self.lockSensor.acquire()
                    self.materiales.put(botella)
                    self.lockSensor.release() 
                    print("contBotellas: " + str(self.contMaterial) + "\n") 
                    self.contMaterial+=1
            print("Termino de registrar: " + self.tipoMaterial)
                
        except Exception as e:
            evento = "Ocurrio un error en la funcion registro de " + self.tipoMaterial + " en la clase Sensor: " + str(e)
            #self.registrarLog(evento)
            print(evento)
    
    #Registra los datos en la base de datos
    def cargar_registro(self):
        try:
            while (self.orden.getEstado()==1 or self.orden.getEstado()==2 or not self.materiales.empty()):                
                if(not self.materiales.empty()):
                    
                    self.lockSensor.acquire()
                    material=self.materiales.get()
                    self.lockSensor.release()
                    
                    #Registra la botella en la BD
                    #material.registrarBD()
                    print("------------------------PROCESO DE ORDEN" + str(self.orden.getRefOrden()) + "------------------------")
                    print(self.tipoMaterial + " " + str(material.getId()) + ": "  + str(material.getFechaHora()))
                
        except Exception as e:
            evento = "Ocurrio un error en la funcion cargar_registro de " + self.tipoMaterial + " en la clase sensor: " + str(e)
            print(evento)
            #self.registrarLog(evento)
    
    