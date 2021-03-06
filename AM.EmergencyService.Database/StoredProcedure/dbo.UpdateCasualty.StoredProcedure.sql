USE [AM.EmergencyService.DB]
GO
/****** Object:  StoredProcedure [dbo].[UpdateCasualty]    Script Date: 21.06.2018 22:03:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateCasualty]
@Id int,
@Firstname varchar(50),
@Surname varchar(50),
@Lastname varchar(50),
@Address varchar(50),
@Birthdate date
AS
UPDATE [Casualty]
SET Firstname=@Firstname, Surname=@Surname, Lastname=@Lastname,
Address=@Address, BirthDate=@Birthdate
WHERE [Casualty].Id=@Id
GO
