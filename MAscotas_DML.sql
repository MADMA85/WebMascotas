-- ================================================
-- RMM- 31-03-2023
-- 
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		RMM
-- Create date: 
-- Description:	Demo
-- =============================================
CREATE PROCEDURE dbo.CRUDMascota 
	-- Add the parameters for the stored procedure here	
	@Nombre VARCHAR(50),
	@FechaRegistr DATETIME,
	@Pedigri BIT ,
	@FechaNacimiento DATETIME,
	@Raza VARCHAR(20),
	@EmailResponsable VARCHAR(100),
	 @StatementType NVARCHAR(20) = ''
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	--SET NOCOUNT ON;
	IF @StatementType='SELECT'
	BEGIN
	  SELECT * FROM [Mascotas].[dbo].[Mascota]
	END
	IF @StatementType='INSERT'
	BEGIN
	    -- Insert statements for procedure here
            INSERT INTO Mascota
                        (Nombre ,
						FechaRegistr ,
						Pedigri ,
						FechaNacimiento ,
						Raza ,
						EmailResponsable     )
			VALUES     (@Nombre ,
						@FechaRegistr ,
						@Pedigri ,
						@FechaNacimiento ,
						@Raza ,
						@EmailResponsable      )

    END
END
GO
-- Carga datos de prueba
execute dbo.CRUDMascota  'Falcon1','2023-03-13',1, '2023-03-1' ,'1' ,'rj_madx@hotmail.com', 'INSERT'
execute dbo.CRUDMascota  'Falcon2','2023-03-13',0, '2023-03-1' ,'2' ,'rj_madx@hotmail.com', 'INSERT'
execute dbo.CRUDMascota  'Falcon3','2023-03-13',1, '2023-03-1' ,'3' ,'rj_madx@hotmail.com', 'INSERT'
