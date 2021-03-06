USE [AM.EmergencyService.DB]
GO
/****** Object:  StoredProcedure [dbo].[GetCasualtyNotInRequest]    Script Date: 21.06.2018 22:03:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCasualtyNotInRequest]
@RequestNumber int
AS
SELECT *
FROM Casualty LEFT JOIN RequestCasualty
ON Casualty.Id=RequestCasualty.IdCasualty
WHERE RequestCasualty.RequestNumber!=@RequestNumber OR RequestCasualty.RequestNumber IS NULL
GO
