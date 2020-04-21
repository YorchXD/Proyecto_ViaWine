DROP TABLE IF EXISTS Botellas;
DROP TABLE IF EXISTS Cajas;
DROP TABLE IF EXISTS OrdenPlanificada;
DROP TABLE IF EXISTS Orden;

CREATE TABLE Orden (
    ordenFabricacion Integer NOT NULL,
    version VARCHAR(256) NOT NULL,
    cliente VARCHAR(256) NOT NULL,
    sku VARCHAR(256) NOT NULL,
    descripcionSKAU VARCHAR(512) NOT NULL,
    formatoCaja VARCHAR(256) NOT NULL,
    PRIMARY KEY (ordenFabricacion)
);

CREATE TABLE Botellas (
    id Integer NOT NULL,
    fecha Date NOT NULL,
    horaInicio Time(0) NOT NULL,
    horaTermino Time(0) NOT NULL,
    refOrdenPlan Integer NOT NULL,
    PRIMARY KEY (id, refOrdenPlan)
);

CREATE TABLE Cajas (
    id Integer NOT NULL,
    fecha Date NOT NULL,
    hora Time(0) NOT NULL,
    refOrdenPlan Integer NOT NULL,
    PRIMARY KEY (id, refOrdenPlan)
);

CREATE TABLE OrdenPlanificada (
    id Integer IDENTITY(1,1) NOT NULL,
    refOrden Integer NOT NULL,
    fechaFabricacion Date NOT NULL,
    horaInicioPlanificada Time(0) NOT NULL,
    horaTerminoPlanificada Time(0) NOT NULL,
    botellasPlanificadas Integer NOT NULL,
    cajasPlanificadas Integer NOT NULL,
    horaInicio Time(0) NOT NULL,
    horaTermino Time(0) NOT NULL,
    estdo Integer NOT NULL,
	secuencia Integer NOT NULL,
    PRIMARY KEY (id)
);

ALTER TABLE Botellas ADD FOREIGN KEY (refOrdenPlan) REFERENCES OrdenPlanificada(id);
ALTER TABLE Cajas ADD FOREIGN KEY (refOrdenPlan) REFERENCES OrdenPlanificada(id);
ALTER TABLE OrdenPlanificada ADD FOREIGN KEY (refOrden) REFERENCES Orden(ordenFabricacion);




