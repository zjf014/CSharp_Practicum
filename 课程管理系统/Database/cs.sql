USE [master]
GO
/****** Object:  Database [CourseManagement]    Script Date: 06/15/2021 21:06:11 ******/
CREATE DATABASE [CourseManagement] 
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
/****** Object:  Table [dbo].[Users]    Script Date: 06/15/2021 21:06:12 ******/
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
INSERT [dbo].[Users] ([username], [password], [type]) VALUES (N'111111', N'1', N'T')
INSERT [dbo].[Users] ([username], [password], [type]) VALUES (N'111222', N'2', N'T')
INSERT [dbo].[Users] ([username], [password], [type]) VALUES (N'201900000001', N'1', N'S')
INSERT [dbo].[Users] ([username], [password], [type]) VALUES (N'201900000002', N'2', N'S')
INSERT [dbo].[Users] ([username], [password], [type]) VALUES (N'201900000003', N'3', N'S')
/****** Object:  Table [dbo].[Teacher]    Script Date: 06/15/2021 21:06:12 ******/
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
INSERT [dbo].[Teacher] ([tno], [tname], [tage], [tsex], [ttitle]) VALUES (N'111111', N'李诚', 30, N'男', N'讲师')
INSERT [dbo].[Teacher] ([tno], [tname], [tage], [tsex], [ttitle]) VALUES (N'111222', N'罗翔', 40, N'男', N'教授')
/****** Object:  Table [dbo].[Student]    Script Date: 06/15/2021 21:06:12 ******/
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
INSERT [dbo].[Student] ([sno], [sname], [ssex], [sage], [sclass], [sgrade], [ssubject]) VALUES (N'201900000001', N'张三', N'男', 20, N'1班', 2019, N'地理信息科学')
INSERT [dbo].[Student] ([sno], [sname], [ssex], [sage], [sclass], [sgrade], [ssubject]) VALUES (N'201900000002', N'李四', N'男', 21, N'2班', 2019, N'地理科学')
INSERT [dbo].[Student] ([sno], [sname], [ssex], [sage], [sclass], [sgrade], [ssubject]) VALUES (N'201900000003', N'王五', N'女', 20, N'3班', 2019, N'水文与水资源')
/****** Object:  Table [dbo].[Course]    Script Date: 06/15/2021 21:06:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Course](
	[cno] [nchar](4) NOT NULL,
	[cname] [varchar](30) NOT NULL,
	[credit] [real] NOT NULL,
	[teacher] [varchar](6) NOT NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[cno] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Course] ([cno], [cname], [credit], [teacher]) VALUES (N'0001', N'数据库', 3, N'111111')
INSERT [dbo].[Course] ([cno], [cname], [credit], [teacher]) VALUES (N'0002', N'C#', 3, N'111111')
INSERT [dbo].[Course] ([cno], [cname], [credit], [teacher]) VALUES (N'0003', N'GIS', 3.5, N'111222')
/****** Object:  Table [dbo].[Score]    Script Date: 06/15/2021 21:06:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Score](
	[cno] [nchar](4) NOT NULL,
	[sno] [varchar](12) NOT NULL,
	[score] [int] NULL,
 CONSTRAINT [PK_Score] PRIMARY KEY CLUSTERED 
(
	[cno] ASC,
	[sno] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_Score] ON [dbo].[Score] 
(
	[cno] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_Score_1] ON [dbo].[Score] 
(
	[sno] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
INSERT [dbo].[Score] ([cno], [sno], [score]) VALUES (N'0001', N'201900000001', 99)
INSERT [dbo].[Score] ([cno], [sno], [score]) VALUES (N'0001', N'201900000003', NULL)
INSERT [dbo].[Score] ([cno], [sno], [score]) VALUES (N'0002', N'201900000001', NULL)
INSERT [dbo].[Score] ([cno], [sno], [score]) VALUES (N'0003', N'201900000001', NULL)
/****** Object:  Default [DF_Teacher_tsex]    Script Date: 06/15/2021 21:06:12 ******/
ALTER TABLE [dbo].[Teacher] ADD  CONSTRAINT [DF_Teacher_tsex]  DEFAULT ('男') FOR [tsex]
GO
/****** Object:  Default [DF_Student_ssex]    Script Date: 06/15/2021 21:06:12 ******/
ALTER TABLE [dbo].[Student] ADD  CONSTRAINT [DF_Student_ssex]  DEFAULT ('男') FOR [ssex]
GO
/****** Object:  ForeignKey [FK_Course_Teacher]    Script Date: 06/15/2021 21:06:12 ******/
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Teacher] FOREIGN KEY([teacher])
REFERENCES [dbo].[Teacher] ([tno])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_Teacher]
GO
/****** Object:  ForeignKey [FK_Score_Course]    Script Date: 06/15/2021 21:06:12 ******/
ALTER TABLE [dbo].[Score]  WITH CHECK ADD  CONSTRAINT [FK_Score_Course] FOREIGN KEY([cno])
REFERENCES [dbo].[Course] ([cno])
GO
ALTER TABLE [dbo].[Score] CHECK CONSTRAINT [FK_Score_Course]
GO
/****** Object:  ForeignKey [FK_Score_Student]    Script Date: 06/15/2021 21:06:12 ******/
ALTER TABLE [dbo].[Score]  WITH CHECK ADD  CONSTRAINT [FK_Score_Student] FOREIGN KEY([sno])
REFERENCES [dbo].[Student] ([sno])
GO
ALTER TABLE [dbo].[Score] CHECK CONSTRAINT [FK_Score_Student]
GO
