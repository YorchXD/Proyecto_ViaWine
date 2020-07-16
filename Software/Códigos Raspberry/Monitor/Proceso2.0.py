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

import RPi.GPIO as GPIO

import pyodbc

try:
   import queue
except ImportError:
   import Queue as queue
   

TRIG1= 18
TRIG2= 12
TRIG3= 4

GPIO.setmode(GPIO.BCM)
GPIO.setwarnings(False)

GPIO.setup(TRIG1, GPIO.IN,pull_up_down=GPIO.PUD_UP)     #CONFIGURACION DEL SENSOR FOTOELECTRICO 1 MODO PULL_UP
GPIO.setup(TRIG2, GPIO.IN,pull_up_down=GPIO.PUD_UP)     #CONFIGURACION DEL SENSOR FOTOELECTRICO 2 MODO PULL_UP
GPIO.setup(TRIG3, GPIO.IN,pull_up_down=GPIO.PUD_UP)     #CONFIGURACION DEL SENSOR CAPACITIVO MODO PULL_UP
        
GPIO.add_event_detect(TRIG1, GPIO.RISING)
GPIO.add_event_detect(TRIG2, GPIO.RISING)
#GPIO.add_event_detect(TRIG3, GPIO.RISING, bouncetime=200)

         
class Proceso(threading.Thread):
    #Registra algun evento realizado por la RPI (ejecucion del script, un error, etc)
    def registrarLog(self, evento):
        try:
            fechaHora = datetime.now()  
            fecha = fechaHora.strftime('%Y-%m-%d')  
            hora = fechaHora.strftime("%H:%M:%S")
            cursor = pyodbc.connect(self.datosBD).cursor()
            cursor.execute("INSERT INTO [dbo].[LogsRPI](fecha, hora, evento) VALUES (?,?,?)", fecha, hora, evento)
            cursor.commit()
            cursor.close()
        except Exception as e:
            print("Error: " + str(e))
            
    #Obtiene una orden que se encuentre iniciada en la base de datos
    def cambiarEstado(self):
        try:
            
            while(self.orden.getEstado()<=2):
                fecha = datetime.now().strftime('%Y-%m-%d')
                cursor = pyodbc.connect(self.datosBD).cursor()
                
                cursor.execute("SELECT * FROM OrdenPlanificada WHERE fechaFabricacion = '"+fecha+"' and refOrden = '"+str(self.orden.getRefOrden())+"'")
                
                for row in cursor.fetchall():
                    if(self.orden.getId()==row[0]):
                        self.orden.setEstado(row[9])                
                cursor.close()
            #print("Termino cambiarEstado")
            
        except Exception as e:
            evento = "Ocurrio un error en la funcion cambiarEstado: " + str(e)
            self.registrarLog(evento)
    
    ############## SENSOR 1: BOTELLAS ##############
    def registro_botella_sensor1(self):
        try:
            fecha  =  time.strftime('%Y-%m-%d') 
            
            while (self.orden.getEstado()==1 or self.getEstado()==2):
                
                if(self.orden.getEstado()==1 and GPIO.event_detected(TRIG1)):
                    
                    #Crea el registro de la botella
                    horaInicio = time.strftime("%H:%M:%S")
                    botella = Botella(self.contBotellas1, fecha, horaInicio, self.orden.getId())
                    
                    #Registra la botella en la cola de prioridad del sensor 1
                    self.lockSensor1.acquire()
                    self.botellas_sensor1.put(botella)
                    self.lockSensor1.release() 
                    #print("contBotellas1: " + str(self.contBotellas1) + "\n") 
                    self.contBotellas1+=1
            #print("Termino registro_botella_sensor1")
                
        except Exception as e:
            evento = "Ocurrio un error en la funcion registro_botella_sensor1: " + str(e)
            self.registrarLog(evento)
            #print(evento)


    ############## SENSOR 2: BOTELLAS ##############
    def registro_botella_sensor2(self):
        try:
            fecha  =  time.strftime('%Y-%m-%d') 
            while (self.orden.getEstado()==1 or self.getEstado()==2):
                
                if(self.orden.getEstado()==1 and GPIO.event_detected(TRIG2) and self.contBotellas2<self.contBotellas1):
                        
                    #Se procede a setear la hora de termino de la botella pasada por el sensor 1 ya que paso por el sensor 2
                    horaTermino = time.strftime("%H:%M:%S")
                    botella = Botella(self.contBotellas2, fecha, None, self.orden.getId(),horaTermino)
                    
                    #Registra la botella finalizada en la cola de prioridad del sensor 2
                    self.lockSensor2.acquire()
                    self.botellas_sensor2.put(botella)
                    self.lockSensor2.release()
                    #print("contBotellas1: " + str(self.contBotellas2) + "\n") 
                    self.contBotellas2+=1   
            #print("Termino registro_botella_sensor2")
                    
        except Exception as e:
            evento = "Ocurrio un error en la funcion registro_botella_sensor2: " + str(e)
            self.registrarLog(evento)
            #print(evento)

    #Registra los datos de la botellas en la base de datos
    def cargar_registro_botella(self):
        try:
            while (self.orden.getEstado()==1 or self.orden.getEstado()==2 or (not self.botellas_sensor1.empty() and not self.botellas_sensor1.empty())):
                
                if(not self.botellas_sensor1.empty() and not self.botellas_sensor2.empty()):
                    
                    #obtener primero los datos, luego eliminarlo y por ultimo enviarlo
                    self.lockSensor1.acquire()
                    botella1=self.botellas_sensor1.get()
                    self.lockSensor1.release()
                    
                    self.lockSensor2.acquire()
                    botella2=self.botellas_sensor2.get()
                    self.lockSensor2.release()
                    
                    botella1.setHoraTermino(botella2.getHoraTermino())
                    botella1.registrarBD(self.datosBD)
                    
                    #print("------------------------PROCESO " + str(self.numProceso) + "------------------------")
                    #print("Botella " + str(botella1.getId()) + ": "  + str(botella1.getHoraInicio()) + " | " + str(botella1.getHoraTermino()))
                    #self.contImpresionBotella+=1
            #print("Termino cargar_registro_botellas")
                
        except Exception as e:
            evento = "Ocurrio un error en la funcion cargar_registro_botella: " + str(e)
            self.registrarLog(evento)
            #print(evento)

    ############## SENSOR 3: CAJAS ##############
    def registro_cajas_sensor3(self):
        try:
            cajaEnSensor3 = False
            fecha  =  time.strftime('%Y-%m-%d')
            while (self.orden.getEstado()==1 or self.orden.getEstado()==2):
                if (self.orden.getEstado()==1 and GPIO.input(TRIG3) == True):
                    if(cajaEnSensor3 == False):
                        #Crea el registro de la botella
                        hora = time.strftime("%H:%M:%S")
                        caja = Caja(self.contCajas, fecha, hora, self.orden.getId()) 
                        
                        #Registra la botella en la cola de prioridad del sensor 1
                        self.lockSensor3.acquire()
                        self.cajas_sensor3.put(caja)
                        self.lockSensor3.release() 
                        #print("contCajas: " + str(self.contCajas) + "\n")  
                        cajaEnSensor3 = True
                        self.contCajas+=1
                #print("Termino registro_cajas_sensor3")
                
                elif(GPIO.input(TRIG3) == False):
                #Prepara la proxima lectura de botella
                    cajaEnSensor3 = False
                                            
        except Exception as e:
            evento = "Ocurrio un error en la funcion registro_cajas_sensor3: " + str(e)
            self.registrarLog(evento)
            #print(evento)

    #Registra los datos de la botellas en la base de datos
    def cargar_registro_caja(self):
        try:
            while (self.orden.getEstado()==1 or self.orden.getEstado()==2 or not self.cajas_sensor3.empty()):
                
                if(not self.cajas_sensor3.empty()):
                    #obtener primero los datos, luego eliminarlo y por ultimo enviarlo
                    self.lockSensor3.acquire()
                    caja=self.cajas_sensor3.get()
                    self.lockSensor3.release()
                    
                    caja.registrarBD(self.datosBD)
                    
                    #print("------------------------PROCESO " + str(self.numProceso) + "------------------------")
                    #print("Caja " + str(caja.getId()) + ": " + str(caja.getHora()) )
                    #self.contImpresionCaja+=1
            #print("Termino cargar_registro_caja")
                    
        except Exception as e:
            evento = "Ocurrio un error en la funcion cargar_registro_caja: " + str(e)
            self.registrarLog(evento)
            #print(evento)
            
    def run(self):
        self.numProceso = threading.currentThread().getName()
        #print("Hello, I am the thread %s" % numProceso)
        
        #Ejecuta la funcion principal
        evento = "Se comienza a ejecutar el script para procesar datos" + str(self.numProceso)
        #print(evento)
        #self.orden.imprimirOrden()
        #Comienza a crear los hilos de ejecucion
        listaThreads = []
        for func in [self.registro_botella_sensor1, self.registro_botella_sensor2, self.cargar_registro_botella, self.registro_cajas_sensor3, self.cargar_registro_caja, self.cambiarEstado]:
            listaThreads.append(Thread(target=func))
            listaThreads[-1].start()
        
        #Esto ayuda a que no se sigan creando hilos de ejecucion hasta que se termine la orden
        while(self.orden.getEstado()<=2):
            pass
                
        """GPIO.remove_event_detect(TRIG1)
        GPIO.remove_event_detect(TRIG2)
        GPIO.remove_event_detect(TRIG3)"""
        #GPIO.cleanup
        evento = "La orden Num. " + str(self.orden.getRefOrden()) + " ha finalizado con " + str(self.contBotellas1-1) + " contBotellas1, " + str(self.contBotellas2-1) + " contBotellas2 y " + str(self.contCajas-1)+ " contCajas"
        #evento = "La orden Num. " + str(self.orden.getRefOrden()) + " ha finalizado."
        #print(evento)
        self.registrarLog(evento)
        
    def getEstadoOrden(self):
        return self.orden.getEtado()
    
    #Obtiene la cantidad de botellas que se encuentran registrada en la base de datos
    def obtenerNumeroBotellas(self):
        try:
            cursor = pyodbc.connect(self.datosBD).cursor()
            cursor.execute("SELECT count(*) FROM Botellas WHERE refOrdenPlan = '" + str(self.orden.getId()) + "'")
            contBotellas = 1
            for row in cursor.fetchall():
                self.contBotellas = row[0]+1
                #print("Botellas: " + str(row[0]) + " refOrdenPlan: " + str(self.orden.getId()) + " contBotellas: " + str(contBotellas))
            cursor.close()
            return contBotellas
            
        except Exception as e:
            evento = "Ocurrio un error en la funcion obtenerNumeroBotellas: " + str(e)
            registrarLog(evento)
            #print(evento)

    #Obtiene la cantidad de cajas que se encuentran registrada en la base de datos
    def obtenerNumeroCajas(self):
        try:
            cursor = pyodbc.connect(datosBD).cursor()
            cursor.execute("SELECT count(*) FROM Cajas WHERE refOrdenPlan = '" + str(self.orden.getId()) + "'")
            contCajas = 1
            for row in cursor.fetchall():
                contCajas = row[0]+1
                #print("Cajas: " + str(row[0]) + " refOrdenPlan: " + str(self.orden.getId()))
            cursor.close()
            return contCajas
            
        except Exception as e:
            evento = "Ocurrio un error en la funcion obtenerNumeroCajas: " + str(e)
            registrarLog(evento)
            #print(evento)
    
    def __init__(self, orden, datosBD):
        threading.Thread.__init__(self)
        #Datos monitoreo de sensores
        self.lockSensor1 = Lock()
        self.lockSensor2 = Lock()
        self.lockSensor3 = Lock()
        self.botellas_sensor1 = queue.Queue()
        self.botellas_sensor2 = queue.Queue()
        self.cajas_sensor3 = queue.Queue()
        self.orden = orden
        self.datosBD = datosBD
        
        #self.contBotellas1 = 1
        #self.contBotellas2 = 1
        self.contBotellas1 = self.obtenerNumeroBotellas()
        self.contBotellas2 = self.contBotellas1
        #self.contCajas = 1
        self.contCajas = self.obtenerNumeroCajas()
        #self.contImpresionBotella=1
        #self.contImpresionCaja=1
        self.numProceso = -1

        #self.cajasPlan = 5
        #self.botellasPlan = 60 
        
        

        
    
        
    
        