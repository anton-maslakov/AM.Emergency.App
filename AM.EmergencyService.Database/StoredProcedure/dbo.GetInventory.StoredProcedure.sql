USE [AM.EmergencyService.DB]
GO
/****** Object:  StoredProcedure [dbo].[GetInventory]    Script Date: 21.06.2018 22:03:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetInventory]
AS
(
SELECT *
FROM [Inventory]
);
GO
