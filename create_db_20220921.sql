USE [master]
GO
/****** Object:  Database [SentimentDb]    Script Date: 2022. 09. 28. 10:34:45 ******/
CREATE DATABASE [SentimentDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SentimentDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\SentimentDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SentimentDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\SentimentDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [SentimentDb] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SentimentDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SentimentDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SentimentDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SentimentDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SentimentDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SentimentDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [SentimentDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SentimentDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SentimentDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SentimentDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SentimentDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SentimentDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SentimentDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SentimentDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SentimentDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SentimentDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [SentimentDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SentimentDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SentimentDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SentimentDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SentimentDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SentimentDb] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [SentimentDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SentimentDb] SET RECOVERY FULL 
GO
ALTER DATABASE [SentimentDb] SET  MULTI_USER 
GO
ALTER DATABASE [SentimentDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SentimentDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SentimentDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SentimentDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SentimentDb] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'SentimentDb', N'ON'
GO
ALTER DATABASE [SentimentDb] SET QUERY_STORE = OFF
GO
USE [SentimentDb]
GO
/****** Object:  Table [dbo].[Ratings]    Script Date: 2022. 09. 28. 10:34:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ratings](
	[OID] [bigint] IDENTITY(1,1) NOT NULL,
	[SentenceOID] [bigint] NOT NULL,
	[SentimentUserOID] [bigint] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[IsPositive] [bit] NULL,
 CONSTRAINT [PK_Ratings] PRIMARY KEY CLUSTERED 
(
	[OID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sentences]    Script Date: 2022. 09. 28. 10:34:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sentences](
	[OID] [bigint] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](max) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Sentences] PRIMARY KEY CLUSTERED 
(
	[OID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SentimentUsers]    Script Date: 2022. 09. 28. 10:34:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SentimentUsers](
	[OID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[FirstName] [nvarchar](100) NULL,
	[LastName] [nvarchar](100) NULL,
	[DateOfBirth] [datetime2](7) NOT NULL,
	[IsEnabled] [bit] NOT NULL,
 CONSTRAINT [PK_SentimentUsers] PRIMARY KEY CLUSTERED 
(
	[OID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Sentences] ON 

INSERT [dbo].[Sentences] ([OID], [Text], [CreatedAt]) VALUES (1, N'Géza kék az ég', CAST(N'2022-09-21T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Sentences] ([OID], [Text], [CreatedAt]) VALUES (2, N'A benzinárak további emelkedése várható', CAST(N'2022-09-21T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Sentences] ([OID], [Text], [CreatedAt]) VALUES (3, N'A vizsga emaitt nagyon nehéz lesz', CAST(N'2022-09-20T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Sentences] OFF
SET IDENTITY_INSERT [dbo].[SentimentUsers] ON 

INSERT [dbo].[SentimentUsers] ([OID], [UserName], [FirstName], [LastName], [DateOfBirth], [IsEnabled]) VALUES (1, N'admin', N'System', N'Admin', CAST(N'1998-03-27T00:00:00.0000000' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[SentimentUsers] OFF
/****** Object:  Index [IX_Ratings_SentenceOID]    Script Date: 2022. 09. 28. 10:34:46 ******/
CREATE NONCLUSTERED INDEX [IX_Ratings_SentenceOID] ON [dbo].[Ratings]
(
	[SentenceOID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Ratings_SentimentUserOID]    Script Date: 2022. 09. 28. 10:34:46 ******/
CREATE NONCLUSTERED INDEX [IX_Ratings_SentimentUserOID] ON [dbo].[Ratings]
(
	[SentimentUserOID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Ratings]  WITH CHECK ADD  CONSTRAINT [FK_Ratings_Sentences_SentenceOID] FOREIGN KEY([SentenceOID])
REFERENCES [dbo].[Sentences] ([OID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Ratings] CHECK CONSTRAINT [FK_Ratings_Sentences_SentenceOID]
GO
ALTER TABLE [dbo].[Ratings]  WITH CHECK ADD  CONSTRAINT [FK_Ratings_SentimentUsers_SentimentUserOID] FOREIGN KEY([SentimentUserOID])
REFERENCES [dbo].[SentimentUsers] ([OID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Ratings] CHECK CONSTRAINT [FK_Ratings_SentimentUsers_SentimentUserOID]
GO
USE [master]
GO
ALTER DATABASE [SentimentDb] SET  READ_WRITE 
GO
