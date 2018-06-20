USE [AM.EmergencyService.DB]
GO
CREATE PROCEDURE GetRequestByAddress
	@requestAddress nvarchar(50)
AS
(
SELECT *
FROM [Requests]
WHERE [Requests].[RequestAddress]=@requestAddress
);
GO