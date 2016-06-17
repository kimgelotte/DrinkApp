USE [DrinkAppDB]
GO
/****** Object:  Table [dbo].[Drinks]    Script Date: 2016-04-27 21:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Drinks](
	[DrinkID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[DrinkTaste] [nvarchar](max) NULL,
	[DrinkType] [nvarchar](max) NULL,
	[Complexity] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Drinks] PRIMARY KEY CLUSTERED 
(
	[DrinkID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Drinks] ON 

GO
INSERT [dbo].[Drinks] ([DrinkID], [Name], [DrinkTaste], [DrinkType], [Complexity]) VALUES (1, N'Redbull Vodka', N'Sweet', N'Longdrink', 1)
GO
INSERT [dbo].[Drinks] ([DrinkID], [Name], [DrinkTaste], [DrinkType], [Complexity]) VALUES (2, N'Cuba Libre', N'Sweet', N'Longdrink', 1)
GO
INSERT [dbo].[Drinks] ([DrinkID], [Name], [DrinkTaste], [DrinkType], [Complexity]) VALUES (3, N'Fidel Castro', N'Ginger', N'Longdrink', 2)
GO
INSERT [dbo].[Drinks] ([DrinkID], [Name], [DrinkTaste], [DrinkType], [Complexity]) VALUES (4, N'White Russian', N'Chocolate', N'Longdrink Creamy', 2)
GO
INSERT [dbo].[Drinks] ([DrinkID], [Name], [DrinkTaste], [DrinkType], [Complexity]) VALUES (5, N'Tequila Sunrise', N'Fruity', N'Longdrink', 2)
GO
INSERT [dbo].[Drinks] ([DrinkID], [Name], [DrinkTaste], [DrinkType], [Complexity]) VALUES (6, N'Long Island Ice Tea', N'Strong', N'Longdrink', 3)
GO
INSERT [dbo].[Drinks] ([DrinkID], [Name], [DrinkTaste], [DrinkType], [Complexity]) VALUES (7, N'Screwdriver', N'Orange/Sweet', N'Longdrink', 1)
GO
INSERT [dbo].[Drinks] ([DrinkID], [Name], [DrinkTaste], [DrinkType], [Complexity]) VALUES (8, N'Pina Colada', N'Coconut/Sweet', N'Longdrink Creamy', 2)
GO
INSERT [dbo].[Drinks] ([DrinkID], [Name], [DrinkTaste], [DrinkType], [Complexity]) VALUES (9, N'Lynchburg Lemonad', N'Sour', N'Shaked Longdrink', 3)
GO
INSERT [dbo].[Drinks] ([DrinkID], [Name], [DrinkTaste], [DrinkType], [Complexity]) VALUES (10, N'Whiskey Sour', N'Sour', N'Shortdrink', 3)
GO
INSERT [dbo].[Drinks] ([DrinkID], [Name], [DrinkTaste], [DrinkType], [Complexity]) VALUES (13, N'Mojito', N'Sour/Mint/Fresh', N'Longdrink', 4)
GO
INSERT [dbo].[Drinks] ([DrinkID], [Name], [DrinkTaste], [DrinkType], [Complexity]) VALUES (14, N'Kamikazi', N'Sour', N'Shots', 2)
GO
INSERT [dbo].[Drinks] ([DrinkID], [Name], [DrinkTaste], [DrinkType], [Complexity]) VALUES (15, N'Liquid Cocaine', N'Peppermint', N'Shots', 2)
GO
INSERT [dbo].[Drinks] ([DrinkID], [Name], [DrinkTaste], [DrinkType], [Complexity]) VALUES (16, N'Ragnar', N'Fruity', N'Longdrink', 1)
GO
INSERT [dbo].[Drinks] ([DrinkID], [Name], [DrinkTaste], [DrinkType], [Complexity]) VALUES (17, N'P2', N'Sour', N'Longdrink', 2)
GO
INSERT [dbo].[Drinks] ([DrinkID], [Name], [DrinkTaste], [DrinkType], [Complexity]) VALUES (18, N'Vanilla Sky', N'Sweet', N'Longdrink', 2)
GO
INSERT [dbo].[Drinks] ([DrinkID], [Name], [DrinkTaste], [DrinkType], [Complexity]) VALUES (19, N'Cosmopolitan', N'Sweet/Sour', N'Cocktail', 3)
GO
INSERT [dbo].[Drinks] ([DrinkID], [Name], [DrinkTaste], [DrinkType], [Complexity]) VALUES (20, N'Grasshopper', N'Sweet/Mint', N'Cocktail', 3)
GO
INSERT [dbo].[Drinks] ([DrinkID], [Name], [DrinkTaste], [DrinkType], [Complexity]) VALUES (21, N'B52', N'Creamy/Sweet', N'Shots', 4)
GO
INSERT [dbo].[Drinks] ([DrinkID], [Name], [DrinkTaste], [DrinkType], [Complexity]) VALUES (22, N'Jager Bomb', N'Bitter/Sweet', N'Shots', 2)
GO
INSERT [dbo].[Drinks] ([DrinkID], [Name], [DrinkTaste], [DrinkType], [Complexity]) VALUES (23, N'Calypso', N'coffee', N'Shots', 2)
GO
SET IDENTITY_INSERT [dbo].[Drinks] OFF
GO
