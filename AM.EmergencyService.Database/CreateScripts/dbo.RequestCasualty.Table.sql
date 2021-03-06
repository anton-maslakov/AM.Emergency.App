USE [AM.EmergencyService.DB]
GO
/****** Object:  Table [dbo].[RequestCasualty]    Script Date: 21.06.2018 22:03:13 ******/
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
