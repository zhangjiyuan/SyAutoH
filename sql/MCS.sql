USE [master]
GO
/****** Object:  Database [MCS]    Script Date: 07/29/2012 10:05:10 ******/
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
/****** Object:  Table [dbo].[TransCommand]    Script Date: 07/29/2012 10:05:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransCommand](
	[Command] [nchar](10) NULL,
	[PosFrom] [int] NULL,
	[PosTo] [int] NULL,
	[FoupID] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stocker]    Script Date: 07/29/2012 10:05:11 ******/
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
/****** Object:  Table [dbo].[OHVLocal]    Script Date: 07/29/2012 10:05:11 ******/
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
/****** Object:  Table [dbo].[Foup]    Script Date: 07/29/2012 10:05:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Foup](
	[ID] [int] NULL,
	[OHV] [int] NULL,
	[STOCKER] [int] NULL,
	[Status] [nchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DevStatus]    Script Date: 07/29/2012 10:05:11 ******/
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
