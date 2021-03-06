USE [AM.EmergencyService.DB]
GO
/****** Object:  StoredProcedure [dbo].[GetRescuersNotInBrigade]    Script Date: 21.06.2018 22:03:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetRescuersNotInBrigade]
AS
SELECT [Rescuers].Id, [Rescuers].Firstname, [Rescuers].Surname, [Rescuers].Lastname,
[Rescuers].BirthDate, [Rescuers].Job
FROM [Rescuers] LEFT JOIN [RescuersBrigades]
ON [RescuersBrigades].IdRescuers=[Rescuers].Id
WHERE [RescuersBrigades].Date!=Convert(date,GETDATE())
GO
