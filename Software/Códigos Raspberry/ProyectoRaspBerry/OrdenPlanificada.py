class OrdenPlanificada(object):
    def __init__(self, id, refOrden, fechaFabricacion, horaInicioPlanificada, horaTerminoPlanificada, botellasPlanificadas, cajasPlanificadas, estado, secuencia):
        self.id = id
        self.refOrden = refOrden
        self.fechaFabricacion = fechaFabricacion
        self.horaInicioPlanificada = horaInicioPlanificada
        self.horaTerminoPlanificada = horaTerminoPlanificada
        self.horaInicio = None
        self.horaTermino = None
        self.botellasPlanificadas = botellasPlanificadas
        self.cajasPlanificadas = cajasPlanificadas
        self.estado = estado
        self.secuencia = secuencia

    def getId(self):
        return self.id
        
    def getRefOrden(self):
        return self.refOrden
        
    def getFechaPlanificacion(self):
        return self.fechaFabricacion
    
    def getHoraInicioPlanificada(self):
        return self.horaInicioPlanificada
    
    def getHoraTerminoPlanificada(self):
        return self.horaTerminoPlanificada
    
    def getHoraInicio(self):
        return self.horaInicio
    
    def getHoraTermino(self):
        return self.horaTermino
    
    def getBotellasPlanificadas(self):
        return self.botellasPlanificadas
    
    def getCajasPlanificadas(self):
        return self.cajasPlanificadas
    
    def getEstado(self):
        return self.estado
    
    def getSecuencia(self):
        return self.secuencia
    
    def setEstado(self, estado):
        self.estado = estado
    
    def setHoraInicio(self, horaInicio):
        self.horaInicio = horaInicio
    
    def setHoraTermino(self, horaTermino):
        self.horaTermino = horaTermino
        
    def imprimirOrden(self):
        print("--------------------------------------------------------------------------------------")
        print("Id: ", self.id)
        print("Ref. Orden: ", self.refOrden)
        print("Fecha de fabricacion: ", self.fechaFabricacion)
        print("Hora inicio planificada: ", self.horaInicioPlanificada)
        print("Hora termino planificada: ", self.horaTerminoPlanificada)
        print("Hora inicio: ", self.horaInicio)
        print("Hora termino: ", self.horaTermino)
        print("Botellas planificadas: ", self.botellasPlanificadas)
        print("Cajas planificadas: ", self.cajasPlanificadas)
        print("Estado: ", self.estado)
        print("Secuencia: ", self.secuencia)
        print("--------------------------------------------------------------------------------------\n")