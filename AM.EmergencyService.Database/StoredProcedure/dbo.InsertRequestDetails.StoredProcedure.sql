USE [AM.EmergencyService.DB]
GO
/****** Object:  StoredProcedure [dbo].[InsertRequestDetails]    Script Date: 21.06.2018 22:03:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[InsertRequestDetails]
    @RequestNumber int,
	@IncidentInformation varchar(200),
	@IncidentReason varchar(200),
	@BrigadeNumber int,
	@BrigadeCallDate as datetime null,
	@BrigadeArrivalDate as datetime null,
	@BrigadeEndDate as datetime null,
	@BrigadeReturnDate as datetime null
AS  
INSERT INTO RequestDetails
           ([RequestNumber],[IncidentInformation],[IncidentReason],[BrigadeNumber],
[BrigadeCallDate],[BrigadeArrivalDate],[BrigadeEndDate],[BrigadeReturnDate])  
     VALUES  
           (@RequestNumber,@IncidentInformation,@IncidentReason,@BrigadeNumber,
@BrigadeCallDate,@BrigadeArrivalDate, @BrigadeEndDate, @BrigadeReturnDate)
GO
