SET FOREIGN_KEY_CHECKS = 0;
DROP TABLE IF EXISTS `Orden`;
DROP TABLE IF EXISTS `Botellas`;
DROP TABLE IF EXISTS `Cajas`;
DROP TABLE IF EXISTS `OrdenPlanificada`;
DROP TABLE IF EXISTS `Acividad`;
DROP TABLE IF EXISTS `Clasificacion`;
DROP TABLE IF EXISTS `Tiempo`;
DROP TABLE IF EXISTS `OrdenPlanificada-Clasidicacion`;
DROP TABLE IF EXISTS `Area`;
SET FOREIGN_KEY_CHECKS = 1;

CREATE TABLE `Orden` (
    `ordenFabricacion` Integer NOT NULL,
    `version` VARCHAR(256) NOT NULL,
    `cliente` VARCHAR(256) NOT NULL,
    `sku` VARCHAR(256) NOT NULL,
    `descripcionSKAU` VARCHAR(256) NOT NULL,
    `formatoCaja` VARCHAR(256) NOT NULL,
    PRIMARY KEY (`ordenFabricacion`)
);

CREATE TABLE `Botellas` (
    `id` Integer NOT NULL,
    `fecha` Date NOT NULL,
    `horaInicio` Time(0) NOT NULL,
    `horaTermino` Time(0) NOT NULL,
    `refOrdenPlan` Integer NOT NULL,
    PRIMARY KEY (`id`, `refOrdenPlan`)
);

CREATE TABLE `Cajas` (
    `id` Integer NOT NULL,
    `fecha` Date NOT NULL,
    `hora` Time(0) NOT NULL,
    `refOrdenPlan` Integer NOT NULL,
    PRIMARY KEY (`id`, `refOrdenPlan`)
);

CREATE TABLE `OrdenPlanificada` (
    `id` Integer NOT NULL,
    `refOrden` Integer NOT NULL,
    `fechaFabricacion` Date NOT NULL,
    `horaInicioPlanificada` Time(0) NOT NULL,
    `horaTerminoPlanificada` Time(0) NOT NULL,
    `botellasPlanificadas` Integer NOT NULL,
    `cajasPlanificadas` Integer NOT NULL,
    `horaInicio` Time(0) NOT NULL,
    `horaTermino` Time(0) NOT NULL,
    `estdo` Integer NOT NULL,
    `secuencia` Integer NOT NULL,
    PRIMARY KEY (`id`)
);

CREATE TABLE `Acividad` (
    `codigo` Integer NOT NULL,
    `descripcion` VARCCHAR(512) NOT NULL,
    PRIMARY KEY (`codigo`)
);

CREATE TABLE `Clasificacion` (
    `codigo` Integer NOT NULL,
    `descripcion` VARCHAR(512) NOT NULL,
    `refActividad` Integer NOT NULL,
    `refTiempo` Integer NOT NULL,
    PRIMARY KEY (`codigo`)
);

CREATE TABLE `Tiempo` (
    `codigo` Integer NOT NULL,
    `descripcion` VARCHAR(512) NOT NULL,
    PRIMARY KEY (`codigo`)
);

CREATE TABLE `OrdenPlanificada-Clasidicacion` (
    `id` Integer NOT NULL,
    `refOrdenPlanificada` Integer NOT NULL,
    `refClasificacion` Integer NOT NULL,
    `refArea` Integer NOT NULL,
    `fecha` Date NOT NULL,
    `observacion` VARCHAR(512) NOT NULL,
    PRIMARY KEY (`id`)
);

CREATE TABLE `Area` (
    `id` Integer NOT NULL,
    `nombre` VARCHAR(256) NOT NULL,
    PRIMARY KEY (`id`)
);

ALTER TABLE `Botellas` ADD FOREIGN KEY (`refOrdenPlan`) REFERENCES `OrdenPlanificada`(`id`);
ALTER TABLE `Cajas` ADD FOREIGN KEY (`refOrdenPlan`) REFERENCES `OrdenPlanificada`(`id`);
ALTER TABLE `OrdenPlanificada` ADD FOREIGN KEY (`refOrden`) REFERENCES `Orden`(`ordenFabricacion`);
ALTER TABLE `Clasificacion` ADD FOREIGN KEY (`refActividad`) REFERENCES `Acividad`(`codigo`);
ALTER TABLE `Clasificacion` ADD FOREIGN KEY (`refTiempo`) REFERENCES `Tiempo`(`codigo`);
ALTER TABLE `OrdenPlanificada-Clasidicacion` ADD FOREIGN KEY (`refOrdenPlanificada`) REFERENCES `OrdenPlanificada`(`id`);
ALTER TABLE `OrdenPlanificada-Clasidicacion` ADD FOREIGN KEY (`refClasificacion`) REFERENCES `Clasificacion`(`codigo`);
ALTER TABLE `OrdenPlanificada-Clasidicacion` ADD FOREIGN KEY (`refArea`) REFERENCES `Area`(`id`);