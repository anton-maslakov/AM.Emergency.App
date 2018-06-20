USE [AM.EmergencyService.DB]
GO
CREATE PROCEDURE GetBrigadeRescuers
@BrigadeId int
AS
(
SELECT [Rescuers].Id, [Rescuers].Firstname, [Rescuers].Surname, [Rescuers].Lastname,
[Rescuers].BirthDate, [Rescuers].Job
FROM [Rescuers] INNER JOIN [RescuersBrigade]
ON [RescuersBrigade].IdBrigades=@BrigadeId 
WHERE [RescuersBrigade].IdRescuers=[Rescuers].Id
);
