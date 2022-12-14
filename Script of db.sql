USE [master]
GO
/****** Object:  Database [hosms]    Script Date: 7/2/2022 8:26:55 PM ******/
CREATE DATABASE [hosms]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'hosms', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER01\MSSQL\DATA\hosms.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'hosms_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER01\MSSQL\DATA\hosms_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [hosms] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [hosms].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [hosms] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [hosms] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [hosms] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [hosms] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [hosms] SET ARITHABORT OFF 
GO
ALTER DATABASE [hosms] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [hosms] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [hosms] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [hosms] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [hosms] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [hosms] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [hosms] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [hosms] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [hosms] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [hosms] SET  DISABLE_BROKER 
GO
ALTER DATABASE [hosms] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [hosms] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [hosms] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [hosms] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [hosms] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [hosms] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [hosms] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [hosms] SET RECOVERY FULL 
GO
ALTER DATABASE [hosms] SET  MULTI_USER 
GO
ALTER DATABASE [hosms] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [hosms] SET DB_CHAINING OFF 
GO
ALTER DATABASE [hosms] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [hosms] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [hosms] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [hosms] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'hosms', N'ON'
GO
ALTER DATABASE [hosms] SET QUERY_STORE = OFF
GO
USE [hosms]
GO
/****** Object:  Table [dbo].[AdminPanel]    Script Date: 7/2/2022 8:26:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminPanel](
	[AdminId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Role] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_AdminPanel] PRIMARY KEY CLUSTERED 
(
	[AdminId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departments ]    Script Date: 7/2/2022 8:26:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments ](
	[DepartmentId] [int] IDENTITY(1,1) NOT NULL,
	[DeptName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Departments ] PRIMARY KEY CLUSTERED 
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DeptwiseDoctors]    Script Date: 7/2/2022 8:26:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeptwiseDoctors](
	[DeptwiseId] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[DoctorId] [int] NOT NULL,
	[Designation] [nvarchar](100) NOT NULL,
	[Institution] [nvarchar](100) NULL,
	[VisitFee] [money] NOT NULL,
	[Picture] [nvarchar](100) NULL,
 CONSTRAINT [PK_DeptwiseDoctors_1] PRIMARY KEY CLUSTERED 
(
	[DeptwiseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Doctors ]    Script Date: 7/2/2022 8:26:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doctors ](
	[DoctorId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[PatientId] [int] NULL,
 CONSTRAINT [PK_Doctor's Table] PRIMARY KEY CLUSTERED 
(
	[DoctorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Doctors Salary]    Script Date: 7/2/2022 8:26:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doctors Salary](
	[DocsId] [int] IDENTITY(1,1) NOT NULL,
	[VisitingDay] [nvarchar](50) NOT NULL,
	[PayRate] [money] NOT NULL,
	[TotalHour] [int] NOT NULL,
	[DoctorId] [int] NOT NULL,
 CONSTRAINT [PK_Doctors Salary] PRIMARY KEY CLUSTERED 
(
	[DocsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Maintenence Employee]    Script Date: 7/2/2022 8:26:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Maintenence Employee](
	[EmpId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Phone] [int] NULL,
	[Work section] [nvarchar](50) NULL,
	[Salary] [money] NOT NULL,
	[AdminId] [int] NULL,
 CONSTRAINT [PK_Maintenence Employee] PRIMARY KEY CLUSTERED 
(
	[EmpId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nurses]    Script Date: 7/2/2022 8:26:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nurses](
	[NurseId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Phone] [int] NULL,
	[Salary] [money] NOT NULL,
	[DepartmentId] [int] NOT NULL,
 CONSTRAINT [PK_Nurses] PRIMARY KEY CLUSTERED 
(
	[NurseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patinets]    Script Date: 7/2/2022 8:26:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patinets](
	[PatientId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[VisitDate] [date] NOT NULL,
	[Fee] [money] NOT NULL,
	[Isadmitted] [bit] NULL,
 CONSTRAINT [PK_Patinets] PRIMARY KEY CLUSTERED 
(
	[PatientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 7/2/2022 8:26:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[Role] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserInfo]    Script Date: 7/2/2022 8:26:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserInfo](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Confirm pass] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[Role] [nchar](10) NULL,
 CONSTRAINT [PK_UserInfo] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AdminPanel] ON 

INSERT [dbo].[AdminPanel] ([AdminId], [Name], [Role]) VALUES (1, N'Sohan kahn', N'Director')
INSERT [dbo].[AdminPanel] ([AdminId], [Name], [Role]) VALUES (2, N'Rubel khan', N'Manager')
SET IDENTITY_INSERT [dbo].[AdminPanel] OFF
GO
SET IDENTITY_INSERT [dbo].[Departments ] ON 

INSERT [dbo].[Departments ] ([DepartmentId], [DeptName]) VALUES (11, N'Nueromedicine')
INSERT [dbo].[Departments ] ([DepartmentId], [DeptName]) VALUES (14, N'Orthopedic')
INSERT [dbo].[Departments ] ([DepartmentId], [DeptName]) VALUES (17, N'Medicine')
INSERT [dbo].[Departments ] ([DepartmentId], [DeptName]) VALUES (18, N'Diabtics')
INSERT [dbo].[Departments ] ([DepartmentId], [DeptName]) VALUES (21, N'Surgery')
INSERT [dbo].[Departments ] ([DepartmentId], [DeptName]) VALUES (22, N'Dermatology')
INSERT [dbo].[Departments ] ([DepartmentId], [DeptName]) VALUES (29, N'Diabtics')
SET IDENTITY_INSERT [dbo].[Departments ] OFF
GO
SET IDENTITY_INSERT [dbo].[DeptwiseDoctors] ON 

INSERT [dbo].[DeptwiseDoctors] ([DeptwiseId], [DepartmentId], [DoctorId], [Designation], [Institution], [VisitFee], [Picture]) VALUES (24, 11, 20, N'Senior Consultant', N'Nitor', 1050.0000, N'~/Images\b5cc392b-9639-4ef0-a44c-61d3faed30aa.jpg')
INSERT [dbo].[DeptwiseDoctors] ([DeptwiseId], [DepartmentId], [DoctorId], [Designation], [Institution], [VisitFee], [Picture]) VALUES (27, 21, 22, N'Assistant Doctor ', N'Nitor', 950.0000, N'~/Images\a3195993-14eb-4615-97b2-b949fd1dad38.jpg')
INSERT [dbo].[DeptwiseDoctors] ([DeptwiseId], [DepartmentId], [DoctorId], [Designation], [Institution], [VisitFee], [Picture]) VALUES (33, 11, 11, N'Assistant Doctor ', N'Dhaka medical', 650.0000, N'~/Images\495837f3-7209-40f5-a8d0-6605d76d8e52.jpg')
INSERT [dbo].[DeptwiseDoctors] ([DeptwiseId], [DepartmentId], [DoctorId], [Designation], [Institution], [VisitFee], [Picture]) VALUES (34, 17, 17, N'Senior Consultant', N'Dhaka medical', 750.0000, N'~/Images\2f352256-5aa9-4c7e-8cc2-0a9c4efe4203.jpg')
INSERT [dbo].[DeptwiseDoctors] ([DeptwiseId], [DepartmentId], [DoctorId], [Designation], [Institution], [VisitFee], [Picture]) VALUES (36, 11, 11, N'Assistant Doctor ', N'Dhaka medical', 750.0000, N'~/Images\ebd2866f-eab5-43f2-a7a0-285816cd11e5.jpg')
INSERT [dbo].[DeptwiseDoctors] ([DeptwiseId], [DepartmentId], [DoctorId], [Designation], [Institution], [VisitFee], [Picture]) VALUES (37, 29, 30, N'Associate professor', N'Dhaka medical', 750.0000, N'~/Images\5b91e813-d6b3-45e6-b544-8d21974c2d92.jpg')
SET IDENTITY_INSERT [dbo].[DeptwiseDoctors] OFF
GO
SET IDENTITY_INSERT [dbo].[Doctors ] ON 

INSERT [dbo].[Doctors ] ([DoctorId], [Name], [PatientId]) VALUES (11, N'Dr. sohan kahn', 8)
INSERT [dbo].[Doctors ] ([DoctorId], [Name], [PatientId]) VALUES (17, N'Dr.Ariful Islam', 7)
INSERT [dbo].[Doctors ] ([DoctorId], [Name], [PatientId]) VALUES (19, N'Main Uddin', 6)
INSERT [dbo].[Doctors ] ([DoctorId], [Name], [PatientId]) VALUES (20, N'Dr. Shahidul Haque', 5)
INSERT [dbo].[Doctors ] ([DoctorId], [Name], [PatientId]) VALUES (21, N'Dr.Dewan Saifuddin', 5)
INSERT [dbo].[Doctors ] ([DoctorId], [Name], [PatientId]) VALUES (22, N'Dr.Fatima Tori', 6)
INSERT [dbo].[Doctors ] ([DoctorId], [Name], [PatientId]) VALUES (23, N'Dr.Shahida haque', 8)
INSERT [dbo].[Doctors ] ([DoctorId], [Name], [PatientId]) VALUES (24, N'Dr.Sayeed khan', 5)
INSERT [dbo].[Doctors ] ([DoctorId], [Name], [PatientId]) VALUES (30, N'sohan kahn', NULL)
SET IDENTITY_INSERT [dbo].[Doctors ] OFF
GO
SET IDENTITY_INSERT [dbo].[Doctors Salary] ON 

INSERT [dbo].[Doctors Salary] ([DocsId], [VisitingDay], [PayRate], [TotalHour], [DoctorId]) VALUES (6, N' Friday', 1200.0000, 3, 11)
INSERT [dbo].[Doctors Salary] ([DocsId], [VisitingDay], [PayRate], [TotalHour], [DoctorId]) VALUES (7, N'Sunday', 1300.0000, 4, 17)
SET IDENTITY_INSERT [dbo].[Doctors Salary] OFF
GO
SET IDENTITY_INSERT [dbo].[Maintenence Employee] ON 

INSERT [dbo].[Maintenence Employee] ([EmpId], [Name], [Phone], [Work section], [Salary], [AdminId]) VALUES (2, N'Milon miah', 1537583955, N'Electronics', 15000.0000, 1)
INSERT [dbo].[Maintenence Employee] ([EmpId], [Name], [Phone], [Work section], [Salary], [AdminId]) VALUES (3, N'Shahana khatun', 1538756988, N'Kitchen', 10000.0000, 2)
SET IDENTITY_INSERT [dbo].[Maintenence Employee] OFF
GO
SET IDENTITY_INSERT [dbo].[Nurses] ON 

INSERT [dbo].[Nurses] ([NurseId], [Name], [Phone], [Salary], [DepartmentId]) VALUES (1, N'Habibur Rahman', 1637583988, 20000.0000, 11)
INSERT [dbo].[Nurses] ([NurseId], [Name], [Phone], [Salary], [DepartmentId]) VALUES (2, N'Shila katun', 1537683988, 25000.0000, 14)
SET IDENTITY_INSERT [dbo].[Nurses] OFF
GO
SET IDENTITY_INSERT [dbo].[Patinets] ON 

INSERT [dbo].[Patinets] ([PatientId], [Name], [Email], [VisitDate], [Fee], [Isadmitted]) VALUES (5, N'Anju moni', N'moni@gmail.com', CAST(N'2022-06-03' AS Date), 750.0000, 0)
INSERT [dbo].[Patinets] ([PatientId], [Name], [Email], [VisitDate], [Fee], [Isadmitted]) VALUES (6, N'sohan kahn', N'sohankhanss1996@gmail.com', CAST(N'2022-06-03' AS Date), 750.0000, 0)
INSERT [dbo].[Patinets] ([PatientId], [Name], [Email], [VisitDate], [Fee], [Isadmitted]) VALUES (7, N'Humayra ', N'hu@gmail.com', CAST(N'2022-06-23' AS Date), 950.0000, 1)
INSERT [dbo].[Patinets] ([PatientId], [Name], [Email], [VisitDate], [Fee], [Isadmitted]) VALUES (8, N'Nigar Sultana', N'n@gmail.com', CAST(N'2022-06-22' AS Date), 950.0000, 1)
INSERT [dbo].[Patinets] ([PatientId], [Name], [Email], [VisitDate], [Fee], [Isadmitted]) VALUES (9, N'sohan kahn', N'sohankhanss1996@gmail.com', CAST(N'2022-07-06' AS Date), 950.0000, 1)
INSERT [dbo].[Patinets] ([PatientId], [Name], [Email], [VisitDate], [Fee], [Isadmitted]) VALUES (10, N'Shamim Rahman', N's@gmail.com', CAST(N'2022-07-13' AS Date), 750.0000, 1)
INSERT [dbo].[Patinets] ([PatientId], [Name], [Email], [VisitDate], [Fee], [Isadmitted]) VALUES (11, N'Niloy Rahman', N'Niloy@gamil.com', CAST(N'2022-07-13' AS Date), 950.0000, 1)
SET IDENTITY_INSERT [dbo].[Patinets] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([RoleId], [Role]) VALUES (1, N'Viewer')
INSERT [dbo].[Role] ([RoleId], [Role]) VALUES (2, N'Admin')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[UserInfo] ON 

INSERT [dbo].[UserInfo] ([UserId], [Name], [Email], [Password], [Confirm pass], [Phone], [Role]) VALUES (2, N'sohan kahn', N'sohankhanss1996@gmail.com', N'302910', N'302910', N'01951797336', N'viewer    ')
INSERT [dbo].[UserInfo] ([UserId], [Name], [Email], [Password], [Confirm pass], [Phone], [Role]) VALUES (3, N'Nigar Sultana', N'n@gmail.com', N'4133095', N'4133095', N'01951797337', N'admin     ')
INSERT [dbo].[UserInfo] ([UserId], [Name], [Email], [Password], [Confirm pass], [Phone], [Role]) VALUES (5, N'Shamim Rahman', N'sha@gmail.com', N'shamim', N'shamim', N'01951797338', N'viewer    ')
INSERT [dbo].[UserInfo] ([UserId], [Name], [Email], [Password], [Confirm pass], [Phone], [Role]) VALUES (6, N'Main Uddin', N'm@gmail.com', N'main', N'main', N'01951797335', N'admin     ')
SET IDENTITY_INSERT [dbo].[UserInfo] OFF
GO
ALTER TABLE [dbo].[DeptwiseDoctors]  WITH CHECK ADD  CONSTRAINT [FK__DeptwiseD__Depar__4D94879B] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments ] ([DepartmentId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DeptwiseDoctors] CHECK CONSTRAINT [FK__DeptwiseD__Depar__4D94879B]
GO
ALTER TABLE [dbo].[DeptwiseDoctors]  WITH CHECK ADD  CONSTRAINT [FK__DeptwiseD__Docto__4E88ABD4] FOREIGN KEY([DoctorId])
REFERENCES [dbo].[Doctors ] ([DoctorId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DeptwiseDoctors] CHECK CONSTRAINT [FK__DeptwiseD__Docto__4E88ABD4]
GO
ALTER TABLE [dbo].[Doctors ]  WITH CHECK ADD  CONSTRAINT [FK_Doctors _Doctors ] FOREIGN KEY([DoctorId])
REFERENCES [dbo].[Doctors ] ([DoctorId])
GO
ALTER TABLE [dbo].[Doctors ] CHECK CONSTRAINT [FK_Doctors _Doctors ]
GO
ALTER TABLE [dbo].[Doctors ]  WITH CHECK ADD  CONSTRAINT [FK_Doctor's Table_Patinets] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patinets] ([PatientId])
GO
ALTER TABLE [dbo].[Doctors ] CHECK CONSTRAINT [FK_Doctor's Table_Patinets]
GO
ALTER TABLE [dbo].[Doctors Salary]  WITH CHECK ADD  CONSTRAINT [FK_Doctors Salary_Doctors ] FOREIGN KEY([DoctorId])
REFERENCES [dbo].[Doctors ] ([DoctorId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Doctors Salary] CHECK CONSTRAINT [FK_Doctors Salary_Doctors ]
GO
ALTER TABLE [dbo].[Maintenence Employee]  WITH CHECK ADD  CONSTRAINT [FK_Maintenence Employee_AdminPanel] FOREIGN KEY([AdminId])
REFERENCES [dbo].[AdminPanel] ([AdminId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Maintenence Employee] CHECK CONSTRAINT [FK_Maintenence Employee_AdminPanel]
GO
ALTER TABLE [dbo].[Nurses]  WITH CHECK ADD  CONSTRAINT [FK_Nurses_Departments ] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments ] ([DepartmentId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Nurses] CHECK CONSTRAINT [FK_Nurses_Departments ]
GO
USE [master]
GO
ALTER DATABASE [hosms] SET  READ_WRITE 
GO
