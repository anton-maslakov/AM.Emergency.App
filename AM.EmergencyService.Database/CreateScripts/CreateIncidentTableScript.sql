USE [AM.EmergencyService.DB]
GO

/****** Object:  Table [dbo].[Incident]    Script Date: 21.05.2018 11:53:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Incident](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IncidentInformation] [varchar](200) NULL,
	[IncidentReason] [varchar](200) NOT NULL,
	[IdRequest] [int] NOT NULL,
 CONSTRAINT [PK_Incident] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Incident]  WITH CHECK ADD  CONSTRAINT [FK_Incident_Requests] FOREIGN KEY([IdRequest])
REFERENCES [dbo].[Requests] ([Id])
GO

ALTER TABLE [dbo].[Incident] CHECK CONSTRAINT [FK_Incident_Requests]
GO


