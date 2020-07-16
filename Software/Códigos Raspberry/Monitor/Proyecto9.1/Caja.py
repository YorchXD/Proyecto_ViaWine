from datetime import datetime
import time
from ConexionBD import ConexionBD


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
    
    def registrarLog(self, evento):
        fechaHora = datetime.now()  
        fecha = fechaHora.strftime('%Y-%m-%d')  
        hora = time.strftime("%H:%M:%S")
        conexion = ConexionBD()
        with conexion:
            conexion.conn.cursor().execute("INSERT INTO LogsRPI(fecha, hora, evento) VALUES (?,?,?)", fecha, hora, evento)
            conexion.conn.commit()
    
    def registrarBD(self):
        try:
            conexion = ConexionBD()
            with conexion:
                conexion.conn.cursor().execute("INSERT INTO Cajas(id, fecha, hora, refOrdenPlan) VALUES (?,?,?,?)", self.id, self.fecha, self.hora, self.refOrdenPlan)
                conexion.conn.commit()

        except Exception as e:
            evento = "Ocurrio un error en la funcion registrarBD en la clase Caja: " + str(e)
            self.registrarLog(evento)
            #print(evento)
            
            
        
