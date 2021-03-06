USE [AM.EmergencyService.DB]
GO
/****** Object:  StoredProcedure [dbo].[GetRequests]    Script Date: 21.06.2018 22:03:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetRequests]
AS
(
SELECT [RequestNumber], [RequestAddress], [RequestReason], [RequestDate], [CategoryName]
FROM [Requests], [Category]
WHERE [Requests].IdCategory=[Category].Id
);
GO
