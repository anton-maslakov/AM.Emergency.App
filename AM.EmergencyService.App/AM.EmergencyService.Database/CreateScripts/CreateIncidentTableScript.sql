USE [AM.EmergencyService.DB]
GO

/****** Object:  Table [dbo].[Incident]    Script Date: 21.05.2018 0:01:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Incident](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IncidentInformation] [varchar](200) NULL,
	[IncidentReason] [varchar](200) NOT NULL,
	[IdBrigade] [nchar](10) NULL,
	[IdRequest] [int] NOT NULL,
 CONSTRAINT [PK_Incident] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


