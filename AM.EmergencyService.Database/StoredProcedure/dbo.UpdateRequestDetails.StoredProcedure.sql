USE [AM.EmergencyService.DB]
GO
/****** Object:  StoredProcedure [dbo].[UpdateRequestDetails]    Script Date: 21.06.2018 22:03:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[UpdateRequestDetails]
    @RequestNumber int,
	@IncidentInformation varchar(200),
	@IncidentReason varchar(200),
	@BrigadeNumber int,
	@BrigadeCallDate date,
	@BrigadeArrivalDate date,
	@BrigadeEndDate date,
	@BrigadeReturnDate date
AS  
UPDATE RequestDetails
     SET   [IncidentInformation]=@IncidentInformation,[IncidentReason]=@IncidentReason,
		   [BrigadeNumber]=@BrigadeNumber,[BrigadeCallDate]=@BrigadeCallDate,
		   [BrigadeArrivalDate]=@BrigadeArrivalDate, [BrigadeEndDate]=@BrigadeEndDate,
		   [BrigadeReturnDate]=@BrigadeReturnDate
WHERE [RequestNumber]=@RequestNumber
GO
