USE [AM.EmergencyService.DB]
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 21.06.2018 22:03:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[DeleteUser]
@Id int
AS  
DELETE FROM UserRoles
WHERE UserRoles.UserId=@Id
DELETE FROM [User]
WHERE [User].Id=@Id
GO
