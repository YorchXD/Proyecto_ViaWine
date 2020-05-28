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
    
    def registrarBD(self, conn):
        try:
            cursor = conn.cursor()
            cursor.execute("INSERT INTO Cajas(id, fecha, hora, refOrdenPlan) VALUES (?,?,?,?)", self.id, self.fecha, self.hora, self.refOrdenPlan)
            conn.commit()
            cursor.close()
        except Exception as e:
            print("Ocurrio un error en la funcion registrarBD en la clase Caja: " + str(e))