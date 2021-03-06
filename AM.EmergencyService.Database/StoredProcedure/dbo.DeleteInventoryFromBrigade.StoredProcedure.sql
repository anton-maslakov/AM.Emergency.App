USE [AM.EmergencyService.DB]
GO
/****** Object:  StoredProcedure [dbo].[DeleteInventoryFromBrigade]    Script Date: 21.06.2018 22:03:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteInventoryFromBrigade]
@BrigadeNumber int,
@InventoryNumber int
AS
DELETE FROM BrigadesInventory
WHERE BrigadesInventory.BrigadeNumber=@BrigadeNumber
AND BrigadesInventory.InventoryNumber=@InventoryNumber
AND BrigadesInventory.Date=CONVERT(date, GETDATE())
GO
