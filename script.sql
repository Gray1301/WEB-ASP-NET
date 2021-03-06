USE MASTER 
GO

IF EXISTS(SELECT name FROM sys.databases WHERE name='QLDODIENTU')
	DROP DATABASE QLDODIENTU
GO

CREATE DATABASE QLDODIENTU
GO

USE QLDODIENTU
GO
USE [QLDODIENTU]
GO
/****** Object:  Table [dbo].[ChiTietGioHang-SanPham]    Script Date: 10/5/2021 3:10:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietGioHang-SanPham](
	[MaGH] [int] NOT NULL,
	[MaSP] [int] NOT NULL,
	[SoLuong] [int] NOT NULL,
	[Gia] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaGH] ASC,
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DanhMucSP]    Script Date: 10/5/2021 3:10:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhMucSP](
	[MaDM] [int] IDENTITY(1,1) NOT NULL,
	[TenDM] [nvarchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DonHang]    Script Date: 10/5/2021 3:10:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonHang](
	[MaDH] [int] IDENTITY(1,1) NOT NULL,
	[MaGH] [int] NOT NULL,
	[NgayDat] [date] NULL,
	[DiaChiNhan] [ntext] NULL,
	[TinhTrang] [nvarchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GioHang]    Script Date: 10/5/2021 3:10:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GioHang](
	[MaGH] [int] IDENTITY(1,1) NOT NULL,
	[TenTK] [varchar](60) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaGH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 10/5/2021 3:10:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[MaSP] [int] IDENTITY(1,1) NOT NULL,
	[TenSP] [nvarchar](80) NOT NULL,
	[Anh] [ntext] NOT NULL,
	[ThuongHieu] [nchar](20) NULL,
	[GiaHang] [float] NULL,
	[Gia] [float] NOT NULL,
	[MoTa] [nvarchar](80) NULL,
	[SoLuongCon] int NOT NULL,
	[MaDM] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 10/5/2021 3:10:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[TenTK] [varchar](60) NOT NULL,
	[MatKhau] [varchar](60) NOT NULL,
	[HoTen] [nvarchar](60) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[SDT] [varchar](12) NULL,
	[NgaySinh] [date] NULL,
	[Tinh_ThanhPho] [nvarchar](25) NULL,
	[DiaChi] [ntext] NULL,
	[PhanQuyen] [nvarchar](25) NOT NULL,
	[TinhTrang] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TenTK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[ChiTietGioHang-SanPham] ([MaGH], [MaSP], [SoLuong], [Gia]) VALUES (1, 1, 1, 699000)
INSERT [dbo].[ChiTietGioHang-SanPham] ([MaGH], [MaSP], [SoLuong], [Gia]) VALUES (1, 2, 1, 3090000)
INSERT [dbo].[ChiTietGioHang-SanPham] ([MaGH], [MaSP], [SoLuong], [Gia]) VALUES (2, 2, 1, 3090000)
INSERT [dbo].[ChiTietGioHang-SanPham] ([MaGH], [MaSP], [SoLuong], [Gia]) VALUES (2, 28, 1, 119890000)
INSERT [dbo].[ChiTietGioHang-SanPham] ([MaGH], [MaSP], [SoLuong], [Gia]) VALUES (2, 39, 1, 20990000)
INSERT [dbo].[ChiTietGioHang-SanPham] ([MaGH], [MaSP], [SoLuong], [Gia]) VALUES (3, 15, 1, 14990000)
INSERT [dbo].[ChiTietGioHang-SanPham] ([MaGH], [MaSP], [SoLuong], [Gia]) VALUES (3, 37, 1, 3990000)
GO
SET IDENTITY_INSERT [dbo].[DanhMucSP] ON 

INSERT [dbo].[DanhMucSP] ([MaDM], [TenDM]) VALUES (1, N'Micro')
INSERT [dbo].[DanhMucSP] ([MaDM], [TenDM]) VALUES (2, N'Tivi LED/OLED/QLED')
INSERT [dbo].[DanhMucSP] ([MaDM], [TenDM]) VALUES (3, N'Amply')
INSERT [dbo].[DanhMucSP] ([MaDM], [TenDM]) VALUES (4, N'Loa Karaok')
INSERT [dbo].[DanhMucSP] ([MaDM], [TenDM]) VALUES (5, N'Dàn máy')
SET IDENTITY_INSERT [dbo].[DanhMucSP] OFF
GO
SET IDENTITY_INSERT [dbo].[DonHang] ON 

INSERT [dbo].[DonHang] ([MaDH], [MaGH], [NgayDat], [DiaChiNhan], [TinhTrang]) VALUES (1, 1, '2021-10-05', N'Đông Anh, Hà Nội', N'Chờ xác nhận')
INSERT [dbo].[DonHang] ([MaDH], [MaGH], [NgayDat], [DiaChiNhan], [TinhTrang]) VALUES (2, 2, '2021-10-03', N'Thanh Xuân, Hà Nội', N'Đang giao')
INSERT [dbo].[DonHang] ([MaDH], [MaGH], [NgayDat], [DiaChiNhan], [TinhTrang]) VALUES (3, 3, '2021-01-05' , N'Quận 7, TP Hồ Chí Minh', N'Đã hủy')
INSERT [dbo].[DonHang] ([MaDH], [MaGH], [NgayDat], [DiaChiNhan], [TinhTrang]) VALUES (4, 3, '2021-01-05' , N'Quận 7, TP Hồ Chí Minh', N'Đã hủy')
INSERT [dbo].[DonHang] ([MaDH], [MaGH], [NgayDat], [DiaChiNhan], [TinhTrang]) VALUES (5, 3, '2021-01-05', N'Quận 7, TP Hồ Chí Minh', N'Đã giao')
SET IDENTITY_INSERT [dbo].[DonHang] OFF
GO
SET IDENTITY_INSERT [dbo].[GioHang] ON 

INSERT [dbo].[GioHang] ([MaGH], [TenTK]) VALUES (1, N'dangvantuan')
INSERT [dbo].[GioHang] ([MaGH], [TenTK]) VALUES (2, N'leanhtuan')
INSERT [dbo].[GioHang] ([MaGH], [TenTK]) VALUES (3, N'hoangxuanthanh')
INSERT [dbo].[GioHang] ([MaGH], [TenTK]) VALUES (4, N'nguyennhutrong')
SET IDENTITY_INSERT [dbo].[GioHang] OFF
GO
SET IDENTITY_INSERT [dbo].[SanPham] ON 

INSERT [dbo].[SanPham] ([MaSP], [TenSP], [Anh], [ThuongHieu], [GiaHang], [Gia], [MoTa], [SoLuongCon], [MaDM]) VALUES (1, N'MICRO ZENBOS MZ-328', N'micro1.png', N'ZENBOS              ', NULL, 699000, N'Micro có dây; Tần số 70Hz-15KHz; Độ nhạy 68 dB +- 3dB', 2, 1)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [Anh], [ThuongHieu], [GiaHang], [Gia], [MoTa], [SoLuongCon], [MaDM]) VALUES (2, N'Micro Không Dây Hiệu BN AUDIO BA-2000II', N'micro2.png', N'BN AUDIO            ', NULL, 3090000, N'Micro không dây; Tần số 740 - 790 MHZ;  Số kênh 200', 3, 1)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [Anh], [ThuongHieu], [GiaHang], [Gia], [MoTa], [SoLuongCon], [MaDM]) VALUES (3, N'Micro Có Dây PLATINUM KS-5000', N'micro3.png', N'OTHER               ', 399000, 299000, N'Micro có dây; Tần số 50Hz ~ 14000Hz; Độ nhạy -72dB', 4, 1)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [Anh], [ThuongHieu], [GiaHang], [Gia], [MoTa], [SoLuongCon], [MaDM]) VALUES (4, N'Bộ Micro Không Dây PLATINUM U20', N'micro4.png', N'OTHER               ', 1699000, 1249000, N'Micro không dây; Tần số 640MHz-690MHz; Độ nhạy 2.0 u V',5, 1)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [Anh], [ThuongHieu], [GiaHang], [Gia], [MoTa], [SoLuongCon], [MaDM]) VALUES (5, N'Microphone PARAMAX SM-1000 SMART', N'micro5.png', N'PARAMAX             ', 3790000, 3190000, N'Micro không dây; Tần số 40Hz ~ 18KHz; Băng tần UHF', 6, 1)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [Anh], [ThuongHieu], [GiaHang], [Gia], [MoTa], [SoLuongCon], [MaDM]) VALUES (6, N'Micro JAMMY B518', N'micro6.png', N'JAMMY               ', 1690000, 1190000, N'Micro không dây; Tần số đáp tuyến 180MHz-270MHz', 7, 1)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [Anh], [ThuongHieu], [GiaHang], [Gia], [MoTa], [SoLuongCon], [MaDM]) VALUES (7, N'Micro không dây ZENBOS MZ-212', N'micro7.png', N'ZENBOS              ', 2690000, 2490000, N'Micro không dây; Tần số đáp tuyến 700 - 770 kHz; Băn tần UHF',8, 1)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [Anh], [ThuongHieu], [GiaHang], [Gia], [MoTa], [SoLuongCon], [MaDM]) VALUES (8, N'Micro không dây ZENBOS MZ-201', N'micro8.png', N'ZENBOS              ', 1130000, 990000, N'Micro không dây; Tần số đáp tuyến 700 - 770 kHz; Băn tần UHF', 12, 1)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [Anh], [ThuongHieu], [GiaHang], [Gia], [MoTa], [SoLuongCon], [MaDM]) VALUES (9, N'Micro Không Dây GUINNESS MU-113', N'micro9.png', N'GUINNESS            ', 1790000, 1690000, N'Micro không dây; Tần số đáp tuyến 40Hz -18KHz; Băng tần UHF', 6, 1)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [Anh], [ThuongHieu], [GiaHang], [Gia], [MoTa], [SoLuongCon], [MaDM]) VALUES (10, N'Micro GUINNESS M-810S', N'micro10.png', N'GUINNESS            ', 879000, 799000, N'Micro không dây; Tần số đáp tuyến 50Hz-18kHz; Băng tần UHF', 45, 1)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [Anh], [ThuongHieu], [GiaHang], [Gia], [MoTa], [SoLuongCon], [MaDM]) VALUES (11, N'Android Tivi 4K Sony 43 Inch KD-43X7500H', N'tivi1.png', N'SONY                ', 13410000, 11890000, N'Loại Androi TV; Kích thước 43 Inch; Có HDMI x3', 0, 2)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [Anh], [ThuongHieu], [GiaHang], [Gia], [MoTa], [SoLuongCon], [MaDM]) VALUES (12, N'Android Tivi 4K TCL 55 Inch 55P618', N'tivi2.png', N'TCL                 ', NULL, 13990000, N'Loại smart LED; Kích thước 55 inch; Có HDMI x2', 0, 2)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [Anh], [ThuongHieu], [GiaHang], [Gia], [MoTa], [SoLuongCon], [MaDM]) VALUES (13, N'Smart Tivi Samsung UA43AU8000KXXV', N'tivi3.png', N'SAMSUNG             ', 15400000, 14690000, N'Loại smart LED; Kích thước 43 Inch; Độ phân giải Ultra HD 4K', 0, 2)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [Anh], [ThuongHieu], [GiaHang], [Gia], [MoTa], [SoLuongCon], [MaDM]) VALUES (14, N'Androi Tivi TCL 42 Inch L42S6500', N'tivi4.png', N'TCL                 ', 7590000, 7490000, N'Loại smart LED; Kích thước 42 Inch; Độ phân giải full HD', 11, 2)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [Anh], [ThuongHieu], [GiaHang], [Gia], [MoTa], [SoLuongCon], [MaDM]) VALUES (15, N'Android Tivi Sony 4K 43 Inch KD-43X8050H', N'tivi5.png', N'SONY                ', 16340000, 13590000, N'Loại Androi TV; Kích thước 43 Inch; Có HDMI x4', 22, 2)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [Anh], [ThuongHieu], [GiaHang], [Gia], [MoTa], [SoLuongCon], [MaDM]) VALUES (16, N'Smart Tivi 4K Samsung 43 Inch UA43AU9000KXXV', N'tivi6.png', N'SAMSUNG             ', 15900000, 15390000, N'Loại smart LED; Kích thước 43 Inch; Độ phân giản Ultra HD 4K', 33, 2)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [Anh], [ThuongHieu], [GiaHang], [Gia], [MoTa], [SoLuongCon], [MaDM]) VALUES (17, N'Smart Tivi Casper 55 Inch 55UX6200', N'tivi7.png', N'CASPER              ', 15990000, 11990000, N'Loại smart LED; Kích thước 55 Inch; Độ phân giải Ultra 4K', 9, 2)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [Anh], [ThuongHieu], [GiaHang], [Gia], [MoTa], [SoLuongCon], [MaDM]) VALUES (18, N'Smart Nanocell Tivi LG 4K 43 Inch 43NANO77TPA ThinQ AI', N'tivi8.png', N'LG                  ', 16900000, 13690000, N'Loại NanoCell TV; Kích thước 43 Inch', 8, 2)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [Anh], [ThuongHieu], [GiaHang], [Gia], [MoTa], [SoLuongCon], [MaDM]) VALUES (19, N'Smart Tivi OLED LG 4K 55 inch OLED55A1PTA', N'tivi9.png', N'LG                  ', 42900000, 27690000, N'Loại OLED; Kích thước 55 Inch; Độ phân giải Ultra 4K', 10, 2)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [Anh], [ThuongHieu], [GiaHang], [Gia], [MoTa], [SoLuongCon], [MaDM]) VALUES (20, N'Smart Tivi Casper 42 Inch 42FX5200', N'tivi10.png', N'CASPER              ', 8990000, 6290000, N'Loại smart LED; Kích thước 42 Inch; Độ phân giải Full HD', 34, 2)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [Anh], [ThuongHieu], [GiaHang], [Gia], [MoTa], [SoLuongCon], [MaDM]) VALUES (21, N'Internet Tivi Casper 32 Inch 32HX6200', N'tivi11.png', N'CASPER              ', 6990000, 5590000, N'Loại Internet TV; Kích thước 32 Inch; Độ phân giải HD', 76, 2)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [Anh], [ThuongHieu], [GiaHang], [Gia], [MoTa], [SoLuongCon], [MaDM]) VALUES (22, N'Smart Tivi QLED 4K Samsung 50 Inch QA50Q60AAKXXV', N'tivi12.png', N'SAMSUNG             ', 21900000, 19690000, N'Loại QLED TV; Kích thước 50 Inch; Độ phân giải Ultra HD 4K',4, 2)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [Anh], [ThuongHieu], [GiaHang], [Gia], [MoTa], [SoLuongCon], [MaDM]) VALUES (23, N'Smart Tivi OLED LG 4K 55 Inch OLED55CXPTA ThinQ AI', N'tivi13.png', N'LG                  ', 49900000, 26890000, N'Loại OLED TV; Kích thước 55 Inch; có HDMI x3', 7, 2)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [Anh], [ThuongHieu], [GiaHang], [Gia], [MoTa], [SoLuongCon], [MaDM]) VALUES (24, N'Smart Tivi HD Philips 32 Inch 32PHT5883/74', N'tivi14.png', N'PHILIPS             ', NULL, 5490000, N'Loại LED TV; Kích thước 32 Inch; Độ phân giải HD', 0, 2)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [Anh], [ThuongHieu], [GiaHang], [Gia], [MoTa], [SoLuongCon], [MaDM]) VALUES (25, N'Android Tivi TCL 4K 55 inch 55P725', N'tivi15.png', N'TCL                 ', 16990000, 14990000, N'Loại smart LED; Kích thước 55 Inch; Độ phân giải Ultra HD 4K', 0, 2)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [Anh], [ThuongHieu], [GiaHang], [Gia], [MoTa], [SoLuongCon], [MaDM]) VALUES (26, N'Tivi Casper 32 Inch 32HN5200', N'tivi16.png', N'CASPER              ', NULL, 4590000, N'Loại smart LED; Kích thước 32 Inch; Độ phân giải HD', 0, 2)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [Anh], [ThuongHieu], [GiaHang], [Gia], [MoTa], [SoLuongCon], [MaDM]) VALUES (27, N'Smart Tivi Neo QLED 8K Samsung 75 Inch QA75QN800AKXXV', N'tivi17.png', N'SAMSUNG             ', 139900000, 104890000, N'Loại Neo QLED;Kích thước 75 Inch;Phân giải 8K Ultra HD', 12, 2)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [Anh], [ThuongHieu], [GiaHang], [Gia], [MoTa], [SoLuongCon], [MaDM]) VALUES (28, N'Smart Tivi Neo QLED 8K Samsung 65 Inch QA65QN900AKXXV', N'tivi18.png', N'SAMSUNG             ', 129900000, 119890000, N'Loại Neo QLED;Kích thước 65 Inch;Phân giải 8K Ultra HD', 13, 2)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [Anh], [ThuongHieu], [GiaHang], [Gia], [MoTa], [SoLuongCon], [MaDM]) VALUES (29, N'Thiết Bị Xử Lý Âm Thanh Hiệu DAH-100SE', N'amply1.png', N'BMB                 ', 13990000, 8990000, N'Công suất 200W;Có kết nối Bluetooth', 14, 3)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [Anh], [ThuongHieu], [GiaHang], [Gia], [MoTa], [SoLuongCon], [MaDM]) VALUES (30, N'Mixer PARAMAX DX-2500 AIR', N'amply2.png', N'PARAMAX             ', 4990000, 4490000, N'Model DX-2500 AIR; Công suất 15W; Bluetooth', 16, 3)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [Anh], [ThuongHieu], [GiaHang], [Gia], [MoTa], [SoLuongCon], [MaDM]) VALUES (31, N'Amply PARAMAX SA-999 AIR MAX Limited', N'amply3.png', N'PARAMAX             ', 7990000, 6590000, N'Công suất 700W;Tần số20Hz ~ 20,000Hz; Có Bluetooth',18, 3)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [Anh], [ThuongHieu], [GiaHang], [Gia], [MoTa], [SoLuongCon], [MaDM]) VALUES (32, N'Vang Liền Công Suất Hiệu BN AUDIO PA-6500II', N'amply4.png', N'BN AUDIO            ', 11000000, 9690000, N'Công suất 600W;Có USB;Kết nối Bluetooth,Octical,Coaxial', 20, 3)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [Anh], [ThuongHieu], [GiaHang], [Gia], [MoTa], [SoLuongCon], [MaDM]) VALUES (33, N'Thiết Bị Khuếch Đại Âm Tần BA300', N'amply5.png', N'BOSTON AUDIO        ', 9800000, 8090000, N'Công suất 300W;Có USB;Có 2 kênh', 11, 3)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [Anh], [ThuongHieu], [GiaHang], [Gia], [MoTa], [SoLuongCon], [MaDM]) VALUES (34, N'Thiết Bị Khuếch Đại BOSTON AUDIO PA-1100B', N'amply6.png', N'BOSTON AUDIO        ', 7900000, 4990000, N'Công suất 300W; Có 2 kênh; Kết nối Bluetooth', 4, 3)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [Anh], [ThuongHieu], [GiaHang], [Gia], [MoTa], [SoLuongCon], [MaDM]) VALUES (35, N'Amply ZENBOS LX-8800H', N'amply7.png', N'ZENBOS              ', NULL, 4590000, N'Công suất 1300W;Có 2 kênh', 3, 3)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [Anh], [ThuongHieu], [GiaHang], [Gia], [MoTa], [SoLuongCon], [MaDM]) VALUES (36, N'BỘ LOA JAMO S628 HCS Dark Apple', N'loakaraok1.png', N'JAMO                ', NULL, 17390000, N'Loa bộ; Gồm 5 loa;Độ nhạy 90dB', 2, 4)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [Anh], [ThuongHieu], [GiaHang], [Gia], [MoTa], [SoLuongCon], [MaDM]) VALUES (37, N'LOA TORIMY RT-891', N'loakaraok2.png', N'TORIMY              ', 4890000, 3990000, N'Loa đứng;Gồm 2 loa;Độ nhạy 89dB', 1, 4)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [Anh], [ThuongHieu], [GiaHang], [Gia], [MoTa], [SoLuongCon], [MaDM]) VALUES (38, N'Loa YAMAHA NS-F330 Màu Đen //G', N'loakaraok3.png', N'YAMAHA              ', 13980000, 10780000, N'Loa đứng; Độ nhạy 89dB', 1, 4)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [Anh], [ThuongHieu], [GiaHang], [Gia], [MoTa], [SoLuongCon], [MaDM]) VALUES (39, N'Bộ Loa Đã Lắp Vào Thùng JBL Ki 312-PAK', N'loakaraok4.png', N'JBL                 ', 24590000, 20990000, N'Loa ngang; Độ nhạy 92dB; Gồm 2 loa', 1, 4)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [Anh], [ThuongHieu], [GiaHang], [Gia], [MoTa], [SoLuongCon], [MaDM]) VALUES (40, N'Loa TORIMY RT-819', N'loakaraok5.png', N'TORIMY              ', 4990000, 3490000, N'Loa ngang; Gồm 2 loa; Độ nhạy 89dB', 0, 4)
SET IDENTITY_INSERT [dbo].[SanPham] OFF
GO
INSERT [dbo].[TaiKhoan] ([TenTK], [MatKhau], [HoTen], [Email], [SDT], [NgaySinh], [Tinh_ThanhPho], [DiaChi], [PhanQuyen], [TinhTrang]) VALUES (N'admin', N'admin', N'Người quản trị', N'admin@gmail.com', NULL, N'2000-01-01', NULL, NULL, N'Người quản trị', 1)
INSERT [dbo].[TaiKhoan] ([TenTK], [MatKhau], [HoTen], [Email], [SDT], [NgaySinh], [Tinh_ThanhPho], [DiaChi], [PhanQuyen], [TinhTrang]) VALUES (N'dangvantuan', N'123', N'Đặng Văn Tuấn', N'dangvantuan@gmail.com', N'0965475210', N'2000-01-01' , N'Ninh Bình', N'Yên Mô, Yên Lạc, Ninh Bình', N'Khách hàng', 1)
INSERT [dbo].[TaiKhoan] ([TenTK], [MatKhau], [HoTen], [Email], [SDT], [NgaySinh], [Tinh_ThanhPho], [DiaChi], [PhanQuyen], [TinhTrang]) VALUES (N'hoangxuanthanh', N'123', N'Hoàng Xuân Thanh', N'hoangxuanthanh@gmail.com', N'0945125330', '2000-01-10' , N'Thái Bình', N'Đông Hứng, Thái Bình', N'Khách hàng', 1)
INSERT [dbo].[TaiKhoan] ([TenTK], [MatKhau], [HoTen], [Email], [SDT], [NgaySinh], [Tinh_ThanhPho], [DiaChi], [PhanQuyen], [TinhTrang]) VALUES (N'leanhtuan', N'123', N'Lê Anh Tuấn', N'leanhtuan@gmail.com', N'0978415220',N'2000-10-02', N'Hà Nội', N'Thanh Xuân, Hà Nội', N'Khách hàng', 1)
INSERT [dbo].[TaiKhoan] ([TenTK], [MatKhau], [HoTen], [Email], [SDT], [NgaySinh], [Tinh_ThanhPho], [DiaChi], [PhanQuyen], [TinhTrang]) VALUES (N'letuanh', N'123', N'Lê Tú Anh', N'letuanh@gmail.com', N'0956123220',N'2000-01-12', N'Nam Định', N'Ý Yên, Nam Định', N'Khách hàng', 0)
INSERT [dbo].[TaiKhoan] ([TenTK], [MatKhau], [HoTen], [Email], [SDT], [NgaySinh], [Tinh_ThanhPho], [DiaChi], [PhanQuyen], [TinhTrang]) VALUES (N'nguyennhutrong', N'123', N'Nguyễn Như Trọng', N'nguyennhutrong@gmail.com', N'0912365441', N'2000-10-10', N'Hà Nội', N'Hoàng Mai, Hà Nội', N'Khách hàng', 0)
GO
ALTER TABLE [dbo].[ChiTietGioHang-SanPham]  WITH CHECK ADD FOREIGN KEY([MaGH])
REFERENCES [dbo].[GioHang] ([MaGH])
GO
ALTER TABLE [dbo].[ChiTietGioHang-SanPham]  WITH CHECK ADD FOREIGN KEY([MaSP])
REFERENCES [dbo].[SanPham] ([MaSP])
GO
ALTER TABLE [dbo].[DonHang]  WITH CHECK ADD FOREIGN KEY([MaGH])
REFERENCES [dbo].[GioHang] ([MaGH])
GO
ALTER TABLE [dbo].[GioHang]  WITH CHECK ADD FOREIGN KEY([TenTK])
REFERENCES [dbo].[TaiKhoan] ([TenTK])
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD FOREIGN KEY([MaDM])
REFERENCES [dbo].[DanhMucSP] ([MaDM])
GO
