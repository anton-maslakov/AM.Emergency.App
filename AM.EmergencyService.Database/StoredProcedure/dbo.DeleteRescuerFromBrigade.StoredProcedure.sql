USE [AM.EmergencyService.DB]
GO
/****** Object:  StoredProcedure [dbo].[DeleteRescuerFromBrigade]    Script Date: 21.06.2018 22:03:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteRescuerFromBrigade]
@BrigadeNumber int,
@IdRescuers int
AS
DELETE FROM RescuersBrigades
WHERE RescuersBrigades.BrigadeNumber=@BrigadeNumber
AND RescuersBrigades.IdRescuers=@IdRescuers
AND RescuersBrigades.Date=CONVERT(date, GETDATE())
GO
