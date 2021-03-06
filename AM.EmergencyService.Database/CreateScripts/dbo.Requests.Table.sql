USE [AM.EmergencyService.DB]
GO
/****** Object:  Table [dbo].[Requests]    Script Date: 21.06.2018 22:03:13 ******/
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
ALTER TABLE [dbo].[Requests] ADD  CONSTRAINT [DF_Requests_RequestDate]  DEFAULT (getdate()) FOR [RequestDate]
GO
ALTER TABLE [dbo].[Requests]  WITH CHECK ADD  CONSTRAINT [FK_Requests_Category] FOREIGN KEY([IdCategory])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Requests] CHECK CONSTRAINT [FK_Requests_Category]
GO
