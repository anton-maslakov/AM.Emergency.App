USE [AM.EmergencyService.DB]
GO
CREATE PROCEDURE GetRequestByNumber 
	@requestNumber int
AS
(
SELECT *
FROM [Requests]
WHERE [Requests].[RequestNumber]=@requestNumber
);
GO
