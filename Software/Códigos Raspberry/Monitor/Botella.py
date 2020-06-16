from datetime import datetime
import time
import pyodbc

def registrarLog(evento, datosBD):
        fechaHora = datetime.now()  
        fecha = fechaHora.strftime('%Y-%m-%d')  
        hora = time.strftime("%H:%M:%S")
        cursor = pyodbc.connect(datosBD).cursor()
        cursor.execute("INSERT INTO LogsRPI(fecha, hora, evento) VALUES (?,?,?)", fecha, hora, evento)
        cursor.commit()
        cursor.close()

class Botella(object):
    def __init__(self, id, fecha, horaInicio, refOrdenPlan, horaTermino="00:00:00"):
        self.id =id
        self.fecha = fecha
        self.horaInicio = horaInicio
        self.horaTermino = horaTermino
        self.refOrdenPlan = refOrdenPlan
    
    def getId(self):
        return self.id
        
    def getFecha(self):
        return self.fecha
        
    def getHoraInicio(self):
        return self.horaInicio
    
    def getHoraTermino(self):
        return self.horaTermino
    
    def getRefOrdenPlan(self):
        return self.refOrdenPlan
    
    def setHoraTermino(self, horaTermino):
        self.horaTermino = horaTermino
    
    def registrarBD(self, datosBD):
        try:
            #cursor = conn.cursor()
            cursor = pyodbc.connect(datosBD).cursor()
            cursor.execute("INSERT INTO Botellas(id, fecha, horaInicio, horaTermino, refOrdenPlan) VALUES (?,?,?,?,?)", self.id, self.fecha, self.horaInicio, self.horaTermino, self.refOrdenPlan)
            cursor.commit()
            cursor.close()
        except Exception as e:
            evento = "Ocurrio un error en la funcion registrarBD en la clase Botella: " + str(e)
            #registrarLog(evento, datosBD)
            print(evento)