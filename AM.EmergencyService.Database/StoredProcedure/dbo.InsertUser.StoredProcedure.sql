USE [AM.EmergencyService.DB]
GO
/****** Object:  StoredProcedure [dbo].[InsertUser]    Script Date: 21.06.2018 22:03:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[InsertUser]
@Login varchar(50),
@Password varchar(15),
@Email varchar(50)
AS  
INSERT INTO [User]
           ([Login],[Password],[email])  
     VALUES  
           (@Login,@Password,@Email)
GO
