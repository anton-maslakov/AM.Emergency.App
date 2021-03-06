USE [AM.EmergencyService.DB]
GO
/****** Object:  StoredProcedure [dbo].[GetRequestInventory]    Script Date: 21.06.2018 22:03:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetRequestInventory]
@RequestNumber int
AS
(
SELECT [Inventory].InventoryNumber, [Inventory].InventoryName
FROM [Inventory]
INNER JOIN [InventoryRequestDetails] ON [InventoryRequestDetails].RequestNumber=@RequestNumber
WHERE [InventoryRequestDetails].InventoryNumber = [Inventory].InventoryNumber
);
GO
