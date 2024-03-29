USE [master]
GO
/****** Object:  Database [CreditCompany]    Script Date: 28/02/2022 17:47:34 ******/
CREATE DATABASE [CreditCompany]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CreditCompany', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\CreditCompany.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CreditCompany_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\CreditCompany_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CreditCompany] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CreditCompany].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CreditCompany] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CreditCompany] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CreditCompany] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CreditCompany] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CreditCompany] SET ARITHABORT OFF 
GO
ALTER DATABASE [CreditCompany] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CreditCompany] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CreditCompany] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CreditCompany] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CreditCompany] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CreditCompany] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CreditCompany] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CreditCompany] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CreditCompany] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CreditCompany] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CreditCompany] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CreditCompany] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CreditCompany] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CreditCompany] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CreditCompany] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CreditCompany] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CreditCompany] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CreditCompany] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CreditCompany] SET  MULTI_USER 
GO
ALTER DATABASE [CreditCompany] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CreditCompany] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CreditCompany] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CreditCompany] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CreditCompany] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CreditCompany] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [CreditCompany] SET QUERY_STORE = OFF
GO
USE [CreditCompany]
GO
/****** Object:  Table [dbo].[CreditCards]    Script Date: 28/02/2022 17:47:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CreditCards](
	[CreditCardNumber] [nvarchar](50) NOT NULL,
	[ClientId] [int] NULL,
	[Credit] [float] NULL,
	[UsedCredit] [float] NULL,
	[IsCanceled] [bit] NOT NULL,
	[AccountId] [int] NULL,
	[IsRecievingOnly] [bit] NOT NULL,
	[Club] [nvarchar](50) NULL,
 CONSTRAINT [PK_CreditCards] PRIMARY KEY CLUSTERED 
(
	[CreditCardNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[NumberOfCards_View]    Script Date: 28/02/2022 17:47:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[NumberOfCards_View] as 
select COUNT(ccs.ClientId) as [Number Of Cards], ccs.ClientId from CreditCards ccs
group by ClientId
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 28/02/2022 17:47:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[ClientId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[CreditScore] [int] NULL,
	[AssignDate] [date] NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ClientsInfo]    Script Date: 28/02/2022 17:47:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create view [dbo].[ClientsInfo] as
select c.ClientId,(c.FirstName+' '+c.LastName) as [Name],c.CreditScore ,RIGHT(c.MainCreditCard,4) as [Main Card Last Digits],ncv.[Number Of Cards],ccs.[Total Used Credit],ccs.[Total credit]
from Clients c
left outer join NumberOfCards_View as ncv on c.ClientId=ncv.ClientId
left outer join (select SUM(ccs.Credit) [Total credit], SUM(ccs.UsedCredit) [Total Used Credit], ccs.ClientId from CreditCards ccs group by ccs.ClientId) as ccs on ccs.ClientId=c.ClientId


GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 28/02/2022 17:47:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[UniqueAccountId] [int] IDENTITY(1,1) NOT NULL,
	[AccountNumber] [int] NULL,
	[BranchNumber] [int] NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[UniqueAccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Banks]    Script Date: 28/02/2022 17:47:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Banks](
	[BankNumber] [int] NOT NULL,
	[BankName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[BankNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Branches]    Script Date: 28/02/2022 17:47:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Branches](
	[BranchNumber] [int] NOT NULL,
	[BankNumber] [int] NULL,
	[BranchName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Branches] PRIMARY KEY CLUSTERED 
(
	[BranchNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clients_Accounts]    Script Date: 28/02/2022 17:47:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients_Accounts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [int] NULL,
	[AccountId] [int] NULL,
 CONSTRAINT [PK_Clients_Accounts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Managers]    Script Date: 28/02/2022 17:47:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Managers](
	[ManagerId] [int] IDENTITY(1,1) NOT NULL,
	[Manager_Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Managers] PRIMARY KEY CLUSTERED 
(
	[ManagerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Messages]    Script Date: 28/02/2022 17:47:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Messages](
	[MessageId] [int] IDENTITY(1,1) NOT NULL,
	[Manager_SenderId] [int] NULL,
	[Client_RecieverId] [int] NULL,
	[MessageTitle] [nvarchar](50) NULL,
	[MessageContent] [nvarchar](max) NULL,
	[IsViewed] [bit] NULL,
 CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED 
(
	[MessageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Requests_From_Clients]    Script Date: 28/02/2022 17:47:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Requests_From_Clients](
	[RequestId] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [int] NULL,
	[Title] [nvarchar](100) NULL,
	[Content] [nvarchar](max) NULL,
	[HasBeenViewd] [bit] NULL,
	[Answered] [bit] NULL,
	[Date] [datetime] NULL,
 CONSTRAINT [PK_ClientsRequests] PRIMARY KEY CLUSTERED 
(
	[RequestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 28/02/2022 17:47:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[TransactionId] [int] IDENTITY(1,1) NOT NULL,
	[PayerCardNumber] [nvarchar](50) NULL,
	[ReciverClientId] [int] NULL,
	[Payment] [float] NULL,
	[Date] [datetime] NULL,
	[CardShowed] [bit] NULL,
	[Business] [nvarchar](50) NULL,
	[IsDenied] [bit] NULL,
	[DenyRequestId] [int] NULL,
 CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED 
(
	[TransactionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 28/02/2022 17:47:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[UserPassword] [nvarchar](50) NULL,
	[IsManager] [bit] NULL,
	[If_Manager_Id] [int] NULL,
	[If_Client_Id] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Accounts] ON 

INSERT [dbo].[Accounts] ([UniqueAccountId], [AccountNumber], [BranchNumber]) VALUES (1, 130226, 109)
INSERT [dbo].[Accounts] ([UniqueAccountId], [AccountNumber], [BranchNumber]) VALUES (2, 211544, 686)
INSERT [dbo].[Accounts] ([UniqueAccountId], [AccountNumber], [BranchNumber]) VALUES (3, 23311178, 925)
INSERT [dbo].[Accounts] ([UniqueAccountId], [AccountNumber], [BranchNumber]) VALUES (4, 111987, 650)
INSERT [dbo].[Accounts] ([UniqueAccountId], [AccountNumber], [BranchNumber]) VALUES (5, 233554, 125)
INSERT [dbo].[Accounts] ([UniqueAccountId], [AccountNumber], [BranchNumber]) VALUES (6, 233222, 125)
INSERT [dbo].[Accounts] ([UniqueAccountId], [AccountNumber], [BranchNumber]) VALUES (8, 474495, 650)
INSERT [dbo].[Accounts] ([UniqueAccountId], [AccountNumber], [BranchNumber]) VALUES (9, 221992, 926)
INSERT [dbo].[Accounts] ([UniqueAccountId], [AccountNumber], [BranchNumber]) VALUES (10, 111111, 1)
INSERT [dbo].[Accounts] ([UniqueAccountId], [AccountNumber], [BranchNumber]) VALUES (11, 211444, 651)
SET IDENTITY_INSERT [dbo].[Accounts] OFF
GO
INSERT [dbo].[Banks] ([BankNumber], [BankName]) VALUES (11, N'Discount')
INSERT [dbo].[Banks] ([BankNumber], [BankName]) VALUES (31, N'Habenleumi')
INSERT [dbo].[Banks] ([BankNumber], [BankName]) VALUES (12, N'Hapoalim')
INSERT [dbo].[Banks] ([BankNumber], [BankName]) VALUES (10, N'Leumi')
INSERT [dbo].[Banks] ([BankNumber], [BankName]) VALUES (17, N'Marcentil Discount')
INSERT [dbo].[Banks] ([BankNumber], [BankName]) VALUES (46, N'Massad')
INSERT [dbo].[Banks] ([BankNumber], [BankName]) VALUES (20, N'Mizrahi Tfahot')
INSERT [dbo].[Banks] ([BankNumber], [BankName]) VALUES (14, N'Otsar Hahyal')
INSERT [dbo].[Banks] ([BankNumber], [BankName]) VALUES (9, N'Post Bank')
INSERT [dbo].[Banks] ([BankNumber], [BankName]) VALUES (26, N'UBank')
INSERT [dbo].[Banks] ([BankNumber], [BankName]) VALUES (13, N'Union')
INSERT [dbo].[Banks] ([BankNumber], [BankName]) VALUES (4, N'Yahav')
GO
INSERT [dbo].[Branches] ([BranchNumber], [BankNumber], [BranchName]) VALUES (1, 9, N'Israel')
INSERT [dbo].[Branches] ([BranchNumber], [BankNumber], [BranchName]) VALUES (109, 31, N'Ashkelon')
INSERT [dbo].[Branches] ([BranchNumber], [BankNumber], [BranchName]) VALUES (125, 4, N'Ashkelon')
INSERT [dbo].[Branches] ([BranchNumber], [BankNumber], [BranchName]) VALUES (128, 11, N'Ashkelon')
INSERT [dbo].[Branches] ([BranchNumber], [BankNumber], [BranchName]) VALUES (427, 20, N'Ashkelon')
INSERT [dbo].[Branches] ([BranchNumber], [BankNumber], [BranchName]) VALUES (650, 12, N'Afridar')
INSERT [dbo].[Branches] ([BranchNumber], [BankNumber], [BranchName]) VALUES (651, 12, N'Barnea')
INSERT [dbo].[Branches] ([BranchNumber], [BankNumber], [BranchName]) VALUES (686, 12, N'Shimshon')
INSERT [dbo].[Branches] ([BranchNumber], [BankNumber], [BranchName]) VALUES (925, 10, N'Ashkelon')
INSERT [dbo].[Branches] ([BranchNumber], [BankNumber], [BranchName]) VALUES (926, 10, N'Ashkelon')
INSERT [dbo].[Branches] ([BranchNumber], [BankNumber], [BranchName]) VALUES (927, 10, N'Qiryat-Gat')
GO
SET IDENTITY_INSERT [dbo].[Clients] ON 

INSERT [dbo].[Clients] ([ClientId], [FirstName], [LastName], [CreditScore], [AssignDate]) VALUES (-1, N'Deleted', N'Client', 0, CAST(N'2022-01-31' AS Date))
INSERT [dbo].[Clients] ([ClientId], [FirstName], [LastName], [CreditScore], [AssignDate]) VALUES (1, N'Avichay', N'Vaknin', 675, CAST(N'2022-01-01' AS Date))
INSERT [dbo].[Clients] ([ClientId], [FirstName], [LastName], [CreditScore], [AssignDate]) VALUES (2, N'Super', N'Pharm', 800, CAST(N'2022-01-01' AS Date))
INSERT [dbo].[Clients] ([ClientId], [FirstName], [LastName], [CreditScore], [AssignDate]) VALUES (4, N'Some', N'Some', 800, NULL)
INSERT [dbo].[Clients] ([ClientId], [FirstName], [LastName], [CreditScore], [AssignDate]) VALUES (7, N'אביחי', N'וקנין', 120, NULL)
SET IDENTITY_INSERT [dbo].[Clients] OFF
GO
SET IDENTITY_INSERT [dbo].[Clients_Accounts] ON 

INSERT [dbo].[Clients_Accounts] ([Id], [ClientId], [AccountId]) VALUES (1, 1, 1)
INSERT [dbo].[Clients_Accounts] ([Id], [ClientId], [AccountId]) VALUES (2, 2, 2)
INSERT [dbo].[Clients_Accounts] ([Id], [ClientId], [AccountId]) VALUES (3, 4, 8)
INSERT [dbo].[Clients_Accounts] ([Id], [ClientId], [AccountId]) VALUES (6, 7, 11)
SET IDENTITY_INSERT [dbo].[Clients_Accounts] OFF
GO
INSERT [dbo].[CreditCards] ([CreditCardNumber], [ClientId], [Credit], [UsedCredit], [IsCanceled], [AccountId], [IsRecievingOnly], [Club]) VALUES (N'0000111122223333', -1, -1, 0, 0, NULL, 0, NULL)
INSERT [dbo].[CreditCards] ([CreditCardNumber], [ClientId], [Credit], [UsedCredit], [IsCanceled], [AccountId], [IsRecievingOnly], [Club]) VALUES (N'2700522647526256', 7, 1500, 0, 0, 11, 0, N'הכללי')
INSERT [dbo].[CreditCards] ([CreditCardNumber], [ClientId], [Credit], [UsedCredit], [IsCanceled], [AccountId], [IsRecievingOnly], [Club]) VALUES (N'3755123456789012', 2, 1000000, 275002, 0, 2, 0, N'Default')
INSERT [dbo].[CreditCards] ([CreditCardNumber], [ClientId], [Credit], [UsedCredit], [IsCanceled], [AccountId], [IsRecievingOnly], [Club]) VALUES (N'4023356041624013', 1, 1500, 0, 1, 1, 1, N'הכללי')
INSERT [dbo].[CreditCards] ([CreditCardNumber], [ClientId], [Credit], [UsedCredit], [IsCanceled], [AccountId], [IsRecievingOnly], [Club]) VALUES (N'4580123456789012', 1, 10000, 2722.9, 0, 1, 0, N'Default')
GO
SET IDENTITY_INSERT [dbo].[Managers] ON 

INSERT [dbo].[Managers] ([ManagerId], [Manager_Name]) VALUES (1, N'Avichay')
SET IDENTITY_INSERT [dbo].[Managers] OFF
GO
SET IDENTITY_INSERT [dbo].[Messages] ON 

INSERT [dbo].[Messages] ([MessageId], [Manager_SenderId], [Client_RecieverId], [MessageTitle], [MessageContent], [IsViewed]) VALUES (1, 1, 1, N'Card Issued', N'Your card has been issued succefully, with the club "Default", number ending with 9012', 1)
INSERT [dbo].[Messages] ([MessageId], [Manager_SenderId], [Client_RecieverId], [MessageTitle], [MessageContent], [IsViewed]) VALUES (2, 1, 2, N'Card Issued', N'Your card has been issued succefully, with the club "Default", number ending with 9012', 0)
INSERT [dbo].[Messages] ([MessageId], [Manager_SenderId], [Client_RecieverId], [MessageTitle], [MessageContent], [IsViewed]) VALUES (3, 1, 1, N'Thanks for joining', N'Thank you for joining us', 1)
INSERT [dbo].[Messages] ([MessageId], [Manager_SenderId], [Client_RecieverId], [MessageTitle], [MessageContent], [IsViewed]) VALUES (7, 1, 1, N'Debug', N'content', 1)
INSERT [dbo].[Messages] ([MessageId], [Manager_SenderId], [Client_RecieverId], [MessageTitle], [MessageContent], [IsViewed]) VALUES (8, 1, 1, N'debug', N'debug', 1)
INSERT [dbo].[Messages] ([MessageId], [Manager_SenderId], [Client_RecieverId], [MessageTitle], [MessageContent], [IsViewed]) VALUES (9, 1, 1, N'debug', N'4013 canceled', 1)
INSERT [dbo].[Messages] ([MessageId], [Manager_SenderId], [Client_RecieverId], [MessageTitle], [MessageContent], [IsViewed]) VALUES (10, 1, 1, N'debug', N'4013 canceled', 1)
INSERT [dbo].[Messages] ([MessageId], [Manager_SenderId], [Client_RecieverId], [MessageTitle], [MessageContent], [IsViewed]) VALUES (11, 1, 1, N'debug', N'4013 holded', 0)
INSERT [dbo].[Messages] ([MessageId], [Manager_SenderId], [Client_RecieverId], [MessageTitle], [MessageContent], [IsViewed]) VALUES (12, 1, 7, N'Thanks for joining', N'Thank you for joining us', 0)
INSERT [dbo].[Messages] ([MessageId], [Manager_SenderId], [Client_RecieverId], [MessageTitle], [MessageContent], [IsViewed]) VALUES (13, 1, 7, N'First Card issued!', N'Card''s club: הכללי, Card''s Credit: 1500', 0)
SET IDENTITY_INSERT [dbo].[Messages] OFF
GO
SET IDENTITY_INSERT [dbo].[Requests_From_Clients] ON 

INSERT [dbo].[Requests_From_Clients] ([RequestId], [ClientId], [Title], [Content], [HasBeenViewd], [Answered], [Date]) VALUES (1, 1, N'New Card', N'I want a card with the "Default" club', 1, 1, CAST(N'1970-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Requests_From_Clients] ([RequestId], [ClientId], [Title], [Content], [HasBeenViewd], [Answered], [Date]) VALUES (2, 2, N'New Card', N'I want a card with "Default" club', 1, 1, CAST(N'1970-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Requests_From_Clients] ([RequestId], [ClientId], [Title], [Content], [HasBeenViewd], [Answered], [Date]) VALUES (28, 1, N'*Immidiate* Block Credit Card.', N'', 1, 1, CAST(N'2022-02-21T16:59:04.157' AS DateTime))
INSERT [dbo].[Requests_From_Clients] ([RequestId], [ClientId], [Title], [Content], [HasBeenViewd], [Answered], [Date]) VALUES (30, 1, N'Denial of transaction.', N'I wish to deny the transaction number: 4
which been done at 10/02/2022 00:00:00
at business: SuperPharm', 1, 1, CAST(N'2022-02-21T16:59:43.423' AS DateTime))
SET IDENTITY_INSERT [dbo].[Requests_From_Clients] OFF
GO
SET IDENTITY_INSERT [dbo].[Transactions] ON 

INSERT [dbo].[Transactions] ([TransactionId], [PayerCardNumber], [ReciverClientId], [Payment], [Date], [CardShowed], [Business], [IsDenied], [DenyRequestId]) VALUES (1, N'4580123456789012', 2, 500, CAST(N'2022-01-13T00:00:00.000' AS DateTime), 1, NULL, NULL, NULL)
INSERT [dbo].[Transactions] ([TransactionId], [PayerCardNumber], [ReciverClientId], [Payment], [Date], [CardShowed], [Business], [IsDenied], [DenyRequestId]) VALUES (2, N'4580123456789012', 2, 2100, CAST(N'2022-01-12T00:00:00.000' AS DateTime), 1, NULL, NULL, NULL)
INSERT [dbo].[Transactions] ([TransactionId], [PayerCardNumber], [ReciverClientId], [Payment], [Date], [CardShowed], [Business], [IsDenied], [DenyRequestId]) VALUES (3, N'3755123456789012', 1, 100, CAST(N'2022-01-14T00:00:00.000' AS DateTime), 1, NULL, NULL, NULL)
INSERT [dbo].[Transactions] ([TransactionId], [PayerCardNumber], [ReciverClientId], [Payment], [Date], [CardShowed], [Business], [IsDenied], [DenyRequestId]) VALUES (4, N'4580123456789012', 2, 100, CAST(N'2022-02-10T00:00:00.000' AS DateTime), 1, N'SuperPharm', 1, 30)
INSERT [dbo].[Transactions] ([TransactionId], [PayerCardNumber], [ReciverClientId], [Payment], [Date], [CardShowed], [Business], [IsDenied], [DenyRequestId]) VALUES (11, N'3755123456789012', 1, 0.55, CAST(N'2022-02-26T20:44:37.433' AS DateTime), 1, N'SuperPharm', NULL, NULL)
INSERT [dbo].[Transactions] ([TransactionId], [PayerCardNumber], [ReciverClientId], [Payment], [Date], [CardShowed], [Business], [IsDenied], [DenyRequestId]) VALUES (12, N'4580123456789012', 2, 22.9, CAST(N'2022-02-27T00:27:37.043' AS DateTime), 1, N'SuperPharm', NULL, NULL)
INSERT [dbo].[Transactions] ([TransactionId], [PayerCardNumber], [ReciverClientId], [Payment], [Date], [CardShowed], [Business], [IsDenied], [DenyRequestId]) VALUES (13, N'3755123456789012', 7, 2, CAST(N'2022-02-27T21:22:57.713' AS DateTime), 1, N'SuperPharm', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Transactions] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserId], [UserName], [UserPassword], [IsManager], [If_Manager_Id], [If_Client_Id]) VALUES (1, N'Avichay', N'123456', 1, 1, 1)
INSERT [dbo].[Users] ([UserId], [UserName], [UserPassword], [IsManager], [If_Manager_Id], [If_Client_Id]) VALUES (2, N'Super-Pharm', N'1234567', 0, NULL, 2)
INSERT [dbo].[Users] ([UserId], [UserName], [UserPassword], [IsManager], [If_Manager_Id], [If_Client_Id]) VALUES (3, N'Some', N'123', NULL, NULL, 4)
INSERT [dbo].[Users] ([UserId], [UserName], [UserPassword], [IsManager], [If_Manager_Id], [If_Client_Id]) VALUES (6, N'second', N'123456', NULL, NULL, 7)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Table_1]    Script Date: 28/02/2022 17:47:36 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Table_1] ON [dbo].[Banks]
(
	[BankName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CreditCards] ADD  CONSTRAINT [DF_CreditCards_IsCanceled]  DEFAULT ((0)) FOR [IsCanceled]
GO
ALTER TABLE [dbo].[CreditCards] ADD  CONSTRAINT [DF_CreditCards_IsRecievingOnly]  DEFAULT ((0)) FOR [IsRecievingOnly]
GO
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_Branches] FOREIGN KEY([BranchNumber])
REFERENCES [dbo].[Branches] ([BranchNumber])
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_Branches]
GO
ALTER TABLE [dbo].[Branches]  WITH CHECK ADD  CONSTRAINT [FK_Branches_Table_1] FOREIGN KEY([BankNumber])
REFERENCES [dbo].[Banks] ([BankNumber])
GO
ALTER TABLE [dbo].[Branches] CHECK CONSTRAINT [FK_Branches_Table_1]
GO
ALTER TABLE [dbo].[Clients_Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Clients_Accounts_Accounts] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Accounts] ([UniqueAccountId])
GO
ALTER TABLE [dbo].[Clients_Accounts] CHECK CONSTRAINT [FK_Clients_Accounts_Accounts]
GO
ALTER TABLE [dbo].[Clients_Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Clients_Accounts_Clients] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Clients] ([ClientId])
GO
ALTER TABLE [dbo].[Clients_Accounts] CHECK CONSTRAINT [FK_Clients_Accounts_Clients]
GO
ALTER TABLE [dbo].[CreditCards]  WITH CHECK ADD  CONSTRAINT [FK_CreditCards_Accounts] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Accounts] ([UniqueAccountId])
GO
ALTER TABLE [dbo].[CreditCards] CHECK CONSTRAINT [FK_CreditCards_Accounts]
GO
ALTER TABLE [dbo].[CreditCards]  WITH CHECK ADD  CONSTRAINT [FK_CreditCards_Clients] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Clients] ([ClientId])
GO
ALTER TABLE [dbo].[CreditCards] CHECK CONSTRAINT [FK_CreditCards_Clients]
GO
ALTER TABLE [dbo].[Messages]  WITH CHECK ADD  CONSTRAINT [FK_Messages_Clients] FOREIGN KEY([Client_RecieverId])
REFERENCES [dbo].[Clients] ([ClientId])
GO
ALTER TABLE [dbo].[Messages] CHECK CONSTRAINT [FK_Messages_Clients]
GO
ALTER TABLE [dbo].[Messages]  WITH CHECK ADD  CONSTRAINT [FK_Messages_Managers] FOREIGN KEY([Manager_SenderId])
REFERENCES [dbo].[Managers] ([ManagerId])
GO
ALTER TABLE [dbo].[Messages] CHECK CONSTRAINT [FK_Messages_Managers]
GO
ALTER TABLE [dbo].[Requests_From_Clients]  WITH CHECK ADD  CONSTRAINT [FK_ClientsRequests_Clients] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Clients] ([ClientId])
GO
ALTER TABLE [dbo].[Requests_From_Clients] CHECK CONSTRAINT [FK_ClientsRequests_Clients]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Cards_payer] FOREIGN KEY([PayerCardNumber])
REFERENCES [dbo].[CreditCards] ([CreditCardNumber])
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_Cards_payer]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Clients_reciver] FOREIGN KEY([ReciverClientId])
REFERENCES [dbo].[Clients] ([ClientId])
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_Clients_reciver]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Requests_From_Clients] FOREIGN KEY([DenyRequestId])
REFERENCES [dbo].[Requests_From_Clients] ([RequestId])
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_Requests_From_Clients]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Clients] FOREIGN KEY([If_Manager_Id])
REFERENCES [dbo].[Managers] ([ManagerId])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Clients]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Clients1] FOREIGN KEY([If_Client_Id])
REFERENCES [dbo].[Clients] ([ClientId])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Clients1]
GO
USE [master]
GO
ALTER DATABASE [CreditCompany] SET  READ_WRITE 
GO
