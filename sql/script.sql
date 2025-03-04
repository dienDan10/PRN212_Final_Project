USE [master]
GO
/****** Object:  Database [library_management]    Script Date: 7/17/2024 11:15:17 PM ******/
CREATE DATABASE [library_management]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'library_management', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\library_management.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'library_management_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\library_management_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [library_management] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [library_management].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [library_management] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [library_management] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [library_management] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [library_management] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [library_management] SET ARITHABORT OFF 
GO
ALTER DATABASE [library_management] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [library_management] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [library_management] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [library_management] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [library_management] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [library_management] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [library_management] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [library_management] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [library_management] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [library_management] SET  ENABLE_BROKER 
GO
ALTER DATABASE [library_management] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [library_management] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [library_management] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [library_management] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [library_management] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [library_management] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [library_management] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [library_management] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [library_management] SET  MULTI_USER 
GO
ALTER DATABASE [library_management] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [library_management] SET DB_CHAINING OFF 
GO
ALTER DATABASE [library_management] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [library_management] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [library_management] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [library_management] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [library_management] SET QUERY_STORE = ON
GO
ALTER DATABASE [library_management] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [library_management]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 7/17/2024 11:15:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[BookId] [int] IDENTITY(1,1) NOT NULL,
	[BookName] [nvarchar](100) NULL,
	[Author] [nvarchar](100) NULL,
	[Publisher] [nvarchar](100) NULL,
	[PublishDate] [date] NULL,
	[Price] [money] NULL,
	[Quantity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Borrows]    Script Date: 7/17/2024 11:15:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Borrows](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NULL,
	[BookId] [int] NULL,
	[BorrowDate] [date] NULL,
	[ReturnDate] [date] NULL,
	[Status] [nvarchar](50) NULL,
	[quantity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Librarians]    Script Date: 7/17/2024 11:15:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Librarians](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NULL,
	[Code] [nvarchar](30) NULL,
	[Phone] [varchar](30) NULL,
	[Email] [varchar](30) NULL,
	[Password] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 7/17/2024 11:15:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[StudentId] [int] IDENTITY(1,1) NOT NULL,
	[StudentCode] [varchar](10) NULL,
	[Name] [nvarchar](30) NULL,
	[Phone] [varchar](20) NULL,
	[Email] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Books] ON 

INSERT [dbo].[Books] ([BookId], [BookName], [Author], [Publisher], [PublishDate], [Price], [Quantity]) VALUES (1, N'Cây Cam Ngọt Của Tôi', N' José Mauro de Vasconcelos', N'Nhà Xuất Bản Hội Nhà Văn', CAST(N'2023-07-04' AS Date), 75500.0000, 50)
INSERT [dbo].[Books] ([BookId], [BookName], [Author], [Publisher], [PublishDate], [Price], [Quantity]) VALUES (2, N'Chiến Binh Cầu Vồng (Tái Bản 2020)', N' Andrea Hirata', N'Nhà Xuất Bản Hội Nhà Văn', CAST(N'2021-06-09' AS Date), 83800.0000, 66)
INSERT [dbo].[Books] ([BookId], [BookName], [Author], [Publisher], [PublishDate], [Price], [Quantity]) VALUES (3, N'Tam Thể 1 (Tái Bản)', N'Lưu Từ Hân', N'Nhà Xuất Bản Hà Nội', CAST(N'2020-12-14' AS Date), 115000.0000, 26)
INSERT [dbo].[Books] ([BookId], [BookName], [Author], [Publisher], [PublishDate], [Price], [Quantity]) VALUES (4, N'Tam Thể - Khu Rừng Đen Tối', N'Lưu Từ Hân', N'NXB Hội Nhà Văn', CAST(N'2020-12-03' AS Date), 171000.0000, 56)
INSERT [dbo].[Books] ([BookId], [BookName], [Author], [Publisher], [PublishDate], [Price], [Quantity]) VALUES (5, N'Đàn Ông Sao Hỏa Đàn Bà Sao Kim ', N'John Gray', N'NXB Hội Nhà Văn', CAST(N'2020-12-16' AS Date), 125900.0000, 30)
SET IDENTITY_INSERT [dbo].[Books] OFF
GO
SET IDENTITY_INSERT [dbo].[Borrows] ON 

INSERT [dbo].[Borrows] ([Id], [StudentId], [BookId], [BorrowDate], [ReturnDate], [Status], [quantity]) VALUES (2, 2, 1, CAST(N'2024-07-17' AS Date), CAST(N'2024-07-17' AS Date), N'Đã trả', 1)
INSERT [dbo].[Borrows] ([Id], [StudentId], [BookId], [BorrowDate], [ReturnDate], [Status], [quantity]) VALUES (3, 2, 2, CAST(N'2024-07-17' AS Date), NULL, N'Đang mượn', 2)
INSERT [dbo].[Borrows] ([Id], [StudentId], [BookId], [BorrowDate], [ReturnDate], [Status], [quantity]) VALUES (4, 2, 4, CAST(N'2024-07-17' AS Date), NULL, N'Đang mượn', 2)
INSERT [dbo].[Borrows] ([Id], [StudentId], [BookId], [BorrowDate], [ReturnDate], [Status], [quantity]) VALUES (5, 2, 3, CAST(N'2024-07-17' AS Date), NULL, N'Đang mượn', 1)
INSERT [dbo].[Borrows] ([Id], [StudentId], [BookId], [BorrowDate], [ReturnDate], [Status], [quantity]) VALUES (6, 1, 3, CAST(N'2024-07-17' AS Date), NULL, N'Đang mượn', 1)
INSERT [dbo].[Borrows] ([Id], [StudentId], [BookId], [BorrowDate], [ReturnDate], [Status], [quantity]) VALUES (7, 1, 4, CAST(N'2024-07-17' AS Date), NULL, N'Đang mượn', 1)
INSERT [dbo].[Borrows] ([Id], [StudentId], [BookId], [BorrowDate], [ReturnDate], [Status], [quantity]) VALUES (8, 1, 5, CAST(N'2024-07-17' AS Date), CAST(N'2024-07-17' AS Date), N'Đã trả', 1)
INSERT [dbo].[Borrows] ([Id], [StudentId], [BookId], [BorrowDate], [ReturnDate], [Status], [quantity]) VALUES (9, 3, 5, CAST(N'2024-07-17' AS Date), NULL, N'Đang mượn', 1)
INSERT [dbo].[Borrows] ([Id], [StudentId], [BookId], [BorrowDate], [ReturnDate], [Status], [quantity]) VALUES (10, 3, 4, CAST(N'2024-07-17' AS Date), NULL, N'Đang mượn', 1)
INSERT [dbo].[Borrows] ([Id], [StudentId], [BookId], [BorrowDate], [ReturnDate], [Status], [quantity]) VALUES (11, 3, 3, CAST(N'2024-07-17' AS Date), NULL, N'Đang mượn', 1)
INSERT [dbo].[Borrows] ([Id], [StudentId], [BookId], [BorrowDate], [ReturnDate], [Status], [quantity]) VALUES (12, 3, 2, CAST(N'2024-07-17' AS Date), NULL, N'Đang mượn', 1)
INSERT [dbo].[Borrows] ([Id], [StudentId], [BookId], [BorrowDate], [ReturnDate], [Status], [quantity]) VALUES (13, 4, 5, CAST(N'2024-07-17' AS Date), NULL, N'Đang mượn', 1)
INSERT [dbo].[Borrows] ([Id], [StudentId], [BookId], [BorrowDate], [ReturnDate], [Status], [quantity]) VALUES (14, 4, 3, CAST(N'2024-07-17' AS Date), NULL, N'Đang mượn', 1)
INSERT [dbo].[Borrows] ([Id], [StudentId], [BookId], [BorrowDate], [ReturnDate], [Status], [quantity]) VALUES (15, 4, 2, CAST(N'2024-07-17' AS Date), NULL, N'Đang mượn', 1)
SET IDENTITY_INSERT [dbo].[Borrows] OFF
GO
SET IDENTITY_INSERT [dbo].[Librarians] ON 

INSERT [dbo].[Librarians] ([Id], [Name], [Code], [Phone], [Email], [Password]) VALUES (1, N'Tran Dinh Tu', N'LB123456', N'1122334455', N'tu@gmail.com', N'trandinhtu')
SET IDENTITY_INSERT [dbo].[Librarians] OFF
GO
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([StudentId], [StudentCode], [Name], [Phone], [Email]) VALUES (1, N'HE181524', N'Tran Dinh Tu', N'123456789', N'tutran@gmail.com')
INSERT [dbo].[Students] ([StudentId], [StudentCode], [Name], [Phone], [Email]) VALUES (2, N'HE111222', N'Ta Viet Hoang', N'121212121', N'hoang@gmail.com')
INSERT [dbo].[Students] ([StudentId], [StudentCode], [Name], [Phone], [Email]) VALUES (3, N'HE123456', N'Ta Minh Dang', N'45454545', N'dang@gmail.com')
INSERT [dbo].[Students] ([StudentId], [StudentCode], [Name], [Phone], [Email]) VALUES (4, N'HE478458', N'Lai Vu Hai Anh', N'1235689', N'haianh@gmail.com')
SET IDENTITY_INSERT [dbo].[Students] OFF
GO
ALTER TABLE [dbo].[Borrows]  WITH CHECK ADD FOREIGN KEY([BookId])
REFERENCES [dbo].[Books] ([BookId])
GO
ALTER TABLE [dbo].[Borrows]  WITH CHECK ADD FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([StudentId])
GO
USE [master]
GO
ALTER DATABASE [library_management] SET  READ_WRITE 
GO
