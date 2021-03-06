USE [master]
GO
/****** Object:  Database [AM.EmergencyService.DB]    Script Date: 21.06.2018 22:04:35 ******/
CREATE DATABASE [AM.EmergencyService.DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AM.EmergencyService.DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.ENTONISQL\MSSQL\DATA\AM.EmergencyService.DB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AM.EmergencyService.DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.ENTONISQL\MSSQL\DATA\AM.EmergencyService.DB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [AM.EmergencyService.DB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AM.EmergencyService.DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AM.EmergencyService.DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AM.EmergencyService.DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AM.EmergencyService.DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AM.EmergencyService.DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AM.EmergencyService.DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [AM.EmergencyService.DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AM.EmergencyService.DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AM.EmergencyService.DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AM.EmergencyService.DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AM.EmergencyService.DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AM.EmergencyService.DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AM.EmergencyService.DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AM.EmergencyService.DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AM.EmergencyService.DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AM.EmergencyService.DB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AM.EmergencyService.DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AM.EmergencyService.DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AM.EmergencyService.DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AM.EmergencyService.DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AM.EmergencyService.DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AM.EmergencyService.DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AM.EmergencyService.DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AM.EmergencyService.DB] SET RECOVERY FULL 
GO
ALTER DATABASE [AM.EmergencyService.DB] SET  MULTI_USER 
GO
ALTER DATABASE [AM.EmergencyService.DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AM.EmergencyService.DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AM.EmergencyService.DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AM.EmergencyService.DB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AM.EmergencyService.DB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'AM.EmergencyService.DB', N'ON'
GO
ALTER DATABASE [AM.EmergencyService.DB] SET QUERY_STORE = OFF
GO
USE [AM.EmergencyService.DB]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [AM.EmergencyService.DB]
GO
/****** Object:  Table [dbo].[Brigades]    Script Date: 21.06.2018 22:04:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brigades](
	[BrigadeNumber] [int] NOT NULL,
 CONSTRAINT [PK_Brigades] PRIMARY KEY CLUSTERED 
(
	[BrigadeNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BrigadesInventory]    Script Date: 21.06.2018 22:04:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BrigadesInventory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BrigadeNumber] [int] NOT NULL,
	[InventoryNumber] [int] NOT NULL,
	[Date] [date] NOT NULL,
 CONSTRAINT [PK_BrigadesInventory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[Date] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Casualty]    Script Date: 21.06.2018 22:04:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Casualty](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Firstname] [varchar](50) NULL,
	[Surname] [varchar](50) NULL,
	[Lastname] [varchar](50) NULL,
	[BirthDate] [date] NULL,
	[Address] [varchar](50) NULL,
 CONSTRAINT [PK_Casualty] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 21.06.2018 22:04:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inventory]    Script Date: 21.06.2018 22:04:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventory](
	[InventoryNumber] [int] NOT NULL,
	[InventoryName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Inventory] PRIMARY KEY CLUSTERED 
(
	[InventoryNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InventoryRequestDetails]    Script Date: 21.06.2018 22:04:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InventoryRequestDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RequestNumber] [int] NOT NULL,
	[InventoryNumber] [int] NOT NULL,
 CONSTRAINT [PK_InventoryRequestDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RequestCasualty]    Script Date: 21.06.2018 22:04:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequestCasualty](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RequestNumber] [int] NOT NULL,
	[IdCasualty] [int] NOT NULL,
 CONSTRAINT [PK_IncidentCasualty] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RequestDetails]    Script Date: 21.06.2018 22:04:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequestDetails](
	[RequestNumber] [int] NOT NULL,
	[IncidentInformation] [varchar](200) NULL,
	[IncidentReason] [varchar](200) NULL,
	[BrigadeNumber] [int] NULL,
	[BrigadeCallDate] [datetime] NULL,
	[BrigadeArrivalDate] [datetime] NULL,
	[BrigadeEndDate] [datetime] NULL,
	[BrigadeReturnDate] [datetime] NULL,
 CONSTRAINT [PK_Incident] PRIMARY KEY CLUSTERED 
(
	[RequestNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Requests]    Script Date: 21.06.2018 22:04:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Requests](
	[RequestNumber] [int] IDENTITY(1,1) NOT NULL,
	[RequestAddress] [varchar](100) NOT NULL,
	[RequestReason] [varchar](50) NOT NULL,
	[RequestDate] [datetime] NOT NULL,
	[IdCategory] [int] NOT NULL,
 CONSTRAINT [PK_Requests_1] PRIMARY KEY CLUSTERED 
(
	[RequestNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rescuers]    Script Date: 21.06.2018 22:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rescuers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Firstname] [varchar](50) NOT NULL,
	[Surname] [varchar](50) NOT NULL,
	[Lastname] [varchar](50) NOT NULL,
	[BirthDate] [date] NOT NULL,
	[Job] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Rescuers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RescuersBrigades]    Script Date: 21.06.2018 22:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RescuersBrigades](
	[BrigadeNumber] [int] NOT NULL,
	[IdRescuers] [int] NOT NULL,
	[Date] [date] NOT NULL,
 CONSTRAINT [PK_RescuersBrigades] PRIMARY KEY CLUSTERED 
(
	[BrigadeNumber] ASC,
	[IdRescuers] ASC,
	[Date] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 21.06.2018 22:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 21.06.2018 22:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [varchar](50) NOT NULL,
	[Password] [varchar](15) NOT NULL,
	[email] [varchar](50) NOT NULL,
 CONSTRAINT [PK_User_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 21.06.2018 22:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BrigadesInventory] ADD  CONSTRAINT [DF_BrigadesInventory_Date]  DEFAULT (getdate()) FOR [Date]
GO
ALTER TABLE [dbo].[Requests] ADD  CONSTRAINT [DF_Requests_RequestDate]  DEFAULT (getdate()) FOR [RequestDate]
GO
ALTER TABLE [dbo].[RescuersBrigades] ADD  CONSTRAINT [DF_RescuersBrigades_Date]  DEFAULT (getdate()) FOR [Date]
GO
ALTER TABLE [dbo].[BrigadesInventory]  WITH CHECK ADD  CONSTRAINT [FK_BrigadesInventory_Brigades] FOREIGN KEY([BrigadeNumber])
REFERENCES [dbo].[Brigades] ([BrigadeNumber])
GO
ALTER TABLE [dbo].[BrigadesInventory] CHECK CONSTRAINT [FK_BrigadesInventory_Brigades]
GO
ALTER TABLE [dbo].[BrigadesInventory]  WITH CHECK ADD  CONSTRAINT [FK_BrigadesInventory_Inventory1] FOREIGN KEY([InventoryNumber])
REFERENCES [dbo].[Inventory] ([InventoryNumber])
GO
ALTER TABLE [dbo].[BrigadesInventory] CHECK CONSTRAINT [FK_BrigadesInventory_Inventory1]
GO
ALTER TABLE [dbo].[InventoryRequestDetails]  WITH CHECK ADD  CONSTRAINT [FK_InventoryRequestDetails_Inventory] FOREIGN KEY([InventoryNumber])
REFERENCES [dbo].[Inventory] ([InventoryNumber])
GO
ALTER TABLE [dbo].[InventoryRequestDetails] CHECK CONSTRAINT [FK_InventoryRequestDetails_Inventory]
GO
ALTER TABLE [dbo].[InventoryRequestDetails]  WITH CHECK ADD  CONSTRAINT [FK_InventoryRequestDetails_RequestDetails1] FOREIGN KEY([RequestNumber])
REFERENCES [dbo].[RequestDetails] ([RequestNumber])
GO
ALTER TABLE [dbo].[InventoryRequestDetails] CHECK CONSTRAINT [FK_InventoryRequestDetails_RequestDetails1]
GO
ALTER TABLE [dbo].[RequestCasualty]  WITH CHECK ADD  CONSTRAINT [FK_IncidentCasualty_Casualty] FOREIGN KEY([IdCasualty])
REFERENCES [dbo].[Casualty] ([Id])
GO
ALTER TABLE [dbo].[RequestCasualty] CHECK CONSTRAINT [FK_IncidentCasualty_Casualty]
GO
ALTER TABLE [dbo].[RequestCasualty]  WITH CHECK ADD  CONSTRAINT [FK_RequestCasualty_Requests] FOREIGN KEY([RequestNumber])
REFERENCES [dbo].[Requests] ([RequestNumber])
GO
ALTER TABLE [dbo].[RequestCasualty] CHECK CONSTRAINT [FK_RequestCasualty_Requests]
GO
ALTER TABLE [dbo].[RequestDetails]  WITH CHECK ADD  CONSTRAINT [FK_RequestDetails_Brigades1] FOREIGN KEY([BrigadeNumber])
REFERENCES [dbo].[Brigades] ([BrigadeNumber])
GO
ALTER TABLE [dbo].[RequestDetails] CHECK CONSTRAINT [FK_RequestDetails_Brigades1]
GO
ALTER TABLE [dbo].[RequestDetails]  WITH NOCHECK ADD  CONSTRAINT [FK_RequestDetails_Requests] FOREIGN KEY([RequestNumber])
REFERENCES [dbo].[Requests] ([RequestNumber])
GO
ALTER TABLE [dbo].[RequestDetails] CHECK CONSTRAINT [FK_RequestDetails_Requests]
GO
ALTER TABLE [dbo].[Requests]  WITH CHECK ADD  CONSTRAINT [FK_Requests_Category] FOREIGN KEY([IdCategory])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Requests] CHECK CONSTRAINT [FK_Requests_Category]
GO
ALTER TABLE [dbo].[RescuersBrigades]  WITH CHECK ADD  CONSTRAINT [FK_RescuersBrigades_Brigades] FOREIGN KEY([BrigadeNumber])
REFERENCES [dbo].[Brigades] ([BrigadeNumber])
GO
ALTER TABLE [dbo].[RescuersBrigades] CHECK CONSTRAINT [FK_RescuersBrigades_Brigades]
GO
ALTER TABLE [dbo].[RescuersBrigades]  WITH CHECK ADD  CONSTRAINT [FK_RescuersBrigades_Rescuers] FOREIGN KEY([IdRescuers])
REFERENCES [dbo].[Rescuers] ([Id])
GO
ALTER TABLE [dbo].[RescuersBrigades] CHECK CONSTRAINT [FK_RescuersBrigades_Rescuers]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Role]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_User]
GO
/****** Object:  StoredProcedure [dbo].[CreateBrigade]    Script Date: 21.06.2018 22:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateBrigade]
@BrigadeNumber int,
@InventoryNumber int,
@IdRescuers int
AS
INSERT INTO [BrigadesInventory](BrigadeNumber,InventoryNumber)
VALUES (@BrigadeNumber,@InventoryNumber)
INSERT INTO [RescuersBrigades](BrigadeNumber,IdRescuers)
VALUES (@BrigadeNumber,@IdRescuers)
GO
/****** Object:  StoredProcedure [dbo].[DeleteCasualtyFromRequest]    Script Date: 21.06.2018 22:04:37 ******/
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
/****** Object:  StoredProcedure [dbo].[DeleteInventoryFromBrigade]    Script Date: 21.06.2018 22:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteInventoryFromBrigade]
@BrigadeNumber int,
@InventoryNumber int
AS
DELETE FROM BrigadesInventory
WHERE BrigadesInventory.BrigadeNumber=@BrigadeNumber
AND BrigadesInventory.InventoryNumber=@InventoryNumber
AND BrigadesInventory.Date=CONVERT(date, GETDATE())
GO
/****** Object:  StoredProcedure [dbo].[DeleteInventoryFromRequest]    Script Date: 21.06.2018 22:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[DeleteInventoryFromRequest]
@RequestNumber int,
@InventoryNumber int
AS
DELETE FROM InventoryRequestDetails
WHERE InventoryRequestDetails.RequestNumber=@RequestNumber
AND InventoryRequestDetails.InventoryNumber=@InventoryNumber
GO
/****** Object:  StoredProcedure [dbo].[DeleteRescuerFromBrigade]    Script Date: 21.06.2018 22:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteRescuerFromBrigade]
@BrigadeNumber int,
@IdRescuers int
AS
DELETE FROM RescuersBrigades
WHERE RescuersBrigades.BrigadeNumber=@BrigadeNumber
AND RescuersBrigades.IdRescuers=@IdRescuers
AND RescuersBrigades.Date=CONVERT(date, GETDATE())
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 21.06.2018 22:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[DeleteUser]
@Id int
AS  
DELETE FROM UserRoles
WHERE UserRoles.UserId=@Id
DELETE FROM [User]
WHERE [User].Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[GetAllCasualty]    Script Date: 21.06.2018 22:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllCasualty]
AS
SELECT *
FROM Casualty
GO
/****** Object:  StoredProcedure [dbo].[GetAllLogins]    Script Date: 21.06.2018 22:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllLogins]
AS
SELECT [User].Login
FROM [User]
GO
/****** Object:  StoredProcedure [dbo].[GetAllRoles]    Script Date: 21.06.2018 22:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllRoles]
AS
SELECT *
FROM [Role]
GO
/****** Object:  StoredProcedure [dbo].[GetAllUsers]    Script Date: 21.06.2018 22:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllUsers] 
AS
SELECT [User].Id, [User].Login, [User].Password, [User].email
FROM [User]
GO
/****** Object:  StoredProcedure [dbo].[GetBrigadeByDate]    Script Date: 21.06.2018 22:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetBrigadeByDate]
@Date datetime
AS
SELECT DISTINCT  Brigades.BrigadeNumber
FROM Brigades Inner JOIN RescuersBrigades
ON Brigades.BrigadeNumber=RescuersBrigades.BrigadeNumber
WHERE RescuersBrigades.Date=CONVERT(date,@Date)
GO
/****** Object:  StoredProcedure [dbo].[GetBrigadeInventory]    Script Date: 21.06.2018 22:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetBrigadeInventory]
@BrigadeNumber int,
@Date date
AS
SELECT *
FROM [Inventory] INNER JOIN [BrigadesInventory]
ON BrigadesInventory.InventoryNumber=Inventory.InventoryNumber
AND BrigadesInventory.Date=CONVERT(date,@Date)
WHERE BrigadesInventory.BrigadeNumber=@BrigadeNumber
GO
/****** Object:  StoredProcedure [dbo].[GetBrigadeRescuers]    Script Date: 21.06.2018 22:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetBrigadeRescuers]
@BrigadeNumber int,
@Date date
AS
(
SELECT [Rescuers].Id, [Rescuers].Firstname, [Rescuers].Surname, [Rescuers].Lastname,
[Rescuers].BirthDate, [Rescuers].Job
FROM [Rescuers] INNER JOIN [RescuersBrigades]
ON [RescuersBrigades].BrigadeNumber=@BrigadeNumber 
WHERE [RescuersBrigades].IdRescuers=[Rescuers].Id AND [RescuersBrigades].Date=Convert(date,@Date)
);
GO
/****** Object:  StoredProcedure [dbo].[GetBrigades]    Script Date: 21.06.2018 22:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetBrigades]
AS
(
SELECT *
FROM [Brigades]
);
GO
/****** Object:  StoredProcedure [dbo].[GetCasualtyById]    Script Date: 21.06.2018 22:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCasualtyById]
@Id int
AS
SELECT *
FROM [Casualty]
WHERE [Casualty].Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[GetCasualtyByRequest]    Script Date: 21.06.2018 22:04:37 ******/
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
/****** Object:  StoredProcedure [dbo].[GetCasualtyNotInRequest]    Script Date: 21.06.2018 22:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCasualtyNotInRequest]
@RequestNumber int
AS
SELECT *
FROM Casualty LEFT JOIN RequestCasualty
ON Casualty.Id=RequestCasualty.IdCasualty
WHERE RequestCasualty.RequestNumber!=@RequestNumber OR RequestCasualty.RequestNumber IS NULL
GO
/****** Object:  StoredProcedure [dbo].[GetCategories]    Script Date: 21.06.2018 22:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCategories]
AS
SELECT *
FROM Category
GO
/****** Object:  StoredProcedure [dbo].[GetInventory]    Script Date: 21.06.2018 22:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetInventory]
AS
(
SELECT *
FROM [Inventory]
);
GO
/****** Object:  StoredProcedure [dbo].[GetInventoryNotInRequest]    Script Date: 21.06.2018 22:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetInventoryNotInRequest]
@RequestNumber int
AS
SELECT [Inventory].InventoryNumber, [Inventory].InventoryName
FROM [Inventory] LEFT JOIN [InventoryRequestDetails]
ON [InventoryRequestDetails].InventoryNumber = [Inventory].InventoryNumber
WHERE [InventoryRequestDetails].RequestNumber!=@RequestNumber
OR InventoryRequestDetails.RequestNumber IS NULL
GO
/****** Object:  StoredProcedure [dbo].[GetRequestByAddress]    Script Date: 21.06.2018 22:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetRequestByAddress]
	@RequestAddress nvarchar(50)
AS
(
SELECT [Requests].RequestNumber, [Requests].[RequestAddress], [Requests].RequestReason,
 [Requests].RequestDate, [Category].CategoryName
FROM [Requests] INNER JOIN [Category]
ON [Requests].IdCategory=[Category].Id
WHERE CHARINDEX(@RequestAddress, [Requests].[RequestAddress])>0
);
GO
/****** Object:  StoredProcedure [dbo].[GetRequestByAddressAndDate]    Script Date: 21.06.2018 22:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetRequestByAddressAndDate]
	@RequestAddress nvarchar(50),
	@RequestDate datetime
AS
SELECT [Requests].RequestNumber, [Requests].[RequestAddress], [Requests].RequestReason,
 [Requests].RequestDate, [Category].CategoryName
FROM [Requests] INNER JOIN [Category]
ON [Requests].IdCategory=[Category].Id
WHERE CHARINDEX(@RequestAddress, [Requests].[RequestAddress])>0 AND CONVERT(date,[Requests].RequestDate)=CONVERT(date, @RequestDate)
GO
/****** Object:  StoredProcedure [dbo].[GetRequestByCategory]    Script Date: 21.06.2018 22:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetRequestByCategory]
	@RequestCategory nvarchar(50)
AS
(
SELECT [Requests].RequestNumber, [Requests].[RequestAddress], [Requests].RequestReason,
 [Requests].RequestDate, [Category].CategoryName
FROM [Requests] INNER JOIN [Category]
ON [Requests].IdCategory=[Category].Id
WHERE CHARINDEX(@RequestCategory, [Category].CategoryName)>0
);
GO
/****** Object:  StoredProcedure [dbo].[GetRequestByCategoryAndDate]    Script Date: 21.06.2018 22:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetRequestByCategoryAndDate]
	@RequestCategory nvarchar(50),
	@RequestDate datetime
AS
(
SELECT [Requests].RequestNumber, [Requests].[RequestAddress], [Requests].RequestReason,
 [Requests].RequestDate, [Category].CategoryName
FROM [Requests] INNER JOIN [Category]
ON [Requests].IdCategory=[Category].Id
WHERE CHARINDEX(@RequestCategory, [Category].CategoryName)>0 AND CONVERT(date,[Requests].RequestDate)=CONVERT(date, @RequestDate)
);
GO
/****** Object:  StoredProcedure [dbo].[GetRequestByNumber]    Script Date: 21.06.2018 22:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetRequestByNumber] 
	@RequestNumber int
AS
(
SELECT [Requests].RequestNumber, [Requests].[RequestAddress], [Requests].RequestReason,
 [Requests].RequestDate, [Category].CategoryName
FROM [Requests] INNER JOIN [Category]
ON [Requests].IdCategory=[Category].Id
WHERE [Requests].[RequestNumber]=@RequestNumber
);
GO
/****** Object:  StoredProcedure [dbo].[GetRequestByNumberAndDate]    Script Date: 21.06.2018 22:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetRequestByNumberAndDate] 
	@RequestNumber int,
	@RequestDate datetime
AS
SELECT [Requests].RequestNumber, [Requests].[RequestAddress], [Requests].RequestReason,
 [Requests].RequestDate, [Category].CategoryName
FROM [Requests] INNER JOIN [Category]
ON [Requests].IdCategory=[Category].Id
WHERE [Requests].[RequestNumber]=@RequestNumber AND CONVERT(date,[Requests].RequestDate)=CONVERT(date, @RequestDate)
GO
/****** Object:  StoredProcedure [dbo].[GetRequestDetails]    Script Date: 21.06.2018 22:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetRequestDetails]
@RequestNumber int
AS
(
SELECT [RequestDetails].RequestNumber, [RequestDetails].IncidentInformation, [RequestDetails].IncidentReason, [RequestDetails].BrigadeNumber,
[RequestDetails].BrigadeCallDate, [RequestDetails].BrigadeArrivalDate, [RequestDetails].BrigadeEndDate, [RequestDetails].BrigadeReturnDate
FROM [RequestDetails]
WHERE [RequestDetails].RequestNumber=@RequestNumber
);
GO
/****** Object:  StoredProcedure [dbo].[GetRequestInventory]    Script Date: 21.06.2018 22:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetRequestInventory]
@RequestNumber int
AS
(
SELECT [Inventory].InventoryNumber, [Inventory].InventoryName
FROM [Inventory]
INNER JOIN [InventoryRequestDetails] ON [InventoryRequestDetails].RequestNumber=@RequestNumber
WHERE [InventoryRequestDetails].InventoryNumber = [Inventory].InventoryNumber
);
GO
/****** Object:  StoredProcedure [dbo].[GetRequests]    Script Date: 21.06.2018 22:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetRequests]
AS
(
SELECT [RequestNumber], [RequestAddress], [RequestReason], [RequestDate], [CategoryName]
FROM [Requests], [Category]
WHERE [Requests].IdCategory=[Category].Id
);
GO
/****** Object:  StoredProcedure [dbo].[GetResceruerById]    Script Date: 21.06.2018 22:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetResceruerById]
@Id int
AS
SELECT *
FROM [Rescuers]
WHERE [Rescuers].Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[GetRescuers]    Script Date: 21.06.2018 22:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetRescuers]
AS
(
SELECT *
FROM [Rescuers]
);


GO
/****** Object:  StoredProcedure [dbo].[GetRescuersNotInBrigade]    Script Date: 21.06.2018 22:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetRescuersNotInBrigade]
AS
SELECT [Rescuers].Id, [Rescuers].Firstname, [Rescuers].Surname, [Rescuers].Lastname,
[Rescuers].BirthDate, [Rescuers].Job
FROM [Rescuers] LEFT JOIN [RescuersBrigades]
ON [RescuersBrigades].IdRescuers=[Rescuers].Id
WHERE [RescuersBrigades].Date!=Convert(date,GETDATE())
GO
/****** Object:  StoredProcedure [dbo].[GetRoleById]    Script Date: 21.06.2018 22:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetRoleById]
@Id int
AS
SELECT *
FROM [Role]
WHERE [Role].Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[GetUserById]    Script Date: 21.06.2018 22:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserById]
@Id int
AS
SELECT *
FROM [User]
WHERE [User].Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[GetUserByLogin]    Script Date: 21.06.2018 22:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserByLogin]
@login NVARCHAR(20)
AS
SELECT *
FROM [User]
WHERE [User].Login=@login
GO
/****** Object:  StoredProcedure [dbo].[GetUserRoles]    Script Date: 21.06.2018 22:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserRoles]
@UserId int
AS
SELECT [Role].RoleName
FROM [Role] INNER JOIN [UserRoles]
ON [UserRoles].UserId=@UserId
WHERE [Role].Id=[UserRoles].RoleId
GO
/****** Object:  StoredProcedure [dbo].[InsertBrigades]    Script Date: 21.06.2018 22:04:37 ******/
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
/****** Object:  StoredProcedure [dbo].[InsertBrigadesInventory]    Script Date: 21.06.2018 22:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[InsertBrigadesInventory]
    @BrigadeNumber int,
	@InventoryNumber int
AS  
INSERT INTO BrigadesInventory
           ([BrigadeNumber],[InventoryNumber])  
     VALUES  
           (@BrigadeNumber,@InventoryNumber)
GO
/****** Object:  StoredProcedure [dbo].[InsertCasualty]    Script Date: 21.06.2018 22:04:37 ******/
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
/****** Object:  StoredProcedure [dbo].[InsertInventory]    Script Date: 21.06.2018 22:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[InsertInventory]
    @InventoryName varchar(50),
	@InventoryNumber int
AS  
INSERT INTO Inventory
           ([InventoryNumber],[InventoryName])  
     VALUES  
           (@InventoryNumber,@InventoryName)
GO
/****** Object:  StoredProcedure [dbo].[InsertInventoryRequestDetails]    Script Date: 21.06.2018 22:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[InsertInventoryRequestDetails]
    @RequestNumber int,
	@InventoryNumber int
AS  
INSERT INTO InventoryRequestDetails
           ([RequestNumber],[InventoryNumber])  
     VALUES  
           (@RequestNumber,@InventoryNumber)
GO
/****** Object:  StoredProcedure [dbo].[InsertRequest]    Script Date: 21.06.2018 22:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[InsertRequest]
    @RequestAddress varchar(100),
	@RequestReason varchar(50),
	@IdCategory int  
AS  
INSERT INTO Requests 
           ([RequestAddress],[RequestReason],[IdCategory])  
     VALUES  
           (@RequestAddress,@RequestReason,@IdCategory)
GO
/****** Object:  StoredProcedure [dbo].[InsertRequestCasualty]    Script Date: 21.06.2018 22:04:37 ******/
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
/****** Object:  StoredProcedure [dbo].[InsertRequestDetails]    Script Date: 21.06.2018 22:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[InsertRequestDetails]
    @RequestNumber int,
	@IncidentInformation varchar(200),
	@IncidentReason varchar(200),
	@BrigadeNumber int,
	@BrigadeCallDate as datetime null,
	@BrigadeArrivalDate as datetime null,
	@BrigadeEndDate as datetime null,
	@BrigadeReturnDate as datetime null
AS  
INSERT INTO RequestDetails
           ([RequestNumber],[IncidentInformation],[IncidentReason],[BrigadeNumber],
[BrigadeCallDate],[BrigadeArrivalDate],[BrigadeEndDate],[BrigadeReturnDate])  
     VALUES  
           (@RequestNumber,@IncidentInformation,@IncidentReason,@BrigadeNumber,
@BrigadeCallDate,@BrigadeArrivalDate, @BrigadeEndDate, @BrigadeReturnDate)
GO
/****** Object:  StoredProcedure [dbo].[InsertRescuers]    Script Date: 21.06.2018 22:04:37 ******/
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
/****** Object:  StoredProcedure [dbo].[InsertRescuersBrigades]    Script Date: 21.06.2018 22:04:37 ******/
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
/****** Object:  StoredProcedure [dbo].[InsertUser]    Script Date: 21.06.2018 22:04:37 ******/
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
/****** Object:  StoredProcedure [dbo].[InsertUserRoles]    Script Date: 21.06.2018 22:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertUserRoles]
@UserId int,
@RoleId int
AS
INSERT INTO [UserRoles] (RoleId,UserId)
VALUES(@RoleId, @UserId)
GO
/****** Object:  StoredProcedure [dbo].[UpdateCasualty]    Script Date: 21.06.2018 22:04:37 ******/
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
/****** Object:  StoredProcedure [dbo].[UpdateInventory]    Script Date: 21.06.2018 22:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateInventory]
@inventoryNumber int,
@inventoryName varchar(50)
AS
UPDATE [Inventory]
SET InventoryName=@inventoryName
WHERE [Inventory].InventoryNumber=@inventoryNumber
GO
/****** Object:  StoredProcedure [dbo].[UpdateRequest]    Script Date: 21.06.2018 22:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[UpdateRequest]
    @RequestNumber int,
	@RequestAddress varchar(100),
	@RequestReason varchar(50),
	@RequestDate datetime,
	@IdCategory int
AS  
UPDATE Requests
     SET   RequestAddress=@RequestAddress,RequestReason=@RequestReason,
		   RequestDate=@RequestDate,IdCategory=@IdCategory
WHERE [RequestNumber]=@RequestNumber
GO
/****** Object:  StoredProcedure [dbo].[UpdateRequestDetails]    Script Date: 21.06.2018 22:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[UpdateRequestDetails]
    @RequestNumber int,
	@IncidentInformation varchar(200),
	@IncidentReason varchar(200),
	@BrigadeNumber int,
	@BrigadeCallDate date,
	@BrigadeArrivalDate date,
	@BrigadeEndDate date,
	@BrigadeReturnDate date
AS  
UPDATE RequestDetails
     SET   [IncidentInformation]=@IncidentInformation,[IncidentReason]=@IncidentReason,
		   [BrigadeNumber]=@BrigadeNumber,[BrigadeCallDate]=@BrigadeCallDate,
		   [BrigadeArrivalDate]=@BrigadeArrivalDate, [BrigadeEndDate]=@BrigadeEndDate,
		   [BrigadeReturnDate]=@BrigadeReturnDate
WHERE [RequestNumber]=@RequestNumber
GO
/****** Object:  StoredProcedure [dbo].[UpdateRescuer]    Script Date: 21.06.2018 22:04:37 ******/
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
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 21.06.2018 22:04:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateUser]
@Id int,
@Login varchar(50),
@Password varchar(15),
@Email varchar(50)
AS
BEGIN
UPDATE [User]
SET [Login]=@Login, [Password]=@Password, [email]=@Email
WHERE [User].Id=@Id
DELETE FROM [UserRoles]
WHERE [UserRoles].UserId=@Id
END
GO
USE [master]
GO
ALTER DATABASE [AM.EmergencyService.DB] SET  READ_WRITE 
GO
