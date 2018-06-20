USE [AM.EmergencyService.DB]
GO

/****** Object:  Table [dbo].[Category]    Script Date: 23.05.2018 19:21:57 ******/
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

CREATE TABLE [dbo].[Inventory](
	[InventoryNumber] [int] NOT NULL,
	[InventoryName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Inventory] PRIMARY KEY CLUSTERED 
(
	[InventoryNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Brigades](
	[BrigadeNumber] [int] NOT NULL,
 CONSTRAINT [PK_Brigades] PRIMARY KEY CLUSTERED 
(
	[BrigadeNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[BrigadesInventory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BrigadeNumber] [int] NOT NULL,
	[InventoryNumber] [int] NOT NULL,
 CONSTRAINT [PK_BrigadesInventory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
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

ALTER TABLE [dbo].[RescuersBrigades] ADD  CONSTRAINT [DF_RescuersBrigades_Date]  DEFAULT (getdate()) FOR [Date]
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

CREATE TABLE [dbo].[RequestDetails](
	[RequestNumber] [int] NOT NULL,
	[IncidentInformation] [varchar](200) NULL,
	[IncidentReason] [varchar](200) NULL,
	[BrigadeNumber] [int] NULL,
	[BrigadeCallDate] [date] NULL,
	[BrigadeArrivalDate] [date] NULL,
	[BrigadeEndDate] [date] NULL,
	[BrigadeReturnDate] [date] NULL,
	[IdInventory] [int] NULL,
 CONSTRAINT [PK_Incident] PRIMARY KEY CLUSTERED 
(
	[RequestNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[RequestDetails]  WITH CHECK ADD  CONSTRAINT [FK_RequestDetails_Brigades] FOREIGN KEY([BrigadeNumber])
REFERENCES [dbo].[Brigades] ([BrigadeNumber])
GO

ALTER TABLE [dbo].[RequestDetails] CHECK CONSTRAINT [FK_RequestDetails_Brigades]
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

ALTER TABLE [dbo].[RequestCasualty]  WITH CHECK ADD  CONSTRAINT [FK_IncidentCasualty_Casualty] FOREIGN KEY([IdCasualty])
REFERENCES [dbo].[Casualty] ([Id])
GO

ALTER TABLE [dbo].[RequestCasualty] CHECK CONSTRAINT [FK_IncidentCasualty_Casualty]
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

ALTER TABLE [dbo].[Requests]  WITH CHECK ADD  CONSTRAINT [FK_Requests_Category] FOREIGN KEY([IdCategory])
REFERENCES [dbo].[Category] ([Id])
GO

ALTER TABLE [dbo].[Requests] CHECK CONSTRAINT [FK_Requests_Category]
GO

ALTER TABLE [dbo].[Requests]  WITH CHECK ADD  CONSTRAINT [FK_Requests_RequestCasualty] FOREIGN KEY([RequestNumber])
REFERENCES [dbo].[RequestCasualty] ([Id])
GO

ALTER TABLE [dbo].[Requests] CHECK CONSTRAINT [FK_Requests_RequestCasualty]
GO

ALTER TABLE [dbo].[Requests]  WITH CHECK ADD  CONSTRAINT [FK_Requests_RequestDetails] FOREIGN KEY([RequestNumber])
REFERENCES [dbo].[RequestDetails] ([RequestNumber])
GO

ALTER TABLE [dbo].[Requests] CHECK CONSTRAINT [FK_Requests_RequestDetails]
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

ALTER TABLE [dbo].[InventoryRequestDetails]  WITH CHECK ADD  CONSTRAINT [FK_InventoryRequestDetails_Inventory] FOREIGN KEY([InventoryNumber])
REFERENCES [dbo].[Inventory] ([InventoryNumber])
GO

ALTER TABLE [dbo].[InventoryRequestDetails] CHECK CONSTRAINT [FK_InventoryRequestDetails_Inventory]
GO

ALTER TABLE [dbo].[InventoryRequestDetails]  WITH CHECK ADD  CONSTRAINT [FK_InventoryRequestDetails_RequestDetails] FOREIGN KEY([RequestNumber])
REFERENCES [dbo].[RequestDetails] ([RequestNumber])
GO

ALTER TABLE [dbo].[InventoryRequestDetails] CHECK CONSTRAINT [FK_InventoryRequestDetails_RequestDetails]
GO
