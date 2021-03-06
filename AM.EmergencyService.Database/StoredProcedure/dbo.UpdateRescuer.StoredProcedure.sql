USE [AM.EmergencyService.DB]
GO
/****** Object:  StoredProcedure [dbo].[UpdateRescuer]    Script Date: 21.06.2018 22:03:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateRescuer]
@Id int,
@Firstname varchar(50),
@Surname varchar(50),
@Lastname varchar(50),
@Birthdate date,
@Job varchar(50)
AS
UPDATE [Rescuers]
SET [Firstname]=@Firstname, Surname=@Surname, Lastname=@Lastname,
BirthDate=@Birthdate, Job=@Job
WHERE [Rescuers].Id=@Id
GO
