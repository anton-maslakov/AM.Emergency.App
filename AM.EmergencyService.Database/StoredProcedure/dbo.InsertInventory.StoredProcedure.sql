USE [AM.EmergencyService.DB]
GO
/****** Object:  StoredProcedure [dbo].[InsertInventory]    Script Date: 21.06.2018 22:03:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[InsertInventory]
    @InventoryName varchar(50),
	@InventoryNumber int
AS  
INSERT INTO Inventory
           ([InventoryNumber],[InventoryName])  
     VALUES  
           (@InventoryNumber,@InventoryName)
GO
