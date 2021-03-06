USE [AM.EmergencyService.DB]
GO
/****** Object:  Table [dbo].[InventoryRequestDetails]    Script Date: 21.06.2018 22:03:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InventoryRequestDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RequestNumber] [int] NOT NULL,
	[InventoryNumber] [int] NOT NULL,
 CONSTRAINT [PK_InventoryRequestDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[InventoryRequestDetails]  WITH CHECK ADD  CONSTRAINT [FK_InventoryRequestDetails_Inventory] FOREIGN KEY([InventoryNumber])
REFERENCES [dbo].[Inventory] ([InventoryNumber])
GO
ALTER TABLE [dbo].[InventoryRequestDetails] CHECK CONSTRAINT [FK_InventoryRequestDetails_Inventory]
GO
ALTER TABLE [dbo].[InventoryRequestDetails]  WITH CHECK ADD  CONSTRAINT [FK_InventoryRequestDetails_RequestDetails1] FOREIGN KEY([RequestNumber])
REFERENCES [dbo].[RequestDetails] ([RequestNumber])
GO
ALTER TABLE [dbo].[InventoryRequestDetails] CHECK CONSTRAINT [FK_InventoryRequestDetails_RequestDetails1]
GO
