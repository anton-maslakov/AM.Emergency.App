USE [AM.EmergencyService.DB]
GO
CREATE PROCEDURE GetRequests
AS
(
SELECT *
FROM [Requests]
);
