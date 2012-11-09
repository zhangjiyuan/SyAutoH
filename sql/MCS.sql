USE [master]
GO
/****** Object:  Database [MCS]    Script Date: 11/09/2012 16:16:25 ******/
CREATE DATABASE [MCS] ON  PRIMARY 
( NAME = N'MCS', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL10_50.AMHS\MSSQL\DATA\MCS.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'MCS_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL10_50.AMHS\MSSQL\DATA\MCS_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [MCS] SET COMPATIBILITY_LEVEL = 100
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
/****** Object:  Table [dbo].[TransCommand]    Script Date: 11/09/2012 16:16:26 ******/
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
/****** Object:  Table [dbo].[Stocker]    Script Date: 11/09/2012 16:16:26 ******/
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
/****** Object:  Table [dbo].[RightInfo]    Script Date: 11/09/2012 16:16:26 ******/
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
/****** Object:  Table [dbo].[PathInfo]    Script Date: 11/09/2012 16:16:26 ******/
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
/****** Object:  Table [dbo].[OptsRights]    Script Date: 11/09/2012 16:16:26 ******/
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
/****** Object:  Table [dbo].[OHVLocal]    Script Date: 11/09/2012 16:16:26 ******/
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
/****** Object:  Table [dbo].[McsUser]    Script Date: 11/09/2012 16:16:26 ******/
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
/****** Object:  Table [dbo].[MapInfo]    Script Date: 11/09/2012 16:16:26 ******/
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
/****** Object:  Table [dbo].[LinkSession]    Script Date: 11/09/2012 16:16:26 ******/
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
INSERT [dbo].[LinkSession] ([SessionID], [UserID], [RealRight], [OrginRight], [AccessTime], [ConnectInfo], [UserStatus]) VALUES (1, 1, 4, 4, CAST(0x0000A10400EFA3A8 AS DateTime), N'local address = 127.0.0.1:21210
remote address = 127.0.0.1:54419', 1)
INSERT [dbo].[LinkSession] ([SessionID], [UserID], [RealRight], [OrginRight], [AccessTime], [ConnectInfo], [UserStatus]) VALUES (2, 1, 4, 4, CAST(0x0000A10400F1C23C AS DateTime), N'local address = 127.0.0.1:21210
remote address = 127.0.0.1:54942', 1)
INSERT [dbo].[LinkSession] ([SessionID], [UserID], [RealRight], [OrginRight], [AccessTime], [ConnectInfo], [UserStatus]) VALUES (3, 1, 4, 4, CAST(0x0000A10400F202B0 AS DateTime), N'local address = 127.0.0.1:21210
remote address = 127.0.0.1:54983', 1)
INSERT [dbo].[LinkSession] ([SessionID], [UserID], [RealRight], [OrginRight], [AccessTime], [ConnectInfo], [UserStatus]) VALUES (4, 1, 4, 4, CAST(0x0000A10400F27330 AS DateTime), N'local address = 127.0.0.1:21210
remote address = 127.0.0.1:55100', 1)
INSERT [dbo].[LinkSession] ([SessionID], [UserID], [RealRight], [OrginRight], [AccessTime], [ConnectInfo], [UserStatus]) VALUES (5, 1, 4, 4, CAST(0x0000A10400F38568 AS DateTime), N'local address = 127.0.0.1:21210
remote address = 127.0.0.1:55355', 1)
INSERT [dbo].[LinkSession] ([SessionID], [UserID], [RealRight], [OrginRight], [AccessTime], [ConnectInfo], [UserStatus]) VALUES (6, 1, 4, 4, CAST(0x0000A10400F3A2B4 AS DateTime), N'local address = 127.0.0.1:21210
remote address = 127.0.0.1:55384', 1)
INSERT [dbo].[LinkSession] ([SessionID], [UserID], [RealRight], [OrginRight], [AccessTime], [ConnectInfo], [UserStatus]) VALUES (7, 1, 4, 4, CAST(0x0000A10400F5AE88 AS DateTime), N'local address = 127.0.0.1:21210
remote address = 127.0.0.1:56096', 1)
INSERT [dbo].[LinkSession] ([SessionID], [UserID], [RealRight], [OrginRight], [AccessTime], [ConnectInfo], [UserStatus]) VALUES (8, 1, 4, 4, CAST(0x0000A10400F7D7A8 AS DateTime), N'local address = 127.0.0.1:21210
remote address = 127.0.0.1:56685', 1)
INSERT [dbo].[LinkSession] ([SessionID], [UserID], [RealRight], [OrginRight], [AccessTime], [ConnectInfo], [UserStatus]) VALUES (9, 1, 4, 4, CAST(0x0000A10400F9AFEC AS DateTime), N'local address = 127.0.0.1:21210
remote address = 127.0.0.1:57033', 1)
INSERT [dbo].[LinkSession] ([SessionID], [UserID], [RealRight], [OrginRight], [AccessTime], [ConnectInfo], [UserStatus]) VALUES (10, 1, 4, 4, CAST(0x0000A10400FADE44 AS DateTime), N'local address = 127.0.0.1:21210
remote address = 127.0.0.1:57254', 1)
INSERT [dbo].[LinkSession] ([SessionID], [UserID], [RealRight], [OrginRight], [AccessTime], [ConnectInfo], [UserStatus]) VALUES (11, 1, 4, 4, CAST(0x0000A10400FB4438 AS DateTime), N'local address = 127.0.0.1:21210
remote address = 127.0.0.1:57291', 1)
INSERT [dbo].[LinkSession] ([SessionID], [UserID], [RealRight], [OrginRight], [AccessTime], [ConnectInfo], [UserStatus]) VALUES (12, 1, 4, 4, CAST(0x0000A10400FB7C78 AS DateTime), N'local address = 127.0.0.1:21210
remote address = 127.0.0.1:57390', 1)
INSERT [dbo].[LinkSession] ([SessionID], [UserID], [RealRight], [OrginRight], [AccessTime], [ConnectInfo], [UserStatus]) VALUES (13, 1, 4, 4, CAST(0x0000A10400FC13A4 AS DateTime), N'local address = 127.0.0.1:21210
remote address = 127.0.0.1:57512', 1)
INSERT [dbo].[LinkSession] ([SessionID], [UserID], [RealRight], [OrginRight], [AccessTime], [ConnectInfo], [UserStatus]) VALUES (14, 1, 4, 4, CAST(0x0000A10400FC5D78 AS DateTime), N'local address = 127.0.0.1:21210
remote address = 127.0.0.1:57547', 1)
INSERT [dbo].[LinkSession] ([SessionID], [UserID], [RealRight], [OrginRight], [AccessTime], [ConnectInfo], [UserStatus]) VALUES (15, 1, 4, 4, CAST(0x0000A10400FD32C0 AS DateTime), N'local address = 127.0.0.1:21210
remote address = 127.0.0.1:57730', 1)
INSERT [dbo].[LinkSession] ([SessionID], [UserID], [RealRight], [OrginRight], [AccessTime], [ConnectInfo], [UserStatus]) VALUES (16, 1, 4, 4, CAST(0x0000A10400FD5E1C AS DateTime), N'local address = 127.0.0.1:21210
remote address = 127.0.0.1:57767', 1)
INSERT [dbo].[LinkSession] ([SessionID], [UserID], [RealRight], [OrginRight], [AccessTime], [ConnectInfo], [UserStatus]) VALUES (17, 1, 4, 4, CAST(0x0000A1040100BDC8 AS DateTime), N'local address = 127.0.0.1:21210
remote address = 127.0.0.1:58293', 1)
INSERT [dbo].[LinkSession] ([SessionID], [UserID], [RealRight], [OrginRight], [AccessTime], [ConnectInfo], [UserStatus]) VALUES (18, 1, 4, 4, CAST(0x0000A1040103B654 AS DateTime), N'local address = 127.0.0.1:21210
remote address = 127.0.0.1:58725', 1)
INSERT [dbo].[LinkSession] ([SessionID], [UserID], [RealRight], [OrginRight], [AccessTime], [ConnectInfo], [UserStatus]) VALUES (19, 1, 4, 4, CAST(0x0000A1040104AB40 AS DateTime), N'local address = 127.0.0.1:21210
remote address = 127.0.0.1:58909', 1)
INSERT [dbo].[LinkSession] ([SessionID], [UserID], [RealRight], [OrginRight], [AccessTime], [ConnectInfo], [UserStatus]) VALUES (20, 1, 4, 4, CAST(0x0000A10401064C70 AS DateTime), N'local address = 127.0.0.1:21210
remote address = 127.0.0.1:59196', 1)
INSERT [dbo].[LinkSession] ([SessionID], [UserID], [RealRight], [OrginRight], [AccessTime], [ConnectInfo], [UserStatus]) VALUES (21, 1, 4, 4, CAST(0x0000A104010699C8 AS DateTime), N'local address = 127.0.0.1:21210
remote address = 127.0.0.1:59234', 2)
INSERT [dbo].[LinkSession] ([SessionID], [UserID], [RealRight], [OrginRight], [AccessTime], [ConnectInfo], [UserStatus]) VALUES (22, 1, 4, 4, CAST(0x0000A1040106A328 AS DateTime), N'local address = 127.0.0.1:21210
remote address = 127.0.0.1:59234', 1)
SET IDENTITY_INSERT [dbo].[LinkSession] OFF
/****** Object:  Table [dbo].[KeyPoints]    Script Date: 11/09/2012 16:16:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
 CONSTRAINT [PK_KeyPoints] PRIMARY KEY CLUSTERED 
(
	[Position] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Foup]    Script Date: 11/09/2012 16:16:26 ******/
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
/****** Object:  Table [dbo].[DevStatus]    Script Date: 11/09/2012 16:16:26 ******/
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
