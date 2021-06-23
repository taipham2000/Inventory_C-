USE [Inventory]
GO
/****** Object:  Table [dbo].[Inventory]    Script Date: 6/23/2021 8:26:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventory](
	[CarID] [int] NULL,
	[Make] [nvarchar](50) NULL,
	[Color] [nvarchar](50) NULL,
	[PetName] [nvarchar](50) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[Inventory] ([CarID], [Make], [Color], [PetName]) VALUES (3, N'trau', N'tim ', N'man')
INSERT [dbo].[Inventory] ([CarID], [Make], [Color], [PetName]) VALUES (4, N'bo', N'hong', N'han')
INSERT [dbo].[Inventory] ([CarID], [Make], [Color], [PetName]) VALUES (5, N'heo', N'den', N'mam')
INSERT [dbo].[Inventory] ([CarID], [Make], [Color], [PetName]) VALUES (1, N'meo', N'do', N'nam')
GO
