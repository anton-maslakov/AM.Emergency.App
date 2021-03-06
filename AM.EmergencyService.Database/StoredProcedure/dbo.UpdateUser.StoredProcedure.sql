USE [AM.EmergencyService.DB]
GO
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 21.06.2018 22:03:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateUser]
@Id int,
@Login varchar(50),
@Password varchar(15),
@Email varchar(50)
AS
BEGIN
UPDATE [User]
SET [Login]=@Login, [Password]=@Password, [email]=@Email
WHERE [User].Id=@Id
DELETE FROM [UserRoles]
WHERE [UserRoles].UserId=@Id
END
GO
