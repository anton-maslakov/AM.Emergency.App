USE [AM.EmergencyService.DB]
GO
/****** Object:  StoredProcedure [dbo].[DeleteCasualtyFromRequest]    Script Date: 21.06.2018 22:03:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteCasualtyFromRequest]
@RequestNumber int,
@CasualtyId int
AS
DELETE FROM RequestCasualty
WHERE RequestCasualty.RequestNumber=@RequestNumber
AND RequestCasualty.IdCasualty=@CasualtyId
GO
