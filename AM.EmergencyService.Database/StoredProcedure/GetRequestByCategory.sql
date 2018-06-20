USE [AM.EmergencyService.DB]
GO
CREATE PROCEDURE GetRequestByCategory
	@requestCategory nvarchar(50)
AS
(
SELECT *
FROM [Requests]
WHERE [Requests].[RequestCategory]=@requestCategory
);
GO
