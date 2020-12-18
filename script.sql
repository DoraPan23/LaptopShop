USE [LaptopShop]
GO
/****** Object:  Table [dbo].[Brand]    Script Date: 12/13/2020 4:50:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brand](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Brand_Name] [nvarchar](30) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cart]    Script Date: 12/13/2020 4:50:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Product_Id] [int] NULL,
	[Quantity] [int] NULL,
	[Combo_Id] [int] NULL,
	[Customer_Id] [int] NULL,
 CONSTRAINT [PK_Cart] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Catalog]    Script Date: 12/13/2020 4:50:55 PM ******/
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
/****** Object:  Table [dbo].[Combo]    Script Date: 12/13/2020 4:50:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Combo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Combo_Name] [nvarchar](50) NOT NULL,
	[Product_List] [text] NOT NULL,
	[startDate] [date] NOT NULL,
	[endDate] [date] NOT NULL,
	[totalMoney] [decimal](10, 0) NOT NULL,
	[discount] [int] NOT NULL,
	[discountMoney] [decimal](10, 0) NOT NULL,
 CONSTRAINT [PK__Combo__3214EC27DB0F4795] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 12/13/2020 4:50:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[firstName] [nvarchar](50) NOT NULL,
	[lastName] [nvarchar](20) NOT NULL,
	[gender] [bit] NOT NULL,
	[birthDate] [date] NOT NULL,
	[address] [nvarchar](100) NULL,
	[joinDate] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 12/13/2020 4:50:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[firstName] [nvarchar](50) NOT NULL,
	[lastName] [nvarchar](20) NOT NULL,
	[gender] [bit] NOT NULL,
	[birthDate] [date] NOT NULL,
	[address] [text] NOT NULL,
	[joinDate] [date] NOT NULL,
	[Role_ID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invoice]    Script Date: 12/13/2020 4:50:55 PM ******/
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
/****** Object:  Table [dbo].[InvoiceDetail]    Script Date: 12/13/2020 4:50:55 PM ******/
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
/****** Object:  Table [dbo].[Order]    Script Date: 12/13/2020 4:50:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NULL,
	[Total_Price] [float] NULL,
	[Customer_Id] [int] NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 12/13/2020 4:50:55 PM ******/
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
/****** Object:  Table [dbo].[Product]    Script Date: 12/13/2020 4:50:55 PM ******/
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
/****** Object:  Table [dbo].[Role]    Script Date: 12/13/2020 4:50:55 PM ******/
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
SET IDENTITY_INSERT [dbo].[Brand] ON 

INSERT [dbo].[Brand] ([ID], [Brand_Name]) VALUES (1, N'Dell')
INSERT [dbo].[Brand] ([ID], [Brand_Name]) VALUES (2, N'Asus')
SET IDENTITY_INSERT [dbo].[Brand] OFF
GO
SET IDENTITY_INSERT [dbo].[Cart] ON 

INSERT [dbo].[Cart] ([ID], [Product_Id], [Quantity], [Combo_Id], [Customer_Id]) VALUES (17, 10, 2, NULL, 6)
SET IDENTITY_INSERT [dbo].[Cart] OFF
GO
SET IDENTITY_INSERT [dbo].[Catalog] ON 

INSERT [dbo].[Catalog] ([ID], [Catalog_Name]) VALUES (1, N'PC')
INSERT [dbo].[Catalog] ([ID], [Catalog_Name]) VALUES (2, N'Bàn Phím')
INSERT [dbo].[Catalog] ([ID], [Catalog_Name]) VALUES (3, N'Chuột')
INSERT [dbo].[Catalog] ([ID], [Catalog_Name]) VALUES (4, N'Tai nghe')
INSERT [dbo].[Catalog] ([ID], [Catalog_Name]) VALUES (5, N'Loa')
INSERT [dbo].[Catalog] ([ID], [Catalog_Name]) VALUES (6, N'Laptop')
INSERT [dbo].[Catalog] ([ID], [Catalog_Name]) VALUES (7, N'Ghế Gaming')
INSERT [dbo].[Catalog] ([ID], [Catalog_Name]) VALUES (8, N'Thiết bị văn phòng')
INSERT [dbo].[Catalog] ([ID], [Catalog_Name]) VALUES (9, N'Combo')
SET IDENTITY_INSERT [dbo].[Catalog] OFF
GO
SET IDENTITY_INSERT [dbo].[Combo] ON 

INSERT [dbo].[Combo] ([ID], [Combo_Name], [Product_List], [startDate], [endDate], [totalMoney], [discount], [discountMoney]) VALUES (1, N'Giảm giá Giáng Sinh', N'1;3;5;7', CAST(N'2015-11-20' AS Date), CAST(N'2015-11-20' AS Date), CAST(15580000 AS Decimal(10, 0)), 15, CAST(13243000 AS Decimal(10, 0)))
SET IDENTITY_INSERT [dbo].[Combo] OFF
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([ID], [username], [password], [firstName], [lastName], [gender], [birthDate], [address], [joinDate]) VALUES (2, N'sieusaopolo15', N'Password1234', N'Huỳnh Tuấn', N'Đạt', 1, CAST(N'2015-11-20' AS Date), N'267/16 Tùng Thiện Vương', CAST(N'2015-11-20' AS Date))
INSERT [dbo].[Customer] ([ID], [username], [password], [firstName], [lastName], [gender], [birthDate], [address], [joinDate]) VALUES (3, N'abcxyz', N'123456', N'Nguyễn Văn', N'A', 1, CAST(N'2015-11-20' AS Date), N'193 Hàm Tử', CAST(N'2015-11-20' AS Date))
INSERT [dbo].[Customer] ([ID], [username], [password], [firstName], [lastName], [gender], [birthDate], [address], [joinDate]) VALUES (4, N'hello', N'123456', N'Nguyễn Văn', N'B', 1, CAST(N'2015-11-20' AS Date), N'193 Hàm Tử', CAST(N'2015-11-20' AS Date))
INSERT [dbo].[Customer] ([ID], [username], [password], [firstName], [lastName], [gender], [birthDate], [address], [joinDate]) VALUES (6, N'trung', N'123', N'Trung', N'Do Tham', 1, CAST(N'1999-01-13' AS Date), NULL, CAST(N'2001-01-01' AS Date))
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([ID], [username], [password], [firstName], [lastName], [gender], [birthDate], [address], [joinDate], [Role_ID]) VALUES (3, N'NV_001', N'123456', N'Nguyễn Văn', N'A', 1, CAST(N'1999-01-01' AS Date), N'193 Hàm T?', CAST(N'2015-11-20' AS Date), 1)
INSERT [dbo].[Employee] ([ID], [username], [password], [firstName], [lastName], [gender], [birthDate], [address], [joinDate], [Role_ID]) VALUES (4, N'NV_002', N'123456', N'Nguyễn Văn', N'B', 0, CAST(N'1999-02-01' AS Date), N'193 Hàm T?', CAST(N'2015-11-20' AS Date), 2)
INSERT [dbo].[Employee] ([ID], [username], [password], [firstName], [lastName], [gender], [birthDate], [address], [joinDate], [Role_ID]) VALUES (5, N'NV_003', N'123456', N'Nguyễn Văn', N'C', 0, CAST(N'1999-02-01' AS Date), N'193 Hàm T?', CAST(N'2015-11-20' AS Date), 2)
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([ID], [Date], [Total_Price], [Customer_Id], [Status]) VALUES (1, CAST(N'2020-12-13' AS Date), 33990000, 6, 1)
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderDetail] ON 

INSERT [dbo].[OrderDetail] ([ID], [Order_Id], [Product_Id], [Combo_Id], [Quantity], [Price]) VALUES (1, 1, 10, NULL, 2, 33990000)
SET IDENTITY_INSERT [dbo].[OrderDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ID], [Product_Name], [Catalog_ID], [Amount], [Price], [Image], [Discount], [Detail], [Brand_ID]) VALUES (1, N'Dell Vostro 15 5590', 6, 10, CAST(19590000 AS Decimal(10, 0)), N'/Assets/Layout2/images/Laptop/Dell/vostro5590_00.jpg', 10, N'CPU: Intel Core i3 Ice Lake, 1005G1, 1.20 GHz;RAM: 8 GB, DDR4 (On board 4GB +1 khe 4GB), 2400 MHz;Ổ cứng: SSD 512 GB M.2 PCIe, Hỗ trợ khe cắm HDD SATA;Màn hình: 15.6 inch, Full HD (1920 x 1080);Card màn hình: Card đồ họa tích hợp, Intel UHD Graphics;Cổng kết nối: 2 x USB 2.0, USB 3.1, HDMI, LAN (RJ45);Hệ điều hành: Windows 10 Home SL;Thiết kế: Vỏ nhựa, PIN liền;Kích thước: Dày 19.9 mm, 1.7 kg', 1)
INSERT [dbo].[Product] ([ID], [Product_Name], [Catalog_ID], [Amount], [Price], [Image], [Discount], [Detail], [Brand_ID]) VALUES (2, N'Dell Inspiron 7501', 6, 5, CAST(29290000 AS Decimal(10, 0)), N'/Assets/Layout2/images/Laptop/Dell/inspiron7501_00.jpg', NULL, N'CPU: Intel Core i3 Ice Lake, 1005G1, 1.20 GHz;RAM: 8 GB, DDR4 (On board 4GB +1 khe 4GB), 2400 MHz;Ổ cứng: SSD 512 GB M.2 PCIe, Hỗ trợ khe cắm HDD SATA;Màn hình: 15.6 inch, Full HD (1920 x 1080);Card màn hình: Card đồ họa tích hợp, Intel UHD Graphics;Cổng kết nối: 2 x USB 2.0, USB 3.1, HDMI, LAN (RJ45);Hệ điều hành: Windows 10 Home SL;Thiết kế: Vỏ nhựa, PIN liền;Kích thước: Dày 19.9 mm, 1.7 kg', 1)
INSERT [dbo].[Product] ([ID], [Product_Name], [Catalog_ID], [Amount], [Price], [Image], [Discount], [Detail], [Brand_ID]) VALUES (3, N'Bàn phím Newmen GM368', 2, 18, CAST(790000 AS Decimal(10, 0)), N'/Assets/Layout2/images/Laptop/Dell/inspiron7501_00.jpg', NULL, N'CPU: Intel Core i3 Ice Lake, 1005G1, 1.20 GHz;RAM: 8 GB, DDR4 (On board 4GB +1 khe 4GB), 2400 MHz;Ổ cứng: SSD 512 GB M.2 PCIe, Hỗ trợ khe cắm HDD SATA;Màn hình: 15.6 inch, Full HD (1920 x 1080);Card màn hình: Card đồ họa tích hợp, Intel UHD Graphics;Cổng kết nối: 2 x USB 2.0, USB 3.1, HDMI, LAN (RJ45);Hệ điều hành: Windows 10 Home SL;Thiết kế: Vỏ nhựa, PIN liền;Kích thước: Dày 19.9 mm, 1.7 kg', NULL)
INSERT [dbo].[Product] ([ID], [Product_Name], [Catalog_ID], [Amount], [Price], [Image], [Discount], [Detail], [Brand_ID]) VALUES (4, N'Bàn phím E-Dra EK311', 2, 15, CAST(690000 AS Decimal(10, 0)), N'/Assets/Layout2/images/Laptop/Dell/inspiron7501_00.jpg', NULL, N'CPU: Intel Core i3 Ice Lake, 1005G1, 1.20 GHz;RAM: 8 GB, DDR4 (On board 4GB +1 khe 4GB), 2400 MHz;Ổ cứng: SSD 512 GB M.2 PCIe, Hỗ trợ khe cắm HDD SATA;Màn hình: 15.6 inch, Full HD (1920 x 1080);Card màn hình: Card đồ họa tích hợp, Intel UHD Graphics;Cổng kết nối: 2 x USB 2.0, USB 3.1, HDMI, LAN (RJ45);Hệ điều hành: Windows 10 Home SL;Thiết kế: Vỏ nhựa, PIN liền;Kích thước: Dày 19.9 mm, 1.7 kg', NULL)
INSERT [dbo].[Product] ([ID], [Product_Name], [Catalog_ID], [Amount], [Price], [Image], [Discount], [Detail], [Brand_ID]) VALUES (5, N'Chuột Gaming Zadez G151M Ðen', 3, 15, CAST(300000 AS Decimal(10, 0)), N'/Assets/Layout2/images/Laptop/Dell/dell-gaming-g7-7590-GamingG77590.jpg', NULL, N'CPU: Intel Core i3 Ice Lake, 1005G1, 1.20 GHz;RAM: 8 GB, DDR4 (On board 4GB +1 khe 4GB), 2400 MHz;Ổ cứng: SSD 512 GB M.2 PCIe, Hỗ trợ khe cắm HDD SATA;Màn hình: 15.6 inch, Full HD (1920 x 1080);Card màn hình: Card đồ họa tích hợp, Intel UHD Graphics;Cổng kết nối: 2 x USB 2.0, USB 3.1, HDMI, LAN (RJ45);Hệ điều hành: Windows 10 Home SL;Thiết kế: Vỏ nhựa, PIN liền;Kích thước: Dày 19.9 mm, 1.7 kg', NULL)
INSERT [dbo].[Product] ([ID], [Product_Name], [Catalog_ID], [Amount], [Price], [Image], [Discount], [Detail], [Brand_ID]) VALUES (6, N'Chuộtt không dây Zadez M353 Xám', 3, 10, CAST(300000 AS Decimal(10, 0)), N'/Assets/Layout2/images/Laptop/Dell/inspiron7501_00.jpg', NULL, N'CPU: Intel Core i3 Ice Lake, 1005G1, 1.20 GHz;RAM: 8 GB, DDR4 (On board 4GB +1 khe 4GB), 2400 MHz;Ổ cứng: SSD 512 GB M.2 PCIe, Hỗ trợ khe cắm HDD SATA;Màn hình: 15.6 inch, Full HD (1920 x 1080);Card màn hình: Card đồ họa tích hợp, Intel UHD Graphics;Cổng kết nối: 2 x USB 2.0, USB 3.1, HDMI, LAN (RJ45);Hệ điều hành: Windows 10 Home SL;Thiết kế: Vỏ nhựa, PIN liền;Kích thước: Dày 19.9 mm, 1.7 kg', NULL)
INSERT [dbo].[Product] ([ID], [Product_Name], [Catalog_ID], [Amount], [Price], [Image], [Discount], [Detail], [Brand_ID]) VALUES (7, N'Tai nghe Bluetooth True Wireless Mozard Air 3 Ðen', 4, 10, CAST(800000 AS Decimal(10, 0)), N'/Assets/Layout2/images/Laptop/Dell/inspiron7501_00.jpg', NULL, N'CPU: Intel Core i3 Ice Lake, 1005G1, 1.20 GHz;RAM: 8 GB, DDR4 (On board 4GB +1 khe 4GB), 2400 MHz;Ổ cứng: SSD 512 GB M.2 PCIe, Hỗ trợ khe cắm HDD SATA;Màn hình: 15.6 inch, Full HD (1920 x 1080);Card màn hình: Card đồ họa tích hợp, Intel UHD Graphics;Cổng kết nối: 2 x USB 2.0, USB 3.1, HDMI, LAN (RJ45);Hệ điều hành: Windows 10 Home SL;Thiết kế: Vỏ nhựa, PIN liền;Kích thước: Dày 19.9 mm, 1.7 kg', NULL)
INSERT [dbo].[Product] ([ID], [Product_Name], [Catalog_ID], [Amount], [Price], [Image], [Discount], [Detail], [Brand_ID]) VALUES (8, N'Tai nghe Bluetooth True Wireless Jabra Elite Activ', 4, 5, CAST(3790000 AS Decimal(10, 0)), N'/Assets/Layout2/images/Laptop/Dell/inspiron7501_00.jpg', NULL, N'CPU: Intel Core i3 Ice Lake, 1005G1, 1.20 GHz;RAM: 8 GB, DDR4 (On board 4GB +1 khe 4GB), 2400 MHz;Ổ cứng: SSD 512 GB M.2 PCIe, Hỗ trợ khe cắm HDD SATA;Màn hình: 15.6 inch, Full HD (1920 x 1080);Card màn hình: Card đồ họa tích hợp, Intel UHD Graphics;Cổng kết nối: 2 x USB 2.0, USB 3.1, HDMI, LAN (RJ45);Hệ điều hành: Windows 10 Home SL;Thiết kế: Vỏ nhựa, PIN liền;Kích thước: Dày 19.9 mm, 1.7 kg', NULL)
INSERT [dbo].[Product] ([ID], [Product_Name], [Catalog_ID], [Amount], [Price], [Image], [Discount], [Detail], [Brand_ID]) VALUES (9, N'Loa Bluetooth LG Xboom Go PL7 Xanh Ðen', 5, 8, CAST(3390000 AS Decimal(10, 0)), N'/Assets/Layout2/images/Laptop/Dell/dell-gaming-g7-7590-GamingG77590.jpg', NULL, N'CPU: Intel Core i3 Ice Lake, 1005G1, 1.20 GHz;RAM: 8 GB, DDR4 (On board 4GB +1 khe 4GB), 2400 MHz;Ổ cứng: SSD 512 GB M.2 PCIe, Hỗ trợ khe cắm HDD SATA;Màn hình: 15.6 inch, Full HD (1920 x 1080);Card màn hình: Card đồ họa tích hợp, Intel UHD Graphics;Cổng kết nối: 2 x USB 2.0, USB 3.1, HDMI, LAN (RJ45);Hệ điều hành: Windows 10 Home SL;Thiết kế: Vỏ nhựa, PIN liền;Kích thước: Dày 19.9 mm, 1.7 kg', NULL)
INSERT [dbo].[Product] ([ID], [Product_Name], [Catalog_ID], [Amount], [Price], [Image], [Discount], [Detail], [Brand_ID]) VALUES (10, N'Loa Bluetooth JBL PULSE2BLKAS Ðen', 5, 6, CAST(2952000 AS Decimal(10, 0)), N'/Assets/Layout2/images/Laptop/Dell/dell-gaming-g7-7590-GamingG77590.jpg', NULL, N'CPU: Intel Core i3 Ice Lake, 1005G1, 1.20 GHz;RAM: 8 GB, DDR4 (On board 4GB +1 khe 4GB), 2400 MHz;Ổ cứng: SSD 512 GB M.2 PCIe, Hỗ trợ khe cắm HDD SATA;Màn hình: 15.6 inch, Full HD (1920 x 1080);Card màn hình: Card đồ họa tích hợp, Intel UHD Graphics;Cổng kết nối: 2 x USB 2.0, USB 3.1, HDMI, LAN (RJ45);Hệ điều hành: Windows 10 Home SL;Thiết kế: Vỏ nhựa, PIN liền;Kích thước: Dày 19.9 mm, 1.7 kg', NULL)
INSERT [dbo].[Product] ([ID], [Product_Name], [Catalog_ID], [Amount], [Price], [Image], [Discount], [Detail], [Brand_ID]) VALUES (11, N'GVN Titan 10 M', 1, 10, CAST(8990000 AS Decimal(10, 0)), N'/Assets/Layout2/images/Laptop/Dell/dell-gaming-g7-7590-GamingG77590.jpg', NULL, N'CPU: Intel Core i3 Ice Lake, 1005G1, 1.20 GHz;RAM: 8 GB, DDR4 (On board 4GB +1 khe 4GB), 2400 MHz;Ổ cứng: SSD 512 GB M.2 PCIe, Hỗ trợ khe cắm HDD SATA;Màn hình: 15.6 inch, Full HD (1920 x 1080);Card màn hình: Card đồ họa tích hợp, Intel UHD Graphics;Cổng kết nối: 2 x USB 2.0, USB 3.1, HDMI, LAN (RJ45);Hệ điều hành: Windows 10 Home SL;Thiết kế: Vỏ nhựa, PIN liền;Kích thước: Dày 19.9 mm, 1.7 kg', NULL)
INSERT [dbo].[Product] ([ID], [Product_Name], [Catalog_ID], [Amount], [Price], [Image], [Discount], [Detail], [Brand_ID]) VALUES (12, N'Dell Gaming G7 7590', 6, 10, CAST(21990000 AS Decimal(10, 0)), N'/Assets/Layout2/images/Laptop/Dell/dell-gaming-g7-7590-GamingG77590.jpg', NULL, N'CPU: Intel Core i3 Ice Lake, 1005G1, 1.20 GHz;RAM: 8 GB, DDR4 (On board 4GB +1 khe 4GB), 2400 MHz;Ổ cứng: SSD 512 GB M.2 PCIe, Hỗ trợ khe cắm HDD SATA;Màn hình: 15.6 inch, Full HD (1920 x 1080);Card màn hình: Card đồ họa tích hợp, Intel UHD Graphics;Cổng kết nối: 2 x USB 2.0, USB 3.1, HDMI, LAN (RJ45);Hệ điều hành: Windows 10 Home SL;Thiết kế: Vỏ nhựa, PIN liền;Kích thước: Dày 19.9 mm, 1.7 kg', 2)
INSERT [dbo].[Product] ([ID], [Product_Name], [Catalog_ID], [Amount], [Price], [Image], [Discount], [Detail], [Brand_ID]) VALUES (13, N'Dell XPS 15 9500', 6, 10, CAST(37990000 AS Decimal(10, 0)), N'/Assets/Layout2/images/Laptop/Dell/dell-xps-15-9500-XPS159500.jpg', NULL, N'CPU: Intel Core i3 Ice Lake, 1005G1, 1.20 GHz;RAM: 8 GB, DDR4 (On board 4GB +1 khe 4GB), 2400 MHz;Ổ cứng: SSD 512 GB M.2 PCIe, Hỗ trợ khe cắm HDD SATA;Màn hình: 15.6 inch, Full HD (1920 x 1080);Card màn hình: Card đồ họa tích hợp, Intel UHD Graphics;Cổng kết nối: 2 x USB 2.0, USB 3.1, HDMI, LAN (RJ45);Hệ điều hành: Windows 10 Home SL;Thiết kế: Vỏ nhựa, PIN liền;Kích thước: Dày 19.9 mm, 1.7 kg', 1)
INSERT [dbo].[Product] ([ID], [Product_Name], [Catalog_ID], [Amount], [Price], [Image], [Discount], [Detail], [Brand_ID]) VALUES (14, N'Dell Inspiron 14 5402', 6, 10, CAST(19490000 AS Decimal(10, 0)), N'/Assets/Layout2/images/Laptop/Dell/5402_00.jpg', NULL, N'CPU: Intel Core i3 Ice Lake, 1005G1, 1.20 GHz;RAM: 8 GB, DDR4 (On board 4GB +1 khe 4GB), 2400 MHz;Ổ cứng: SSD 512 GB M.2 PCIe, Hỗ trợ khe cắm HDD SATA;Màn hình: 15.6 inch, Full HD (1920 x 1080);Card màn hình: Card đồ họa tích hợp, Intel UHD Graphics;Cổng kết nối: 2 x USB 2.0, USB 3.1, HDMI, LAN (RJ45);Hệ điều hành: Windows 10 Home SL;Thiết kế: Vỏ nhựa, PIN liền;Kích thước: Dày 19.9 mm, 1.7 kg', 1)
INSERT [dbo].[Product] ([ID], [Product_Name], [Catalog_ID], [Amount], [Price], [Image], [Discount], [Detail], [Brand_ID]) VALUES (15, N'Dell XPS 13 9310', 6, 10, CAST(33990000 AS Decimal(10, 0)), N'/Assets/Layout2/images/Laptop/Dell/xps93102-1s_00.jpg', NULL, N'CPU: Intel Core i3 Ice Lake, 1005G1, 1.20 GHz;RAM: 8 GB, DDR4 (On board 4GB +1 khe 4GB), 2400 MHz;Ổ cứng: SSD 512 GB M.2 PCIe, Hỗ trợ khe cắm HDD SATA;Màn hình: 15.6 inch, Full HD (1920 x 1080);Card màn hình: Card đồ họa tích hợp, Intel UHD Graphics;Cổng kết nối: 2 x USB 2.0, USB 3.1, HDMI, LAN (RJ45);Hệ điều hành: Windows 10 Home SL;Thiết kế: Vỏ nhựa, PIN liền;Kích thước: Dày 19.9 mm, 1.7 kg', 1)
INSERT [dbo].[Product] ([ID], [Product_Name], [Catalog_ID], [Amount], [Price], [Image], [Discount], [Detail], [Brand_ID]) VALUES (16, N'Dell XPS 13 7390', 6, 10, CAST(23990000 AS Decimal(10, 0)), N'/Assets/Layout2/images/Laptop/Dell/dell-xps-13-7390-XPS7390.jpg', NULL, N'CPU: Intel Core i3 Ice Lake, 1005G1, 1.20 GHz;RAM: 8 GB, DDR4 (On board 4GB +1 khe 4GB), 2400 MHz;Ổ cứng: SSD 512 GB M.2 PCIe, Hỗ trợ khe cắm HDD SATA;Màn hình: 15.6 inch, Full HD (1920 x 1080);Card màn hình: Card đồ họa tích hợp, Intel UHD Graphics;Cổng kết nối: 2 x USB 2.0, USB 3.1, HDMI, LAN (RJ45);Hệ điều hành: Windows 10 Home SL;Thiết kế: Vỏ nhựa, PIN liền;Kích thước: Dày 19.9 mm, 1.7 kg', 1)
INSERT [dbo].[Product] ([ID], [Product_Name], [Catalog_ID], [Amount], [Price], [Image], [Discount], [Detail], [Brand_ID]) VALUES (17, N'Dell Inspiron 13 7306', 6, 10, CAST(34990000 AS Decimal(10, 0)), N'/Assets/Layout2/images/Laptop/Dell/Inspiron7306_00.jpg', NULL, N'CPU: Intel Core i3 Ice Lake, 1005G1, 1.20 GHz;RAM: 8 GB, DDR4 (On board 4GB +1 khe 4GB), 2400 MHz;Ổ cứng: SSD 512 GB M.2 PCIe, Hỗ trợ khe cắm HDD SATA;Màn hình: 15.6 inch, Full HD (1920 x 1080);Card màn hình: Card đồ họa tích hợp, Intel UHD Graphics;Cổng kết nối: 2 x USB 2.0, USB 3.1, HDMI, LAN (RJ45);Hệ điều hành: Windows 10 Home SL;Thiết kế: Vỏ nhựa, PIN liền;Kích thước: Dày 19.9 mm, 1.7 kg', 1)
INSERT [dbo].[Product] ([ID], [Product_Name], [Catalog_ID], [Amount], [Price], [Image], [Discount], [Detail], [Brand_ID]) VALUES (18, N'Dell XPS 13 9310 2-in-1', 6, 10, CAST(38990000 AS Decimal(10, 0)), N'/Assets/Layout2/images/Laptop/Dell/xps93102-1s_00.jpg', NULL, N'CPU: Intel Core i3 Ice Lake, 1005G1, 1.20 GHz;RAM: 8 GB, DDR4 (On board 4GB +1 khe 4GB), 2400 MHz;Ổ cứng: SSD 512 GB M.2 PCIe, Hỗ trợ khe cắm HDD SATA;Màn hình: 15.6 inch, Full HD (1920 x 1080);Card màn hình: Card đồ họa tích hợp, Intel UHD Graphics;Cổng kết nối: 2 x USB 2.0, USB 3.1, HDMI, LAN (RJ45);Hệ điều hành: Windows 10 Home SL;Thiết kế: Vỏ nhựa, PIN liền;Kích thước: Dày 19.9 mm, 1.7 kg', 1)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Customer__F3DBC572F4AA84E8]    Script Date: 12/13/2020 4:50:55 PM ******/
ALTER TABLE [dbo].[Customer] ADD UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Employee__F3DBC5725E44AC6E]    Script Date: 12/13/2020 4:50:55 PM ******/
ALTER TABLE [dbo].[Employee] ADD UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[InvoiceDetail] ADD  CONSTRAINT [DF_InvoiceDetail_Amount]  DEFAULT ((1)) FOR [Amount]
GO
