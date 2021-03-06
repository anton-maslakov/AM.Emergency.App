USE [AM.EmergencyService.DB]
GO
/****** Object:  Table [dbo].[RequestDetails]    Script Date: 21.06.2018 22:03:13 ******/
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
