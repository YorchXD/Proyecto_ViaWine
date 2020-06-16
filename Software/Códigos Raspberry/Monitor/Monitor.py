from threading import Lock, Thread
from time import sleep
from datetime import datetime
import queue

lockSensor1 = Lock()
lockSensor2 = Lock()
sensor1 = queue.Queue()
sensor2 = queue.Queue()


def agregar_sensor1():
    global sensor1
    cont=0
    while cont<50:
        lockSensor1.acquire()
        sensor1.put(cont)
        print("s1: " + str(cont))
        lockSensor1.release()
        sleep(0.1)
        cont+=1
       
def agregar_sensor2():
    global sensor2
    cont=0
    while cont<50:
        lockSensor2.acquire()
        sensor2.put(cont)
        print("s2: " + str(cont))
        lockSensor2.release()
        sleep(0.1)
        cont+=1

def cargar_registro_botella():
    global sensor1, sensor2
    cont=0
    while cont<50:
        if(not sensor1.empty() and not sensor2.empty()):
            t1 = datetime.now()
            lockSensor1.acquire()
            dato1=sensor1.get()
            sleep(0.1)
            lockSensor1.release()
            
            t2 = datetime.now()
            print("t1: " + str(t1.microsecond))
            print("t2: " + str(t2.microsecond))
            latencia = t2.microsecond-t1.microsecond
            print("Latencia: " + str(latencia))
            
            lockSensor2.acquire()
            dato2=sensor2.get()
            lockSensor2.release()
            
            print("Envio de datos")
            #obtener primero los datos, luego eliminarlo y por ultimo enviarlo
            print("s1: " + str(dato1) + " s2: " + str(dato2))
            sleep(0.15)
            cont+=1
        
#Main
listaThreads = []
for func in [agregar_sensor1, agregar_sensor2, cargar_registro_botella]:
    listaThreads.append(Thread(target=func))
    listaThreads[-1].start()