USE [AM.EmergencyService.DB]
GO
/****** Object:  StoredProcedure [dbo].[InsertBrigades]    Script Date: 21.06.2018 22:03:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[InsertBrigades]
    @BrigadeNumber int
AS  
INSERT INTO Brigades
           ([BrigadeNumber])  
     VALUES  
           (@BrigadeNumber)
GO
