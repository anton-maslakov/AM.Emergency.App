USE [AM.EmergencyService.DB]
GO
/****** Object:  StoredProcedure [dbo].[CreateBrigade]    Script Date: 21.06.2018 22:03:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateBrigade]
@BrigadeNumber int,
@InventoryNumber int,
@IdRescuers int
AS
INSERT INTO [BrigadesInventory](BrigadeNumber,InventoryNumber)
VALUES (@BrigadeNumber,@InventoryNumber)
INSERT INTO [RescuersBrigades](BrigadeNumber,IdRescuers)
VALUES (@BrigadeNumber,@IdRescuers)
GO
