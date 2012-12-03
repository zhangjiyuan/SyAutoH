
USE [master]
GO
IF EXISTS (SELECT name FROM sys.databases WHERE name = N'MCS')
BEGIN
	DROP DATABASE [MCS]
END
GO
CREATE DATABASE [MCS]
GO
USE [MCS]
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MCS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MCS] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [MCS] SET ANSI_NULLS OFF
GO
ALTER DATABASE [MCS] SET ANSI_PADDING OFF
GO
ALTER DATABASE [MCS] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [MCS] SET ARITHABORT OFF
GO
ALTER DATABASE [MCS] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [MCS] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [MCS] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [MCS] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [MCS] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [MCS] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [MCS] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [MCS] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [MCS] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [MCS] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [MCS] SET  DISABLE_BROKER
GO
ALTER DATABASE [MCS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [MCS] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [MCS] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [MCS] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [MCS] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [MCS] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [MCS] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [MCS] SET  READ_WRITE
GO
ALTER DATABASE [MCS] SET RECOVERY SIMPLE
GO
ALTER DATABASE [MCS] SET  MULTI_USER
GO
ALTER DATABASE [MCS] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [MCS] SET DB_CHAINING OFF
GO
USE [MCS]
GO
/****** Object:  Table [dbo].[TransCommand]    Script Date: 11/30/2012 10:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransCommand](
	[Command] [nchar](10) NULL,
	[PosFrom] [int] NULL,
	[PosTo] [int] NULL,
	[FoupID] [int] NULL,
	[Status] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stocker]    Script Date: 11/30/2012 10:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stocker](
	[ID] [int] NULL,
	[Max] [int] NULL,
	[Free] [int] NULL,
	[Status] [nchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RightInfo]    Script Date: 11/30/2012 10:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RightInfo](
	[ID] [int] NOT NULL,
	[RoleName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_RightInfo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[RightInfo] ([ID], [RoleName]) VALUES (1, N'NoRight')
INSERT [dbo].[RightInfo] ([ID], [RoleName]) VALUES (2, N'Viewer')
INSERT [dbo].[RightInfo] ([ID], [RoleName]) VALUES (3, N'Guest')
INSERT [dbo].[RightInfo] ([ID], [RoleName]) VALUES (4, N'Operator')
INSERT [dbo].[RightInfo] ([ID], [RoleName]) VALUES (5, N'Builder')
INSERT [dbo].[RightInfo] ([ID], [RoleName]) VALUES (6, N'Admin')
INSERT [dbo].[RightInfo] ([ID], [RoleName]) VALUES (7, N'SuperAdmin')
/****** Object:  Table [dbo].[PathInfo]    Script Date: 11/30/2012 10:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PathInfo](
	[id] [int] NOT NULL,
	[Start] [int] NOT NULL,
	[Finish] [int] NOT NULL,
	[Prev] [int] NOT NULL,
	[Next] [int] NOT NULL,
	[MapID] [int] NOT NULL,
	[Type] [tinyint] NOT NULL,
	[Next2] [int] NOT NULL,
 CONSTRAINT [PK_PathInfo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OptsRights]    Script Date: 11/30/2012 10:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OptsRights](
	[OPT] [varchar](50) NOT NULL,
	[MODE] [int] NOT NULL,
	[RoleRight] [int] NOT NULL,
 CONSTRAINT [PK_OptsRights] PRIMARY KEY CLUSTERED 
(
	[OPT] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[OptsRights] ([OPT], [MODE], [RoleRight]) VALUES (N'OHT.POS', 0, 3)
INSERT [dbo].[OptsRights] ([OPT], [MODE], [RoleRight]) VALUES (N'OHT.STS', 0, 3)
INSERT [dbo].[OptsRights] ([OPT], [MODE], [RoleRight]) VALUES (N'STK.FOUP', 0, 3)
/****** Object:  Table [dbo].[OHVLocal]    Script Date: 11/30/2012 10:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OHVLocal](
	[ID] [int] NULL,
	[PosFrom] [int] NULL,
	[PosTo] [int] NULL,
	[FoupID] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[McsUser]    Script Date: 11/30/2012 10:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[McsUser](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[UserRight] [int] NOT NULL,
 CONSTRAINT [PK_McsUser] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Name] ON [dbo].[McsUser] 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[McsUser] ON
INSERT [dbo].[McsUser] ([id], [Name], [Password], [UserRight]) VALUES (1, N'admin', N'ad53c70e673460a260d12cdfb59e43eb9a5b7f9b', 4)
SET IDENTITY_INSERT [dbo].[McsUser] OFF
/****** Object:  Table [dbo].[MapInfo]    Script Date: 11/30/2012 10:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MapInfo](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Descript] [ntext] NULL,
	[CreateTime] [datetime] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LinkSession]    Script Date: 11/30/2012 10:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LinkSession](
	[SessionID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[RealRight] [int] NOT NULL,
	[OrginRight] [int] NOT NULL,
	[AccessTime] [datetime] NOT NULL,
	[ConnectInfo] [varchar](200) NOT NULL,
	[UserStatus] [int] NOT NULL,
 CONSTRAINT [PK_LinkSession] PRIMARY KEY CLUSTERED 
(
	[SessionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[LinkSession] ON
INSERT [dbo].[LinkSession] ([SessionID], [UserID], [RealRight], [OrginRight], [AccessTime], [ConnectInfo], [UserStatus]) VALUES (164, 1, 4, 4, CAST(0x0000A11100F661D4 AS DateTime), N'local address = 127.0.0.1:21210
remote address = 127.0.0.1:57678', 2)
INSERT [dbo].[LinkSession] ([SessionID], [UserID], [RealRight], [OrginRight], [AccessTime], [ConnectInfo], [UserStatus]) VALUES (167, 1, 4, 4, CAST(0x0000A11100FD8E28 AS DateTime), N'local address = 127.0.0.1:21210
remote address = 127.0.0.1:59424', 1)
INSERT [dbo].[LinkSession] ([SessionID], [UserID], [RealRight], [OrginRight], [AccessTime], [ConnectInfo], [UserStatus]) VALUES (172, 1, 4, 4, CAST(0x0000A1110106D208 AS DateTime), N'local address = 127.0.0.1:21210
remote address = 127.0.0.1:63778', 1)
INSERT [dbo].[LinkSession] ([SessionID], [UserID], [RealRight], [OrginRight], [AccessTime], [ConnectInfo], [UserStatus]) VALUES (229, 1, 4, 4, CAST(0x0000A11500F8A138 AS DateTime), N'local address = 127.0.0.1:21210
remote address = 127.0.0.1:6187', 1)
INSERT [dbo].[LinkSession] ([SessionID], [UserID], [RealRight], [OrginRight], [AccessTime], [ConnectInfo], [UserStatus]) VALUES (230, 1, 4, 4, CAST(0x0000A11500F8D39C AS DateTime), N'local address = 127.0.0.1:21210
remote address = 127.0.0.1:6212', 1)
INSERT [dbo].[LinkSession] ([SessionID], [UserID], [RealRight], [OrginRight], [AccessTime], [ConnectInfo], [UserStatus]) VALUES (231, 1, 4, 4, CAST(0x0000A11500F8E9E0 AS DateTime), N'local address = 127.0.0.1:21210
remote address = 127.0.0.1:6381', 1)
INSERT [dbo].[LinkSession] ([SessionID], [UserID], [RealRight], [OrginRight], [AccessTime], [ConnectInfo], [UserStatus]) VALUES (232, 1, 4, 4, CAST(0x0000A11500F941C4 AS DateTime), N'local address = 127.0.0.1:21210
remote address = 127.0.0.1:6450', 1)
INSERT [dbo].[LinkSession] ([SessionID], [UserID], [RealRight], [OrginRight], [AccessTime], [ConnectInfo], [UserStatus]) VALUES (234, 1, 4, 4, CAST(0x0000A11500FA4BC8 AS DateTime), N'local address = 127.0.0.1:21210
remote address = 127.0.0.1:6763', 1)
INSERT [dbo].[LinkSession] ([SessionID], [UserID], [RealRight], [OrginRight], [AccessTime], [ConnectInfo], [UserStatus]) VALUES (235, 1, 4, 4, CAST(0x0000A11500FA797C AS DateTime), N'local address = 127.0.0.1:21210
remote address = 127.0.0.1:6792', 1)
INSERT [dbo].[LinkSession] ([SessionID], [UserID], [RealRight], [OrginRight], [AccessTime], [ConnectInfo], [UserStatus]) VALUES (236, 1, 4, 4, CAST(0x0000A11500FB04F0 AS DateTime), N'local address = 127.0.0.1:21210
remote address = 127.0.0.1:6954', 1)
INSERT [dbo].[LinkSession] ([SessionID], [UserID], [RealRight], [OrginRight], [AccessTime], [ConnectInfo], [UserStatus]) VALUES (237, 1, 4, 4, CAST(0x0000A11500FB63DC AS DateTime), N'local address = 127.0.0.1:21210
remote address = 127.0.0.1:7150', 1)
INSERT [dbo].[LinkSession] ([SessionID], [UserID], [RealRight], [OrginRight], [AccessTime], [ConnectInfo], [UserStatus]) VALUES (238, 1, 4, 4, CAST(0x0000A11500FB8F38 AS DateTime), N'local address = 127.0.0.1:21210
remote address = 127.0.0.1:7180', 1)
INSERT [dbo].[LinkSession] ([SessionID], [UserID], [RealRight], [OrginRight], [AccessTime], [ConnectInfo], [UserStatus]) VALUES (239, 1, 4, 4, CAST(0x0000A11500FC579C AS DateTime), N'local address = 127.0.0.1:21210
remote address = 127.0.0.1:7469', 1)
INSERT [dbo].[LinkSession] ([SessionID], [UserID], [RealRight], [OrginRight], [AccessTime], [ConnectInfo], [UserStatus]) VALUES (240, 1, 4, 4, CAST(0x0000A11500FCCA74 AS DateTime), N'local address = 127.0.0.1:21210
remote address = 127.0.0.1:7655', 1)
INSERT [dbo].[LinkSession] ([SessionID], [UserID], [RealRight], [OrginRight], [AccessTime], [ConnectInfo], [UserStatus]) VALUES (245, 1, 4, 4, CAST(0x0000A11500FFC684 AS DateTime), N'local address = 127.0.0.1:21210
remote address = 127.0.0.1:8640', 1)
INSERT [dbo].[LinkSession] ([SessionID], [UserID], [RealRight], [OrginRight], [AccessTime], [ConnectInfo], [UserStatus]) VALUES (246, 1, 4, 4, CAST(0x0000A11501000E00 AS DateTime), N'local address = 127.0.0.1:21210
remote address = 127.0.0.1:8780', 1)
INSERT [dbo].[LinkSession] ([SessionID], [UserID], [RealRight], [OrginRight], [AccessTime], [ConnectInfo], [UserStatus]) VALUES (247, 1, 4, 4, CAST(0x0000A11501003254 AS DateTime), N'local address = 127.0.0.1:21210
remote address = 127.0.0.1:8797', 1)
INSERT [dbo].[LinkSession] ([SessionID], [UserID], [RealRight], [OrginRight], [AccessTime], [ConnectInfo], [UserStatus]) VALUES (248, 1, 4, 4, CAST(0x0000A11501004D48 AS DateTime), N'local address = 127.0.0.1:21210
remote address = 127.0.0.1:8863', 1)
INSERT [dbo].[LinkSession] ([SessionID], [UserID], [RealRight], [OrginRight], [AccessTime], [ConnectInfo], [UserStatus]) VALUES (249, 1, 4, 4, CAST(0x0000A1150100BA44 AS DateTime), N'local address = 127.0.0.1:21210
remote address = 127.0.0.1:9027', 1)
INSERT [dbo].[LinkSession] ([SessionID], [UserID], [RealRight], [OrginRight], [AccessTime], [ConnectInfo], [UserStatus]) VALUES (253, 1, 4, 4, CAST(0x0000A115010404D8 AS DateTime), N'local address = 127.0.0.1:21210
remote address = 127.0.0.1:10164', 1)
INSERT [dbo].[LinkSession] ([SessionID], [UserID], [RealRight], [OrginRight], [AccessTime], [ConnectInfo], [UserStatus]) VALUES (254, 1, 4, 4, CAST(0x0000A11501050450 AS DateTime), N'local address = 127.0.0.1:21210
remote address = 127.0.0.1:10512', 1)
INSERT [dbo].[LinkSession] ([SessionID], [UserID], [RealRight], [OrginRight], [AccessTime], [ConnectInfo], [UserStatus]) VALUES (255, 1, 4, 4, CAST(0x0000A11600A6A16C AS DateTime), N'local address = 127.0.0.1:21210
remote address = 127.0.0.1:16037', 1)
INSERT [dbo].[LinkSession] ([SessionID], [UserID], [RealRight], [OrginRight], [AccessTime], [ConnectInfo], [UserStatus]) VALUES (256, 1, 4, 4, CAST(0x0000A11600A78BCC AS DateTime), N'local address = 127.0.0.1:21210
remote address = 127.0.0.1:16070', 1)
INSERT [dbo].[LinkSession] ([SessionID], [UserID], [RealRight], [OrginRight], [AccessTime], [ConnectInfo], [UserStatus]) VALUES (258, 1, 4, 4, CAST(0x0000A11600F67DF4 AS DateTime), N'local address = 127.0.0.1:21210
remote address = 127.0.0.1:22031', 1)
INSERT [dbo].[LinkSession] ([SessionID], [UserID], [RealRight], [OrginRight], [AccessTime], [ConnectInfo], [UserStatus]) VALUES (259, 1, 4, 4, CAST(0x0000A11600F75C9C AS DateTime), N'local address = 127.0.0.1:21210
remote address = 127.0.0.1:22060', 1)
INSERT [dbo].[LinkSession] ([SessionID], [UserID], [RealRight], [OrginRight], [AccessTime], [ConnectInfo], [UserStatus]) VALUES (272, 1, 4, 4, CAST(0x0000A1160104292C AS DateTime), N'local address = 127.0.0.1:21210
remote address = 127.0.0.1:22714', 1)
INSERT [dbo].[LinkSession] ([SessionID], [UserID], [RealRight], [OrginRight], [AccessTime], [ConnectInfo], [UserStatus]) VALUES (273, 1, 4, 4, CAST(0x0000A1160107A4F8 AS DateTime), N'local address = 127.0.0.1:21210
remote address = 127.0.0.1:23679', 1)
INSERT [dbo].[LinkSession] ([SessionID], [UserID], [RealRight], [OrginRight], [AccessTime], [ConnectInfo], [UserStatus]) VALUES (279, 1, 4, 4, CAST(0x0000A116010C30A4 AS DateTime), N'local address = 127.0.0.1:21210
remote address = 127.0.0.1:24805', 1)
INSERT [dbo].[LinkSession] ([SessionID], [UserID], [RealRight], [OrginRight], [AccessTime], [ConnectInfo], [UserStatus]) VALUES (281, 1, 4, 4, CAST(0x0000A116010D4660 AS DateTime), N'local address = 127.0.0.1:21210
remote address = 127.0.0.1:25046', 1)
INSERT [dbo].[LinkSession] ([SessionID], [UserID], [RealRight], [OrginRight], [AccessTime], [ConnectInfo], [UserStatus]) VALUES (282, 1, 4, 4, CAST(0x0000A116010DC4F0 AS DateTime), N'local address = 127.0.0.1:21210
remote address = 127.0.0.1:25181', 1)
INSERT [dbo].[LinkSession] ([SessionID], [UserID], [RealRight], [OrginRight], [AccessTime], [ConnectInfo], [UserStatus]) VALUES (292, 1, 4, 4, CAST(0x0000A11700ADB77C AS DateTime), N'local address = 127.0.0.1:21210
remote address = 127.0.0.1:35082', 1)
INSERT [dbo].[LinkSession] ([SessionID], [UserID], [RealRight], [OrginRight], [AccessTime], [ConnectInfo], [UserStatus]) VALUES (294, 1, 4, 4, CAST(0x0000A11801087B6C AS DateTime), N'local address = 127.0.0.1:21210
remote address = 127.0.0.1:23678', 1)
SET IDENTITY_INSERT [dbo].[LinkSession] OFF
/****** Object:  Table [dbo].[KeyPoints]    Script Date: 11/30/2012 10:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KeyPoints](
	[Position] [int] NOT NULL,
	[Type] [tinyint] NOT NULL,
	[SpeedRate] [tinyint] NOT NULL,
	[TeachMode] [tinyint] NOT NULL,
	[OHT_ID] [tinyint] NOT NULL,
	[Rail_ID] [tinyint] NOT NULL,
	[Prev] [int] NOT NULL,
	[Next] [int] NOT NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_KeyPoints] PRIMARY KEY CLUSTERED 
(
	[Position] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[KeyPoints] ([Position], [Type], [SpeedRate], [TeachMode], [OHT_ID], [Rail_ID], [Prev], [Next], [Name]) VALUES (1, 1, 10, 1, 1, 0, 0, 0, NULL)
INSERT [dbo].[KeyPoints] ([Position], [Type], [SpeedRate], [TeachMode], [OHT_ID], [Rail_ID], [Prev], [Next], [Name]) VALUES (30, 2, 30, 1, 1, 0, 0, 0, NULL)
INSERT [dbo].[KeyPoints] ([Position], [Type], [SpeedRate], [TeachMode], [OHT_ID], [Rail_ID], [Prev], [Next], [Name]) VALUES (50, 4, 50, 1, 1, 0, 0, 0, NULL)
INSERT [dbo].[KeyPoints] ([Position], [Type], [SpeedRate], [TeachMode], [OHT_ID], [Rail_ID], [Prev], [Next], [Name]) VALUES (70, 8, 70, 1, 1, 0, 0, 0, NULL)
INSERT [dbo].[KeyPoints] ([Position], [Type], [SpeedRate], [TeachMode], [OHT_ID], [Rail_ID], [Prev], [Next], [Name]) VALUES (100, 16, 100, 1, 1, 0, 0, 0, NULL)
INSERT [dbo].[KeyPoints] ([Position], [Type], [SpeedRate], [TeachMode], [OHT_ID], [Rail_ID], [Prev], [Next], [Name]) VALUES (2000, 1, 50, 1, 14, 0, 0, 0, NULL)
/****** Object:  Table [dbo].[Foup]    Script Date: 11/30/2012 10:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Foup](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Local] [int] NOT NULL,
	[Type] [tinyint] NOT NULL,
	[Status] [tinyint] NOT NULL,
	[Lot] [varchar](50) NULL,
	[FoupID] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Foup] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_FoupID] ON [dbo].[Foup] 
(
	[FoupID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DevStatus]    Script Date: 11/30/2012 10:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DevStatus](
	[ID] [int] NOT NULL,
	[Type] [nchar](10) NULL,
	[Status] [nchar](10) NULL
) ON [PRIMARY]
GO
