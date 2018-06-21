USE [AM.EmergencyService.DB]
GO
/****** Object:  StoredProcedure [dbo].[InsertRequestCasualty]    Script Date: 21.06.2018 22:03:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[InsertRequestCasualty]
    @RequestNumber int,
	@IdCasualty int
AS  
INSERT INTO RequestCasualty
           ([RequestNumber],[IdCasualty])  
     VALUES  
           (@RequestNumber,@IdCasualty)
GO
