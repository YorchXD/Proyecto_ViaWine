import serial
import time
import csv

i = 0
j = 0
k = 0
l = 0
n=100
lista1 = [0]*n  # SENSOR 1 - BOTELLAS PRIMER PASO
hora1=[0]*n
lista2 = [0]*n  # SENSOR 2 - BOTELLAS SEGUNDO PASO
hora2=[0]*n
lista3 = [0]*n  # SENSOR 3 - CAJAS
hora3=[0]*n
cantBotellas = 0
cantCajas = 0

ser = serial.Serial('COM6',9600, timeout=1)
while 1:
    arduinoData = ser.readline().decode('ascii')
    clasif = int(arduinoData)
    
    if(clasif==2):              # SENSOR 1 DE BOTELLAS
        lista1.insert(i,int(time.strftime("%H%M%S")))
        hora1.insert(i,time.strftime("%H:%M:%S"))
        i = i + 1

    if(clasif==3):              # SENSOR 2 DE BOTELLAS 
        lista2.insert(j,int(time.strftime("%H%M%S")))
        hora2.insert(j,time.strftime("%H:%M:%S"))
        j = j + 1
        if(lista2[k] > 0 and lista1[k]> 0):
            print("Hora pasado botella primer sensor: ")
            print(hora1[k])
            print("Hora pasado botella segundo sensor: ")
            print(hora2[k])
            print("Botella contada")
            k = k + 1
            cantBotellas = cantBotellas + 1
            print("Botellas pasadas: ")
            print(cantBotellas)
            print("-------------------")

    if(clasif==4):              # SENSOR 1 DE BOTELLAS Y SENSOR 2 DE BOTELLAS
        lista1.insert(i,int(time.strftime("%H%M%S")))
        hora1.insert(i,time.strftime("%H%M%S"))
        i = i + 1
        lista2.insert(j,int(time.strftime("%H%M%S")))
        hora2.insert(j,time.strftime("%H:%M:%S"))
        j = j + 1
        if(lista2[k] > 0 and lista1[k]> 0):
            print("Hora pasado botella primer sensor: ")
            print(hora1[k])
            print("Hora pasado botella segundo sensor: ")
            print(hora2[k])
            print("Botella contada")
            k = k + 1
            cantBotellas = cantBotellas + 1
            print("Botellas pasadas: ")
            print(cantBotellas)
            print("-------------------")

    if(clasif==5):              # SENSOR DE CAJAS
        lista3.insert(l,int(time.strftime("%H%M%S")))
        hora3.insert(l,time.strftime("%H:%M:%S"))
        l = l+1
        if(lista3[l-1] > 0):
            print("Hora pasado de caja: ")
            print(hora3[l-1])    
            cantCajas = cantCajas + 1
            print("Cajas pasadas: ")
            print(cantCajas)
            print("-------------------")

    if(clasif==6):              # SENSOR DE CAJA Y SENSOR 1 DE BOTELLAS
        lista3.insert(l,int(time.strftime("%H%M%S")))
        hora3.insert(l,time.strftime("%H:%M:%S"))
        l = l+1
        lista1.insert(i,int(time.strftime("%H%M%S")))
        hora1.insert(i,time.strftime("%H:%M:%S"))
        i = i + 1
        if(lista3[l-1] > 0):
            print("Hora pasado de caja: ")
            print(hora3[l-1])  
            cantCajas = cantCajas + 1
            print("Cajas pasadas: ")
            print(cantCajas)
            print("-------------------")

    if(clasif==7):              # SENSOR DE CAJA Y SENSOR 2 DE BOTELLAS
        lista3.insert(l,int(time.strftime("%H%M%S")))
        hora3.insert(l,time.strftime("%H:%M:%S"))
        l = l+1
        lista2.insert(j,int(time.strftime("%H%M%S")))
        hora2.insert(j,time.strftime("%H:%M:%S"))
        j = j + 1
        if(lista2[k] > 0 and lista1[k]> 0):
            print("Hora pasado botella primer sensor: ")
            print(hora1[k])
            print("Hora pasado botella segundo sensor: ")
            print(hora2[k])
            print("Botella contada")
            k = k + 1
            cantBotellas = cantBotellas + 1
            print("Botellas pasadas: ")
            print(cantBotellas)
            print("-------------------")
        
        if(lista3[l-1] > 0):
            print("Hora pasado de caja: ")
            print(hora3[l-1])  
            cantCajas = cantCajas + 1
            print("Cajas pasadas: ")
            print(cantCajas)
            print("-------------------")
    
    if(clasif==8):
        lista1.insert(i,int(time.strftime("%H%M%S")))
        hora1.insert(i,time.strftime("%H:%M:%S"))
        i = i + 1
        lista2.insert(j,int(time.strftime("%H%M%S")))
        hora2.insert(j,time.strftime("%H:%M:%S"))
        j = j + 1
        if(lista2[k] > 0 and lista1[k]> 0):
            print("Hora pasado botella primer sensor: ")
            print(hora1[k])
            print("Hora pasado botella segundo sensor: ")
            print(hora2[k])
            print("Botella contada")
            k = k + 1
            cantBotellas = cantBotellas + 1
            print("Botellas pasadas: ")
            print(cantBotellas)
            print("-------------------")
        lista3.insert(l,int(time.strftime("%H%M%S")))
        hora3.insert(l,time.strftime("%H:%M:%S"))
        l = l+1
        if(lista3[l-1] > 0):
            print("Hora pasado de caja: ")
            print(hora3[l-1])    
            cantCajas = cantCajas + 1
            print("Cajas pasadas: ")
            print(cantCajas)
            print("-------------------")


   

