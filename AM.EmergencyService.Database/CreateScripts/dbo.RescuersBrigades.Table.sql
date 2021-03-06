USE [AM.EmergencyService.DB]
GO
/****** Object:  Table [dbo].[RescuersBrigades]    Script Date: 21.06.2018 22:03:13 ******/
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
