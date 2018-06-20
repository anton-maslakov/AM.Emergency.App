USE [AM.EmergencyService.DB]
GO
CREATE PROCEDURE GetIncident
@RequestId int
AS
(
SELECT [Incident].Id, [Incident].IncidentInformation, [Incident].IncidentReason, [Incident].IdRequest
FROM [Incident]
WHERE [Incident].IdRequest=@RequestId
);
