from datetime import datetime
import time
import pyodbc

def registrarLog(evento, datosBD):
        fechaHora = datetime.now()  
        fecha = fechaHora.strftime('%Y-%m-%d')  
        hora = time.strftime("%H:%M:%S")
        #cursor = conn.cursor()
        cursor = pyodbc.connect(datosBD).cursor()
        cursor.execute("INSERT INTO LogsRPI(fecha, hora, evento) VALUES (?,?,?)", fecha, hora, evento)
        cursor.commit()
        cursor.close()


class Caja(object):
    def __init__(self, id, fecha, hora, refOrdenPlan):
        self.id =id
        self.fecha = fecha
        self.hora = hora
        self.refOrdenPlan = refOrdenPlan
    
    def getId(self):
        return self.id
        
    def getFecha(self):
        return self.fecha
        
    def getHora(self):
        return self.hora
    
    def getRefOrdenPlan(self):
        return self.refOrdenPlan
    
    def registrarBD(self, datosBD):
        try:
            #cursor = conn.cursor()
            cursor = pyodbc.connect(datosBD).cursor()
            cursor.execute("INSERT INTO Cajas(id, fecha, hora, refOrdenPlan) VALUES (?,?,?,?)", self.id, self.fecha, self.hora, self.refOrdenPlan)
            cursor.commit()
            cursor.close()
        except Exception as e:
            evento = "Ocurrio un error en la funcion registrarBD en la clase Caja: " + str(e)
            #registrarLog(evento, datosBD)
            print(evento)