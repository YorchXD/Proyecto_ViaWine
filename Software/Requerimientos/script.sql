SET FOREIGN_KEY_CHECKS = 0;
DROP TABLE IF EXISTS `Services`;
DROP TABLE IF EXISTS `User`;
DROP TABLE IF EXISTS `material_requests`;
DROP TABLE IF EXISTS `Material`;
DROP TABLE IF EXISTS `Centro-Usuario`;
SET FOREIGN_KEY_CHECKS = 1;

CREATE TABLE `Services` (
    `id` Integer NOT NULL,
    `codigo` VARCHAR(256) NOT NULL,
    `direccion` VARCHAR(256) NOT NULL,
    `nombre` VARCHAR(256) NOT NULL,
    `latitud` float NOT NULL,
    `longitud` float NOT NULL,
    PRIMARY KEY (`id`)
);

CREATE TABLE `User` (
    `id` Integer NOT NULL,
    `nombre` VARCHAR(256) NOT NULL,
    `apellido` VARCHAR(256) NOT NULL,
    `rut` VARCHAR(256) NOT NULL,
    `correo` VARCHAR(256) NOT NULL,
    `telefono` INTEGER NOT NULL,
    `rol` VACHAR(256) NOT NULL,
    `usuario` VARCHAR(256) NOT NULL,
    `clave` VARCHAR(256) NOT NULL,
    PRIMARY KEY (`id`)
);

CREATE TABLE `material_requests` (
    `id` Integer NOT NULL,
    `ref_user` Integer NOT NULL,
    `ref_service` Integer NOT NULL,
    `created` DATE NOT NULL,
    `modified` DATE NOT NULL,
    `status` VARCHAR(256) NOT NULL,
    `observation` VARCHAR(256),
    `date_required` DATE,
    `date_issue` DATE,
    `num_requisition` Integer,
    PRIMARY KEY (`id`)
);

CREATE TABLE `Material` (
    `id` Integer NOT NULL,
    `refMateriaRequest` Integer NOT NULL,
    `description` VARCHAR(256) NOT NULL,
    `unid_of_measurement` VARCHAR(256) NOT NULL,
    `size` VARCHAR(5),
    `colour` VARCHAR(256),
    `refCode_unid_of_measurement` Integer NOT NULL,
    `quantity` float NOT NULL,
    `description_unid_of_measurement` VARCHAR(256) NOT NULL,
    PRIMARY KEY (`id`)
);

CREATE TABLE `Centro-Usuario` (
    `ref_centro` Integer NOT NULL,
    `ref_usuario` Integer NOT NULL
);

ALTER TABLE `material_requests` ADD FOREIGN KEY (`ref_service`) REFERENCES `Services`(`id`);
ALTER TABLE `material_requests` ADD FOREIGN KEY (`ref_user`) REFERENCES `User`(`id`);
ALTER TABLE `Material` ADD FOREIGN KEY (`refMateriaRequest`) REFERENCES `material_requests`(`id`);
ALTER TABLE `Centro-Usuario` ADD FOREIGN KEY (`ref_centro`) REFERENCES `Services`(`id`);
ALTER TABLE `Centro-Usuario` ADD FOREIGN KEY (`ref_usuario`) REFERENCES `User`(`id`);