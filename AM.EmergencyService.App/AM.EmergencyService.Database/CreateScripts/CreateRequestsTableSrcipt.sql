USE [AM.EmergencyService.DB]
GO

/****** Object:  Table [dbo].[Requests]    Script Date: 21.05.2018 0:01:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Requests](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RequestNumber] [int] NOT NULL,
	[RequestAddress] [varchar](100) NOT NULL,
	[RequestReason] [varchar](50) NOT NULL,
	[RequestDate] [datetime] NOT NULL,
	[BrigadeCallDate] [datetime] NOT NULL,
	[BrigadeArrivalDate] [datetime] NOT NULL,
	[BrigadeEndDate] [datetime] NOT NULL,
	[BrigadeReturnDate] [datetime] NOT NULL,
	[RequestCategory] [varchar](50) NOT NULL,
	[IdBrigade] [int] NOT NULL,
 CONSTRAINT [PK_Requests] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Requests]  WITH CHECK ADD  CONSTRAINT [FK_Requests_Brigades] FOREIGN KEY([IdBrigade])
REFERENCES [dbo].[Brigades] ([Id])
GO

ALTER TABLE [dbo].[Requests] CHECK CONSTRAINT [FK_Requests_Brigades]
GO


