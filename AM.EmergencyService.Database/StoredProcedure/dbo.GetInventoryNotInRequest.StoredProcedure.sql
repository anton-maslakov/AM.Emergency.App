USE [AM.EmergencyService.DB]
GO
/****** Object:  StoredProcedure [dbo].[GetInventoryNotInRequest]    Script Date: 21.06.2018 22:03:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetInventoryNotInRequest]
@RequestNumber int
AS
SELECT [Inventory].InventoryNumber, [Inventory].InventoryName
FROM [Inventory] LEFT JOIN [InventoryRequestDetails]
ON [InventoryRequestDetails].InventoryNumber = [Inventory].InventoryNumber
WHERE [InventoryRequestDetails].RequestNumber!=@RequestNumber
OR InventoryRequestDetails.RequestNumber IS NULL
GO
