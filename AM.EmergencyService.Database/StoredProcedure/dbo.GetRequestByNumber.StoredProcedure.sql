USE [AM.EmergencyService.DB]
GO
/****** Object:  StoredProcedure [dbo].[GetRequestByNumber]    Script Date: 21.06.2018 22:03:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetRequestByNumber] 
	@RequestNumber int
AS
(
SELECT [Requests].RequestNumber, [Requests].[RequestAddress], [Requests].RequestReason,
 [Requests].RequestDate, [Category].CategoryName
FROM [Requests] INNER JOIN [Category]
ON [Requests].IdCategory=[Category].Id
WHERE [Requests].[RequestNumber]=@RequestNumber
);
GO
