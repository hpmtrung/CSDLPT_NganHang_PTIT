USE [master]
GO
/****** Object:  Database [NGANHANG]    Script Date: 22/12/2021 11:10:16 ******/
CREATE DATABASE [NGANHANG]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NGANHANG', FILENAME = N'F:\program x64\Microsoft SQL Server\MSSQL15.SERVER3\MSSQL\DATA\NGANHANG.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'NGANHANG_log', FILENAME = N'F:\program x64\Microsoft SQL Server\MSSQL15.SERVER3\MSSQL\DATA\NGANHANG_log.ldf' , SIZE = 401408KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [NGANHANG] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NGANHANG].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NGANHANG] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NGANHANG] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NGANHANG] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NGANHANG] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NGANHANG] SET ARITHABORT OFF 
GO
ALTER DATABASE [NGANHANG] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [NGANHANG] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NGANHANG] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NGANHANG] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NGANHANG] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NGANHANG] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NGANHANG] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NGANHANG] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NGANHANG] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NGANHANG] SET  DISABLE_BROKER 
GO
ALTER DATABASE [NGANHANG] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NGANHANG] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NGANHANG] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NGANHANG] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NGANHANG] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NGANHANG] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [NGANHANG] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NGANHANG] SET RECOVERY FULL 
GO
ALTER DATABASE [NGANHANG] SET  MULTI_USER 
GO
ALTER DATABASE [NGANHANG] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NGANHANG] SET DB_CHAINING OFF 
GO
ALTER DATABASE [NGANHANG] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [NGANHANG] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [NGANHANG] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [NGANHANG] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'NGANHANG', N'ON'
GO
ALTER DATABASE [NGANHANG] SET QUERY_STORE = OFF
GO
USE [NGANHANG]
GO
/****** Object:  User [HTKN]    Script Date: 22/12/2021 11:10:16 ******/
CREATE USER [HTKN] FOR LOGIN [HTKN] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [HTKN]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 22/12/2021 11:10:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[CMND] [nchar](10) NOT NULL,
	[HO] [nvarchar](50) NOT NULL,
	[TEN] [nvarchar](10) NOT NULL,
	[DIACHI] [nvarchar](100) NOT NULL,
	[PHAI] [nvarchar](3) NULL,
	[NGAYCAP] [date] NOT NULL,
	[SODT] [nvarchar](15) NOT NULL,
	[MACN] [nchar](10) NULL,
	[rowguid] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[CMND] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'00111     ', N'Tèo', N'Nguyễn', N'11122 22233', N'Nam', CAST(N'2021-12-12' AS Date), N'0800908761', N'BENTHANH  ', N'182ee120-2c5b-ec11-9511-d09466f7ed41')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'0111882751', N'Joshua Wood', N'Etta', N'1236 Azpic Terrace', N'Nam', CAST(N'2020-03-10' AS Date), N'0015336248', N'TANDINH   ', N'cac0d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'0137546824', N'Eliza Waters Dfeq', N'Bryan', N'1882 Akci Grove', N'Nam', CAST(N'2020-08-17' AS Date), N'0745945393', N'BENTHANH  ', N'cbc0d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'0169558810', N'Miguel Vega', N'Janie', N'563 Jiiwa Manor', N'Nữ', CAST(N'2020-04-14' AS Date), N'0439513041', N'BENTHANH  ', N'ccc0d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'0392948929', N'Kwj', N'Kjkfj', N'kjfk', N'Nam', CAST(N'2021-12-18' AS Date), N'9832739898', N'BENTHANH  ', N'c2beb3d7-de5f-ec11-9511-d09466f7ed41')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'0472835687', N'Ruby Marsh', N'Blake', N'26 Luto Drive', N'Nam', CAST(N'2020-08-20' AS Date), N'0529733832', N'TANDINH   ', N'cdc0d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'0522729620', N'Alvin Barnett', N'Jeffery', N'1333 Etodef', N'Nam', CAST(N'2020-12-25' AS Date), N'0538741243', N'BENTHANH  ', N'cec0d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'0522729621', N'Ds', N'We', N'd dsfsf', N'Nam', CAST(N'2021-12-12' AS Date), N'0192837465', N'BENTHANH  ', N'256d1929-3a5b-ec11-9511-d09466f7ed41')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'0522729622', N'D', N'W', N'sdf', N'Nam', CAST(N'2021-12-22' AS Date), N'0987654321', N'BENTHANH  ', N'f319e972-a862-ec11-9512-d09466f7ed41')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'0522729627', N'Sdf', N'Df', N'sf', N'Nữ', CAST(N'2021-12-12' AS Date), N'0987654321', N'BENTHANH  ', N'84c0536c-3a5b-ec11-9511-d09466f7ed41')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'0522729628', N'We Dsdf E Sf', N'Dwe', N'dds sdfs', N'Nữ', CAST(N'2020-12-12' AS Date), N'0987654321', N'BENTHANH  ', N'9a466c1a-e45f-ec11-9511-d09466f7ed41')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'0522729629', N'Xx', N'Ss', N'ee', N'Nữ', CAST(N'2010-12-12' AS Date), N'0987654321', N'BENTHANH  ', N'3d7be080-305b-ec11-9511-d09466f7ed41')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'0642439998', N'Ella Hollowa', N'Ricardox', N'd', N'Nam', CAST(N'2020-03-19' AS Date), N'0697873330', N'BENTHANH  ', N'cfc0d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'0791223456', N'Huỳnh Phạm', N'Tèo', N'223 Phạm Thúc Kháng', N'Nam', CAST(N'2021-10-09' AS Date), N'0703273645', N'BENTHANH  ', N'3b001c74-305b-ec11-9511-d09466f7ed41')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'0792333456', N'Đoàn Thị', N'Bích', N'222 cbd', N'Nam', CAST(N'2021-10-09' AS Date), N'0897736456', N'BENTHANH  ', N'438b2328-305b-ec11-9511-d09466f7ed41')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'0855158569', N'Eunice Schwartz', N'Verno', N'1676 Lobta Extensio', N'Nam', CAST(N'2020-02-05' AS Date), N'0837328929', N'BENTHANH  ', N'd0c0d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'0903940294', N'Kw', N'Kdf', N'93 kjds', N'Nam', CAST(N'2021-12-18' AS Date), N'0987654354', N'BENTHANH  ', N'e298a8d9-e15f-ec11-9511-d09466f7ed41')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'0909087364', N'', N'', N'', N'Nam', CAST(N'2021-12-18' AS Date), N'', NULL, N'6a32f952-b05f-ec11-9511-d09466f7ed41')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'0914175848', N'Harry Crawford', N'Ray', N'1749 Amufo Path', N'Nữ', CAST(N'2020-04-01' AS Date), N'0059874474', N'TANDINH   ', N'd1c0d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'0914313243', N'Kathryn Collins', N'Lando', N'105 Baeve Lane', N'Nam', CAST(N'2020-07-16' AS Date), N'0102558522', N'BENTHANH  ', N'd2c0d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'0920348283', N'', N'', N'', NULL, CAST(N'2021-12-18' AS Date), N'', NULL, N'92319b3a-b15f-ec11-9511-d09466f7ed41')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'0987654321', N'D', N'D', N'kl', N'Nam', CAST(N'2021-12-18' AS Date), N'0987654322', N'BENTHANH  ', N'8a22d9b6-aa5f-ec11-9511-d09466f7ed41')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'0987676543', N'Dd', N'W', N'd', N'Nam', CAST(N'2021-12-18' AS Date), N'0909909012', N'BENTHANH  ', N'c8cdc49e-ab5f-ec11-9511-d09466f7ed41')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'1002999392', N'Sdf', N'Jjhj', N'kkkd', N'Nam', CAST(N'2021-12-18' AS Date), N'0987654332', N'BENTHANH  ', N'9cd7a15b-0660-ec11-9511-d09466f7ed41')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'1076791458', N'Bill Day', N'Jayde', N'1021 Suwiz Lane', N'Nữ', CAST(N'2020-02-19' AS Date), N'0528662287', N'BENTHANH  ', N'd3c0d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'1084773787', N'Luis Mullins', N'Jorge', N'1348 Junot Square', N'Nữ', CAST(N'2020-04-27' AS Date), N'0597991957', N'TANDINH   ', N'd4c0d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'1239842757', N'Rosalie Brya', N'Elva', N'1591 Hikdun Key', N'Nam', CAST(N'2020-09-21' AS Date), N'0429037076', N'TANDINH   ', N'd5c0d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'1323213371', N'Eleanor Strickland', N'Rachel', N'12 Hoanu Plaza', N'Nữ', CAST(N'2020-08-16' AS Date), N'0863352308', N'TANDINH   ', N'd6c0d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'1354818663', N'Michael Ford', N'Sally', N'1289 Sela Street', N'Nam', CAST(N'2020-07-31' AS Date), N'0183245505', N'TANDINH   ', N'd7c0d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'1447643575', N'Lora Foor', N'Hettie', N'232 Farul Place', N'Nam', CAST(N'2020-07-30' AS Date), N'0818466430', N'BENTHANH  ', N'd8c0d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'1864525183', N'Verna Patterso', N'Bettie', N'1710 Worpuk Path', N'Nam', CAST(N'2020-08-02' AS Date), N'0435938818', N'TANDINH   ', N'd9c0d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'1925833587', N'Loretta Munoz', N'Myra', N'1992 Jota Turnpike', N'Nam', CAST(N'2020-07-26' AS Date), N'0542528997', N'BENTHANH  ', N'dac0d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'2093838208', N'Francis Jacobs', N'Ane', N'834 Faawi Terrace', N'Nam', CAST(N'2020-08-06' AS Date), N'0767885450', N'BENTHANH  ', N'dbc0d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'2100455580', N'Jean Garner', N'Viola', N'367 Ipabe Way', N'Nam', CAST(N'2020-11-04' AS Date), N'0008218971', N'TANDINH   ', N'dcc0d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'2170299003', N'Violet Parsons', N'Sophie', N'1746 Vaha Court', N'Nữ', CAST(N'2020-12-09' AS Date), N'0083888360', N'BENTHANH  ', N'ddc0d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'2178217843', N'Carl Wong', N'Hunter', N'536 Pitba Highway', N'Nữ', CAST(N'2020-06-12' AS Date), N'0493786034', N'TANDINH   ', N'dec0d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'2388497095', N'Nell Welch', N'Bradley', N'10 Oruduf Trail', N'Nữ', CAST(N'2020-07-10' AS Date), N'0673396680', N'TANDINH   ', N'dfc0d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'2427662550', N'Christine Owe', N'Della', N'1406 Goze Circle', N'Nam', CAST(N'2020-11-04' AS Date), N'0833507009', N'TANDINH   ', N'e0c0d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'2472879029', N'W89jhsa', N'Jshfjh', N'hsfjhj', N'Nam', CAST(N'2021-12-18' AS Date), N'2987837489', N'BENTHANH  ', N'1f26922a-df5f-ec11-9511-d09466f7ed41')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'2487003275', N'Lester Pena', N'Glen', N'1369 Ibhar River', N'Nữ', CAST(N'2020-04-25' AS Date), N'0793858866', N'TANDINH   ', N'e1c0d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'2542545858', N'Iva Marti', N'Wesley', N'1870 Abma Path', N'Nữ', CAST(N'2020-07-08' AS Date), N'0737734990', N'BENTHANH  ', N'e2c0d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'2795357214', N'Eugenia Torres', N'Jackso', N'167 Avudib Circle', N'Nữ', CAST(N'2020-05-24' AS Date), N'0063021829', N'BENTHANH  ', N'e3c0d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'2923829481', N'Kjk', N'Kjf', N'kjks', N'Nam', CAST(N'2021-12-18' AS Date), N'9239898912', N'BENTHANH  ', N'26040f83-df5f-ec11-9511-d09466f7ed41')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'2997911875', N'Millie Stokes', N'Terry', N'378 Zikew Highway', N'Nam', CAST(N'2020-07-27' AS Date), N'0309385041', N'TANDINH   ', N'e4c0d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'3094418418', N'Corey Simmons', N'Timothy', N'1506 Kajiv River', N'Nữ', CAST(N'2020-03-19' AS Date), N'0553513938', N'TANDINH   ', N'e5c0d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'3172400787', N'Isaiah Riley', N'Marguerite', N'1044 Tejig Court', N'Nam', CAST(N'2020-03-26' AS Date), N'0472148820', N'TANDINH   ', N'e6c0d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'3263947708', N'Lina McGuire', N'Joh', N'139 Dikba Grove', N'Nam', CAST(N'2020-04-08' AS Date), N'0252546001', N'TANDINH   ', N'e7c0d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'3322011484', N'Franklin McKenzie', N'Herma', N'1504 Uzomal Heights', N'Nam', CAST(N'2020-03-10' AS Date), N'0079147859', N'TANDINH   ', N'e8c0d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'3333769874', N'Ann Ortiz', N'Chad', N'174 Amaca Heights', N'Nữ', CAST(N'2020-11-30' AS Date), N'0307568275', N'BENTHANH  ', N'e9c0d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'3385184419', N'Charlotte Holmes', N'Jay', N'1418 Zijo Pike', N'Nam', CAST(N'2020-02-13' AS Date), N'0159465546', N'BENTHANH  ', N'eac0d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'3422698929', N'Eliza Woods', N'Loretta', N'1667 Coac Manor', N'Nam', CAST(N'2020-04-15' AS Date), N'0442784922', N'BENTHANH  ', N'ebc0d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'3477436470', N'Estelle Harvey', N'Della', N'1916 Duguge River', N'Nữ', CAST(N'2020-09-16' AS Date), N'0435805768', N'TANDINH   ', N'ecc0d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'3528014672', N'Ian Clark', N'Ola', N'1990 Wazgi Street', N'Nam', CAST(N'2020-04-06' AS Date), N'0689118714', N'TANDINH   ', N'edc0d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'3741510209', N'George Walters', N'Nicholas', N'675 Tojha River', N'Nam', CAST(N'2020-05-04' AS Date), N'0758248235', N'BENTHANH  ', N'eec0d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'3850427790', N'Dustin Hanse', N'Edna', N'1612 Fezi Square', N'Nữ', CAST(N'2020-04-26' AS Date), N'0176069433', N'TANDINH   ', N'efc0d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'3898619396', N'Austin Larso', N'Isabelle', N'1691 Welvi Point', N'Nam', CAST(N'2020-03-02' AS Date), N'0204725791', N'TANDINH   ', N'f0c0d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'4034431198', N'Lucas Hoga', N'Edgar', N'1407 Mehje Manor', N'Nam', CAST(N'2020-06-24' AS Date), N'0116666468', N'TANDINH   ', N'f1c0d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'4162292212', N'Ollie Watkins', N'Maude', N'177 Olofos Court', N'Nam', CAST(N'2020-08-02' AS Date), N'0293458736', N'BENTHANH  ', N'f2c0d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'4307030062', N'Mittie Rodgers', N'Bess', N'222 Uchap Heights', N'Nữ', CAST(N'2020-12-07' AS Date), N'0796046258', N'TANDINH   ', N'f3c0d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'4326062055', N'Evelyn Wright', N'Rhoda', N'1792 Bidur Court', N'Nam', CAST(N'2020-09-06' AS Date), N'0554715313', N'BENTHANH  ', N'f4c0d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'4364671443', N'Luis Waters', N'Agnes', N'1037 Akofa Boulevard', N'Nam', CAST(N'2020-04-09' AS Date), N'0402593986', N'TANDINH   ', N'f5c0d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'4451656579', N'Adeline Alvarezy', N'Katie', N'258 Fagbe View', N'Nữ', CAST(N'2020-02-22' AS Date), N'0464557735', N'BENTHANH  ', N'f6c0d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'4465900493', N'Leo Bowew', N'Lillia', N'260 Ledoj Junctio', N'Nam', CAST(N'2020-05-30' AS Date), N'0574287805', N'BENTHANH  ', N'f7c0d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'4513681099', N'Jeffrey Robersow', N'Clifford', N'1915 Gitvoc Loop', N'Nam', CAST(N'2020-03-18' AS Date), N'0127681534', N'BENTHANH  ', N'f8c0d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'4644184359', N'Phoebe King', N'Cora', N'1425 Opime Pass', N'Nữ', CAST(N'2020-12-27' AS Date), N'0506542471', N'TANDINH   ', N'f9c0d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'4821068101', N'Mollie Yates', N'Gary', N'122 Sevgin Ridge', N'Nam', CAST(N'2020-03-19' AS Date), N'0618113627', N'BENTHANH  ', N'fac0d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'4893760874', N'Ricardo Evans', N'Leroy', N'1804 Gutjew Boulevard', N'Nữ', CAST(N'2020-11-16' AS Date), N'0852735698', N'BENTHANH  ', N'fbc0d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'4901968229', N'Leila Ramirez', N'Bradley', N'1603 Vuzi Court', N'Nữ', CAST(N'2020-11-12' AS Date), N'0888663145', N'BENTHANH  ', N'fcc0d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'5324056466', N'Harry Carpenter', N'Addie', N'998 Uvodop Highway', N'Nữ', CAST(N'2020-02-03' AS Date), N'0279513871', N'BENTHANH  ', N'fdc0d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'5532240501', N'Jessie Garcia', N'Hele', N'1092 Nogav Junctio', N'Nữ', CAST(N'2020-12-02' AS Date), N'0015978504', N'BENTHANH  ', N'fec0d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'5641845709', N'Cordelia Waters', N'Lewis', N'1915 Jimkep Highway', N'Nam', CAST(N'2020-05-17' AS Date), N'0496147896', N'BENTHANH  ', N'ffc0d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'5749474845', N'Leonard Peters', N'Lola', N'295 Buso River', N'Nữ', CAST(N'2020-09-07' AS Date), N'0658999274', N'TANDINH   ', N'00c1d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'5823311151', N'Madge Patto', N'Mattie', N'1761 Mumed Loop', N'Nam', CAST(N'2020-04-20' AS Date), N'0449515033', N'TANDINH   ', N'01c1d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'5843799763', N'Sophia Bowma', N'Sylvia', N'794 Timvov Trail', N'Nữ', CAST(N'2020-02-15' AS Date), N'0086045873', N'TANDINH   ', N'02c1d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'6021447076', N'Max Pittma', N'Harry', N'989 Gawdo Street', N'Nữ', CAST(N'2020-10-03' AS Date), N'0003306257', N'BENTHANH  ', N'03c1d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'6036197780', N'Keith Hopkins', N'Allie', N'1908 Datbed Manor', N'Nữ', CAST(N'2020-05-13' AS Date), N'0508972128', N'BENTHANH  ', N'04c1d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'6110491235', N'Adele Francis', N'Jeffrey', N'926 Vimete Court', N'Nữ', CAST(N'2020-12-06' AS Date), N'0844675138', N'TANDINH   ', N'05c1d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'6183033642', N'Lenora Wells', N'Wesley', N'1625 Eneze Ridge', N'Nam', CAST(N'2020-09-09' AS Date), N'0512516198', N'TANDINH   ', N'06c1d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'6365913052', N'Juan Payne', N'Sylvia', N'844 Morov Manor', N'Nữ', CAST(N'2020-07-01' AS Date), N'0277166405', N'BENTHANH  ', N'07c1d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'6519092873', N'Evelyn Peters', N'Esther', N'1359 Jatzic Court', N'Nam', CAST(N'2020-01-16' AS Date), N'0868159965', N'BENTHANH  ', N'08c1d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'6602924209', N'Martin Quin', N'Lora', N'1727 Sozkaw Extensio', N'Nam', CAST(N'2020-09-30' AS Date), N'0438623046', N'TANDINH   ', N'09c1d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'6613051582', N'Nancy Johnso', N'Jennie', N'1048 Leuvi Mill', N'Nam', CAST(N'2020-12-01' AS Date), N'0312029731', N'BENTHANH  ', N'0ac1d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'6724455894', N'Emma Gonzalez', N'May', N'312 Kalaci Place', N'Nam', CAST(N'2020-04-23' AS Date), N'0414877307', N'BENTHANH  ', N'0bc1d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'6800450087', N'Thomas Webster', N'Noah', N'1296 Javu Center', N'Nam', CAST(N'2020-01-22' AS Date), N'0569022591', N'BENTHANH  ', N'0cc1d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'6957125892', N'Polly Hernandez', N'Arthur', N'1092 Junrek Lane', N'Nữ', CAST(N'2020-01-22' AS Date), N'0354579135', N'BENTHANH  ', N'0dc1d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'6987942811', N'Charles Myers', N'Abbie', N'1612 Wemne Terrace', N'Nữ', CAST(N'2020-02-25' AS Date), N'0125453411', N'BENTHANH  ', N'0ec1d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'7257963148', N'Bessie Warre', N'Mildred', N'135 Ejwir Extensio', N'Nữ', CAST(N'2020-07-29' AS Date), N'0625974336', N'TANDINH   ', N'0fc1d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'7427467771', N'Rosie Brewer', N'George', N'1759 Hiove Path', N'Nam', CAST(N'2020-07-30' AS Date), N'0648526435', N'TANDINH   ', N'10c1d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'7702377389', N'Gordon Pearso', N'Margaret', N'213 Vidu Terrace', N'Nam', CAST(N'2020-05-11' AS Date), N'0677233818', N'TANDINH   ', N'11c1d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'7726539359', N'Lulu Daniels', N'Dominic', N'764 Haco Point', N'Nam', CAST(N'2020-03-06' AS Date), N'0395772928', N'BENTHANH  ', N'12c1d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'7743624774', N'Ricardo Morris', N'Cecilia', N'1319 Vote Park', N'Nữ', CAST(N'2020-10-28' AS Date), N'0603699226', N'TANDINH   ', N'13c1d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'7817884638', N'Fred Neal', N'David', N'1360 Enozip Road', N'Nam', CAST(N'2020-12-16' AS Date), N'0062228014', N'BENTHANH  ', N'14c1d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'7887845135', N'Estelle Sanders', N'Leah', N'1303 Emateh Ridge', N'Nữ', CAST(N'2020-03-03' AS Date), N'0748523841', N'BENTHANH  ', N'15c1d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'7970849626', N'Jared Schwartz', N'Lura', N'1342 Faguju Circle', N'Nam', CAST(N'2020-10-24' AS Date), N'0039104289', N'TANDINH   ', N'16c1d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'8017508324', N'Dylan Luna', N'Richard', N'215 Eripeb Way', N'Nam', CAST(N'2020-01-13' AS Date), N'0288582287', N'BENTHANH  ', N'17c1d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'8082508450', N'Jerry Obrie', N'Emilie', N'1752 Munca Plaza', N'Nữ', CAST(N'2020-03-03' AS Date), N'0172057029', N'BENTHANH  ', N'18c1d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'8187512127', N'Bertie Delgado', N'Lida', N'1603 Nenot Court', N'Nam', CAST(N'2020-04-16' AS Date), N'0827252781', N'TANDINH   ', N'19c1d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'8205616979', N'Abbie Dawso', N'Clyde', N'379 Keazu Junctio', N'Nữ', CAST(N'2020-07-08' AS Date), N'0738448728', N'TANDINH   ', N'1ac1d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'8360867893', N'Glenn Howard', N'Marcus', N'409 Huzne Center', N'Nam', CAST(N'2020-08-04' AS Date), N'0853082271', N'TANDINH   ', N'1bc1d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'8399701456', N'Polly Page', N'Ronnie', N'40 Ecohof Street', N'Nam', CAST(N'2020-11-26' AS Date), N'0492709465', N'TANDINH   ', N'1cc1d3aa-0c11-ec11-94f5-5eea1d228b33')
GO
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'8483527657', N'Adelaide Harringto', N'Eva', N'777 Ziiw Manor', N'Nữ', CAST(N'2020-10-24' AS Date), N'0655215533', N'BENTHANH  ', N'1dc1d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'8493128453', N'Christina Little', N'Roxie', N'1954 Apuuse Avenue', N'Nữ', CAST(N'2020-10-30' AS Date), N'0469238320', N'BENTHANH  ', N'1ec1d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'8731580707', N'Scott Potter', N'Harvey', N'194 Hinuz Center', N'Nam', CAST(N'2020-03-13' AS Date), N'0684042446', N'TANDINH   ', N'1fc1d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'8754485417', N'Pearl Parker', N'Jackso', N'1600 Siva Plaza', N'Nam', CAST(N'2020-02-27' AS Date), N'0406423600', N'BENTHANH  ', N'20c1d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'8767224659', N'Eugene Davidso', N'Marti', N'1314 Lepkuj Boulevard', N'Nam', CAST(N'2020-12-13' AS Date), N'0657419395', N'BENTHANH  ', N'21c1d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'8785141767', N'Lida Maldonado', N'Bobby', N'148 Nebcav Parkway', N'Nam', CAST(N'2020-10-08' AS Date), N'0654562064', N'TANDINH   ', N'22c1d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'8883907623', N'Lilly Walto', N'Lillie', N'1751 Cotih River', N'Nam', CAST(N'2020-09-17' AS Date), N'0238207026', N'TANDINH   ', N'23c1d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'8973059220', N'Mabelle Thornto', N'Sylvia', N'1684 Tiej Court', N'Nữ', CAST(N'2020-11-10' AS Date), N'0727972238', N'BENTHANH  ', N'24c1d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'9013630684', N'Theresa Day', N'Ollie', N'1044 Tihejo Turnpike', N'Nam', CAST(N'2020-06-19' AS Date), N'0753721094', N'BENTHANH  ', N'25c1d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'9155651279', N'Irene Page', N'George', N'456 Wotok Circle', N'Nữ', CAST(N'2020-07-14' AS Date), N'0774051630', N'BENTHANH  ', N'26c1d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'9223121108', N'Victor Thomas', N'Ollie', N'36 Ucese Path', N'Nam', CAST(N'2020-11-08' AS Date), N'0703671990', N'TANDINH   ', N'27c1d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'9238499822', N'Dsdfj', N'Kjkdjf', N'skdfj', N'Nam', CAST(N'2021-12-18' AS Date), N'9238492322', N'BENTHANH  ', N'76f9addd-b35f-ec11-9511-d09466f7ed41')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'9327779645', N'Cynthia Nunez', N'Gle', N'1487 Wowe Boulevard', N'Nữ', CAST(N'2020-01-23' AS Date), N'0093191696', N'BENTHANH  ', N'28c1d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'9330190909', N'Ruth Gross', N'Philip', N'711 Liwhip Drive', N'Nữ', CAST(N'2020-09-28' AS Date), N'0193573786', N'TANDINH   ', N'29c1d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'9552676361', N'Gerald Colo', N'Luis', N'506 Dotve Avenue', N'Nam', CAST(N'2020-02-03' AS Date), N'0874973106', N'BENTHANH  ', N'2ac1d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'9655760244', N'Dominic Rowe', N'Lewis', N'182 Jefrih Turnpike', N'Nam', CAST(N'2020-06-21' AS Date), N'0116093570', N'TANDINH   ', N'2bc1d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'9919312985', N'Tom Nash', N'Rodney', N'839 Jamroz Trail', N'Nữ', CAST(N'2020-07-30' AS Date), N'0897547713', N'BENTHANH  ', N'2cc1d3aa-0c11-ec11-94f5-5eea1d228b33')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'9954576082', N'Brandon Steele', N'Vincent', N'47 Hasze Avenue', N'Nam', CAST(N'2020-02-12' AS Date), N'0315749017', N'BENTHANH  ', N'2dc1d3aa-0c11-ec11-94f5-5eea1d228b33')
GO
/****** Object:  Index [MSmerge_index_965578478]    Script Date: 22/12/2021 11:10:16 ******/
CREATE UNIQUE NONCLUSTERED INDEX [MSmerge_index_965578478] ON [dbo].[KhachHang]
(
	[rowguid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[KhachHang] ADD  CONSTRAINT [CK_KHPHAI]  DEFAULT (N'Nam') FOR [PHAI]
GO
ALTER TABLE [dbo].[KhachHang] ADD  CONSTRAINT [MSmerge_df_rowguid_660E6100930E4D1FBDDA82EDBE811C58]  DEFAULT (newsequentialid()) FOR [rowguid]
GO
ALTER TABLE [dbo].[KhachHang]  WITH NOCHECK ADD  CONSTRAINT [CK__KhachHang__PHAI__59FA5E80] CHECK NOT FOR REPLICATION (([PHAI]=N'Nam' OR [PHAI]=N'Nữ'))
GO
ALTER TABLE [dbo].[KhachHang] CHECK CONSTRAINT [CK__KhachHang__PHAI__59FA5E80]
GO
USE [master]
GO
ALTER DATABASE [NGANHANG] SET  READ_WRITE 
GO
