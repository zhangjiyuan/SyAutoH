USE [MCS]
GO
/****** Object:  Index [IX_Name]    Script Date: 2012/12/18 17:38:14 ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[McsUser]') AND name = N'IX_Name')
DROP INDEX [IX_Name] ON [dbo].[McsUser]
GO
/****** Object:  Index [IX_FoupID]    Script Date: 2012/12/18 17:38:14 ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Foup]') AND name = N'IX_FoupID')
DROP INDEX [IX_FoupID] ON [dbo].[Foup]
GO
/****** Object:  Table [dbo].[TypeLane]    Script Date: 2012/12/18 17:38:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TypeLane]') AND type in (N'U'))
DROP TABLE [dbo].[TypeLane]
GO
/****** Object:  Table [dbo].[TransCommand]    Script Date: 2012/12/18 17:38:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TransCommand]') AND type in (N'U'))
DROP TABLE [dbo].[TransCommand]
GO
/****** Object:  Table [dbo].[Stocker]    Script Date: 2012/12/18 17:38:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Stocker]') AND type in (N'U'))
DROP TABLE [dbo].[Stocker]
GO
/****** Object:  Table [dbo].[RightInfo]    Script Date: 2012/12/18 17:38:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RightInfo]') AND type in (N'U'))
DROP TABLE [dbo].[RightInfo]
GO
/****** Object:  Table [dbo].[OptsRights]    Script Date: 2012/12/18 17:38:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OptsRights]') AND type in (N'U'))
DROP TABLE [dbo].[OptsRights]
GO
/****** Object:  Table [dbo].[OHVLocal]    Script Date: 2012/12/18 17:38:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OHVLocal]') AND type in (N'U'))
DROP TABLE [dbo].[OHVLocal]
GO
/****** Object:  Table [dbo].[McsUser]    Script Date: 2012/12/18 17:38:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[McsUser]') AND type in (N'U'))
DROP TABLE [dbo].[McsUser]
GO
/****** Object:  Table [dbo].[MapInfo]    Script Date: 2012/12/18 17:38:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MapInfo]') AND type in (N'U'))
DROP TABLE [dbo].[MapInfo]
GO
/****** Object:  Table [dbo].[LinkSession]    Script Date: 2012/12/18 17:38:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LinkSession]') AND type in (N'U'))
DROP TABLE [dbo].[LinkSession]
GO
/****** Object:  Table [dbo].[Lane]    Script Date: 2012/12/18 17:38:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Lane]') AND type in (N'U'))
DROP TABLE [dbo].[Lane]
GO
/****** Object:  Table [dbo].[KeyPoints]    Script Date: 2012/12/18 17:38:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KeyPoints]') AND type in (N'U'))
DROP TABLE [dbo].[KeyPoints]
GO
/****** Object:  Table [dbo].[Foup]    Script Date: 2012/12/18 17:38:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Foup]') AND type in (N'U'))
DROP TABLE [dbo].[Foup]
GO
/****** Object:  Table [dbo].[DevStatus]    Script Date: 2012/12/18 17:38:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DevStatus]') AND type in (N'U'))
DROP TABLE [dbo].[DevStatus]
GO
USE [master]
GO
/****** Object:  Database [MCS]    Script Date: 2012/12/18 17:38:14 ******/
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'MCS')
DROP DATABASE [MCS]
GO
/****** Object:  Database [MCS]    Script Date: 2012/12/18 17:38:14 ******/
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'MCS')
BEGIN
CREATE DATABASE [MCS]
END

GO
ALTER DATABASE [MCS] SET COMPATIBILITY_LEVEL = 110
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
ALTER DATABASE [MCS] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MCS] SET  MULTI_USER 
GO
ALTER DATABASE [MCS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MCS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MCS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MCS] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [MCS]
GO
/****** Object:  Table [dbo].[DevStatus]    Script Date: 2012/12/18 17:38:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DevStatus]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DevStatus](
	[ID] [int] NOT NULL,
	[Type] [nchar](10) NULL,
	[Status] [nchar](10) NULL
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Foup]    Script Date: 2012/12/18 17:38:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Foup]') AND type in (N'U'))
BEGIN
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[KeyPoints]    Script Date: 2012/12/18 17:38:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KeyPoints]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[KeyPoints](
	[Position] [int] NOT NULL,
	[Type] [tinyint] NOT NULL,
	[SpeedRate] [tinyint] NOT NULL,
	[TeachMode] [tinyint] NOT NULL,
	[OHT_ID] [tinyint] NOT NULL,
	[Lane_ID] [int] NOT NULL,
	[Prev] [int] NOT NULL,
	[Next] [int] NOT NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_KeyPoints] PRIMARY KEY CLUSTERED 
(
	[Position] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Lane]    Script Date: 2012/12/18 17:38:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Lane]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Lane](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Start] [int] NOT NULL,
	[Finish] [int] NOT NULL,
	[Prev] [int] NOT NULL,
	[Next] [int] NOT NULL,
	[Next_Frok] [int] NOT NULL,
	[Length] [int] NOT NULL,
	[MapID] [int] NOT NULL,
	[Type] [tinyint] NOT NULL,
	[Enable] [bit] NOT NULL,
 CONSTRAINT [PK_PathInfo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[LinkSession]    Script Date: 2012/12/18 17:38:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LinkSession]') AND type in (N'U'))
BEGIN
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MapInfo]    Script Date: 2012/12/18 17:38:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MapInfo]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[MapInfo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Descript] [ntext] NULL,
	[CreateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_MapInfo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[McsUser]    Script Date: 2012/12/18 17:38:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[McsUser]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[McsUser](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[UserRight] [int] NOT NULL,
 CONSTRAINT [PK_McsUser] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OHVLocal]    Script Date: 2012/12/18 17:38:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OHVLocal]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[OHVLocal](
	[ID] [int] NULL,
	[PosFrom] [int] NULL,
	[PosTo] [int] NULL,
	[FoupID] [int] NULL
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[OptsRights]    Script Date: 2012/12/18 17:38:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OptsRights]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[OptsRights](
	[OPT] [varchar](50) NOT NULL,
	[MODE] [int] NOT NULL,
	[RoleRight] [int] NOT NULL,
 CONSTRAINT [PK_OptsRights] PRIMARY KEY CLUSTERED 
(
	[OPT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RightInfo]    Script Date: 2012/12/18 17:38:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RightInfo]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[RightInfo](
	[ID] [int] NOT NULL,
	[RoleName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_RightInfo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Stocker]    Script Date: 2012/12/18 17:38:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Stocker]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Stocker](
	[ID] [int] NULL,
	[Max] [int] NULL,
	[Free] [int] NULL,
	[Status] [nchar](10) NULL
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[TransCommand]    Script Date: 2012/12/18 17:38:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TransCommand]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TransCommand](
	[Command] [nchar](10) NULL,
	[PosFrom] [int] NULL,
	[PosTo] [int] NULL,
	[FoupID] [int] NULL,
	[Status] [int] NULL
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[TypeLane]    Script Date: 2012/12/18 17:38:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TypeLane]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TypeLane](
	[TypeID] [tinyint] NOT NULL,
	[TypeName] [varchar](50) NOT NULL,
	[TypeDesc] [varchar](50) NULL
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[KeyPoints] ([Position], [Type], [SpeedRate], [TeachMode], [OHT_ID], [Lane_ID], [Prev], [Next], [Name]) VALUES (1, 1, 10, 1, 1, 0, 0, 0, NULL)
INSERT [dbo].[KeyPoints] ([Position], [Type], [SpeedRate], [TeachMode], [OHT_ID], [Lane_ID], [Prev], [Next], [Name]) VALUES (30, 2, 30, 1, 1, 0, 0, 0, NULL)
INSERT [dbo].[KeyPoints] ([Position], [Type], [SpeedRate], [TeachMode], [OHT_ID], [Lane_ID], [Prev], [Next], [Name]) VALUES (50, 4, 50, 1, 1, 0, 0, 0, NULL)
INSERT [dbo].[KeyPoints] ([Position], [Type], [SpeedRate], [TeachMode], [OHT_ID], [Lane_ID], [Prev], [Next], [Name]) VALUES (70, 8, 70, 1, 1, 0, 0, 0, NULL)
INSERT [dbo].[KeyPoints] ([Position], [Type], [SpeedRate], [TeachMode], [OHT_ID], [Lane_ID], [Prev], [Next], [Name]) VALUES (100, 16, 100, 1, 1, 0, 0, 0, NULL)
INSERT [dbo].[KeyPoints] ([Position], [Type], [SpeedRate], [TeachMode], [OHT_ID], [Lane_ID], [Prev], [Next], [Name]) VALUES (200, 1, 60, 1, 1, 0, 0, 0, NULL)
INSERT [dbo].[KeyPoints] ([Position], [Type], [SpeedRate], [TeachMode], [OHT_ID], [Lane_ID], [Prev], [Next], [Name]) VALUES (400, 4, 60, 1, 1, 0, 0, 0, NULL)
INSERT [dbo].[KeyPoints] ([Position], [Type], [SpeedRate], [TeachMode], [OHT_ID], [Lane_ID], [Prev], [Next], [Name]) VALUES (1050, 4, 50, 1, 253, 0, 0, 0, NULL)
INSERT [dbo].[KeyPoints] ([Position], [Type], [SpeedRate], [TeachMode], [OHT_ID], [Lane_ID], [Prev], [Next], [Name]) VALUES (1250, 8, 50, 1, 253, 0, 0, 0, NULL)
INSERT [dbo].[KeyPoints] ([Position], [Type], [SpeedRate], [TeachMode], [OHT_ID], [Lane_ID], [Prev], [Next], [Name]) VALUES (2000, 1, 50, 1, 14, 0, 0, 0, NULL)
SET IDENTITY_INSERT [dbo].[Lane] ON 

INSERT [dbo].[Lane] ([id], [Start], [Finish], [Prev], [Next], [Next_Frok], [Length], [MapID], [Type], [Enable]) VALUES (1, 0, 50, -1, 3, -1, 50, 1, 2, 1)
INSERT [dbo].[Lane] ([id], [Start], [Finish], [Prev], [Next], [Next_Frok], [Length], [MapID], [Type], [Enable]) VALUES (3, 50, 450, 1, 5, -1, 400, 1, 1, 1)
INSERT [dbo].[Lane] ([id], [Start], [Finish], [Prev], [Next], [Next_Frok], [Length], [MapID], [Type], [Enable]) VALUES (5, 450, 500, 3, 6, -1, 50, 1, 2, 1)
INSERT [dbo].[Lane] ([id], [Start], [Finish], [Prev], [Next], [Next_Frok], [Length], [MapID], [Type], [Enable]) VALUES (6, 500, 600, 5, 7, -1, 100, 1, 1, 1)
INSERT [dbo].[Lane] ([id], [Start], [Finish], [Prev], [Next], [Next_Frok], [Length], [MapID], [Type], [Enable]) VALUES (7, 600, 650, 6, 8, -1, 50, 1, 2, 1)
INSERT [dbo].[Lane] ([id], [Start], [Finish], [Prev], [Next], [Next_Frok], [Length], [MapID], [Type], [Enable]) VALUES (8, 650, 1050, 7, 12, -1, 400, 1, 1, 1)
INSERT [dbo].[Lane] ([id], [Start], [Finish], [Prev], [Next], [Next_Frok], [Length], [MapID], [Type], [Enable]) VALUES (12, 1050, 1100, 8, 13, -1, 50, 1, 2, 1)
INSERT [dbo].[Lane] ([id], [Start], [Finish], [Prev], [Next], [Next_Frok], [Length], [MapID], [Type], [Enable]) VALUES (13, 1100, 1200, 12, 1, -1, 100, 1, 1, 1)
SET IDENTITY_INSERT [dbo].[Lane] OFF
SET IDENTITY_INSERT [dbo].[MapInfo] ON 

INSERT [dbo].[MapInfo] ([ID], [Name], [Descript], [CreateTime]) VALUES (1, N'Single Loop', N'test rail for local', CAST(0x0000A12B00DF9260 AS DateTime))
SET IDENTITY_INSERT [dbo].[MapInfo] OFF
SET IDENTITY_INSERT [dbo].[McsUser] ON 

INSERT [dbo].[McsUser] ([id], [Name], [Password], [UserRight]) VALUES (1, N'admin', N'ad53c70e673460a260d12cdfb59e43eb9a5b7f9b', 4)
SET IDENTITY_INSERT [dbo].[McsUser] OFF
INSERT [dbo].[OptsRights] ([OPT], [MODE], [RoleRight]) VALUES (N'OHT.POS', 0, 3)
INSERT [dbo].[OptsRights] ([OPT], [MODE], [RoleRight]) VALUES (N'OHT.STS', 0, 3)
INSERT [dbo].[OptsRights] ([OPT], [MODE], [RoleRight]) VALUES (N'STK.FOUP', 0, 3)
INSERT [dbo].[RightInfo] ([ID], [RoleName]) VALUES (1, N'NoRight')
INSERT [dbo].[RightInfo] ([ID], [RoleName]) VALUES (2, N'Viewer')
INSERT [dbo].[RightInfo] ([ID], [RoleName]) VALUES (3, N'Guest')
INSERT [dbo].[RightInfo] ([ID], [RoleName]) VALUES (4, N'Operator')
INSERT [dbo].[RightInfo] ([ID], [RoleName]) VALUES (5, N'Builder')
INSERT [dbo].[RightInfo] ([ID], [RoleName]) VALUES (6, N'Admin')
INSERT [dbo].[RightInfo] ([ID], [RoleName]) VALUES (7, N'SuperAdmin')
INSERT [dbo].[TypeLane] ([TypeID], [TypeName], [TypeDesc]) VALUES (1, N'line', NULL)
INSERT [dbo].[TypeLane] ([TypeID], [TypeName], [TypeDesc]) VALUES (2, N'curve', NULL)
INSERT [dbo].[TypeLane] ([TypeID], [TypeName], [TypeDesc]) VALUES (3, N'fork', NULL)
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_FoupID]    Script Date: 2012/12/18 17:38:14 ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Foup]') AND name = N'IX_FoupID')
CREATE UNIQUE NONCLUSTERED INDEX [IX_FoupID] ON [dbo].[Foup]
(
	[FoupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Name]    Script Date: 2012/12/18 17:38:14 ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[McsUser]') AND name = N'IX_Name')
CREATE UNIQUE NONCLUSTERED INDEX [IX_Name] ON [dbo].[McsUser]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [MCS] SET  READ_WRITE 
GO
