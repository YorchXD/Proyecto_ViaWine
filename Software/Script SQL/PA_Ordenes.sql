

/*##############################################Crear##########################################*/


/****** Object:  StoredProcedure [dbo].[Crear_botella]    Script Date: 28/01/2020 9:48:37 ******/
DROP PROCEDURE [dbo].[Crear_botella]
GO

/****** Object:  StoredProcedure [dbo].[Crear_botella]    Script Date: 28/01/2020 9:48:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Crear_botella] 
    @In_IdBotella Integer,
    @In_refOrden Integer,
    @In_fecha char(8),
    @In_horaInicio Time(0),
    @In_horaTermino Time(0)  
    AS    
    INSERT  INTO Botellas(id, fecha, horaInicio, horaTermino, refOrden)
            VALUES (@In_IdBotella, @In_fecha, @In_horaInicio, @In_horaTermino, @In_refOrden)
GO

/****** Object:  StoredProcedure [dbo].[Crear_Cajas]    Script Date: 28/01/2020 9:48:37 ******/
DROP PROCEDURE [dbo].[Crear_Cajas]
GO

/****** Object:  StoredProcedure [dbo].[Crear_Cajas]    Script Date: 28/01/2020 9:48:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Crear_Cajas] 
    @In_IdCaja Integer,
    @In_refOrden Integer,
    @In_fecha char(8),
    @In_hora Time(0)  
    AS    
    INSERT  INTO Cajas(id, fecha, hora, refOrden)
            VALUES (@In_IdCaja, @In_fecha, @In_hora, @In_refOrden)
GO


/****** Object:  StoredProcedure [dbo].[Crear_CantCajas]    Script Date: 28/01/2020 9:48:37 ******/
DROP PROCEDURE [dbo].[Crear_CantCajas]
GO

/****** Object:  StoredProcedure [dbo].[Crear_CantCajas]    Script Date: 28/01/2020 9:48:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Crear_CantCajas] 
    @In_CantCaja Integer,
    @In_refOrden Integer,
    @In_fecha char(8),
    @In_hora Time(0)  
    AS    
    INSERT  INTO CantCajas(fecha, hora, cantCajas, refOrden)
            VALUES (@In_fecha, @In_hora, @In_CantCaja, @In_refOrden)
GO

/****** Object:  StoredProcedure [dbo].[Crear_CantBotellas]    Script Date: 28/01/2020 9:48:37 ******/
DROP PROCEDURE [dbo].[Crear_CantBotellas]
GO

/****** Object:  StoredProcedure [dbo].[Crear_CantBotellas]    Script Date: 28/01/2020 9:48:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Crear_CantBotellas] 
    @In_CantBotellas Integer,
    @In_refOrden Integer,
    @In_fecha char(8),
    @In_hora Time(0)  
    AS    
    INSERT  INTO CantBotellas(fecha, hora, cantBotellas, refOrden)
            VALUES (@In_fecha, @In_hora, @In_CantBotellas, @In_refOrden)
GO





/*##############################################Leer##########################################*/

/****** Object:  StoredProcedure [dbo].[Leer_Orden]    Script Date: 28/01/2020 9:48:37 ******/
DROP PROCEDURE [dbo].[Leer_Ordenes]
GO

/****** Object:  StoredProcedure [dbo].[Leer_Orden]    Script Date: 28/01/2020 9:48:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Leer_Ordenes] 
    @Fecha char(8)  
    AS    
    SELECT * 
    FROM Orden  
    WHERE fechaFabricacion = @Fecha 
    ORDER BY horaInicioPlanificada;
GO


/****** Object:  StoredProcedure [dbo].[Leer_Cajas]    Script Date: 28/01/2020 9:48:37 ******/
DROP PROCEDURE [dbo].[Leer_Cajas]
GO

/****** Object:  StoredProcedure [dbo].[Leer_Cajas]    Script Date: 28/01/2020 9:48:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Leer_Cajas] 
    @Fecha char(8), @Orden Integer  
    AS    
    SELECT * 
    FROM Cajas  
    WHERE fecha = @Fecha 
    ORDER BY hora;
GO


/****** Object:  StoredProcedure [dbo].[Leer_Botellas]    Script Date: 28/01/2020 9:48:37 ******/
DROP PROCEDURE [dbo].[Leer_Botellas]
GO

/****** Object:  StoredProcedure [dbo].[Leer_Botellas]    Script Date: 28/01/2020 9:48:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Leer_Botellas] 
    @Fecha char(8), @Orden Integer  
    AS    
    SELECT * 
    FROM Botellas  
    WHERE fecha = @Fecha 
    ORDER BY horaInicio;
GO

/****** Object:  StoredProcedure [dbo].[Leer_CantCajas]    Script Date: 28/01/2020 9:48:37 ******/
DROP PROCEDURE [dbo].[Leer_CantCajas]
GO

/****** Object:  StoredProcedure [dbo].[Leer_CantCajas]    Script Date: 28/01/2020 9:48:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Leer_CantCajas] 
    @Fecha char(8), @Orden Integer  
    AS    
    SELECT * 
    FROM CantCajas  
    WHERE fecha = @Fecha 
    ORDER BY hora;
GO


/****** Object:  StoredProcedure [dbo].[Leer_CantBotellas]    Script Date: 28/01/2020 9:48:37 ******/
DROP PROCEDURE [dbo].[Leer_CantBotellas]
GO

/****** Object:  StoredProcedure [dbo].[Leer_CantBotellas]    Script Date: 28/01/2020 9:48:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Leer_CantBotellas] 
    @Fecha char(8), @Orden Integer  
    AS    
    SELECT * 
    FROM CantBotellas 
    WHERE fecha = @Fecha 
    ORDER BY hora;
GO


/****** Object:  StoredProcedure [dbo].[Leer_Ordenes_Iniciadas]    Script Date: 02/03/2020 9:48:37 ******/
DROP PROCEDURE [dbo].[Leer_Ordenes_Iniciadas]
GO

/****** Object:  StoredProcedure [dbo].[Leer_Ordenes_Iniciadas]    Script Date: 02/03/2020 9:48:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Leer_Ordenes_Iniciadas] 
    AS    
    SELECT * 
    FROM Orden 
    WHERE estado = '1'
GO


/*##############################################Actualizar##########################################*/
/****** Object:  StoredProcedure [dbo].[Actualizar_Orden]    Script Date: 28/01/2020 9:48:37 ******/
DROP PROCEDURE [dbo].[Actualizar_Estado_Orden]
GO

/****** Object:  StoredProcedure [dbo].[Actualizar_Orden]    Script Date: 28/01/2020 9:48:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Actualizar_Estado_Orden] 
    @OrdenFabricacion Integer, @Estado Integer 
    AS    
    UPDATE Orden 
    SET estado = @Estado
    WHERE ordenFabricacion = @OrdenFabricacion;
GO


/****** Object:  StoredProcedure [dbo].[Actualizar_HoraInicio_Orden]    Script Date: 28/01/2020 9:48:37 ******/
DROP PROCEDURE [dbo].[Actualizar_HoraInicio_Orden]
GO

/****** Object:  StoredProcedure [dbo].[Actualizar_HoraInicio_Orden]    Script Date: 28/01/2020 9:48:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Actualizar_HoraInicio_Orden] 
    @OrdenFabricacion Integer, @HoraInicio Time(0) 
    AS    
    UPDATE Orden 
    SET horaInicio = @HoraInicio
    WHERE ordenFabricacion = @OrdenFabricacion;
GO


/****** Object:  StoredProcedure [dbo].[Actualizar_HoraInicio_Orden]    Script Date: 28/01/2020 9:48:37 ******/
DROP PROCEDURE [dbo].[Actualizar_HoraTermino_Orden]
GO

/****** Object:  StoredProcedure [dbo].[Actualizar_HoraInicio_Orden]    Script Date: 28/01/2020 9:48:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Actualizar_HoraTermino_Orden] 
    @OrdenFabricacion Integer, @HoraTermino Time 
    AS    
    UPDATE Orden 
    SET horaTermino = @HoraTermino
    WHERE ordenFabricacion = @OrdenFabricacion;
GO
