USE [AM.EmergencyService.DB]
GO
/****** Object:  StoredProcedure [dbo].[UpdateRequest]    Script Date: 21.06.2018 22:03:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[UpdateRequest]
    @RequestNumber int,
	@RequestAddress varchar(100),
	@RequestReason varchar(50),
	@RequestDate datetime,
	@IdCategory int
AS  
UPDATE Requests
     SET   RequestAddress=@RequestAddress,RequestReason=@RequestReason,
		   RequestDate=@RequestDate,IdCategory=@IdCategory
WHERE [RequestNumber]=@RequestNumber
GO
