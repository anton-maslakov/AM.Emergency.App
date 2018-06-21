USE [AM.EmergencyService.DB]
GO
/****** Object:  StoredProcedure [dbo].[InsertRescuersBrigades]    Script Date: 21.06.2018 22:03:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[InsertRescuersBrigades]
    @BrigadeNumber int,
	@IdRescuers int
AS  
INSERT INTO [RescuersBrigades](BrigadeNumber,IdRescuers)
VALUES (@BrigadeNumber,@IdRescuers)
GO
