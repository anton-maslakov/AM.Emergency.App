USE [AM.EmergencyService.DB]
GO
/****** Object:  Table [dbo].[Brigades]    Script Date: 21.06.2018 22:03:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brigades](
	[BrigadeNumber] [int] NOT NULL,
 CONSTRAINT [PK_Brigades] PRIMARY KEY CLUSTERED 
(
	[BrigadeNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
