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
        print("Inicia sensor " + self.tipoMaterial)
        
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
    
    def crearRegistro(self):
        #Crea el registro del material
        fechaHora = datetime.now()  
        material = Material(self.contMaterial, fechaHora, self.orden.getId(), self.tipoMaterial)                    
        
        #Registra la botella en la cola de prioridad del sensor 1
        self.lockSensor.acquire()
        self.materiales.put(material)
        self.lockSensor.release() 
        #print("cont" +self.tipoMaterial + ": " + str(self.contMaterial) + "\n") 
        self.contMaterial+=1
        
        
    ############## SENSOR  ##############
    def registro(self):
        try:
            print("comienza a ejecutarse el registro de " + self.tipoMaterial + " con el contador en " + str(self.contMaterial) + " y numero de TRIG " + str(self.TRIG))
            cajaEnSensor = False

            #while (self.orden.estado==1 or self.orden.estado==2):
            while (self.orden.estado==1):
                #if(self.orden.getEstado()==1):                    
                if(self.tipoMaterial=="Caja" and GPIO.input(self.TRIG) == True):
                    if(cajaEnSensor == False):
                        self.crearRegistro()
                        cajaEnSensor = True
                elif(self.tipoMaterial=="Caja" and GPIO.input(self.TRIG) == False):
                    cajaEnSensor = False
                elif(self.tipoMaterial=="Botella" and GPIO.event_detected(self.TRIG)):
                    self.crearRegistro()
                    
                
                #print("Estado de la orden en el sensor de " + self.tipoMaterial + " es " + str(self.orden.getEstado()) + "\n")
                        
            evento = "La orden num. "+ str(self.orden.getRefOrden())+ " termino de registrar " + self.tipoMaterial + " cuando el estado de la orden es " + str(self.orden.getEstado())
            #print(evento + "\n")
            self.registrarLog(evento)
                
        except Exception as e:
            evento = "Ocurrio un error en la funcion registro de " + self.tipoMaterial + " en la clase Sensor: " + str(e)
            self.registrarLog(evento)
            #print(evento)
        except KeyboardInterrupt:
            evento = "Se ha interrumpido el proceso en la funcion registro desde teclado Ctrl+c"
            #GPIO.setmode(GPIO.BCM)
            #GPIO.cleanup() # asegura una salida limpia de sensores 
            self.registrarLog(evento)
            #print(evento)
        
    #Registra los datos en la base de datos
    def cargar_registro(self):
        try:
            #while (self.orden.getEstado()==1 or self.orden.getEstado()==2 or not self.materiales.empty()):
            while (self.orden.getEstado()==1 or not self.materiales.empty()):                   
                if(not self.materiales.empty()):
                    
                    self.lockSensor.acquire()
                    material=self.materiales.get()
                    self.lockSensor.release()
                    
                    #Registra la botella en la BD
                    material.registrarBD()
                    #print("------------------------PROCESO DE ORDEN" + str(self.orden.getRefOrden()) + "------------------------")
                    #print(self.tipoMaterial + " " + str(material.getId()) + ": "  + str(material.getFechaHora()))
                
        except Exception as e:
            evento = "Ocurrio un error en la funcion cargar_registro de " + self.tipoMaterial + " en la clase sensor: " + str(e)
            #print(evento)
            self.registrarLog(evento)
        except KeyboardInterrupt:
            evento = "Se ha interrumpido el proceso en la funcion cargar_registro desde teclado Ctrl+c"
            #GPIO.cleanup() # asegura una salida limpia de sensores 
            self.registrarLog(evento)
            #print(evento)
    
    