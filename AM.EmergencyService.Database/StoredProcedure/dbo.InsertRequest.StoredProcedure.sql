USE [AM.EmergencyService.DB]
GO
/****** Object:  StoredProcedure [dbo].[InsertRequest]    Script Date: 21.06.2018 22:03:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[InsertRequest]
    @RequestAddress varchar(100),
	@RequestReason varchar(50),
	@IdCategory int  
AS  
INSERT INTO Requests 
           ([RequestAddress],[RequestReason],[IdCategory])  
     VALUES  
           (@RequestAddress,@RequestReason,@IdCategory)
GO
