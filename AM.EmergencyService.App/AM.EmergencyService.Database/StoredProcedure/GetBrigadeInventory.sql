USE [AM.EmergencyService.DB]
GO
CREATE PROCEDURE GetBrigadeInventory
@BrigadeId int
AS
(
SELECT *
FROM [Inventory]
WHERE [Inventory].IdBrigade=@BrigadeId
);
