USE [AM.EmergencyService.DB]
GO
/****** Object:  StoredProcedure [dbo].[GetUserRoles]    Script Date: 21.06.2018 22:03:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserRoles]
@UserId int
AS
SELECT [Role].RoleName
FROM [Role] INNER JOIN [UserRoles]
ON [UserRoles].UserId=@UserId
WHERE [Role].Id=[UserRoles].RoleId
GO
