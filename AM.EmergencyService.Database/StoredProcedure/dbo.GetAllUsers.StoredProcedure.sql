USE [AM.EmergencyService.DB]
GO
/****** Object:  StoredProcedure [dbo].[GetAllUsers]    Script Date: 21.06.2018 22:03:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllUsers] 
AS
SELECT [User].Id, [User].Login, [User].Password, [User].email
FROM [User]
GO
