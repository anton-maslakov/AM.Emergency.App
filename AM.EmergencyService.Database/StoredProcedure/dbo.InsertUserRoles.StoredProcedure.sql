USE [AM.EmergencyService.DB]
GO
/****** Object:  StoredProcedure [dbo].[InsertUserRoles]    Script Date: 21.06.2018 22:03:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertUserRoles]
@UserId int,
@RoleId int
AS
INSERT INTO [UserRoles] (RoleId,UserId)
VALUES(@RoleId, @UserId)
GO
