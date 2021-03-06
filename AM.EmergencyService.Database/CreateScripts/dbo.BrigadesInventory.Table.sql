USE [AM.EmergencyService.DB]
GO
/****** Object:  Table [dbo].[BrigadesInventory]    Script Date: 21.06.2018 22:03:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BrigadesInventory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BrigadeNumber] [int] NOT NULL,
	[InventoryNumber] [int] NOT NULL,
	[Date] [date] NOT NULL,
 CONSTRAINT [PK_BrigadesInventory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[Date] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BrigadesInventory] ADD  CONSTRAINT [DF_BrigadesInventory_Date]  DEFAULT (getdate()) FOR [Date]
GO
ALTER TABLE [dbo].[BrigadesInventory]  WITH CHECK ADD  CONSTRAINT [FK_BrigadesInventory_Brigades] FOREIGN KEY([BrigadeNumber])
REFERENCES [dbo].[Brigades] ([BrigadeNumber])
GO
ALTER TABLE [dbo].[BrigadesInventory] CHECK CONSTRAINT [FK_BrigadesInventory_Brigades]
GO
ALTER TABLE [dbo].[BrigadesInventory]  WITH CHECK ADD  CONSTRAINT [FK_BrigadesInventory_Inventory1] FOREIGN KEY([InventoryNumber])
REFERENCES [dbo].[Inventory] ([InventoryNumber])
GO
ALTER TABLE [dbo].[BrigadesInventory] CHECK CONSTRAINT [FK_BrigadesInventory_Inventory1]
GO
