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
    
    def registrarBD(self, conn):
        try:
            cursor = conn.cursor()
            cursor.execute("INSERT INTO Botellas(id, fecha, horaInicio, horaTermino, refOrdenPlan) VALUES (?,?,?,?,?)", self.id, self.fecha, self.horaInicio, self.horaTermino, self.refOrdenPlan)
            conn.commit()
            cursor.close()
        except Exception as e:
            print("Ocurrio un error en la funcion registrarBD en la clase Botella: " + str(e))
            
    def imprimir(self):
        print("--------------------------------------------------------------------------------------")
        print("Id: ", self.id)
        print("Fecha de fabricacion: ", self.fecha)
        print("Hora inicio: ", self.horaInicio)
        print("Hora termino: ", self.horaTermino)
        print("Ref. Orden: ", self.refOrdenPlan)
        print("---------------------------------")
        