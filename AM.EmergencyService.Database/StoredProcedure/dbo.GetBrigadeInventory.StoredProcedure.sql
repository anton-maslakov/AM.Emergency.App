USE [AM.EmergencyService.DB]
GO
/****** Object:  StoredProcedure [dbo].[GetBrigadeInventory]    Script Date: 21.06.2018 22:03:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetBrigadeInventory]
@BrigadeNumber int,
@Date date
AS
SELECT *
FROM [Inventory] INNER JOIN [BrigadesInventory]
ON BrigadesInventory.InventoryNumber=Inventory.InventoryNumber
AND BrigadesInventory.Date=CONVERT(date,@Date)
WHERE BrigadesInventory.BrigadeNumber=@BrigadeNumber
GO
