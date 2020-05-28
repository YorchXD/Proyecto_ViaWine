#import lcddriver
import RPi.GPIO as GPIO
import os
from subprocess import call

#display = lcddriver.lcd()
    
def main():
    import time 
    import pyodbc
    import datetime
    from datetime import date
    from datetime import datetime
    import serial
    from time import sleep

    ###################### INICIO VARIABLES DEL SENSOR ####################

    GPIO.setmode(GPIO.BCM)
    GPIO.setwarnings(False)

    TRIG1= 18
    TRIG2= 12
    TRIG3= 4

    GPIO.setup(TRIG1, GPIO.IN,pull_up_down=GPIO.PUD_UP)     #CONFIGURACION DEL SENSOR FOTOELECTRICO 1 MODO PULL_UP
    GPIO.setup(TRIG2, GPIO.IN,pull_up_down=GPIO.PUD_UP)     #CONFIGURACION DEL SENSOR FOTOELECTRICO 2 MODO PULL_UP
    GPIO.setup(TRIG3, GPIO.IN,pull_up_down=GPIO.PUD_UP)     #CONFIGURACION DEL SENSOR CAPACITIVO MODO PULL_UP
    

    ###################### FINAL VARIABLES DEL SENSOR #######################

    ###################### INICIO VARIABLES DEL PROGRAMA ####################

    DMIN = 5
    H1 = 0
    id_1 = 0
    H2 = 0
    id_2 = 0
    H3 = 0
    id_3 = 0
    h_inicio = time.strftime("%H:%M:%S")
    list1bot = []
    list2bot = []
    oFab = []
    bPlan = []
    cPlan = []
    fCaja = []
    estado = []
    i = 0
    inicio = 0
    tiempoContador = 0
    cStop = 0
    contPausa = 0
    cantPausa = 0
    varPausa = 0
    hInicioPausa = 0
    aux = 0
    a = 0
    b = 0
    c = 0
    estadoActual = []
    sumMinuto = 0

    #display = lcddriver.lcd()



    ######################## INICIO MAIN ###########################################

    if __name__ == '__main__':
        try:
            while True:                                                     # INICIO DEL CICLO DE PROGRAMA

                #display.lcd_clear()

                #if(inicio == 0):
                #    ("Hora Inicio: ", h_inicio)
                #    inicio = 1
                today = datetime.now()                                      ## FORMA 1 FECHA
                hoy = today.strftime('%Y-%m-%d')                            ## FORMA 1 FECHA
                #hoy = datetime.date.today()                                ## FORMA 2 FECHA

                conn = pyodbc.connect('Driver={freetds};SERVER=190.171.160.83;PORT=1433;DATABASE=Automatizacion_ViaWines2.0;UID=sa;PWD=J1h4m3b012*;TDS_Version=4.2;')       # CONEXION PARA INGRESAR AL SERVIDOR
                
                #print("Distance1 = %.1f cm" % dist1, "Distance2 = %.1f cm" % dist2, "Distance3 = %.1f cm" % dist3)
                #time.sleep(.1)
                
                cursor1 = conn.cursor()
                cursor1.execute('SELECT * FROM Orden WHERE fechaFabricacion = CONVERT (date, GETDATE())')                                    # TABLA DESDE LA CUAL SE EXTRAERAN LOS DATOS 

                ########## CODIGO NUEVO

                print("Revision de pedidos: ")                              # SE REVISA SI HAY PEDIDOS DISPONIBLES PARA INGRESAR POSTERIORMENTE AL CICLO
                #display.lcd_display_string("Revisando", 1)                  # ESTOS DATOS SE MUESTRAN EN LA PANTALLA LCD 
                #display.lcd_display_string("Pedidos...", 2)                 # EN CASO QUE NO EXISTA PEDIDO, SE VOLVERA A REALIZAR LA LECTURA CADA 10 SEGUNDOS HASTA ENOCNTRAR 

                for row in cursor1:                                         # LOS PEDIDOS DEL DIA SE LEEN DESDE LA BASE DE DATOS
                    print(row[6])                                           # Y SE GUARDAN  EN DISTINTAS LISTAS
                    oFab.append(row[0])                                     # POR EJ. OFAB ES LA ORDEN DE FABRICACION
                    bPlan.append(row[5])                                    # BPLAN SON BOTELLAS PLANIFICADAS
                    cPlan.append(row[6])                                    # CPLAN SON CAJAS PLANIFICADAS
                    fCaja.append(row[12])                                   # FCAJA SON LOS FORMATOS DE CADA PEDIDO
                    estado.append(int(row[13]))                             # Y EL ESTADO PERMITIRA SABER QUE ACCION TOMARA LA RASPBERRY, SI MANTENERSE SIN INICIO, INICIAR/CONTINUAR PROCESO, PAUSAR, DETENER, O APAGAR LA MISMA
                    if(estado[b] == 1):                                     # SI HAY ALGUNO DE LOS PEDIDOS CUYO ESTADO SEA '1' (SERA SIEMPRE SOLO UNO, Y SERA AL QUE SE QUIERA DAR INICIO)
                        print("Orden: ", oFab[b], "Estado: ", estado[b])    # SE RECONOCERA Y COMENZARA EL PROCESO DE ENVIO DE DATOS A LA BASE DE DATOS, RECOPILANDO LA INFORMACION QUE OBTENGAN LOS SENSORES
                        print("Pedido a realizar...")                       # ESTA INFORMACION ES SOLO VISIBLE PARA EL TERMINAL DE PYTHON. LA PANTALLA LCD MOSTRARA SI EXISTE O NO PEDIDO Y SI SE INICIA O NO
                        aux = 1                                             # LA ACCION, NADA MAS QUE ESO. ADEMAS, LA VARIABLE AUXILIAR PERMITE ENTRAR EN EL CICLO DE LECTURA DE DATOS DE SENSORES.
                        a = b
                    else:                                                   
                        print("Orden: ", oFab[b], "Estado: ", estado[b])    # EN CASO QUE NO HAY NINGUN PEDIDO EN '1', ES DECIR, NINGUN PEDIDO SE HA INICIADO, CADA 10 SEGUNDOS SE REALIZARA UNA NUEVA LECTURA
                        print("No.")
                    b = b + 1

                if(aux==1):                                                 # EL RECONOCIMIENTO DE QUE UN PROCESO SE HA INICIADO HACE QUE EL AUXILIAR SEA 1, PERMITE OBTENER LOS DATOS DEL PEDIDO                                    
                    print("Inicio...")                                      # TODOS ESTOS 'PRINT' SON SOLAMENTE PARA PYTHON
                    #display.lcd_clear()                                     # SE LIMPIA LA PANTALLA LCD PARA MOSTRAR 
                    #display.lcd_display_string("Consulta encontrada.", 1)   # QUE SE HA ENCONTRADO UNA CONSULTA PARA INICIAR
                    #display.lcd_display_string("Inicia Proceso...", 2)      #
                    inicio = 1                                              # 
                    refOrden = oFab[a]                                      # Y SE GUARDAN LOS DATOS CORRESPONDIENTE A LA ORDEN
                    botPlanificada = bPlan[a]
                    caPlanificada = cPlan[a]
                else:
                    print("Sin estados. Volviendo a consultar...")          # CASO CONTRARIO, SE VUELVE A CONSULTAR
                    #display.lcd_clear()
                    #display.lcd_display_string("Sin estados.", 1) 
                    #display.lcd_display_string("Nueva Consulta...", 2) 
                    aux = 0
                    sleep(10)                                               # CADA 10 SEGUNDOS REALIZA LA LECTURA
                    cursor1.close()
                    conn.commit()
                    main()

                ################# INICIO DE PROCESO ##################

                while(inicio == 1):                                         # ENTRA AL CICLO DE LECTURA DE SENSORES  


                    
                    if(tiempoContador == 0):                                # COMIENZA EL CONTEO DEL TIEMPO, PARA DESPUES ENVIAR LOS REPORTES CADA UN MINUTO
                        startTime = time.time()                             # Y REALIZAR UNA CONSULTA A LA BASE DE DATOS CADA 10 SEGUNDOS, SI ES QUE EL USUARIO HA REALIZADO
                        tiempoContador = 1                                  # ALGUNA ACCION PARA DETENER EL PROCESO O CONTINUAR
                    
                    conn = pyodbc.connect('Driver={freetds};SERVER=190.171.160.83;PORT=1433;DATABASE=Automatizacion_ViaWines;UID=sa;PWD=J1h4m3b012*;TDS_Version=4.2;')   # NUEVAMENTE SE CONECTA A LA BASE DE DATOS 
                                                                                                                                                            # AHORA PARA CONECTAR E INGRESAR LOS DATOS

                    ############## SENSOR 1: BOTELLAS ##############

                    if(GPIO.input(TRIG1) == True):                          # SI SE DETECTA UN FLANCO DE SUBIDA EN EL RANGO DEL TRIGGER
                        if(H1 == 0):                                        # SE CONTARA COMO SI HUBIESE PASADO UN OBJETO, SIEMPRE Y CUANDO RECONOZCA QUE HUBO UN 'CAMBIO DE FLANCO'
                            tiempo1 = time.strftime("%H:%M:%S")             # SE REGISTRA EL TIEMPO CUANDO PASO
                            list1bot.append(tiempo1)                        # Y SE GUARDA EN UNA LISTA
                            id_1 = id_1 + 1                                 # SE REGISTRA SU 'ID' Y ADEMAS SE SUMA A LA CUENTA TOTAL DE BOTELLAS
                            H1 = 1
                            print("1")
                        elif(H1 == 1):                                      # ESTO EVITA QUE SIGA SUMANDO BOTELLAS EN EL TRANSCURSO QUE EL FLANCO SIGUE EN EL TRIGGER
                            H1 = 1                                          # YA QUE LA LECTURA PERTENECERA A LA MISMA BOTELLA
                            id_1 = id_1
                    elif (GPIO.input(TRIG1) == False):                      # SI NO SE DETECTA UN FLANCO ASCENDENTE
                        H1 = 0                                              # SE PREPARA PARA LA LECTURA DE LA SIGUIENTE BOTELLA
                        id_1 = id_1

                    ############## SENSOR 1: BOTELLAS ##############

                    ############## SENSOR 2: BOTELLAS ##############

                    if(GPIO.input(TRIG2) == True): 
                        if(H2 == 0):
                            if(id_1>id_2):
                                tiempo2 = time.strftime("%H:%M:%S")
                                list2bot.append(tiempo2)
                                id_2 = id_2 + 1
                                print("2")
                                cursor = conn.cursor()
                                cursor.execute("INSERT INTO Botellas(id, fecha, horaInicio, horaTermino, refOrdenPlan) VALUES (?,?,?,?,?)", id_2, hoy, list1bot[id_2-1], list2bot[id_2-1], refOrden)
                                conn.commit()
                                cursor.close()

                                H2 = 1
                            else:
                                print("No hay botella 1")
                        elif(H2 == 1):
                            H2 = 1
                            id_2 = id_2
                    elif(GPIO.input(TRIG2) == True): 
                        H2 = 0
                        id_2 = id_2

                    ############## SENSOR 2: BOTELLAS ##############

                    ############## SENSOR 3: CAJAS #################

                    if(GPIO.input(TRIG3) == True): 
                        if(H3 == 0):
                            tiempo3 = time.strftime("%H:%M:%S")
                            id_3 = id_3 + 1
                            print("3")
                            cursor = conn.cursor()
                            cursor.execute("INSERT INTO Cajas(id, fecha, hora, refOrdenPlan) VALUES (?,?,?,?)", id_3, hoy, tiempo3, refOrden)
                            H3 = 1

                            conn.commit()
                            cursor.close()

                        elif(H3 == 1):
                            H3 = 1
                            id_3 = id_3
                    elif(GPIO.input(TRIG3) == True): 
                        H3 = 0
                        id_3 = id_3

                    ############## SENSOR 3: CAJAS #################

                    ############## TIEMPOS DETENCION ###############

                    endTime = time.time()
                    epochTime = int(endTime - startTime)

                    if(epochTime >= 10):
                        hActual = time.strftime("%H:%M:%S")
                        #print("Ha pasado un minuto. Hora: ", hActual)
                        startTime = time.time() 
                        sumMinuto = sumMinuto + 1
                        print("SumMinuto: ", sumMinuto)

                        cursor2 = conn.cursor()
                        cursor2.execute('SELECT * FROM Orden WHERE fechaFabricacion = CONVERT (date, GETDATE())')
                        
                        for row in cursor2:
                            #print(row[6])
                            estadoActual.append(int(row[13]))

                        print("Estado de pedido: ", estadoActual[13])
                        
                        if(estadoActual[a]==1):
                            del estadoActual[:]
                            print("Pedido en proceso.")
                            #display.lcd_clear()
                            #display.lcd_display_string("En", 1) 
                            #display.lcd_display_string("Proceso...", 2)
                            cursor2.close()
                            cursor = conn.cursor()
                            if(sumMinuto == 6 and tiempoContador ==1):
                                print("Actualizacion de estados")
                                #cursor.execute("INSERT INTO cantBotellas(fecha,hora,cantBotellas,refOrden) VALUES (?,?,?,?)", hoy,hActual,id_2,refOrden)
                                #cursor.execute("INSERT INTO cantCajas (fecha,hora,cantCajas,refOrden) VALUES (?,?,?,?)", hoy,hActual,id_3,refOrden)
                                sumMinuto = 0
                                conn.commit()
                                cursor.close()
                                tiempoContador = 0
                        elif(estadoActual[a]==2):
                            del estadoActual[:]
                            print("Pedido pausado.")
                            #display.lcd_clear()
                            #display.lcd_display_string("Pedido Pausado.", 1) 
                            #display.lcd_display_string("Esperando", 2)
                            #display.lcd_display_string("Reinicio...", 3)
                            cursor2.close()
                            tiempoContador = 0
                            sumMinuto = 0
                        elif(estadoActual[a]==3):
                            print("Pedido finalizado.")
                            #display.lcd_clear()
                            #display.lcd_display_string("Pedido Finalizado.", 1) 
                            #display.lcd_display_string("Esperando...", 2)
                            cursor2.close()
                            conn.commit()
                            sleep(10)
                            main()
                        elif(estadoActual[a]==4):
                            print("Apagando...")
                            #display.lcd_clear()
                            #display.lcd_display_string("Apagando...", 1)
                            cursor2.close()
                            conn.commit()
                            call("sudo shutdown -P now", shell=True)
                    
                    conn.close()
                    time.sleep(0.1)
                    
                    ############## TIEMPOS DETENCION ###############

        except Exception as e:
            print("Ocurrio un error al conectar a SQL Server:", e)
            del oFab[:]
            del bPlan[:]
            del cPlan[:]
            del fCaja[:]
            del estado[:]
            del estadoActual[:]

        except KeyboardInterrupt:
            print("Measurement stopped by user")
            inicio = 0
            #display.lcd_clear()
            del oFab[:]
            del bPlan[:]
            del cPlan[:]
            del fCaja[:]
            del list1bot[:]
            del list2bot[:]
            del estado[:]
            del estadoActual[:]
            GPIO.cleanup()

#display.lcd_clear()
main()
GPIO.cleanup()
