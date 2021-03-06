USE [AM.EmergencyService.DB]
GO
/****** Object:  StoredProcedure [dbo].[DeleteInventoryFromRequest]    Script Date: 21.06.2018 22:03:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[DeleteInventoryFromRequest]
@RequestNumber int,
@InventoryNumber int
AS
DELETE FROM InventoryRequestDetails
WHERE InventoryRequestDetails.RequestNumber=@RequestNumber
AND InventoryRequestDetails.InventoryNumber=@InventoryNumber
GO
