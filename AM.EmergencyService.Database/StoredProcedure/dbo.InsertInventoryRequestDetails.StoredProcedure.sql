USE [AM.EmergencyService.DB]
GO
/****** Object:  StoredProcedure [dbo].[InsertInventoryRequestDetails]    Script Date: 21.06.2018 22:03:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[InsertInventoryRequestDetails]
    @RequestNumber int,
	@InventoryNumber int
AS  
INSERT INTO InventoryRequestDetails
           ([RequestNumber],[InventoryNumber])  
     VALUES  
           (@RequestNumber,@InventoryNumber)
GO
