USE [AM.EmergencyService.DB]
GO
/****** Object:  Table [dbo].[Rescuers]    Script Date: 21.06.2018 22:03:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rescuers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Firstname] [varchar](50) NOT NULL,
	[Surname] [varchar](50) NOT NULL,
	[Lastname] [varchar](50) NOT NULL,
	[BirthDate] [date] NOT NULL,
	[Job] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Rescuers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
