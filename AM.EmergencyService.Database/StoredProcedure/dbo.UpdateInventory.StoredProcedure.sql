USE [AM.EmergencyService.DB]
GO
/****** Object:  StoredProcedure [dbo].[UpdateInventory]    Script Date: 21.06.2018 22:03:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateInventory]
@inventoryNumber int,
@inventoryName varchar(50)
AS
UPDATE [Inventory]
SET InventoryName=@inventoryName
WHERE [Inventory].InventoryNumber=@inventoryNumber
GO
