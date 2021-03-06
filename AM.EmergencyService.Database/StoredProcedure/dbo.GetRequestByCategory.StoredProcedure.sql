USE [AM.EmergencyService.DB]
GO
/****** Object:  StoredProcedure [dbo].[GetRequestByCategory]    Script Date: 21.06.2018 22:03:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetRequestByCategory]
	@RequestCategory nvarchar(50)
AS
(
SELECT [Requests].RequestNumber, [Requests].[RequestAddress], [Requests].RequestReason,
 [Requests].RequestDate, [Category].CategoryName
FROM [Requests] INNER JOIN [Category]
ON [Requests].IdCategory=[Category].Id
WHERE CHARINDEX(@RequestCategory, [Category].CategoryName)>0
);
GO
