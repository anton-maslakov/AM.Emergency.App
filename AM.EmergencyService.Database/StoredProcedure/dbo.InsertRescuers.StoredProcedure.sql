USE [AM.EmergencyService.DB]
GO
/****** Object:  StoredProcedure [dbo].[InsertRescuers]    Script Date: 21.06.2018 22:03:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[InsertRescuers]  
    @Firstname varchar(50),
	@Surname varchar(50),
	@Lastname varchar(50),
	@Birthdate date,
	@Job varchar(50)  
AS  
INSERT INTO Rescuers 
           ([Firstname],[Surname],[Lastname],[BirthDate],[Job])  
     VALUES  
           (@Firstname,@Surname,@Lastname,@Birthdate,@Job)
GO
