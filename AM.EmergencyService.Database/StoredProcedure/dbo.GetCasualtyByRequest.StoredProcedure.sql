USE [AM.EmergencyService.DB]
GO
/****** Object:  StoredProcedure [dbo].[GetCasualtyByRequest]    Script Date: 21.06.2018 22:03:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCasualtyByRequest]
@RequestNumber int
AS
(
SELECT [Casualty].Id, [Casualty].Firstname, [Casualty].Surname, [Casualty].Lastname,
[Casualty].BirthDate, [Casualty].Address
FROM [Casualty] INNER JOIN [RequestCasualty]
ON [RequestCasualty].RequestNumber=@RequestNumber 
WHERE [RequestCasualty].IdCasualty=[Casualty].Id
);
GO
