USE [Automatizacion_ViaWine]
GO

INSERT INTO [dbo].[Orden]
           ([ordenFabricacion]
           ,[version]
           ,[cliente]
           ,[sku]
           ,[descripcionSKAU]
           ,[botellasPlanificadas]
           ,[cajasPlanificadas]
           ,[fechaFabricacion]
           ,[horaInicioPlanificada]
           ,[horaTerminoPlanificada]
           ,[formatoCaja])
     VALUES
           (26304,'DIRECTO', 'Good Price Corporation S.A.S.','14004751-19', 'Chilensis Varietal Rose 2019 P18 Corcho', 14238, 2373, '2020-01-23','8:18:00', '11:28:48', '06x750' )


INSERT INTO [dbo].[Orden]
           ([ordenFabricacion]
           ,[version]
           ,[cliente]
           ,[sku]
           ,[descripcionSKAU]
           ,[botellasPlanificadas]
           ,[cajasPlanificadas]
           ,[fechaFabricacion]
           ,[horaInicioPlanificada]
           ,[horaTerminoPlanificada]
           ,[formatoCaja])
     VALUES
           (26236, 'DIRECTO', 'Good Price Corporation S.A.S.', '14004751-19', 'Chilensis Varietal Merlot 2019 Corcho P16 06x750 Colombia', 1344, 224, '2020-01-23','11:28:48', '12:45:00', '06x750')

INSERT INTO [dbo].[Orden]
           ([ordenFabricacion]
           ,[version]
           ,[cliente]
           ,[sku]
           ,[descripcionSKAU]
           ,[botellasPlanificadas]
           ,[cajasPlanificadas]
           ,[fechaFabricacion]
           ,[horaInicioPlanificada]
           ,[horaTerminoPlanificada]
           ,[formatoCaja])
     VALUES
           (26302, 'DIRECTO', 'Good Price Corporation S.A.S.', '14004751-19', 'Chilensis Varietal Merlot 2019 Corcho P16 06x750 Colombia', 10182, 1697, '2020-01-23','12:45:00', '15:53:24', '06x750')

INSERT INTO [dbo].[Orden]
           ([ordenFabricacion]
           ,[version]
           ,[cliente]
           ,[sku]
           ,[descripcionSKAU]
           ,[botellasPlanificadas]
           ,[cajasPlanificadas]
           ,[fechaFabricacion]
           ,[horaInicioPlanificada]
           ,[horaTerminoPlanificada]
           ,[formatoCaja])
     VALUES
           (26254, 'DIRECTO', 'KANBAN', '14002618-18', 'Oveja Negra Rva NI Cabernet Franc Carmenere 2018 Corcho 12x750 LAT-H', 9600, 800, '2020-01-23', '15:15:24', '18:08:24', '12x750' )
GO