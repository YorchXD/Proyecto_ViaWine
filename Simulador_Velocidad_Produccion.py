# -*- coding: utf-8 -*-
"""
Created on Wed Jan 15 11:53:34 2020

@author: YorchXD
"""


from datetime import datetime
from datetime import timedelta
import random

'''Funcion que muestra la cantidad de botellas y de cajas'''
def impresionContadores(cantBotellas, cantCajas):
    print("\n\n")
    print("Cantidad de Botellas por minuto: " + str(cantBotellas))
    print("Cantidad de cajas por minuto: " + str(cantCajas))
    print("\n\n")
    
'''
Funcion que simula los bit enviado por la arduino. Para ello se requiere un de un numero random
y segun este argumento, sera el caso de deteccion de sensor a procesar
'''
def cadenaBit():
    opcion = random.randint(0, 7)
    switcher = {
        0: "000",
        1: "001",
        2: "010",
        3: "011",
        4: "100",
        5: "101",
        6: "110",
        7: "111"
    }
    return switcher.get(opcion)

def main():
    sensor1=0
    sensor2=0
    caja=0
    cantCajas=0
    cantBotellas=0
    imprimir=0
    segAct=0
    
    while(1):
        
        '''Obtiene la cantidad de bit simulada que provienen desde a arduino'''
        x=cadenaBit()
        
        '''obtiene la fecha y hora que se procesa'''
        fecha_hora = datetime.now()
        #formato = fecha_hora.strftime("%Y-%m-%d %H:%M:%S")
        
        '''Cuando el sensor uno envia un 1 se registra en la base de dato  el id, 
        la fecha y la hora de deteccion de la botela'''
        if(x[0]=="1"):
            sensor1+=1
            #print("Botella " + str(sensor1) + " "  + formato)
        
        '''Cuando el sensor dos envia un 1 se registra en la base de dato  el id, 
        la fecha y la hora de deteccion botella'''
        if(x[1]=="1"):
            sensor2+=1
            cantBotellas+=1
            #print("Botella " + str(sensor2) + " "  + formato)
          
        '''Cuando el sensor tres envia un 1 se registra en la base de dato  el id,
        la fecha y la hora de deteccion de la caja'''
        if(x[2]=="1"):
            caja+=1
            cantCajas+=1
            #print("Caja " + str(caja) + " "  + formato)
          
        '''imprime los segundos cuando existe un cambio. Por ejemplo el segAct 
        es 1 pero si feha_hora es 2, se imprime el nuevo segundo y se registra 
        en segAct'''
        if(segAct!=fecha_hora.second):
            print(fecha_hora.second)
            segAct=fecha_hora.second
        
        '''Cada vez que fecha_hora.second sea igual a 59 seg se debe mostrar la
        velocidad de produccion y resetear los contadores'''
        if(fecha_hora.second ==59 and imprimir==0):
            impresionContadores(cantBotellas,cantCajas)
            cantCajas=0
            cantBotellas=0
            imprimir=1
        
        '''Esta condicion ayuda a que solo se imprima la velocidad de produccion 
        una ves en el seg 59.'''
        if(fecha_hora.second ==0):
            imprimir=0
        
'''Ejecucion de la funcion principal'''
main()