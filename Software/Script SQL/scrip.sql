DROP TABLE IF EXISTS Orden;
DROP TABLE IF EXISTS Botellas;
DROP TABLE IF EXISTS Cajas;
DROP TABLE IF EXISTS CanCajas;
DROP TABLE IF EXISTS CantBotellas;

CREATE TABLE Orden (
    ordenFabricacion Integer NOT NULL,
    version VARCHAR(256) NOT NULL,
    cliente VARCHAR(256) NOT NULL,
    sku VARCHAR(256) NOT NULL,
    descripcionSKAU VARCHAR(256) NOT NULL,
    botellasPlanificadas Integer NOT NULL,
    cajasPlanificadas Integer NOT NULL,
    fechaFabricacion Date NOT NULL,
    horaInicioPlanificada Time (0) NOT NULL,
    horaTerminoPlanificada Time (0) NOT NULL,
    horaInicio Time (0),
    horaTermino Time (0),
    formatoCaja VARCHAR(256) NOT NULL,
    estado Integer NOT NULL,
    PRIMARY KEY (ordenFabricacion)
);

CREATE TABLE Botellas (
    id Integer NOT NULL,
    fecha Date NOT NULL,
    horaInicio Time (0) NOT NULL,
    horaTermino Time (0) NOT NULL,
    refOrden Integer NOT NULL,
    PRIMARY KEY (id, refOrden)
);

CREATE TABLE Cajas (
    id Integer NOT NULL,
    fecha Date NOT NULL,
    hora Time (0) NOT NULL,
    refOrden Integer NOT NULL,
    PRIMARY KEY (id, refOrden)
);

CREATE TABLE CanCajas (
    fecha Date NOT NULL,
    hora Time (0) NOT NULL,
    cantCajas Integer NOT NULL,
    refOrden Integer NOT NULL,
    PRIMARY KEY (fecha, hora, refOrden)
);

CREATE TABLE CantBotellas (
    fecha Date NOT NULL,
    hora Time (0) NOT NULL,
    cantBotellas Integer NOT NULL,
    refOrden Integer NOT NULL,
    PRIMARY KEY (fecha, hora, refOrden)
);

ALTER TABLE Botellas ADD FOREIGN KEY (refOrden) REFERENCES Orden(ordenFabricacion);
ALTER TABLE [dbo].[Orden] ADD  CONSTRAINT [DF_Orden_estdo]  DEFAULT ((0)) FOR [estdo]
ALTER TABLE Cajas ADD FOREIGN KEY (refOrden) REFERENCES Orden(ordenFabricacion);
ALTER TABLE CanCajas ADD FOREIGN KEY (refOrden) REFERENCES Orden(ordenFabricacion);
ALTER TABLE CantBotellas ADD FOREIGN KEY (refOrden) REFERENCES Orden(ordenFabricacion);
