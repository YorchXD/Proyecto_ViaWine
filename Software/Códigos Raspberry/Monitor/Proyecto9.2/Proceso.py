#!/usr/bin/env python2
# -*- coding: utf-8 -*-
"""
Created on Wed Jun 24 01:41:22 2020

@author: pi
"""


import time
from datetime import datetime
from threading import Lock, Thread
import threading

from Caja import Caja
from OrdenPlanificada import OrdenPlanificada
from Botella import Botella
from ConexionBD import ConexionBD


import RPi.GPIO as GPIO

try:
   import queue
except ImportError:
   import Queue as queue

class Proceso(threading.Thread):
    #Registra algun evento realizado por la RPI (ejecucion del script, un error, etc)
    def registrarLog(self, evento):
        fechaHora = datetime.now()  
        fecha = fechaHora.strftime('%Y-%m-%d')  
        hora = fechaHora.strftime("%H:%M:%S")
        conexion = ConexionBD()
        with conexion:
            conexion.conn.cursor().execute("INSERT INTO LogsRPI(fecha, hora, evento) VALUES (?,?,?)", fecha, hora, evento)
            conexion.conn.commit()

    #Cambia el estado de la orden que se encuentra en ejecucion
    def cambiarEstado(self):
        try:
            while(self.orden.getEstado()<=2):
                
                fecha = datetime.now().strftime('%Y-%m-%d')
                query = "SELECT * FROM OrdenPlanificada WHERE fechaFabricacion = '"+fecha+"' and refOrden = '"+str(self.orden.getRefOrden())+"'"
                conexion = ConexionBD()
                
                with conexion:
                    datos = conexion.conn.cursor().execute(query).fetchall()
                    conexion.conn.commit()
                    for row in datos:
                        if(self.orden.getId()==row[0]):
                            self.orden.setEstado(row[9])                
            
        except Exception as e:
            evento = "Ocurrio un error en la funcion cambiarEstado en Main: " + str(e)
            self.registrarLog(evento)
        
        
    #Obtiene la cantidad de botellas que se encuentran registrada en la base de datos
    def obtenerNumeroBotellas(self):
        try:
            query = "SELECT count(*) FROM Botellas WHERE refOrdenPlan = '" + str(self.orden.getId()) + "'"
            conexion = ConexionBD()
            contBotellas = 1
            
            with conexion:
                datos = conexion.conn.cursor().execute(query).fetchall()
                conexion.conn.commit()
                for row in datos:
                    contBotellas = row[0]+1     
            return contBotellas
            
        except Exception as e:
            evento = "Ocurrio un error en la funcion obtenerNumeroBotellas: " + str(e)
            self.registrarLog(evento)
            #print(evento)

    #Obtiene la cantidad de cajas que se encuentran registrada en la base de datos
    def obtenerNumeroCajas(self):
        try:
            query = "SELECT count(*) FROM Cajas WHERE refOrdenPlan = '" + str(self.orden.getId()) + "'"
            conexion = ConexionBD()
            contCajas = 1
            
            with conexion:
                datos = conexion.conn.cursor().execute(query).fetchall()
                conexion.conn.commit()
                for row in datos:
                    contCajas = row[0]+1    
            return contCajas
            
        except Exception as e:
            evento = "Ocurrio un error en la funcion obtenerNumeroCajas: " + str(e)
            self.registrarLog(evento)
            #print(evento)
            
    
    ############## SENSOR 1 o 2: BOTELLAS ##############
    def registro_botellas(self):
        try:
            fecha  =  time.strftime('%Y-%m-%d') 
            while (self.orden.getEstado()==1 or self.orden.getEstado()==2):
                if(self.orden.getEstado()==1 and GPIO.event_detected(self.TRIG_BOTELLA)):                    
                    #Crea el registro de la botella
                    horaInicio = time.strftime("%H:%M:%S")
                    botella = Botella(self.contBotellas, fecha, horaInicio, self.orden.getId(), horaInicio)                    
                    #Registra la botella en la cola de prioridad del sensor 1
                    self.lockSensorBotella.acquire()
                    self.botellas.put(botella)
                    self.lockSensorBotella.release() 
                    print("contBotellas: " + str(self.contBotellas) + "\n") 
                    self.contBotellas+=1
            #print("Termino registro_botella_sensor1")
                
        except Exception as e:
            evento = "Ocurrio un error en la funcion registro_botella: " + str(e)
            self.registrarLog(evento)
            #print(evento)
    
    #Registra los datos de la botellas en la base de datos
    def cargar_registro_botellas(self):
        try:
            while (self.orden.getEstado()==1 or self.orden.getEstado()==2 or not self.botellas.empty()):                
                if(not self.botellas.empty()):
                    self.lockSensorBotella.acquire()
                    botella=self.botellas.get()
                    self.lockSensorBotella.release()
                    #Registra la botella en la BD
                    botella.registrarBD()
                    #print("------------------------PROCESO " + str(self.numProceso) + "------------------------")
                    #print("Botella " + str(botella.getId()) + ": "  + str(botella.getHoraInicio()) + " | " + str(botella.getHoraTermino()))
                
        except Exception as e:
            evento = "Ocurrio un error en la funcion cargar_registro_botella: " + str(e)
            self.registrarLog(evento)
            
    ############## SENSOR 3: CAJAS ##############
    def registro_cajas(self):
        try:
            cajaEnSensor = False
            fecha  =  time.strftime('%Y-%m-%d')
            while (self.orden.getEstado()==1 or self.orden.getEstado()==2):
                if (self.orden.getEstado()==1 and GPIO.input(self.TRIG_CAJAS) == True):
                    if(cajaEnSensor == False):
                        #Crea el registro de la botella
                        hora = time.strftime("%H:%M:%S")
                        caja = Caja(self.contCajas, fecha, hora, self.orden.getId()) 
                        #Registra la botella en la cola de prioridad del sensor 1
                        self.lockSensorCaja.acquire()
                        self.cajas.put(caja)
                        self.lockSensorCaja.release() 
                        #print("contCajas: " + str(self.contCajas) + "\n")  
                        cajaEnSensor = True
                        self.contCajas+=1
                #Prepara la proxima lectura de botella
                elif(GPIO.input(self.TRIG_CAJAS) == False):
                    cajaEnSensor = False
                                            
        except Exception as e:
            evento = "Ocurrio un error en la funcion registro_cajas: " + str(e)
            self.registrarLog(evento)
            #print(evento)

    #Registra los datos de la botellas en la base de datos
    def cargar_registro_cajas(self):
        try:
            while (self.orden.getEstado()==1 or self.orden.getEstado()==2 or not self.cajas.empty()):
                
                if(not self.cajas.empty()):
                    #obtener primero los datos, luego eliminarlo y por ultimo enviarlo
                    self.lockSensorCaja.acquire()
                    caja=self.cajas.get()
                    self.lockSensorCaja.release()
                    
                    #Registra la botella en la BD
                    caja.registrarBD()
                    
                    #print("------------------------PROCESO " + str(self.numProceso) + "------------------------")
                    #print("Caja " + str(caja.getId()) + ": " + str(caja.getHora()) )
                    #self.contImpresionCaja+=1
            #print("Termino cargar_registro_caja")
                    
        except Exception as e:
            evento = "Ocurrio un error en la funcion cargar_registro_caja: " + str(e)
            self.registrarLog(evento)
            #print(evento)
            
    def run(self):
        try:
            self.numProceso = threading.currentThread().getName()
            #print("Hello, I am the thread %s" % numProceso)
            
            #Ejecuta la funcion principal
            evento = "Se comienza a procesar datos de la orden num. " + str(self.orden.refOrden) + " con "+ str(self.contBotellas-1) + " contBotellas y " + str(self.contCajas-1)+ " contCajas. " + str(self.numProceso) 
            self.registrarLog(evento)
            #self.orden.imprimirOrden()
            
            #Comienza a crear los hilos de ejecucion y va a depender del formato de botella el sensor que se escogera para el conteo de botellas
            listaThreads = []
            for func in [self.registro_botellas, self.cargar_registro_botellas, self.registro_cajas, self.cargar_registro_cajas, self.cambiarEstado]:
                listaThreads.append(Thread(target=func))
                listaThreads[-1].start()
            
            #Esto ayuda a que no se sigan creando hilos de ejecucion de la misma orden hasta que se termine la orden 
            while(self.orden.estado<=2):
                pass
            
            if(self.orden.estado==3):
                evento = "La orden Num. " + str(self.orden.getRefOrden()) + " se ha pospuesto con " + str(self.contBotellas-1) + " contBotellas y " + str(self.contCajas-1)+ " contCajas"
            
            elif(self.orden.estado==4):
                evento = "La orden Num. " + str(self.orden.getRefOrden()) + " ha finalizado con " + str(self.contBotellas-1) + " contBotellas y " + str(self.contCajas-1)+ " contCajas"
            #print(evento)
            self.registrarLog(evento)
        except Exception as e:
            evento = "Ocurrio un error en la funcion run: " + str(e)
            self.registrarLog(evento)
        finally:
            GPIO.cleanup() # asegura una salida limpia de sensores 
            
    def seleccion_sensor_botella(self):
        #if("187,5" in self.orden.formatoCaja or "375" in self.orden.formatoCaja):
        for formato in ["187,5", "375"]: #botellines
            if(formato in self.orden.formatoCaja):
                #print("detecta datos del sensor 1: botellines")
                evento = "Se utiliza el sensor 1 para contar botellines debido a que la botella tiene el siguiente formato: " + str(self.orden.formatoCaja)
                self.registrarLog(evento)
                return 18,300 #indica sensor 1 y el bouncetime(tiempo de rebote) 
                #return 12,250  
        #print("detecta datos del sensor 2: botellas")
        evento = "Se utiliza el sensor 2 para contar botellas debido a que la botella tiene el siguiente formato: " + str(self.orden.formatoCaja)
        self.registrarLog(evento)
        return 12, 300 #indica sensor 2 y el bouncetime(tiempo de rebote) 
        #return 18,250 
    
    def __init__(self, orden):
        threading.Thread.__init__(self)
        #Datos monitoreo de sensores
        self.lockSensorBotella = Lock()
        self.lockSensorCaja = Lock()
        self.botellas = queue.Queue()
        self.cajas = queue.Queue()
        self.orden = orden
        self.contBotellas = self.obtenerNumeroBotellas()
        self.contCajas = self.obtenerNumeroCajas()
        self.numProceso = -1
        self.TRIG_BOTELLA, self.bouncetime = self.seleccion_sensor_botella()
        self.TRIG_CAJAS = 4
        
        GPIO.setmode(GPIO.BCM)
        GPIO.setwarnings(False)
        GPIO.setup(self.TRIG_BOTELLA, GPIO.IN,pull_up_down=GPIO.PUD_DOWN)     #CONFIGURACION DEL SENSOR FOTOELECTRICO 1 MODO PULL_UP
        GPIO.setup(self.TRIG_CAJAS, GPIO.IN,pull_up_down=GPIO.PUD_DOWN)     #CONFIGURACION DEL SENSOR CAPACITIVO MODO PULL_UP
        GPIO.add_event_detect(self.TRIG_BOTELLA, GPIO.RISING, bouncetime= self.bouncetime)

        

        
    
        
    
        