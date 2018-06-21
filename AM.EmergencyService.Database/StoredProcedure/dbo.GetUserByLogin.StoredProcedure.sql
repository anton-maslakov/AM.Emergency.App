USE [AM.EmergencyService.DB]
GO
/****** Object:  StoredProcedure [dbo].[GetUserByLogin]    Script Date: 21.06.2018 22:03:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserByLogin]
@login NVARCHAR(20)
AS
SELECT *
FROM [User]
WHERE [User].Login=@login
GO
