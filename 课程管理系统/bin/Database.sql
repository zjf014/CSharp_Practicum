USE [master]
GO
/****** Object:  Database [CourseManagement]    Script Date: 06/02/2021 14:06:43 ******/
CREATE DATABASE [CourseManagement] ON  PRIMARY 
( NAME = N'CourseManagement', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\CourseManagement.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CourseManagement_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\CourseManagement_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CourseManagement] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CourseManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CourseManagement] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [CourseManagement] SET ANSI_NULLS OFF
GO
ALTER DATABASE [CourseManagement] SET ANSI_PADDING OFF
GO
ALTER DATABASE [CourseManagement] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [CourseManagement] SET ARITHABORT OFF
GO
ALTER DATABASE [CourseManagement] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [CourseManagement] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [CourseManagement] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [CourseManagement] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [CourseManagement] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [CourseManagement] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [CourseManagement] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [CourseManagement] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [CourseManagement] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [CourseManagement] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [CourseManagement] SET  DISABLE_BROKER
GO
ALTER DATABASE [CourseManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [CourseManagement] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [CourseManagement] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [CourseManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [CourseManagement] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [CourseManagement] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [CourseManagement] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [CourseManagement] SET  READ_WRITE
GO
ALTER DATABASE [CourseManagement] SET RECOVERY SIMPLE
GO
ALTER DATABASE [CourseManagement] SET  MULTI_USER
GO
ALTER DATABASE [CourseManagement] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [CourseManagement] SET DB_CHAINING OFF
GO
USE [CourseManagement]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 06/02/2021 14:06:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[username] [varchar](12) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[type] [varchar](10) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 06/02/2021 14:06:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Teacher](
	[tno] [varchar](6) NOT NULL,
	[tname] [varchar](20) NOT NULL,
	[tage] [int] NULL,
	[tsex] [varchar](2) NULL,
	[ttitle] [varchar](10) NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[tno] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Student]    Script Date: 06/02/2021 14:06:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Student](
	[sno] [varchar](12) NOT NULL,
	[sname] [varchar](20) NOT NULL,
	[ssex] [varchar](2) NULL,
	[sage] [int] NULL,
	[sclass] [varchar](12) NULL,
	[sgrade] [int] NULL,
	[ssubject] [varchar](20) NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[sno] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Default [DF_Teacher_tsex]    Script Date: 06/02/2021 14:06:44 ******/
ALTER TABLE [dbo].[Teacher] ADD  CONSTRAINT [DF_Teacher_tsex]  DEFAULT ('男') FOR [tsex]
GO
/****** Object:  Default [DF_Student_ssex]    Script Date: 06/02/2021 14:06:44 ******/
ALTER TABLE [dbo].[Student] ADD  CONSTRAINT [DF_Student_ssex]  DEFAULT ('男') FOR [ssex]
GO
