USE [AM.EmergencyService.DB]
GO
/****** Object:  StoredProcedure [dbo].[InsertCasualty]    Script Date: 21.06.2018 22:03:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[InsertCasualty]
    @Firstname varchar(50),
	@Surname varchar(50),
	@Lastname varchar(50),
	@BirthDate date,
	@Address  varchar(50)
AS  
INSERT INTO Casualty
           ([Firstname],[Surname],[Lastname],[BirthDate],[Address])  
     VALUES  
           (@Firstname,@Surname,@Lastname,@BirthDate,@Address)
GO
