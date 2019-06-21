USE [master]
GO
/****** Object:  Database [TechSupport20190613121821_db]    Script Date: 21-Jun-19 5:08:20 PM ******/
CREATE DATABASE [TechSupport20190613121821_db]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TechSupport20190613121821_db', FILENAME = N'C:\Users\Nikola Pantelic\TechSupport20190613121821_db.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TechSupport20190613121821_db_log', FILENAME = N'C:\Users\Nikola Pantelic\TechSupport20190613121821_db_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [TechSupport20190613121821_db] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TechSupport20190613121821_db].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TechSupport20190613121821_db] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TechSupport20190613121821_db] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TechSupport20190613121821_db] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TechSupport20190613121821_db] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TechSupport20190613121821_db] SET ARITHABORT OFF 
GO
ALTER DATABASE [TechSupport20190613121821_db] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TechSupport20190613121821_db] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TechSupport20190613121821_db] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TechSupport20190613121821_db] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TechSupport20190613121821_db] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TechSupport20190613121821_db] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TechSupport20190613121821_db] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TechSupport20190613121821_db] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TechSupport20190613121821_db] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TechSupport20190613121821_db] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TechSupport20190613121821_db] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TechSupport20190613121821_db] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TechSupport20190613121821_db] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TechSupport20190613121821_db] SET ALLOW_SNAPSHOT_ISOLATION ON 
GO
ALTER DATABASE [TechSupport20190613121821_db] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TechSupport20190613121821_db] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [TechSupport20190613121821_db] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TechSupport20190613121821_db] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TechSupport20190613121821_db] SET  MULTI_USER 
GO
ALTER DATABASE [TechSupport20190613121821_db] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TechSupport20190613121821_db] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TechSupport20190613121821_db] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TechSupport20190613121821_db] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TechSupport20190613121821_db] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TechSupport20190613121821_db] SET QUERY_STORE = ON
GO
ALTER DATABASE [TechSupport20190613121821_db] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 100, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO)
GO
USE [TechSupport20190613121821_db]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [TechSupport20190613121821_db]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 21-Jun-19 5:08:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AgentChannel]    Script Date: 21-Jun-19 5:08:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AgentChannel](
	[Channel] [int] NOT NULL,
	[Agent] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_AgentChannel] PRIMARY KEY CLUSTERED 
(
	[Channel] ASC,
	[Agent] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Answers]    Script Date: 21-Jun-19 5:08:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Answers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Question] [int] NULL,
	[ReplyOn] [int] NULL,
	[Author] [nvarchar](128) NOT NULL,
	[TimeCreated] [datetime] NOT NULL,
	[Text] [nvarchar](256) NOT NULL,
	[Upvotes] [int] NOT NULL,
	[Downvotes] [int] NOT NULL,
 CONSTRAINT [PK_Answer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 21-Jun-19 5:08:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 21-Jun-19 5:08:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 21-Jun-19 5:08:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 21-Jun-19 5:08:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 21-Jun-19 5:08:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
	[FirstName] [nvarchar](256) NULL,
	[LastName] [nvarchar](256) NULL,
	[Tokens] [int] NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 21-Jun-19 5:08:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Channels]    Script Date: 21-Jun-19 5:08:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Channels](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[TimeCreated] [datetime] NOT NULL,
	[Creator] [nvarchar](128) NOT NULL,
	[Closed] [bit] NOT NULL,
	[Price] [int] NULL,
 CONSTRAINT [PK_Channel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Questions]    Script Date: 21-Jun-19 5:08:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Questions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](128) NOT NULL,
	[Text] [nvarchar](256) NOT NULL,
	[Image] [nvarchar](128) NULL,
	[Category] [int] NOT NULL,
	[Author] [nvarchar](128) NOT NULL,
	[TimeCreated] [datetime] NOT NULL,
	[TimeLastLocked] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[Channel] [int] NOT NULL,
	[Locked] [bit] NOT NULL,
 CONSTRAINT [PK_Question] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ratings]    Script Date: 21-Jun-19 5:08:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ratings](
	[AspNetUser] [nvarchar](128) NOT NULL,
	[Answer] [int] NOT NULL,
	[Likes] [bit] NOT NULL,
 CONSTRAINT [PK_Ratings] PRIMARY KEY CLUSTERED 
(
	[AspNetUser] ASC,
	[Answer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Answers] ON 

INSERT [dbo].[Answers] ([Id], [Question], [ReplyOn], [Author], [TimeCreated], [Text], [Upvotes], [Downvotes]) VALUES (1, 2, NULL, N'27cf6b3c-ecdc-48b3-be0e-41f2f231150e', CAST(N'2019-06-17T17:20:24.137' AS DateTime), N'asdasdasd', 0, 0)
INSERT [dbo].[Answers] ([Id], [Question], [ReplyOn], [Author], [TimeCreated], [Text], [Upvotes], [Downvotes]) VALUES (3, 2, NULL, N'27cf6b3c-ecdc-48b3-be0e-41f2f231150e', CAST(N'2019-06-19T17:07:15.823' AS DateTime), N'samo pes', 0, 0)
INSERT [dbo].[Answers] ([Id], [Question], [ReplyOn], [Author], [TimeCreated], [Text], [Upvotes], [Downvotes]) VALUES (4, 2, NULL, N'27cf6b3c-ecdc-48b3-be0e-41f2f231150e', CAST(N'2019-06-19T17:18:29.183' AS DateTime), N'dsa', 0, 0)
INSERT [dbo].[Answers] ([Id], [Question], [ReplyOn], [Author], [TimeCreated], [Text], [Upvotes], [Downvotes]) VALUES (5, 2, NULL, N'27cf6b3c-ecdc-48b3-be0e-41f2f231150e', CAST(N'2019-06-21T15:39:40.840' AS DateTime), N'idemooo nis', 0, 0)
INSERT [dbo].[Answers] ([Id], [Question], [ReplyOn], [Author], [TimeCreated], [Text], [Upvotes], [Downvotes]) VALUES (6, 2, 1, N'27cf6b3c-ecdc-48b3-be0e-41f2f231150e', CAST(N'2019-06-21T16:28:31.813' AS DateTime), N'dsadsadsa', 0, 0)
INSERT [dbo].[Answers] ([Id], [Question], [ReplyOn], [Author], [TimeCreated], [Text], [Upvotes], [Downvotes]) VALUES (7, NULL, NULL, N'27cf6b3c-ecdc-48b3-be0e-41f2f231150e', CAST(N'2019-06-21T16:44:45.677' AS DateTime), N'first level answer', 0, 0)
INSERT [dbo].[Answers] ([Id], [Question], [ReplyOn], [Author], [TimeCreated], [Text], [Upvotes], [Downvotes]) VALUES (8, 2, NULL, N'27cf6b3c-ecdc-48b3-be0e-41f2f231150e', CAST(N'2019-06-21T16:47:18.193' AS DateTime), N'furst lvl answer', 0, 0)
INSERT [dbo].[Answers] ([Id], [Question], [ReplyOn], [Author], [TimeCreated], [Text], [Upvotes], [Downvotes]) VALUES (9, NULL, 8, N'27cf6b3c-ecdc-48b3-be0e-41f2f231150e', CAST(N'2019-06-21T16:48:34.693' AS DateTime), N'sekund lvl answer', 0, 0)
INSERT [dbo].[Answers] ([Id], [Question], [ReplyOn], [Author], [TimeCreated], [Text], [Upvotes], [Downvotes]) VALUES (10, 2, NULL, N'27cf6b3c-ecdc-48b3-be0e-41f2f231150e', CAST(N'2019-06-21T16:52:49.097' AS DateTime), N'proba', 0, 0)
INSERT [dbo].[Answers] ([Id], [Question], [ReplyOn], [Author], [TimeCreated], [Text], [Upvotes], [Downvotes]) VALUES (11, 2, NULL, N'27cf6b3c-ecdc-48b3-be0e-41f2f231150e', CAST(N'2019-06-21T16:57:43.193' AS DateTime), N'probalica', 0, 0)
SET IDENTITY_INSERT [dbo].[Answers] OFF
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'eaed9916-3751-4212-afe2-468987048f41', N'admin')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'def02b4d-7881-4205-bea2-d9058c421e31', N'agent')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'd5fdf1e1-018d-4bac-9803-5de1011033e2', N'user')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'1aa14500-3d9f-432e-a180-5ab695f55480', N'd5fdf1e1-018d-4bac-9803-5de1011033e2')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'27cf6b3c-ecdc-48b3-be0e-41f2f231150e', N'eaed9916-3751-4212-afe2-468987048f41')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'62276f13-1a1d-40f4-8429-603f91d2e2fa', N'd5fdf1e1-018d-4bac-9803-5de1011033e2')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'767b20a8-ab65-4376-9f21-c95498a10162', N'def02b4d-7881-4205-bea2-d9058c421e31')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c4b92da5-861a-4d8d-9da0-52e7889fd7d2', N'def02b4d-7881-4205-bea2-d9058c421e31')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FirstName], [LastName], [Tokens]) VALUES (N'1aa14500-3d9f-432e-a180-5ab695f55480', N'aca@acic.com', 0, NULL, NULL, NULL, 0, 0, NULL, 0, 0, N'aca@acic.com', N'Aca', N'Acic', 0)
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FirstName], [LastName], [Tokens]) VALUES (N'27cf6b3c-ecdc-48b3-be0e-41f2f231150e', N'admin@admin.com', 0, N'AK7d65uUwSUUbLTfikwY5TvIdMkA84ESZGfjqIenfHzfAHDpAOhh+/TKGtXNB9Nq3g==', N'925f6c0e-70bf-4cf3-bf48-2f6d4f5af034', NULL, 0, 0, NULL, 0, 0, N'admin@admin.com', NULL, NULL, 0)
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FirstName], [LastName], [Tokens]) VALUES (N'62276f13-1a1d-40f4-8429-603f91d2e2fa', N'mirko@drzdic.com', 0, N'ALxIam7iPMhXLrY/ofS/l9Ns31//0/xiYR5BA0xNfvaZEx9rqa+Pi78RREji/NtXeg==', N'151e07bc-ffdb-434d-aae5-0ea020e891a2', NULL, 0, 0, NULL, 1, 0, N'mirko@drzdic.com', N'Mirko', N'Drzdic', 0)
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FirstName], [LastName], [Tokens]) VALUES (N'767b20a8-ab65-4376-9f21-c95498a10162', N'agent@agent.com', 0, N'AOmDynl7F4iGyvuWqN1DqWiGdYeYtoAfkFTdpOeyMUh8oIxVpJT0pd4A+zRbMdNQDA==', N'33c7574e-6adc-40bc-a48b-52ffb0427382', NULL, 0, 0, NULL, 1, 0, N'agent@agent.com', N'Agnet', N'Agent', 0)
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FirstName], [LastName], [Tokens]) VALUES (N'c4b92da5-861a-4d8d-9da0-52e7889fd7d2', N'adin@rahmetovic.com', 0, NULL, NULL, NULL, 0, 0, NULL, 0, 0, N'adin@rahmetovic.com', N'Amel', N'Rahmetovic', 0)
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [Name]) VALUES (1, N'Games')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (3, N'asd')
SET IDENTITY_INSERT [dbo].[Categories] OFF
SET IDENTITY_INSERT [dbo].[Channels] ON 

INSERT [dbo].[Channels] ([Id], [Name], [TimeCreated], [Creator], [Closed], [Price]) VALUES (1, N'GamesChannel', CAST(N'2019-06-17T17:18:22.707' AS DateTime), N'62276f13-1a1d-40f4-8429-603f91d2e2fa', 0, NULL)
SET IDENTITY_INSERT [dbo].[Channels] OFF
SET IDENTITY_INSERT [dbo].[Questions] ON 

INSERT [dbo].[Questions] ([Id], [Title], [Text], [Image], [Category], [Author], [TimeCreated], [TimeLastLocked], [LockoutEnabled], [Channel], [Locked]) VALUES (2, N'best 2018', N'What are best games 2018', N'asd', 1, N'62276f13-1a1d-40f4-8429-603f91d2e2fa', CAST(N'2019-06-17T17:20:24.137' AS DateTime), CAST(N'2019-06-20T15:17:29.203' AS DateTime), 1, 1, 0)
SET IDENTITY_INSERT [dbo].[Questions] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 21-Jun-19 5:08:21 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 21-Jun-19 5:08:21 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 21-Jun-19 5:08:21 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_RoleId]    Script Date: 21-Jun-19 5:08:21 PM ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 21-Jun-19 5:08:21 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 21-Jun-19 5:08:21 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Answers] ADD  CONSTRAINT [DF_Answer_Upvotes]  DEFAULT ((0)) FOR [Upvotes]
GO
ALTER TABLE [dbo].[Answers] ADD  CONSTRAINT [DF_Answer_Downvotes]  DEFAULT ((0)) FOR [Downvotes]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  CONSTRAINT [DF_AspNetUsers_Tokens]  DEFAULT ((0)) FOR [Tokens]
GO
ALTER TABLE [dbo].[Channels] ADD  CONSTRAINT [DF_Channel_Closed]  DEFAULT ((0)) FOR [Closed]
GO
ALTER TABLE [dbo].[Questions] ADD  CONSTRAINT [DF_Question_LockoutEnabled]  DEFAULT ((0)) FOR [LockoutEnabled]
GO
ALTER TABLE [dbo].[Questions] ADD  CONSTRAINT [DF_Questions_Locked]  DEFAULT ((0)) FOR [Locked]
GO
ALTER TABLE [dbo].[AgentChannel]  WITH CHECK ADD  CONSTRAINT [FK_AgentChannel_AspNetUsers] FOREIGN KEY([Agent])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AgentChannel] CHECK CONSTRAINT [FK_AgentChannel_AspNetUsers]
GO
ALTER TABLE [dbo].[AgentChannel]  WITH CHECK ADD  CONSTRAINT [FK_AgentChannel_Channels] FOREIGN KEY([Channel])
REFERENCES [dbo].[Channels] ([Id])
GO
ALTER TABLE [dbo].[AgentChannel] CHECK CONSTRAINT [FK_AgentChannel_Channels]
GO
ALTER TABLE [dbo].[Answers]  WITH CHECK ADD  CONSTRAINT [FK_Answer_Answer1] FOREIGN KEY([ReplyOn])
REFERENCES [dbo].[Answers] ([Id])
GO
ALTER TABLE [dbo].[Answers] CHECK CONSTRAINT [FK_Answer_Answer1]
GO
ALTER TABLE [dbo].[Answers]  WITH CHECK ADD  CONSTRAINT [FK_Answer_AspNetUsers] FOREIGN KEY([Author])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Answers] CHECK CONSTRAINT [FK_Answer_AspNetUsers]
GO
ALTER TABLE [dbo].[Answers]  WITH CHECK ADD  CONSTRAINT [FK_Answer_Question] FOREIGN KEY([Question])
REFERENCES [dbo].[Questions] ([Id])
GO
ALTER TABLE [dbo].[Answers] CHECK CONSTRAINT [FK_Answer_Question]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Channels]  WITH CHECK ADD  CONSTRAINT [FK_Channel_AspNetUsers] FOREIGN KEY([Creator])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Channels] CHECK CONSTRAINT [FK_Channel_AspNetUsers]
GO
ALTER TABLE [dbo].[Questions]  WITH CHECK ADD  CONSTRAINT [FK_Questions_Categories] FOREIGN KEY([Category])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Questions] CHECK CONSTRAINT [FK_Questions_Categories]
GO
ALTER TABLE [dbo].[Questions]  WITH CHECK ADD  CONSTRAINT [FK_Questions_Channel] FOREIGN KEY([Channel])
REFERENCES [dbo].[Channels] ([Id])
GO
ALTER TABLE [dbo].[Questions] CHECK CONSTRAINT [FK_Questions_Channel]
GO
ALTER TABLE [dbo].[Ratings]  WITH CHECK ADD  CONSTRAINT [FK_Ratings_Answers] FOREIGN KEY([Answer])
REFERENCES [dbo].[Answers] ([Id])
GO
ALTER TABLE [dbo].[Ratings] CHECK CONSTRAINT [FK_Ratings_Answers]
GO
ALTER TABLE [dbo].[Ratings]  WITH CHECK ADD  CONSTRAINT [FK_Ratings_AspNetUsers] FOREIGN KEY([AspNetUser])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Ratings] CHECK CONSTRAINT [FK_Ratings_AspNetUsers]
GO
USE [master]
GO
ALTER DATABASE [TechSupport20190613121821_db] SET  READ_WRITE 
GO
