USE [AM.EmergencyService.DB]
GO

/****** Object:  Table [dbo].[IncidentCasualty]    Script Date: 20.05.2018 23:10:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[IncidentCasualty](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdIncident] [int] NOT NULL,
	[IdCasualty] [int] NOT NULL,
 CONSTRAINT [PK_IncidentCasualty] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[IncidentCasualty]  WITH CHECK ADD  CONSTRAINT [FK_IncidentCasualty_Casualty] FOREIGN KEY([IdCasualty])
REFERENCES [dbo].[Casualty] ([Id])
GO

ALTER TABLE [dbo].[IncidentCasualty] CHECK CONSTRAINT [FK_IncidentCasualty_Casualty]
GO

ALTER TABLE [dbo].[IncidentCasualty]  WITH CHECK ADD  CONSTRAINT [FK_IncidentCasualty_Incident] FOREIGN KEY([IdIncident])
REFERENCES [dbo].[Incident] ([Id])
GO

ALTER TABLE [dbo].[IncidentCasualty] CHECK CONSTRAINT [FK_IncidentCasualty_Incident]
GO


