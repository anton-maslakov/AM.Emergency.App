USE [AM.EmergencyService.DB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RescuersBrigade](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdBrigades] [int] NOT NULL,
	[IdHumans] [int] NOT NULL,
 CONSTRAINT [PK_RescuersBrigade] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[RescuersBrigade]  WITH CHECK ADD  CONSTRAINT [FK_RescuersBrigade_Brigades] FOREIGN KEY([IdBrigades])
REFERENCES [dbo].[Brigades] ([Id])
GO

ALTER TABLE [dbo].[RescuersBrigade] CHECK CONSTRAINT [FK_RescuersBrigade_Brigades]
GO

ALTER TABLE [dbo].[RescuersBrigade]  WITH CHECK ADD  CONSTRAINT [FK_RescuersBrigade_Humans] FOREIGN KEY([IdHumans])
REFERENCES [dbo].[Humans] ([Id])
GO

ALTER TABLE [dbo].[RescuersBrigade] CHECK CONSTRAINT [FK_RescuersBrigade_Humans]
GO


