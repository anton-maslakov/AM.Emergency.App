USE [AM.EmergencyService.DB]
GO
/****** Object:  StoredProcedure [dbo].[GetResceruerById]    Script Date: 21.06.2018 22:03:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetResceruerById]
@Id int
AS
SELECT *
FROM [Rescuers]
WHERE [Rescuers].Id=@Id
GO
