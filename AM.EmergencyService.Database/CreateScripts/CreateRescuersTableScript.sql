USE [AM.EmergencyService.DB]
GO

/****** Object:  Table [dbo].[Rescuers]    Script Date: 20.05.2018 23:08:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Rescuers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Firstname] [varchar](50) NOT NULL,
	[Surname] [varchar](50) NOT NULL,
	[Lastname] [varchar](50) NULL,
	[BirthDate] [date] NULL,
	[Job] [varchar](50) NULL,
 CONSTRAINT [PK_Humans] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


