USE [AM.EmergencyService.DB]
GO
/****** Object:  StoredProcedure [dbo].[GetRoleById]    Script Date: 21.06.2018 22:03:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetRoleById]
@Id int
AS
SELECT *
FROM [Role]
WHERE [Role].Id=@Id
GO
