USE [AM.EmergencyService.DB]
GO
/****** Object:  StoredProcedure [dbo].[GetUserById]    Script Date: 21.06.2018 22:03:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserById]
@Id int
AS
SELECT *
FROM [User]
WHERE [User].Id=@Id
GO
