USE [AM.EmergencyService.DB]
GO
/****** Object:  StoredProcedure [dbo].[GetBrigadeByDate]    Script Date: 21.06.2018 22:03:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetBrigadeByDate]
@Date datetime
AS
SELECT DISTINCT  Brigades.BrigadeNumber
FROM Brigades Inner JOIN RescuersBrigades
ON Brigades.BrigadeNumber=RescuersBrigades.BrigadeNumber
WHERE RescuersBrigades.Date=CONVERT(date,@Date)
GO
