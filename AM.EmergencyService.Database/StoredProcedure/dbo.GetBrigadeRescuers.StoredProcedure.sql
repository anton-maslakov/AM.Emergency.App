USE [AM.EmergencyService.DB]
GO
/****** Object:  StoredProcedure [dbo].[GetBrigadeRescuers]    Script Date: 21.06.2018 22:03:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetBrigadeRescuers]
@BrigadeNumber int,
@Date date
AS
(
SELECT [Rescuers].Id, [Rescuers].Firstname, [Rescuers].Surname, [Rescuers].Lastname,
[Rescuers].BirthDate, [Rescuers].Job
FROM [Rescuers] INNER JOIN [RescuersBrigades]
ON [RescuersBrigades].BrigadeNumber=@BrigadeNumber 
WHERE [RescuersBrigades].IdRescuers=[Rescuers].Id AND [RescuersBrigades].Date=Convert(date,@Date)
);
GO
