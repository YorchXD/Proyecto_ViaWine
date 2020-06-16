# import threading

# def contar():
#     '''Contar hasta cien'''
#     contador = 0
#     while contador<100:
#         contador+=1
#         print('Hilo:', 
#               threading.current_thread().getName(), 
#               'con identificador:', 
#               threading.current_thread().ident,
#               'Contador:', contador)

# hilo1 = threading.Thread(target=contar)
# hilo2 = threading.Thread(target=contar)
# hilo1.start()
# hilo2.start()

import threading

#variables globales
lista = []
estado0 = 0
estado1 = 0
estado2 = 0



def imprimir():
    global estado0, estado1, estado2, lista
    while(estado0==0 or estado1==0 or estado2==0 or len(lista)!=0):
        if(len(lista)!=0):
            print(lista[0])
            lista.pop(0)
        #print('estado0: ' + str(estado0) + ' estado1: ' + str(estado1) + ' estado2: ' + str(estado2))
    print("fin")

def contar(num_hilo):
    contador = 0
    global estado0, estado1, estado2, lista
    while contador<100:
        contador+=1
        dato = 'Hilo: ' + str(threading.current_thread().getName()) + ' con identificador: ' + str(threading.current_thread().ident) + ' Contador: ' + str(contador)
        lista.append(dato)
        # print('Hilo:', 
        #       threading.current_thread().getName(), 
        #       'con identificador:', 
        #       threading.current_thread().ident,
        #       'Contador:', contador)
    
    print("salio de enviar datos " + threading.current_thread().getName())
    
    if(num_hilo==0):
        print ("estado0")
        estado0=1
        print("numero estado: " + str(estado0))
    if(num_hilo==1):
        print ("estado1")
        estado1=1
        print("numero estado: " + str(estado1))
        
    if(num_hilo==2):
        print ("estado2")
        estado2=1
        print("numero estado: " + str(estado2))

NUM_HILOS = 3

for num_hilo in range(NUM_HILOS):
    hilo = threading.Thread(name='hilo%s' %num_hilo, target=contar, args=(num_hilo,))    
    hilo.start()
hilo = threading.Thread(name='hilo%s' %num_hilo, target=imprimir)    
hilo.start()