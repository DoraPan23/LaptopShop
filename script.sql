USE [master]
GO
/****** Object:  Database [LaptopShop]    Script Date: 4/3/2021 1:24:23 PM ******/
CREATE DATABASE [LaptopShop]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LaptopShop', FILENAME = N'D:\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\LaptopShop.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LaptopShop_log', FILENAME = N'D:\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\LaptopShop_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [LaptopShop] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LaptopShop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LaptopShop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LaptopShop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LaptopShop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LaptopShop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LaptopShop] SET ARITHABORT OFF 
GO
ALTER DATABASE [LaptopShop] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [LaptopShop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LaptopShop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LaptopShop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LaptopShop] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LaptopShop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LaptopShop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LaptopShop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LaptopShop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LaptopShop] SET  ENABLE_BROKER 
GO
ALTER DATABASE [LaptopShop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LaptopShop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LaptopShop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LaptopShop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LaptopShop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LaptopShop] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LaptopShop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LaptopShop] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [LaptopShop] SET  MULTI_USER 
GO
ALTER DATABASE [LaptopShop] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LaptopShop] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LaptopShop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LaptopShop] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LaptopShop] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [LaptopShop] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [LaptopShop] SET QUERY_STORE = OFF
GO
USE [LaptopShop]
GO
/****** Object:  Table [dbo].[Brand]    Script Date: 4/3/2021 1:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brand](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Brand_Name] [nvarchar](30) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cart]    Script Date: 4/3/2021 1:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Product_Id] [int] NULL,
	[Quantity] [int] NULL,
	[Combo_Id] [int] NULL,
	[User_Id] [int] NULL,
 CONSTRAINT [PK_Cart] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Catalog]    Script Date: 4/3/2021 1:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Catalog](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Catalog_Name] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Combo]    Script Date: 4/3/2021 1:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Combo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Image] [nvarchar](150) NOT NULL,
	[Combo_Name] [nvarchar](50) NOT NULL,
	[Product_List] [text] NOT NULL,
	[startDate] [date] NOT NULL,
	[endDate] [date] NOT NULL,
	[totalMoney] [float] NOT NULL,
	[discount] [int] NOT NULL,
 CONSTRAINT [PK__Combo__3214EC27DB0F4795] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invoice]    Script Date: 4/3/2021 1:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Customer_ID] [int] NOT NULL,
	[Employee_ID] [int] NULL,
	[totalMoney] [decimal](10, 0) NOT NULL,
	[createdDate] [date] NOT NULL,
	[customerAddress] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InvoiceDetail]    Script Date: 4/3/2021 1:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceDetail](
	[Invoice_ID] [int] NOT NULL,
	[Product_ID] [int] NULL,
	[Combo_ID] [int] NULL,
	[Amount] [int] NOT NULL,
	[Price] [decimal](10, 0) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 4/3/2021 1:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NULL,
	[Total_Price] [float] NULL,
	[User_Id] [int] NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 4/3/2021 1:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Order_Id] [int] NULL,
	[Product_Id] [int] NULL,
	[Combo_Id] [int] NULL,
	[Quantity] [int] NULL,
	[Price] [float] NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 4/3/2021 1:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Product_Name] [nvarchar](80) NOT NULL,
	[Catalog_ID] [int] NOT NULL,
	[Amount] [int] NOT NULL,
	[Price] [decimal](10, 0) NOT NULL,
	[Image] [text] NULL,
	[Discount] [float] NULL,
	[Detail] [nvarchar](600) NULL,
	[Brand_ID] [int] NULL,
 CONSTRAINT [PK__Product__3214EC271154E5A8] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductDetail]    Script Date: 4/3/2021 1:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductDetail](
	[Product_ID] [int] IDENTITY(1,1) NOT NULL,
	[Product_Detail] [nvarchar](650) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Product_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 4/3/2021 1:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Role_Name] [nvarchar](25) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 4/3/2021 1:24:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[firstName] [nvarchar](50) NULL,
	[lastName] [nvarchar](20) NULL,
	[gender] [bit] NOT NULL,
	[birthDate] [date] NULL,
	[address] [text] NULL,
	[joinDate] [date] NULL,
	[isDisable] [bit] NOT NULL,
	[Role_ID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Brand] ON 

INSERT [dbo].[Brand] ([ID], [Brand_Name]) VALUES (1, N'Dell')
INSERT [dbo].[Brand] ([ID], [Brand_Name]) VALUES (2, N'Asus')
SET IDENTITY_INSERT [dbo].[Brand] OFF
GO
SET IDENTITY_INSERT [dbo].[Cart] ON 

INSERT [dbo].[Cart] ([ID], [Product_Id], [Quantity], [Combo_Id], [User_Id]) VALUES (1098, NULL, 10, 2, 7)
SET IDENTITY_INSERT [dbo].[Cart] OFF
GO
SET IDENTITY_INSERT [dbo].[Catalog] ON 

INSERT [dbo].[Catalog] ([ID], [Catalog_Name]) VALUES (1, N'PC')
INSERT [dbo].[Catalog] ([ID], [Catalog_Name]) VALUES (2, N'Bàn Phím')
INSERT [dbo].[Catalog] ([ID], [Catalog_Name]) VALUES (3, N'Chuột')
INSERT [dbo].[Catalog] ([ID], [Catalog_Name]) VALUES (4, N'Tai nghe')
INSERT [dbo].[Catalog] ([ID], [Catalog_Name]) VALUES (5, N'Loa')
INSERT [dbo].[Catalog] ([ID], [Catalog_Name]) VALUES (6, N'Laptop')
SET IDENTITY_INSERT [dbo].[Catalog] OFF
GO
SET IDENTITY_INSERT [dbo].[Combo] ON 

INSERT [dbo].[Combo] ([ID], [Image], [Combo_Name], [Product_List], [startDate], [endDate], [totalMoney], [discount]) VALUES (1, N'/images/Laptop/Dell/vostro5590_00.jpg', N'Combo Giảm giá Giáng Sinh', N'4;5;7;9', CAST(N'2015-11-20' AS Date), CAST(N'2015-11-20' AS Date), 19521000, 15)
INSERT [dbo].[Combo] ([ID], [Image], [Combo_Name], [Product_List], [startDate], [endDate], [totalMoney], [discount]) VALUES (2, N'images/Combo/2020-12-20.png', N'fgdf', N'4;5', CAST(N'2020-12-21' AS Date), CAST(N'2020-12-21' AS Date), 21070000, 10)
SET IDENTITY_INSERT [dbo].[Combo] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([ID], [Date], [Total_Price], [User_Id], [Status]) VALUES (1002, CAST(N'2020-12-15' AS Date), 102671552, 7, 4)
INSERT [dbo].[Order] ([ID], [Date], [Total_Price], [User_Id], [Status]) VALUES (1003, CAST(N'2020-12-15' AS Date), 51280000, 7, 4)
INSERT [dbo].[Order] ([ID], [Date], [Total_Price], [User_Id], [Status]) VALUES (1004, CAST(N'2020-12-16' AS Date), 16592850, 7, 4)
INSERT [dbo].[Order] ([ID], [Date], [Total_Price], [User_Id], [Status]) VALUES (1005, CAST(N'2020-12-17' AS Date), 52893000, 7, 4)
INSERT [dbo].[Order] ([ID], [Date], [Total_Price], [User_Id], [Status]) VALUES (1006, CAST(N'2020-12-18' AS Date), 25632000, 7, 4)
INSERT [dbo].[Order] ([ID], [Date], [Total_Price], [User_Id], [Status]) VALUES (1007, CAST(N'2020-12-19' AS Date), 46921000, 16, 1)
INSERT [dbo].[Order] ([ID], [Date], [Total_Price], [User_Id], [Status]) VALUES (1008, CAST(N'2020-12-19' AS Date), 21990000, 7, 1)
INSERT [dbo].[Order] ([ID], [Date], [Total_Price], [User_Id], [Status]) VALUES (1009, CAST(N'2020-12-19' AS Date), 21990000, 7, 1)
INSERT [dbo].[Order] ([ID], [Date], [Total_Price], [User_Id], [Status]) VALUES (1010, CAST(N'2020-12-19' AS Date), 16592850, 7, 4)
INSERT [dbo].[Order] ([ID], [Date], [Total_Price], [User_Id], [Status]) VALUES (1011, CAST(N'2020-12-19' AS Date), 33185700, 7, 1)
INSERT [dbo].[Order] ([ID], [Date], [Total_Price], [User_Id], [Status]) VALUES (1012, CAST(N'2020-12-19' AS Date), 33185700, 16, 4)
INSERT [dbo].[Order] ([ID], [Date], [Total_Price], [User_Id], [Status]) VALUES (1013, CAST(N'2020-12-20' AS Date), 49778552, 7, 4)
INSERT [dbo].[Order] ([ID], [Date], [Total_Price], [User_Id], [Status]) VALUES (1014, CAST(N'2020-12-20' AS Date), 49778552, 18, 4)
INSERT [dbo].[Order] ([ID], [Date], [Total_Price], [User_Id], [Status]) VALUES (1015, CAST(N'2020-12-20' AS Date), 49778552, 18, 4)
INSERT [dbo].[Order] ([ID], [Date], [Total_Price], [User_Id], [Status]) VALUES (1016, CAST(N'2020-12-20' AS Date), 49778552, 18, 4)
INSERT [dbo].[Order] ([ID], [Date], [Total_Price], [User_Id], [Status]) VALUES (1017, CAST(N'2020-12-20' AS Date), 49778552, 18, 4)
INSERT [dbo].[Order] ([ID], [Date], [Total_Price], [User_Id], [Status]) VALUES (1018, CAST(N'2020-12-21' AS Date), 21990000, 18, 1)
INSERT [dbo].[Order] ([ID], [Date], [Total_Price], [User_Id], [Status]) VALUES (1019, CAST(N'2020-12-21' AS Date), 385828480, 18, 4)
INSERT [dbo].[Order] ([ID], [Date], [Total_Price], [User_Id], [Status]) VALUES (1020, CAST(N'2020-12-21' AS Date), 17631000, 18, 1)
INSERT [dbo].[Order] ([ID], [Date], [Total_Price], [User_Id], [Status]) VALUES (1021, CAST(N'2020-12-21' AS Date), 35262000, 18, 3)
INSERT [dbo].[Order] ([ID], [Date], [Total_Price], [User_Id], [Status]) VALUES (1022, CAST(N'2020-12-21' AS Date), 49778552, 18, 2)
INSERT [dbo].[Order] ([ID], [Date], [Total_Price], [User_Id], [Status]) VALUES (1023, CAST(N'2021-03-02' AS Date), 75980000, 7, 4)
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderDetail] ON 

INSERT [dbo].[OrderDetail] ([ID], [Order_Id], [Product_Id], [Combo_Id], [Quantity], [Price]) VALUES (1002, 1002, NULL, 1, 3, 16592850)
INSERT [dbo].[OrderDetail] ([ID], [Order_Id], [Product_Id], [Combo_Id], [Quantity], [Price]) VALUES (1003, 1002, 1, NULL, 3, 17631000)
INSERT [dbo].[OrderDetail] ([ID], [Order_Id], [Product_Id], [Combo_Id], [Quantity], [Price]) VALUES (1004, 1003, 2, NULL, 1, 29290000)
INSERT [dbo].[OrderDetail] ([ID], [Order_Id], [Product_Id], [Combo_Id], [Quantity], [Price]) VALUES (1005, 1003, 12, NULL, 1, 21990000)
INSERT [dbo].[OrderDetail] ([ID], [Order_Id], [Product_Id], [Combo_Id], [Quantity], [Price]) VALUES (1006, 1004, NULL, 1, 1, 16592850)
INSERT [dbo].[OrderDetail] ([ID], [Order_Id], [Product_Id], [Combo_Id], [Quantity], [Price]) VALUES (1007, 1005, 1, NULL, 3, 17631000)
INSERT [dbo].[OrderDetail] ([ID], [Order_Id], [Product_Id], [Combo_Id], [Quantity], [Price]) VALUES (1008, 1006, 12, NULL, 1, 21990000)
INSERT [dbo].[OrderDetail] ([ID], [Order_Id], [Product_Id], [Combo_Id], [Quantity], [Price]) VALUES (1009, 1006, 10, NULL, 1, 2952000)
INSERT [dbo].[OrderDetail] ([ID], [Order_Id], [Product_Id], [Combo_Id], [Quantity], [Price]) VALUES (1010, 1006, 4, NULL, 1, 690000)
INSERT [dbo].[OrderDetail] ([ID], [Order_Id], [Product_Id], [Combo_Id], [Quantity], [Price]) VALUES (1011, 1007, 1, NULL, 1, 17631000)
INSERT [dbo].[OrderDetail] ([ID], [Order_Id], [Product_Id], [Combo_Id], [Quantity], [Price]) VALUES (1012, 1007, 2, NULL, 1, 29290000)
INSERT [dbo].[OrderDetail] ([ID], [Order_Id], [Product_Id], [Combo_Id], [Quantity], [Price]) VALUES (1013, 1008, 12, NULL, 1, 21990000)
INSERT [dbo].[OrderDetail] ([ID], [Order_Id], [Product_Id], [Combo_Id], [Quantity], [Price]) VALUES (1014, 1009, 12, NULL, 1, 21990000)
INSERT [dbo].[OrderDetail] ([ID], [Order_Id], [Product_Id], [Combo_Id], [Quantity], [Price]) VALUES (1015, 1010, NULL, 1, 1, 16592850)
INSERT [dbo].[OrderDetail] ([ID], [Order_Id], [Product_Id], [Combo_Id], [Quantity], [Price]) VALUES (1016, 1011, NULL, 1, 2, 16592850)
INSERT [dbo].[OrderDetail] ([ID], [Order_Id], [Product_Id], [Combo_Id], [Quantity], [Price]) VALUES (1017, 1012, NULL, 1, 2, 16592850)
INSERT [dbo].[OrderDetail] ([ID], [Order_Id], [Product_Id], [Combo_Id], [Quantity], [Price]) VALUES (1018, 1013, NULL, 1, 3, 16592850)
INSERT [dbo].[OrderDetail] ([ID], [Order_Id], [Product_Id], [Combo_Id], [Quantity], [Price]) VALUES (1019, 1014, NULL, 1, 3, 16592850)
INSERT [dbo].[OrderDetail] ([ID], [Order_Id], [Product_Id], [Combo_Id], [Quantity], [Price]) VALUES (1020, 1015, NULL, 1, 3, 16592850)
INSERT [dbo].[OrderDetail] ([ID], [Order_Id], [Product_Id], [Combo_Id], [Quantity], [Price]) VALUES (1021, 1016, NULL, 1, 3, 16592850)
INSERT [dbo].[OrderDetail] ([ID], [Order_Id], [Product_Id], [Combo_Id], [Quantity], [Price]) VALUES (1022, 1017, NULL, 1, 3, 16592850)
INSERT [dbo].[OrderDetail] ([ID], [Order_Id], [Product_Id], [Combo_Id], [Quantity], [Price]) VALUES (1023, 1018, 12, NULL, 1, 21990000)
INSERT [dbo].[OrderDetail] ([ID], [Order_Id], [Product_Id], [Combo_Id], [Quantity], [Price]) VALUES (1024, 1019, NULL, 1, 10, 16592850)
INSERT [dbo].[OrderDetail] ([ID], [Order_Id], [Product_Id], [Combo_Id], [Quantity], [Price]) VALUES (1025, 1019, 12, NULL, 10, 21990000)
INSERT [dbo].[OrderDetail] ([ID], [Order_Id], [Product_Id], [Combo_Id], [Quantity], [Price]) VALUES (1026, 1020, 1, NULL, 1, 17631000)
INSERT [dbo].[OrderDetail] ([ID], [Order_Id], [Product_Id], [Combo_Id], [Quantity], [Price]) VALUES (1027, 1021, 1, NULL, 2, 17631000)
INSERT [dbo].[OrderDetail] ([ID], [Order_Id], [Product_Id], [Combo_Id], [Quantity], [Price]) VALUES (1028, 1022, NULL, 1, 3, 16592850)
INSERT [dbo].[OrderDetail] ([ID], [Order_Id], [Product_Id], [Combo_Id], [Quantity], [Price]) VALUES (1029, 1023, 13, NULL, 2, 37990000)
SET IDENTITY_INSERT [dbo].[OrderDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ID], [Product_Name], [Catalog_ID], [Amount], [Price], [Image], [Discount], [Detail], [Brand_ID]) VALUES (4, N'Bàn phím E-Dra EK311', 2, 20, CAST(690000 AS Decimal(10, 0)), N'/images/Keyboard/GM368.png', 0, N'CPU: Intel Core i3 Ice Lake, 1005G1, 1.20 GHz;RAM: 8 GB, DDR4 (On board 4GB +1 khe 4GB), 2400 MHz;Ổ cứng: SSD 512 GB M.2 PCIe, Hỗ trợ khe cắm HDD SATA;Màn hình: 15.6 inch, Full HD (1920 x 1080);Card màn hình: Card đồ họa tích hợp, Intel UHD Graphics;Cổng kết nối: 2 x USB 2.0, USB 3.1, HDMI, LAN (RJ45);Hệ điều hành: Windows 10 Home SL;Thiết kế: Vỏ nhựa, PIN liền;Kích thước: Dày 19.9 mm, 1.7 kg', 0)
INSERT [dbo].[Product] ([ID], [Product_Name], [Catalog_ID], [Amount], [Price], [Image], [Discount], [Detail], [Brand_ID]) VALUES (5, N'Chuột Gaming Zadez G151M Ðen', 3, 17, CAST(300000 AS Decimal(10, 0)), N'/images/Mouse/G151M.png', 0, N'CPU: Intel Core i3 Ice Lake, 1005G1, 1.20 GHz;RAM: 8 GB, DDR4 (On board 4GB +1 khe 4GB), 2400 MHz;Ổ cứng: SSD 512 GB M.2 PCIe, Hỗ trợ khe cắm HDD SATA;Màn hình: 15.6 inch, Full HD (1920 x 1080);Card màn hình: Card đồ họa tích hợp, Intel UHD Graphics;Cổng kết nối: 2 x USB 2.0, USB 3.1, HDMI, LAN (RJ45);Hệ điều hành: Windows 10 Home SL;Thiết kế: Vỏ nhựa, PIN liền;Kích thước: Dày 19.9 mm, 1.7 kg', 0)
INSERT [dbo].[Product] ([ID], [Product_Name], [Catalog_ID], [Amount], [Price], [Image], [Discount], [Detail], [Brand_ID]) VALUES (6, N'Chuộtt không dây Zadez M353 Xám', 3, 10, CAST(300000 AS Decimal(10, 0)), N'/images/Mouse/M353.png', 0, N'CPU: Intel Core i3 Ice Lake, 1005G1, 1.20 GHz;RAM: 8 GB, DDR4 (On board 4GB +1 khe 4GB), 2400 MHz;Ổ cứng: SSD 512 GB M.2 PCIe, Hỗ trợ khe cắm HDD SATA;Màn hình: 15.6 inch, Full HD (1920 x 1080);Card màn hình: Card đồ họa tích hợp, Intel UHD Graphics;Cổng kết nối: 2 x USB 2.0, USB 3.1, HDMI, LAN (RJ45);Hệ điều hành: Windows 10 Home SL;Thiết kế: Vỏ nhựa, PIN liền;Kích thước: Dày 19.9 mm, 1.7 kg', 0)
INSERT [dbo].[Product] ([ID], [Product_Name], [Catalog_ID], [Amount], [Price], [Image], [Discount], [Detail], [Brand_ID]) VALUES (7, N'Tai nghe Bluetooth True Wireless Mozard Air 3 Ðen', 4, 17, CAST(800000 AS Decimal(10, 0)), N'/images/Headphone/EH469RGB.png', 0, N'CPU: Intel Core i3 Ice Lake, 1005G1, 1.20 GHz;RAM: 8 GB, DDR4 (On board 4GB +1 khe 4GB), 2400 MHz;Ổ cứng: SSD 512 GB M.2 PCIe, Hỗ trợ khe cắm HDD SATA;Màn hình: 15.6 inch, Full HD (1920 x 1080);Card màn hình: Card đồ họa tích hợp, Intel UHD Graphics;Cổng kết nối: 2 x USB 2.0, USB 3.1, HDMI, LAN (RJ45);Hệ điều hành: Windows 10 Home SL;Thiết kế: Vỏ nhựa, PIN liền;Kích thước: Dày 19.9 mm, 1.7 kg', 0)
INSERT [dbo].[Product] ([ID], [Product_Name], [Catalog_ID], [Amount], [Price], [Image], [Discount], [Detail], [Brand_ID]) VALUES (8, N'Tai nghe Bluetooth True Wireless Jabra Elite Activ', 4, 20, CAST(3790000 AS Decimal(10, 0)), N'/images/Headphone/EH925SRGB.png', 0, N'CPU: Intel Core i3 Ice Lake, 1005G1, 1.20 GHz;RAM: 8 GB, DDR4 (On board 4GB +1 khe 4GB), 2400 MHz;Ổ cứng: SSD 512 GB M.2 PCIe, Hỗ trợ khe cắm HDD SATA;Màn hình: 15.6 inch, Full HD (1920 x 1080);Card màn hình: Card đồ họa tích hợp, Intel UHD Graphics;Cổng kết nối: 2 x USB 2.0, USB 3.1, HDMI, LAN (RJ45);Hệ điều hành: Windows 10 Home SL;Thiết kế: Vỏ nhựa, PIN liền;Kích thước: Dày 19.9 mm, 1.7 kg', 0)
INSERT [dbo].[Product] ([ID], [Product_Name], [Catalog_ID], [Amount], [Price], [Image], [Discount], [Detail], [Brand_ID]) VALUES (9, N'Loa Bluetooth LG Xboom Go PL7 Xanh Ðen', 5, 20, CAST(3390000 AS Decimal(10, 0)), N'/images/Headphone/EH469RGB.png', 0, N'CPU: Intel Core i3 Ice Lake, 1005G1, 1.20 GHz;RAM: 8 GB, DDR4 (On board 4GB +1 khe 4GB), 2400 MHz;Ổ cứng: SSD 512 GB M.2 PCIe, Hỗ trợ khe cắm HDD SATA;Màn hình: 15.6 inch, Full HD (1920 x 1080);Card màn hình: Card đồ họa tích hợp, Intel UHD Graphics;Cổng kết nối: 2 x USB 2.0, USB 3.1, HDMI, LAN (RJ45);Hệ điều hành: Windows 10 Home SL;Thiết kế: Vỏ nhựa, PIN liền;Kích thước: Dày 19.9 mm, 1.7 kg', 0)
INSERT [dbo].[Product] ([ID], [Product_Name], [Catalog_ID], [Amount], [Price], [Image], [Discount], [Detail], [Brand_ID]) VALUES (10, N'Loa Bluetooth JBL PULSE2BLKAS Ðen', 5, 20, CAST(2952000 AS Decimal(10, 0)), N'/images/Laptop/Dell/dell-gaming-g7-7590-GamingG77590.jpg', 0, N'CPU: Intel Core i3 Ice Lake, 1005G1, 1.20 GHz;RAM: 8 GB, DDR4 (On board 4GB +1 khe 4GB), 2400 MHz;Ổ cứng: SSD 512 GB M.2 PCIe, Hỗ trợ khe cắm HDD SATA;Màn hình: 15.6 inch, Full HD (1920 x 1080);Card màn hình: Card đồ họa tích hợp, Intel UHD Graphics;Cổng kết nối: 2 x USB 2.0, USB 3.1, HDMI, LAN (RJ45);Hệ điều hành: Windows 10 Home SL;Thiết kế: Vỏ nhựa, PIN liền;Kích thước: Dày 19.9 mm, 1.7 kg', 0)
INSERT [dbo].[Product] ([ID], [Product_Name], [Catalog_ID], [Amount], [Price], [Image], [Discount], [Detail], [Brand_ID]) VALUES (11, N'GVN Titan 10 M', 1, 10, CAST(8990000 AS Decimal(10, 0)), N'/images/Laptop/Dell/dell-gaming-g7-7590-GamingG77590.jpg', 0, N'CPU: Intel Core i3 Ice Lake, 1005G1, 1.20 GHz;RAM: 8 GB, DDR4 (On board 4GB +1 khe 4GB), 2400 MHz;Ổ cứng: SSD 512 GB M.2 PCIe, Hỗ trợ khe cắm HDD SATA;Màn hình: 15.6 inch, Full HD (1920 x 1080);Card màn hình: Card đồ họa tích hợp, Intel UHD Graphics;Cổng kết nối: 2 x USB 2.0, USB 3.1, HDMI, LAN (RJ45);Hệ điều hành: Windows 10 Home SL;Thiết kế: Vỏ nhựa, PIN liền;Kích thước: Dày 19.9 mm, 1.7 kg', 0)
INSERT [dbo].[Product] ([ID], [Product_Name], [Catalog_ID], [Amount], [Price], [Image], [Discount], [Detail], [Brand_ID]) VALUES (12, N'Asus ROG Strix G15', 6, 20, CAST(21990000 AS Decimal(10, 0)), N'/images/Laptop/Asus/asus-rog-strix-g15-g512l-uhn145t.png', 0, N'CPU: Intel Core i3 Ice Lake, 1005G1, 1.20 GHz;RAM: 8 GB, DDR4 (On board 4GB +1 khe 4GB), 2400 MHz;Ổ cứng: SSD 512 GB M.2 PCIe, Hỗ trợ khe cắm HDD SATA;Màn hình: 15.6 inch, Full HD (1920 x 1080);Card màn hình: Card đồ họa tích hợp, Intel UHD Graphics;Cổng kết nối: 2 x USB 2.0, USB 3.1, HDMI, LAN (RJ45);Hệ điều hành: Windows 10 Home SL;Thiết kế: Vỏ nhựa, PIN liền;Kích thước: Dày 19.9 mm, 1.7 kg', 2)
INSERT [dbo].[Product] ([ID], [Product_Name], [Catalog_ID], [Amount], [Price], [Image], [Discount], [Detail], [Brand_ID]) VALUES (13, N'Dell XPS 15 9500', 6, 1, CAST(37990000 AS Decimal(10, 0)), N'/images/Laptop/Dell/dell-xps-15-9500-XPS159500.jpg', 0, N'CPU: Intel Core i3 Ice Lake, 1005G1, 1.20 GHz;RAM: 8 GB, DDR4 (On board 4GB +1 khe 4GB), 2400 MHz;Ổ cứng: SSD 512 GB M.2 PCIe, Hỗ trợ khe cắm HDD SATA;Màn hình: 15.6 inch, Full HD (1920 x 1080);Card màn hình: Card đồ họa tích hợp, Intel UHD Graphics;Cổng kết nối: 2 x USB 2.0, USB 3.1, HDMI, LAN (RJ45);Hệ điều hành: Windows 10 Home SL;Thiết kế: Vỏ nhựa, PIN liền;Kích thước: Dày 19.9 mm, 1.7 kg', 1)
INSERT [dbo].[Product] ([ID], [Product_Name], [Catalog_ID], [Amount], [Price], [Image], [Discount], [Detail], [Brand_ID]) VALUES (14, N'Dell Inspiron 14 5402', 6, 10, CAST(19490000 AS Decimal(10, 0)), N'/images/Laptop/Dell/5402_00.jpg', 0, N'CPU: Intel Core i3 Ice Lake, 1005G1, 1.20 GHz;RAM: 8 GB, DDR4 (On board 4GB +1 khe 4GB), 2400 MHz;Ổ cứng: SSD 512 GB M.2 PCIe, Hỗ trợ khe cắm HDD SATA;Màn hình: 15.6 inch, Full HD (1920 x 1080);Card màn hình: Card đồ họa tích hợp, Intel UHD Graphics;Cổng kết nối: 2 x USB 2.0, USB 3.1, HDMI, LAN (RJ45);Hệ điều hành: Windows 10 Home SL;Thiết kế: Vỏ nhựa, PIN liền;Kích thước: Dày 19.9 mm, 1.7 kg', 1)
INSERT [dbo].[Product] ([ID], [Product_Name], [Catalog_ID], [Amount], [Price], [Image], [Discount], [Detail], [Brand_ID]) VALUES (15, N'Dell XPS 13 9310', 6, 10, CAST(33990000 AS Decimal(10, 0)), N'/images/Laptop/Dell/xps93102-1s_00.jpg', 0, N'CPU: Intel Core i3 Ice Lake, 1005G1, 1.20 GHz;RAM: 8 GB, DDR4 (On board 4GB +1 khe 4GB), 2400 MHz;Ổ cứng: SSD 512 GB M.2 PCIe, Hỗ trợ khe cắm HDD SATA;Màn hình: 15.6 inch, Full HD (1920 x 1080);Card màn hình: Card đồ họa tích hợp, Intel UHD Graphics;Cổng kết nối: 2 x USB 2.0, USB 3.1, HDMI, LAN (RJ45);Hệ điều hành: Windows 10 Home SL;Thiết kế: Vỏ nhựa, PIN liền;Kích thước: Dày 19.9 mm, 1.7 kg', 1)
INSERT [dbo].[Product] ([ID], [Product_Name], [Catalog_ID], [Amount], [Price], [Image], [Discount], [Detail], [Brand_ID]) VALUES (16, N'Dell XPS 13 7390', 6, 10, CAST(23990000 AS Decimal(10, 0)), N'/images/Laptop/Dell/dell-xps-13-7390-XPS7390.jpg', 0, N'CPU: Intel Core i3 Ice Lake, 1005G1, 1.20 GHz;RAM: 8 GB, DDR4 (On board 4GB +1 khe 4GB), 2400 MHz;Ổ cứng: SSD 512 GB M.2 PCIe, Hỗ trợ khe cắm HDD SATA;Màn hình: 15.6 inch, Full HD (1920 x 1080);Card màn hình: Card đồ họa tích hợp, Intel UHD Graphics;Cổng kết nối: 2 x USB 2.0, USB 3.1, HDMI, LAN (RJ45);Hệ điều hành: Windows 10 Home SL;Thiết kế: Vỏ nhựa, PIN liền;Kích thước: Dày 19.9 mm, 1.7 kg', 1)
INSERT [dbo].[Product] ([ID], [Product_Name], [Catalog_ID], [Amount], [Price], [Image], [Discount], [Detail], [Brand_ID]) VALUES (17, N'Dell Inspiron 13 7306', 6, 10, CAST(34990000 AS Decimal(10, 0)), N'/images/Laptop/Dell/Inspiron7306_00.jpg', 0, N'CPU: Intel Core i3 Ice Lake, 1005G1, 1.20 GHz;RAM: 8 GB, DDR4 (On board 4GB +1 khe 4GB), 2400 MHz;Ổ cứng: SSD 512 GB M.2 PCIe, Hỗ trợ khe cắm HDD SATA;Màn hình: 15.6 inch, Full HD (1920 x 1080);Card màn hình: Card đồ họa tích hợp, Intel UHD Graphics;Cổng kết nối: 2 x USB 2.0, USB 3.1, HDMI, LAN (RJ45);Hệ điều hành: Windows 10 Home SL;Thiết kế: Vỏ nhựa, PIN liền;Kích thước: Dày 19.9 mm, 1.7 kg', 1)
INSERT [dbo].[Product] ([ID], [Product_Name], [Catalog_ID], [Amount], [Price], [Image], [Discount], [Detail], [Brand_ID]) VALUES (18, N'Dell XPS 13 9310 2-in-1', 6, 10, CAST(38990000 AS Decimal(10, 0)), N'/images/Laptop/Dell/xps93102-1s_00.jpg', 0, N'CPU: Intel Core i3 Ice Lake, 1005G1, 1.20 GHz;RAM: 8 GB, DDR4 (On board 4GB +1 khe 4GB), 2400 MHz;Ổ cứng: SSD 512 GB M.2 PCIe, Hỗ trợ khe cắm HDD SATA;Màn hình: 15.6 inch, Full HD (1920 x 1080);Card màn hình: Card đồ họa tích hợp, Intel UHD Graphics;Cổng kết nối: 2 x USB 2.0, USB 3.1, HDMI, LAN (RJ45);Hệ điều hành: Windows 10 Home SL;Thiết kế: Vỏ nhựa, PIN liền;Kích thước: Dày 19.9 mm, 1.7 kg', 1)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductDetail] ON 

INSERT [dbo].[ProductDetail] ([Product_ID], [Product_Detail]) VALUES (1, N'CPU: Intel Core i3 Ice Lake, 1005G1, 1.20 GHz;RAM: 8 GB, DDR4 (On board 4GB +1 khe 4GB), 2400 MHz;Ổ cứng: SSD 512 GB M.2 PCIe, Hỗ trợ khe cắm HDD SATA;Màn hình: 15.6 inch, Full HD (1920 x 1080);Card màn hình: Card đồ họa tích hợp, Intel UHD Graphics;Cổng kết nối: 2 x USB 2.0, USB 3.1, HDMI, LAN (RJ45);Hệ điều hành: Windows 10 Home SL;Thiết kế: Vỏ nhựa, PIN liền;Kích thước: Dày 19.9 mm, 1.7 kg')
INSERT [dbo].[ProductDetail] ([Product_ID], [Product_Detail]) VALUES (2, N'CPU: Intel Core i7 Comet Lake, 10750H, 2.60 GHz;RAM: 8 GB, DDR4 (2 khe), 3200 MHz;Ổ cứng: Hỗ trợ thêm 2 khe cắm SSD M.2 PCIe, SSD 512 GB M.2 PCIe;Màn hình: 15.6 inch, Full HD (1920 x 1080), 144Hz;Card màn hình: Card đồ họa rời, NVIDIA GeForce GTX 1660Ti 6GB;Cổng kết nối: 3 x USB 3.2, HDMI, LAN (RJ45), USB Type-C;Hệ điều hành: Windows 10 Home SL;Thiết kế: Vỏ nhựa, PIN liền;Kích thước: Dày 25.8 mm, 2.3 Kg')
INSERT [dbo].[ProductDetail] ([Product_ID], [Product_Detail]) VALUES (3, N'Model: GM368;Màu sắc: đen;Kiểu kết nối: bàn phím có dây, 160cm;Kết nối: USB 2.0;Phím chức năng: Standard;Kích thước: Full size, 485x230x40mm;Kiểu bàn phím: bàn phím cơ;Trọng lượng: 1083g')
INSERT [dbo].[ProductDetail] ([Product_ID], [Product_Detail]) VALUES (4, N'Model: EK311;Loại bàn phím: Bàn phím cơ fullsize;Led: LED Rainbow siêu sáng;Switch: Outmenu;Kết nối: USB;Kích thước: Full size, 485x230x40mm;Chất liệu: kim loại')
INSERT [dbo].[ProductDetail] ([Product_ID], [Product_Detail]) VALUES (5, N'Tương thích: Windows;Độ phân giải: 1200 - 3200 DPI;Cách kết nối: Dây cắm USB;Độ dài dây / Khoảng cách kết nối: Dây dài 158 cm;Trọng lượng: 69g;Thương hiệu của: Trung Quốc')
INSERT [dbo].[ProductDetail] ([Product_ID], [Product_Detail]) VALUES (6, N'Tương thích: Windows;Độ phân giải: 1200 - 3200 DPI;Cách kết nối: Dây cắm USB;Độ dài dây / Khoảng cách kết nối: Dây dài 158 cm;Trọng lượng: 69g;Thương hiệu của: Trung Quốc')
INSERT [dbo].[ProductDetail] ([Product_ID], [Product_Detail]) VALUES (7, N'Tương thích: Android, Windows, iOS (iPhone);Cổng sạc: Type-C;Thời gian sử dụng: 4 giờ;Thời gian sạc đầy: 2 giờ;Kết nối cùng lúc: 1 thiết bị;Hỗ trợ kết nối: 10m (Bluetooth 5.0);Phím điều khiển: Nghe/nhận cuộc gọi, Phát/dừng chơi nhạc, Chuyển bài hát, Tăng/giảm âm lượng;Thương hiệu: Thế Giới Di Động;Sản xuất tại: Trung Quốc')
INSERT [dbo].[ProductDetail] ([Product_ID], [Product_Detail]) VALUES (8, N'Tương thích: Android, Windows, iOS (iPhone);Cổng sạc: Micro USB;Thời gian sử dụng: 5 giờ;Thời gian sạc đầy: 2 giờ;Kết nối cùng lúc: 2 thiết bị;Hỗ trợ kết nối: 10m (Bluetooth 5.0);Thương hiệu: Đan Mạch;Sản xuất tại: Trung Quốc')
INSERT [dbo].[ProductDetail] ([Product_ID], [Product_Detail]) VALUES (9, N'Loại loa: Loa bluetooth;Tương thích: Android, Windows, iOS (iPhone);Tổng công suất: 30W;Thời gian sử dụng: dùng khoảng 24 giờ;Thời gian sạc đầy: 5 giờ;Công nghệ âm thanh: Meridian, Sound boost;Kết nối không dây: Bluetooth;Kết nối khác: AUX in;Tiện ích: Kết nối không dây nhiều loa cùng lúc, Chống nước IPX5, Google Assistant;Phím điều khiển: Bật/tắt bluetooth, Nút nguồn, Tăng/giảm âm lượng, Phát/dừng chơi nhạc;Điều khiển bằng điện thoại: LG XBoom;Kích thước: Dài 25 cm - Đường kính 10 cm - Nặng 1.46 kg;Thương hiệu của: Hàn Quốc')
INSERT [dbo].[ProductDetail] ([Product_ID], [Product_Detail]) VALUES (10, N'Loại loa: Loa bluetooth;Tương thích: Android, Windows, iOS (iPhone);Tổng công suất: 16W;Thời gian sử dụng: dùng khoảng 10 giờ;Công nghệ âm thanh: JBL Connect;Kết nối không dây: Bluetooth 4.1;Kết nối khác: Jack 3.5 mm;Tiện ích: Có micro đàm thoại, Bật trợ lý ảo trên điện thoại, Chống nước IPX7;Phím điều khiển: Bật/tắt bluetooth, Nút nguồn, Tăng/giảm âm lượng, Phát/dừng chơi nhạc;Điều khiển bằng điện thoại: LG XBoom;Kích thước: Dài 19.5 cm - Đường kính 8 cm - Nặng 775 g;Thương hiệu của: Mỹ;')
INSERT [dbo].[ProductDetail] ([Product_ID], [Product_Detail]) VALUES (11, N'Mainboard: MSI H410M-A PRO;CPU: Intel Pentium G6400 / 4MB / 4.0GHz / 2 Nhân 4 Luồng / LGA 1200RAM: G.SKILL Ripjaws V 1x8GB 2800VGA: MSI GTX 1650 VENTUS XS 4GB OC V1 GDDR6SSD: PNY SSD CS900 120G 2.5" Sata 3PSU: Deepcool DN450 80 PlusCase: Xigmatek NYX 3F RGB ( Mini Tower )')
SET IDENTITY_INSERT [dbo].[ProductDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([ID], [Role_Name]) VALUES (1, N'Admin')
INSERT [dbo].[Role] ([ID], [Role_Name]) VALUES (2, N'Nhân viên')
INSERT [dbo].[Role] ([ID], [Role_Name]) VALUES (3, N'Khách hàng')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([ID], [username], [password], [firstName], [lastName], [gender], [birthDate], [address], [joinDate], [isDisable], [Role_ID]) VALUES (1, N'NV_001', N'CVJuIRIHoFQ=', N'Nguyễn Văn', N'A', 1, CAST(N'1999-01-01' AS Date), N'193 Hàm T?', CAST(N'2015-11-20' AS Date), 0, 1)
INSERT [dbo].[User] ([ID], [username], [password], [firstName], [lastName], [gender], [birthDate], [address], [joinDate], [isDisable], [Role_ID]) VALUES (2, N'NV_002', N'CVJuIRIHoFQ=', N'Nguyễn Văn', N'B', 0, CAST(N'1999-02-01' AS Date), N'193 Hàm T?', CAST(N'2015-11-20' AS Date), 0, 2)
INSERT [dbo].[User] ([ID], [username], [password], [firstName], [lastName], [gender], [birthDate], [address], [joinDate], [isDisable], [Role_ID]) VALUES (3, N'NV_003', N'CVJuIRIHoFQ=', N'Nguyễn Văn', N'C', 0, CAST(N'1999-02-01' AS Date), N'193 Hàm T?', CAST(N'2015-11-20' AS Date), 0, 2)
INSERT [dbo].[User] ([ID], [username], [password], [firstName], [lastName], [gender], [birthDate], [address], [joinDate], [isDisable], [Role_ID]) VALUES (4, N'sieusaopolo15', N'CVJuIRIHoFQ=', N'Huỳnh Tuấn', N'Đạt', 1, CAST(N'2015-11-20' AS Date), N'267/16 Tùng Thi?n Vuong', CAST(N'2015-11-20' AS Date), 0, 3)
INSERT [dbo].[User] ([ID], [username], [password], [firstName], [lastName], [gender], [birthDate], [address], [joinDate], [isDisable], [Role_ID]) VALUES (5, N'abcxyz', N'CVJuIRIHoFQ=', N'Nguyễn Văn', N'A', 1, CAST(N'2015-11-20' AS Date), N'193 Hàm T?', CAST(N'2015-11-20' AS Date), 0, 3)
INSERT [dbo].[User] ([ID], [username], [password], [firstName], [lastName], [gender], [birthDate], [address], [joinDate], [isDisable], [Role_ID]) VALUES (6, N'hello', N'CVJuIRIHoFQ=', N'Nguyễn Văn', N'B', 1, CAST(N'2015-11-20' AS Date), N'193 Hàm T?', CAST(N'2015-11-20' AS Date), 0, 3)
INSERT [dbo].[User] ([ID], [username], [password], [firstName], [lastName], [gender], [birthDate], [address], [joinDate], [isDisable], [Role_ID]) VALUES (7, N'trung', N'CVJuIRIHoFQ=', N'Trung', N'Do Tham', 1, CAST(N'1999-01-13' AS Date), N'ok', CAST(N'2001-01-01' AS Date), 0, 3)
INSERT [dbo].[User] ([ID], [username], [password], [firstName], [lastName], [gender], [birthDate], [address], [joinDate], [isDisable], [Role_ID]) VALUES (8, N'z', N'CVJuIRIHoFQ=', N'z', N'z', 1, CAST(N'2020-12-17' AS Date), N'z', CAST(N'2020-12-17' AS Date), 0, 0)
INSERT [dbo].[User] ([ID], [username], [password], [firstName], [lastName], [gender], [birthDate], [address], [joinDate], [isDisable], [Role_ID]) VALUES (11, N'w', N'CVJuIRIHoFQ=', N'w', N'w', 1, CAST(N'2020-12-21' AS Date), N'w', CAST(N'2020-12-17' AS Date), 0, 0)
INSERT [dbo].[User] ([ID], [username], [password], [firstName], [lastName], [gender], [birthDate], [address], [joinDate], [isDisable], [Role_ID]) VALUES (12, N's', N'CVJuIRIHoFQ=', N's', N's', 1, CAST(N'2020-12-23' AS Date), N's', CAST(N'2020-12-17' AS Date), 0, 0)
INSERT [dbo].[User] ([ID], [username], [password], [firstName], [lastName], [gender], [birthDate], [address], [joinDate], [isDisable], [Role_ID]) VALUES (13, N'1', N'CVJuIRIHoFQ=', N'1', N'1', 1, CAST(N'1999-01-01' AS Date), N'1', CAST(N'2020-12-19' AS Date), 0, 3)
INSERT [dbo].[User] ([ID], [username], [password], [firstName], [lastName], [gender], [birthDate], [address], [joinDate], [isDisable], [Role_ID]) VALUES (14, N'as', N'CVJuIRIHoFQ=', N'123', N'a', 1, CAST(N'1999-01-01' AS Date), N'', CAST(N'2020-12-19' AS Date), 0, 3)
INSERT [dbo].[User] ([ID], [username], [password], [firstName], [lastName], [gender], [birthDate], [address], [joinDate], [isDisable], [Role_ID]) VALUES (15, N'vsy', N'CVJuIRIHoFQ=', N'vay', N'vay', 1, CAST(N'2020-12-22' AS Date), N'', CAST(N'2020-12-19' AS Date), 0, 3)
INSERT [dbo].[User] ([ID], [username], [password], [firstName], [lastName], [gender], [birthDate], [address], [joinDate], [isDisable], [Role_ID]) VALUES (16, N'vay', N'CVJuIRIHoFQ=', N'adc', N'adc', 1, CAST(N'1999-01-01' AS Date), N'', CAST(N'2020-12-19' AS Date), 0, 3)
INSERT [dbo].[User] ([ID], [username], [password], [firstName], [lastName], [gender], [birthDate], [address], [joinDate], [isDisable], [Role_ID]) VALUES (17, N'trung1', N'CVJuIRIHoFQ=', N'g', N'g', 1, CAST(N'1999-01-01' AS Date), N'', CAST(N'2020-12-20' AS Date), 0, 3)
INSERT [dbo].[User] ([ID], [username], [password], [firstName], [lastName], [gender], [birthDate], [address], [joinDate], [isDisable], [Role_ID]) VALUES (18, N'trungttt', N'LGwLyo9S19w=', N'v', N'v', 1, CAST(N'1999-01-01' AS Date), N'', CAST(N'2020-12-20' AS Date), 0, 3)
INSERT [dbo].[User] ([ID], [username], [password], [firstName], [lastName], [gender], [birthDate], [address], [joinDate], [isDisable], [Role_ID]) VALUES (19, N'trung9', N'hkuxgJwQzE8=', N'a', N'b', 1, CAST(N'1999-01-01' AS Date), N'', CAST(N'2020-12-25' AS Date), 0, 3)
INSERT [dbo].[User] ([ID], [username], [password], [firstName], [lastName], [gender], [birthDate], [address], [joinDate], [isDisable], [Role_ID]) VALUES (20, N'Quinnn', N'fWHdJjknsXk=', N'a', N'a', 1, CAST(N'1999-01-01' AS Date), N'', CAST(N'2021-03-02' AS Date), 0, 3)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
USE [master]
GO
ALTER DATABASE [LaptopShop] SET  READ_WRITE 
GO
