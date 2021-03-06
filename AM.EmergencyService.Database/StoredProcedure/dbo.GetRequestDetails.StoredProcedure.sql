USE [AM.EmergencyService.DB]
GO
/****** Object:  StoredProcedure [dbo].[GetRequestDetails]    Script Date: 21.06.2018 22:03:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetRequestDetails]
@RequestNumber int
AS
(
SELECT [RequestDetails].RequestNumber, [RequestDetails].IncidentInformation, [RequestDetails].IncidentReason, [RequestDetails].BrigadeNumber,
[RequestDetails].BrigadeCallDate, [RequestDetails].BrigadeArrivalDate, [RequestDetails].BrigadeEndDate, [RequestDetails].BrigadeReturnDate
FROM [RequestDetails]
WHERE [RequestDetails].RequestNumber=@RequestNumber
);
GO
