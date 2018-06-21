USE [AM.EmergencyService.DB]
GO
/****** Object:  StoredProcedure [dbo].[InsertBrigadesInventory]    Script Date: 21.06.2018 22:03:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[InsertBrigadesInventory]
    @BrigadeNumber int,
	@InventoryNumber int
AS  
INSERT INTO BrigadesInventory
           ([BrigadeNumber],[InventoryNumber])  
     VALUES  
           (@BrigadeNumber,@InventoryNumber)
GO
