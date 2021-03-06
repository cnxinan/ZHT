USE [master]
GO
/****** Object:  Database [YuanXinBusiness]    Script Date: 12/19/16 06:11:12 PM ******/
CREATE DATABASE [YuanXinBusiness]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'YuanXinBusiness', FILENAME = N'D:\Configurations\DateBase\YuanXinBusiness.mdf' , SIZE = 9216KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'YuanXinBusiness_log', FILENAME = N'D:\Configurations\DateBase\YuanXinBusiness_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [YuanXinBusiness] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [YuanXinBusiness].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [YuanXinBusiness] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [YuanXinBusiness] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [YuanXinBusiness] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [YuanXinBusiness] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [YuanXinBusiness] SET ARITHABORT OFF 
GO
ALTER DATABASE [YuanXinBusiness] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [YuanXinBusiness] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [YuanXinBusiness] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [YuanXinBusiness] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [YuanXinBusiness] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [YuanXinBusiness] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [YuanXinBusiness] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [YuanXinBusiness] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [YuanXinBusiness] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [YuanXinBusiness] SET  DISABLE_BROKER 
GO
ALTER DATABASE [YuanXinBusiness] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [YuanXinBusiness] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [YuanXinBusiness] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [YuanXinBusiness] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [YuanXinBusiness] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [YuanXinBusiness] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [YuanXinBusiness] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [YuanXinBusiness] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [YuanXinBusiness] SET  MULTI_USER 
GO
ALTER DATABASE [YuanXinBusiness] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [YuanXinBusiness] SET DB_CHAINING OFF 
GO
ALTER DATABASE [YuanXinBusiness] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [YuanXinBusiness] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [YuanXinBusiness] SET DELAYED_DURABILITY = DISABLED 
GO
USE [YuanXinBusiness]
GO
/****** Object:  Schema [Business]    Script Date: 12/19/16 06:11:12 PM ******/
CREATE SCHEMA [Business]
GO
/****** Object:  Schema [zc]    Script Date: 12/19/16 06:11:12 PM ******/
CREATE SCHEMA [zc]
GO
/****** Object:  Table [Business].[Attachment]    Script Date: 12/19/16 06:11:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Business].[Attachment](
	[Code] [varchar](36) NOT NULL,
	[AttachmentTypeCode] [nvarchar](50) NULL,
	[ResourceID] [nvarchar](50) NULL,
	[CnName] [nvarchar](100) NOT NULL,
	[Suffix] [nvarchar](50) NULL,
	[URL] [nvarchar](256) NULL,
	[FileSize] [int] NULL,
	[Creator] [nvarchar](50) NOT NULL,
	[VersionStartTime] [datetime] NOT NULL CONSTRAINT [DF_Attachment_VersionStartTime]  DEFAULT (getdate()),
	[VersionEndTime] [datetime] NOT NULL CONSTRAINT [DF_Attachment_VersionEndTime]  DEFAULT (getdate()),
	[ValidStatus] [bit] NOT NULL,
	[SortNo] [int] NULL,
 CONSTRAINT [PK_REGULATIONS_SERVICEPACKAGE] PRIMARY KEY CLUSTERED 
(
	[Code] ASC,
	[VersionEndTime] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Business].[AttachmentType]    Script Date: 12/19/16 06:11:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Business].[AttachmentType](
	[Code] [nvarchar](50) NOT NULL,
	[CnName] [nvarchar](50) NOT NULL,
	[EnName] [nvarchar](50) NULL,
	[Creator] [nvarchar](50) NOT NULL,
	[CreateTime] [datetime] NOT NULL CONSTRAINT [DF_AttachmentType_CreateTime]  DEFAULT (getdate()),
	[Modifier] [nvarchar](50) NULL,
	[ModifyTime] [datetime] NULL,
	[ValidStatus] [bit] NOT NULL CONSTRAINT [DF_AttachmentType_ValidStatus]  DEFAULT ((1)),
	[SortNo] [int] NULL,
 CONSTRAINT [PK_AttachmentType] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Business].[BaseTypes]    Script Date: 12/19/16 06:11:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Business].[BaseTypes](
	[ID] [nvarchar](50) NOT NULL,
	[TypeName] [nvarchar](50) NULL,
	[TypeID] [int] NULL,
	[TypeValue] [nvarchar](100) NULL,
	[Creater] [nvarchar](50) NULL,
	[CreatTime] [datetime] NULL,
	[Modifier] [nvarchar](50) NULL,
	[ModifiyTime] [datetime] NULL,
	[IsDel] [int] NULL,
	[Temp1] [nvarchar](50) NULL,
	[Temp2] [nvarchar](50) NULL,
 CONSTRAINT [PK_BASETYPES] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Business].[BusinessScope]    Script Date: 12/19/16 06:11:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Business].[BusinessScope](
	[Code] [nvarchar](36) NOT NULL,
	[BusinessScopeName] [nvarchar](100) NULL,
	[Creator] [nvarchar](36) NULL,
	[CreateTime] [datetime] NULL,
	[Modifier] [nvarchar](36) NULL,
	[ModifyTime] [datetime] NULL,
	[ValidStatus] [bit] NULL,
 CONSTRAINT [PK_SellerProperty] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Business].[BusinessScopeType]    Script Date: 12/19/16 06:11:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Business].[BusinessScopeType](
	[Code] [nvarchar](36) NOT NULL,
	[GoodsTypeName] [nvarchar](100) NULL,
	[BusinessScopeCode] [nvarchar](36) NULL,
	[Creator] [nvarchar](36) NULL,
	[CreateTime] [datetime] NULL,
	[Modifier] [nvarchar](36) NULL,
	[ModifyTime] [datetime] NULL,
	[ValidStatus] [bit] NULL,
	[SortNumber] [int] NULL,
 CONSTRAINT [PK_BusinessScopeType] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Business].[BusinessType]    Script Date: 12/19/16 06:11:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Business].[BusinessType](
	[Code] [nvarchar](50) NOT NULL,
	[ParentCode] [nvarchar](50) NULL,
	[SimpleCode] [nvarchar](10) NULL,
	[CnName] [nvarchar](50) NOT NULL,
	[EnName] [nvarchar](50) NULL,
	[Creator] [nvarchar](50) NOT NULL CONSTRAINT [DF_BusinessType_Creator]  DEFAULT (N'xcj'),
	[CreateTime] [datetime] NOT NULL CONSTRAINT [DF_BusinessType_CreateTime]  DEFAULT (getdate()),
	[Modifier] [nvarchar](50) NULL,
	[ModifyTime] [datetime] NULL CONSTRAINT [DF_BusinessType_ModifyTime]  DEFAULT (getdate()),
	[ValidStatus] [bit] NOT NULL CONSTRAINT [DF_BusinessType_ValidStatus]  DEFAULT ((1)),
	[SortNo] [int] NULL,
 CONSTRAINT [PK_BusinessType] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Business].[Company]    Script Date: 12/19/16 06:11:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Business].[Company](
	[Code] [nvarchar](36) NOT NULL,
	[BusinessTypeCode] [nvarchar](36) NULL,
	[AuditStatusCode] [nvarchar](36) NULL,
	[CnName] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](200) NULL,
	[BusinessLicenseNumber] [nvarchar](50) NULL,
	[LegalPersonName] [nvarchar](50) NULL,
	[LegalPersonMobilePhone] [nvarchar](15) NULL,
	[LegalPersonIdentityCardNumber] [nvarchar](50) NULL,
	[CountyCode] [nvarchar](36) NULL,
	[Location] [nvarchar](50) NULL,
	[SortNo] [int] NULL,
	[VersionEndTime] [datetime] NOT NULL CONSTRAINT [DF_Company_VersionEndTime]  DEFAULT (getdate()),
	[Creator] [nvarchar](36) NULL,
	[VersionStartTime] [datetime] NULL CONSTRAINT [DF_Company_VersionStartTime]  DEFAULT (getdate()),
	[Category] [int] NULL CONSTRAINT [DF_Company_Class]  DEFAULT ((2)),
	[ContactPerson] [nvarchar](50) NULL,
	[ValidStatus] [bit] NULL,
	[Number] [nvarchar](50) NULL,
	[EvaluationCount] [int] NULL,
	[TotalScore] [int] NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[Code] ASC,
	[VersionEndTime] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Business].[CompanyUser]    Script Date: 12/19/16 06:11:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Business].[CompanyUser](
	[Code] [nvarchar](36) NOT NULL,
	[UserID] [nvarchar](36) NOT NULL,
	[CompanyCode] [nvarchar](36) NOT NULL,
	[ValidStatus] [bit] NOT NULL,
	[IsManager] [bit] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_CompanyUser] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Business].[EnrollUser]    Script Date: 12/19/16 06:11:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Business].[EnrollUser](
	[ID] [nvarchar](50) NOT NULL,
	[EnrollTime] [datetime] NULL,
	[ExhibitionCode] [nvarchar](50) NOT NULL,
	[NickName] [nvarchar](20) NULL,
	[SName] [nvarchar](50) NULL,
	[SPhone] [nvarchar](50) NULL,
	[TicketStatus] [int] NULL,
	[PwdTicket] [nvarchar](50) NULL,
	[Remark] [nvarchar](200) NULL,
	[Creater] [nvarchar](50) NOT NULL,
	[CreatTime] [datetime] NULL,
	[Modifier] [nvarchar](50) NULL,
	[ModifiyTime] [datetime] NULL,
	[IsDel] [int] NULL,
	[Temp1] [nvarchar](50) NULL,
	[Temp2] [nvarchar](50) NULL,
	[TicketTypeCode] [nvarchar](50) NULL,
	[OrderNo] [varchar](50) NULL,
 CONSTRAINT [PK_ENROLLUSER] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Business].[Exhibition]    Script Date: 12/19/16 06:11:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Business].[Exhibition](
	[ID] [nvarchar](50) NOT NULL,
	[ExhibitionName] [nvarchar](100) NULL,
	[BaseTypesCode] [nvarchar](50) NULL,
	[nocolumn] [nvarchar](50) NULL,
	[StartTime] [datetime] NULL,
	[EndTime] [datetime] NULL,
	[Address1] [nvarchar](100) NULL,
	[Address2] [nvarchar](100) NULL,
	[Longitude] [varchar](50) NULL,
	[Latitude] [varchar](50) NULL,
	[Detailes] [nvarchar](200) NULL,
	[RecruitStatus] [int] NULL,
	[EnrollStatus] [int] NULL,
	[BusinessID] [nvarchar](100) NOT NULL,
	[BusinessName] [nvarchar](100) NULL,
	[PublishedTime] [datetime] NULL,
	[RecruitEndTime] [datetime] NULL,
	[EnrollStartTime] [datetime] NULL,
	[EnrollEndTime] [datetime] NULL,
	[LowDiscount] [decimal](18, 2) NULL,
	[SaleProportion] [decimal](18, 2) NULL,
	[Creater] [nvarchar](50) NOT NULL,
	[CreatTime] [datetime] NULL,
	[Modifier] [nvarchar](50) NULL,
	[ModifiyTime] [datetime] NULL,
	[IsDel] [int] NULL,
	[Temp1] [nvarchar](100) NULL,
	[Temp2] [nvarchar](100) NULL,
	[Province] [nvarchar](20) NULL,
	[City] [nvarchar](20) NULL,
	[Area] [nvarchar](100) NULL,
 CONSTRAINT [PK_EXHIBITION] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Business].[ExhibitionProduct]    Script Date: 12/19/16 06:11:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Business].[ExhibitionProduct](
	[ID] [nvarchar](50) NOT NULL,
	[SellerCode] [nvarchar](50) NOT NULL,
	[ExhibitionCode] [nvarchar](50) NOT NULL,
	[YXProductCode] [nvarchar](50) NULL,
	[Unit] [nvarchar](50) NULL,
	[ExhibitionProductClassCode] [nvarchar](50) NULL,
	[NPrice] [decimal](18, 2) NULL,
	[Oprice] [decimal](18, 2) NULL,
	[Quantity] [int] NULL,
	[PDetails] [nvarchar](200) NULL,
	[PStatus] [int] NULL,
	[Creater] [nvarchar](50) NOT NULL,
	[CreatTime] [datetime] NULL,
	[Modifier] [nvarchar](50) NULL,
	[ModifiyTime] [datetime] NULL,
	[IsDel] [int] NULL,
	[Remark] [nvarchar](200) NULL,
	[Temp1] [nvarchar](50) NULL,
	[Temp2] [nvarchar](50) NULL,
	[ProductName] [nvarchar](50) NULL,
 CONSTRAINT [PK_EXHIBITIONPRODUCT] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Business].[ExhibitionProductClass]    Script Date: 12/19/16 06:11:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Business].[ExhibitionProductClass](
	[ID] [nvarchar](50) NOT NULL,
	[ClassName] [nvarchar](50) NULL,
	[ExhibitionCode] [nvarchar](50) NULL,
	[ClassRemark] [nvarchar](100) NULL,
	[Creater] [nvarchar](50) NULL,
	[CreatTime] [datetime] NULL,
	[Modifier] [nvarchar](50) NULL,
	[ModifiyTime] [datetime] NULL,
	[IsDel] [int] NULL,
	[Temp1] [nvarchar](50) NULL,
	[Temp2] [nvarchar](50) NULL,
 CONSTRAINT [PK_EXHIBITIONPRODUCTCLASS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Business].[ExhibitionTag]    Script Date: 12/19/16 06:11:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Business].[ExhibitionTag](
	[ID] [nvarchar](50) NOT NULL,
	[TagName] [nvarchar](50) NULL,
	[ExhibitionCode] [nvarchar](50) NULL,
	[TagRemark] [nvarchar](100) NULL,
	[Creater] [nvarchar](50) NULL,
	[CreatTime] [datetime] NULL,
	[Modifier] [nvarchar](50) NULL,
	[ModifiyTime] [datetime] NULL,
	[IsDel] [int] NULL,
	[Temp1] [nvarchar](50) NULL,
	[Temp2] [nvarchar](50) NULL,
 CONSTRAINT [PK_EXHIBITIONTAG] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Business].[FollowMoment]    Script Date: 12/19/16 06:11:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Business].[FollowMoment](
	[ID] [nvarchar](50) NOT NULL,
	[FollowTime] [datetime] NULL,
	[FollowUserCode] [nvarchar](50) NULL,
	[ExhibitionCode] [nvarchar](50) NOT NULL,
	[MomentCode] [nvarchar](50) NOT NULL,
	[IsDel] [int] NULL,
	[Temp1] [nvarchar](50) NULL,
	[Temp2] [nvarchar](50) NULL,
 CONSTRAINT [PK_FOLLOWMOMENT] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Business].[Goods]    Script Date: 12/19/16 06:11:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Business].[Goods](
	[Code] [nvarchar](36) NOT NULL,
	[GoodsNumber] [nvarchar](36) NULL,
	[SellerCode] [nvarchar](36) NULL,
	[GoodsName] [nvarchar](100) NULL,
	[IsReserve] [bit] NULL,
	[GoodsTypeCode] [nvarchar](36) NULL,
	[GoodsUnitCode] [nvarchar](36) NULL,
	[OldPrice] [int] NULL,
	[Price] [int] NULL,
	[Commission] [int] NULL,
	[Intruduction] [ntext] NULL,
	[IsShelves] [bit] NULL,
	[ExpressCharge] [int] NULL,
	[Creator] [nvarchar](36) NULL,
	[CreateTime] [datetime] NULL,
	[Modifier] [nvarchar](36) NULL,
	[ModifyTime] [datetime] NULL,
	[ValidStatus] [bit] NULL,
	[LinkNumber] [int] NULL,
	[MonthSalesNum] [int] NULL,
	[IsTakeOut] [bit] NULL,
	[IsSoldOut] [bit] NULL,
	[IsRecommend] [bit] NULL,
	[ProvinceCode] [nvarchar](36) NULL,
	[CityCode] [nvarchar](36) NULL,
	[CountyCode] [nvarchar](36) NULL,
	[GoodsWeight] [int] NULL,
	[MinimumQuantity] [int] NULL,
	[IsFreightFee] [bit] NULL,
	[FreightFeeTemplateCode] [nvarchar](36) NULL,
	[IsPreSale] [bit] NULL,
	[IsCrowdfunding] [bit] NULL,
	[CentralizedProcurementCode] [nvarchar](36) NULL,
	[StockCount] [int] NULL,
	[StorageCost] [int] NULL CONSTRAINT [DF_Goods_StorageCost]  DEFAULT ((0)),
	[LimitedQuantity] [int] NULL,
	[IsLimitedNewUser] [bit] NULL CONSTRAINT [DF_Goods_IsLimitedNewUser]  DEFAULT ((0)),
	[OriginPlace] [nvarchar](36) NULL,
 CONSTRAINT [PK_Goods] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [Business].[Goods_BusinessScopeType]    Script Date: 12/19/16 06:11:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Business].[Goods_BusinessScopeType](
	[Code] [nvarchar](36) NOT NULL,
	[GoodsCode] [nvarchar](36) NULL,
	[BusinessScopeTypeCode] [nvarchar](36) NULL,
	[Creator] [nvarchar](36) NULL,
	[CreateTime] [datetime] NULL,
	[Modifier] [nvarchar](36) NULL,
	[ModifyTime] [datetime] NULL,
	[ValidStatus] [bit] NULL,
 CONSTRAINT [PK_Goods_BusinessScope] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Business].[Goods_Material]    Script Date: 12/19/16 06:11:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Business].[Goods_Material](
	[Code] [nvarchar](36) NOT NULL,
	[GoodsCode] [nvarchar](36) NULL,
	[MaterialCode] [nvarchar](36) NULL,
	[Creator] [nvarchar](36) NULL,
	[CreateTime] [datetime] NULL,
	[Modifier] [nvarchar](36) NULL,
	[ModifyTime] [datetime] NULL,
	[ValidStatus] [bit] NULL,
 CONSTRAINT [PK_Goods_Material] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Business].[GoodsUnit]    Script Date: 12/19/16 06:11:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Business].[GoodsUnit](
	[Code] [nvarchar](50) NOT NULL,
	[GoodsUnitName] [nvarchar](100) NULL,
	[Remark] [nvarchar](1024) NULL,
	[SellerCode] [nvarchar](36) NULL,
	[Creator] [nvarchar](36) NULL,
	[CreateTime] [datetime] NULL,
	[Modifier] [nvarchar](36) NULL,
	[ModifyTime] [datetime] NULL,
	[ValidStatus] [bit] NULL,
	[GoodsUnitType] [int] NULL,
 CONSTRAINT [PK_GOODSUNIT] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Business].[Material]    Script Date: 12/19/16 06:11:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Business].[Material](
	[Code] [nvarchar](36) NOT NULL,
	[MaterialType] [int] NULL,
	[MaterialName] [nvarchar](256) NULL,
	[Content] [nvarchar](max) NULL,
	[FilePath] [nvarchar](256) NULL,
	[Creator] [nvarchar](36) NULL,
	[CreateTime] [datetime] NULL,
	[Modifier] [nvarchar](36) NULL,
	[ModifyTime] [datetime] NULL,
	[ValidStatus] [bit] NULL,
 CONSTRAINT [PK_MATERIAL] PRIMARY KEY NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [Business].[Moment]    Script Date: 12/19/16 06:11:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Business].[Moment](
	[ID] [nvarchar](50) NOT NULL,
	[PubTime] [datetime] NULL,
	[PubContent] [nvarchar](100) NULL,
	[Types] [int] NULL,
	[PublisherCode] [nvarchar](50) NOT NULL,
	[ExhibitionCode] [nvarchar](50) NOT NULL,
	[Creater] [nvarchar](50) NOT NULL,
	[CreatTime] [datetime] NULL,
	[Modifier] [nvarchar](50) NULL,
	[ModifiyTime] [datetime] NULL,
	[IsDel] [int] NULL,
	[Temp1] [nvarchar](50) NULL,
	[Temp2] [nvarchar](50) NULL,
	[ViewUserIds] [text] NULL,
 CONSTRAINT [PK_MOMENT] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [Business].[MomentReply]    Script Date: 12/19/16 06:11:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Business].[MomentReply](
	[ID] [nvarchar](50) NOT NULL,
	[ReplyTime] [datetime] NULL,
	[ReplyContent] [nvarchar](50) NULL,
	[MomentCode] [nvarchar](50) NOT NULL,
	[ParentID] [nvarchar](50) NULL,
	[Creater] [nvarchar](50) NOT NULL,
	[CreatTime] [datetime] NULL,
	[Modifier] [nvarchar](50) NULL,
	[ModifiyTime] [datetime] NULL,
	[IsDel] [int] NULL,
	[Temp1] [nvarchar](50) NULL,
	[Temp2] [nvarchar](50) NULL,
 CONSTRAINT [PK_MOMENTREPLY] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Business].[MyFavorites]    Script Date: 12/19/16 06:11:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Business].[MyFavorites](
	[ID] [nvarchar](50) NOT NULL,
	[FavoritesTime] [datetime] NULL,
	[UserCode] [nvarchar](50) NOT NULL,
	[FavoritesCode] [nvarchar](50) NOT NULL,
	[Types] [int] NOT NULL,
	[Creater] [nvarchar](50) NOT NULL,
	[CreatTime] [datetime] NULL,
	[Modifier] [nvarchar](50) NULL,
	[ModifiyTime] [datetime] NULL,
	[IsDel] [int] NULL,
	[Temp1] [nvarchar](50) NULL,
	[Temp2] [nvarchar](50) NULL,
 CONSTRAINT [PK_MYFAVORITES] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Business].[Notify]    Script Date: 12/19/16 06:11:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Business].[Notify](
	[ID] [nvarchar](50) NOT NULL,
	[NotifyTime] [datetime] NULL,
	[NotifyType] [int] NULL,
	[NotifyContent] [nvarchar](200) NULL,
	[UserCode] [int] NULL,
	[Remark] [nvarchar](200) NULL,
	[Creater] [nvarchar](50) NOT NULL,
	[CreatTime] [datetime] NOT NULL,
	[Modifier] [nvarchar](50) NULL,
	[ModifiyTime] [datetime] NULL,
	[IsDel] [int] NULL,
	[Temp1] [nvarchar](50) NULL,
	[Temp2] [nvarchar](50) NULL,
 CONSTRAINT [PK_NOTIFY] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Business].[Order]    Script Date: 12/19/16 06:11:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Business].[Order](
	[Code] [nvarchar](36) NOT NULL,
	[OrderNumber] [nvarchar](36) NULL,
	[WxUnifiedOrderNum] [nvarchar](36) NULL,
	[BusinessUserCode] [nvarchar](36) NULL,
	[SharedBusinessUserCode] [nvarchar](36) NULL,
	[SellerCode] [nvarchar](36) NULL,
	[SellerNumber] [nvarchar](36) NULL,
	[SellerName] [nvarchar](100) NULL,
	[OrderType] [int] NULL,
	[CustomerName] [nvarchar](36) NULL,
	[Telephone] [nvarchar](20) NULL,
	[Sex] [int] NULL,
	[BusinessUserAddress] [nvarchar](1024) NULL,
	[CreateTime] [datetime] NULL,
	[CustomerDate] [datetime] NULL,
	[CustomerTime] [nvarchar](50) NULL,
	[OrderFrom] [int] NULL,
	[PyteType] [int] NULL,
	[ServiceCharge] [int] NULL,
	[StorageCharge] [int] NULL,
	[Charge] [int] NULL,
	[TotalCharge] [int] NULL,
	[BalancePay] [int] NULL,
	[CardVoucherPay] [int] NULL,
	[RealPay] [int] NULL,
	[SendTime] [datetime] NULL,
	[CompleteTime] [datetime] NULL,
	[ExpressNum] [nvarchar](20) NULL,
	[CustomerMessage] [nvarchar](512) NULL,
	[PeopleNum] [int] NULL,
	[DeskNumCode] [nvarchar](36) NULL,
	[Status] [int] NULL,
	[Quantity] [int] NULL,
	[NeedInvoice] [bit] NULL,
	[InvoiceTitle] [nvarchar](255) NULL,
	[InvoiceType] [int] NULL,
	[InvoiceContent] [int] NULL,
	[ModifyTime] [datetime] NULL,
	[IsDelete] [bit] NULL,
	[ValidStatus] [bit] NULL,
	[Modifier] [nvarchar](36) NULL,
	[Creator] [nvarchar](36) NULL,
	[SellerDiscountCode] [nvarchar](36) NULL,
	[ConfirmTime] [datetime] NULL,
	[DiscountCharge] [int] NULL,
	[CourierCode] [nvarchar](36) NULL,
	[CourierUserName] [nvarchar](100) NULL,
	[CourierTelephone] [nvarchar](20) NULL,
	[ExpressType] [int] NULL,
	[TransportMethod] [int] NULL,
	[RealRefundPay] [int] NULL,
	[GroupPurchaseCode] [nvarchar](36) NULL,
	[PlatformCardVoucherPay] [int] NULL,
	[PreSaleCode] [nvarchar](36) NULL,
	[CrowdfundingCode] [nvarchar](36) NULL,
	[FreightCode] [nvarchar](36) NULL,
	[StoreSharingOrderCode] [nvarchar](36) NULL,
	[IsSelfPickup] [bit] NULL,
	[SelfPickupAddressCode] [nvarchar](36) NULL,
	[SelfPickupAddressName] [nvarchar](36) NULL,
	[ShoppingCardPay] [int] NULL,
	[SumCommission] [int] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Business].[OrderDetail]    Script Date: 12/19/16 06:11:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Business].[OrderDetail](
	[Code] [nvarchar](36) NOT NULL,
	[OpenID] [nvarchar](36) NULL,
	[OrderCode] [nvarchar](36) NULL,
	[GoodsCode] [nvarchar](36) NULL,
	[GoodsName] [nvarchar](100) NULL,
	[SharedBusinessUserCode] [nvarchar](36) NULL,
	[GoodsCount] [int] NULL,
	[Charge] [int] NULL,
	[UserName] [nvarchar](255) NULL,
	[Remark] [nvarchar](2014) NULL,
	[CreateTime] [datetime] NULL,
	[Modifier] [nvarchar](36) NULL,
	[ModifyTime] [datetime] NULL,
	[ValidStatus] [bit] NULL,
 CONSTRAINT [PK_ORDERDETAIL] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Business].[Schedule]    Script Date: 12/19/16 06:11:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Business].[Schedule](
	[ID] [nvarchar](50) NOT NULL,
	[STime] [datetime] NULL,
	[StartTime] [datetime] NULL,
	[EndTime] [datetime] NULL,
	[ScheduleName] [nvarchar](50) NULL,
	[ScheduleDesc] [nvarchar](200) NULL,
	[ExhibitionCode] [nvarchar](50) NOT NULL,
	[Creater] [nvarchar](50) NOT NULL,
	[CreatTime] [datetime] NULL,
	[Modifier] [nvarchar](50) NULL,
	[ModifiyTime] [datetime] NULL,
	[IsDel] [int] NULL,
	[Temp1] [nvarchar](50) NULL,
	[Temp2] [nvarchar](50) NULL,
 CONSTRAINT [PK_SCHEDULE] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Business].[SeatNo]    Script Date: 12/19/16 06:11:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Business].[SeatNo](
	[ID] [nvarchar](50) NOT NULL,
	[SeatSetCode] [nvarchar](50) NULL,
	[SeatNo] [nvarchar](50) NULL,
	[Remark] [nvarchar](50) NULL,
	[Creater] [nvarchar](50) NOT NULL,
	[CreatTime] [datetime] NULL,
	[Modifier] [nvarchar](50) NULL,
	[ModifiyTime] [datetime] NULL,
	[IsDel] [int] NULL,
	[Temp1] [nvarchar](50) NULL,
	[Temp2] [nvarchar](50) NULL,
 CONSTRAINT [PK_SEATNO] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Business].[SeatSet]    Script Date: 12/19/16 06:11:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Business].[SeatSet](
	[ID] [nvarchar](50) NOT NULL,
	[ExhibitionCode] [nvarchar](50) NULL,
	[BaseTypesCode] [nvarchar](50) NULL,
	[SeatPrice] [decimal](18, 2) NULL,
	[SeatScale] [nvarchar](50) NULL,
	[Creater] [nvarchar](50) NOT NULL,
	[CreatTime] [datetime] NULL,
	[Modifier] [nvarchar](50) NULL,
	[ModifiyTime] [datetime] NULL,
	[IsDel] [int] NULL,
	[Temp1] [nvarchar](50) NULL,
	[Temp2] [nvarchar](50) NULL,
 CONSTRAINT [PK_SEATSET] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Business].[SellerOrder]    Script Date: 12/19/16 06:11:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Business].[SellerOrder](
	[ID] [nvarchar](50) NOT NULL,
	[EnrollTime] [datetime] NULL,
	[SeatSetCode] [nvarchar](50) NULL,
	[SName] [nvarchar](50) NULL,
	[SPhone] [nvarchar](50) NULL,
	[TotalPrice] [decimal](18, 2) NULL,
	[PayType] [nvarchar](50) NULL,
	[PayAccount] [nvarchar](50) NULL,
	[SellerID] [nvarchar](50) NOT NULL,
	[Remark] [nvarchar](200) NULL,
	[OrderNo] [nvarchar](50) NULL,
	[ExhibitionID] [nvarchar](50) NOT NULL,
	[SellerIntro] [nvarchar](200) NULL,
	[OrderStatus] [int] NULL,
	[CreatTime] [datetime] NOT NULL,
	[Creater] [nvarchar](50) NOT NULL,
	[ModifiyTime] [datetime] NULL,
	[Modifier] [nvarchar](50) NULL,
	[IsDel] [int] NULL,
	[Temp1] [nvarchar](50) NULL,
	[Temp2] [nvarchar](50) NULL,
	[SellerName] [nvarchar](200) NULL,
 CONSTRAINT [PK_SELLERORDER] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Business].[SellerOrderDetails]    Script Date: 12/19/16 06:11:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Business].[SellerOrderDetails](
	[ID] [nvarchar](50) NOT NULL,
	[SellerOrderCode] [nvarchar](50) NOT NULL,
	[SeatNoCode] [nvarchar](50) NOT NULL,
	[CreatTime] [datetime] NOT NULL,
	[Creater] [nvarchar](50) NOT NULL,
	[ModifiyTime] [datetime] NULL,
	[Modifier] [nvarchar](50) NULL,
	[IsDel] [int] NULL,
	[Temp1] [nvarchar](50) NULL,
	[Temp2] [nvarchar](50) NULL,
 CONSTRAINT [PK_SELLERORDERDETAILS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Business].[Settlement]    Script Date: 12/19/16 06:11:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Business].[Settlement](
	[ID] [nvarchar](50) NOT NULL,
	[ExhibitionCode] [nvarchar](50) NULL,
	[Type] [int] NULL,
	[Creater] [nvarchar](50) NULL,
	[CreatTime] [datetime] NULL,
	[IsDel] [int] NULL,
 CONSTRAINT [PK_Settlement] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Business].[TicketsSet]    Script Date: 12/19/16 06:11:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Business].[TicketsSet](
	[ID] [nvarchar](50) NOT NULL,
	[NameRequire] [bit] NULL,
	[PhoneRequire] [bit] NULL,
	[ExhibitionCode] [nvarchar](50) NOT NULL,
	[Creater] [nvarchar](50) NOT NULL,
	[CreatTime] [datetime] NOT NULL,
	[Modifier] [nvarchar](50) NULL,
	[ModifiyTime] [datetime] NULL,
	[IsDel] [int] NULL,
	[Temp1] [nvarchar](50) NULL,
	[Temp2] [nvarchar](50) NULL,
 CONSTRAINT [PK_TICKETSSET] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Business].[TicketsType]    Script Date: 12/19/16 06:11:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Business].[TicketsType](
	[ID] [nvarchar](50) NOT NULL,
	[TicketName] [nvarchar](50) NULL,
	[Price] [decimal](18, 2) NULL,
	[Quota] [int] NULL,
	[Privilege] [nvarchar](200) NULL,
	[TicketsSetCode] [nvarchar](50) NOT NULL,
	[Creater] [nvarchar](50) NOT NULL,
	[CreatTime] [datetime] NOT NULL,
	[Modifier] [nvarchar](50) NULL,
	[ModifiyTime] [datetime] NULL,
	[IsDel] [int] NULL,
	[Temp1] [nvarchar](50) NULL,
	[Temp2] [nvarchar](50) NULL,
 CONSTRAINT [PK_TICKETSTYPE] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [zc].[UserInfo]    Script Date: 12/19/16 06:11:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [zc].[UserInfo](
	[Code] [nvarchar](36) NOT NULL,
	[Nickname] [nvarchar](50) NULL,
	[HeadImage] [nvarchar](256) NULL,
	[Phone] [nvarchar](11) NULL,
	[Email] [nvarchar](50) NULL,
	[Gender] [nvarchar](10) NULL,
	[Province] [nvarchar](36) NULL,
	[City] [nvarchar](36) NULL,
	[Signature] [nvarchar](50) NULL,
	[RealName] [nvarchar](10) NULL,
	[IDNumber] [nvarchar](18) NULL,
	[UserType] [nvarchar](10) NULL,
	[AuditStatus] [nvarchar](10) NULL,
	[Creator] [nvarchar](36) NULL,
	[CreateTime] [datetime] NULL,
	[IsValid] [bit] NULL,
	[FollowerNo] [int] NULL,
	[FocusNo] [int] NULL,
	[CollectNo] [int] NULL,
	[LaunchNo] [int] NULL,
	[SupportNo] [int] NULL,
	[PointTotal] [int] NULL,
	[NewMessage] [int] NULL,
	[PraiseNo] [int] NULL,
	[FriendNo] [int] NULL,
	[FriendApply] [int] NULL,
	[IsApplay] [int] NULL,
	[ApplayNo] [int] NULL,
	[DynamicTime] [datetime] NULL,
	[TaskTime] [datetime] NULL,
	[BankCardNo] [int] NULL,
	[IsLifer] [bit] NULL,
 CONSTRAINT [PK_USERINFO] PRIMARY KEY NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编码' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Attachment', @level2type=N'COLUMN',@level2name=N'Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'附件类型编码' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Attachment', @level2type=N'COLUMN',@level2name=N'AttachmentTypeCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'资源编码' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Attachment', @level2type=N'COLUMN',@level2name=N'ResourceID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'中文名' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Attachment', @level2type=N'COLUMN',@level2name=N'CnName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'英文名' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Attachment', @level2type=N'COLUMN',@level2name=N'Suffix'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'地址' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Attachment', @level2type=N'COLUMN',@level2name=N'URL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'文件大小' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Attachment', @level2type=N'COLUMN',@level2name=N'FileSize'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Attachment', @level2type=N'COLUMN',@level2name=N'Creator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Attachment', @level2type=N'COLUMN',@level2name=N'VersionStartTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'有效性' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Attachment', @level2type=N'COLUMN',@level2name=N'ValidStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Attachment', @level2type=N'COLUMN',@level2name=N'SortNo'
GO
EXEC sys.sp_addextendedproperty @name=N'CnName', @value=N'附件' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Attachment'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'附件' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Attachment'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编码' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'AttachmentType', @level2type=N'COLUMN',@level2name=N'Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'中文名' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'AttachmentType', @level2type=N'COLUMN',@level2name=N'CnName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'英文名' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'AttachmentType', @level2type=N'COLUMN',@level2name=N'EnName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'AttachmentType', @level2type=N'COLUMN',@level2name=N'Creator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'AttachmentType', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'AttachmentType', @level2type=N'COLUMN',@level2name=N'Modifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'AttachmentType', @level2type=N'COLUMN',@level2name=N'ModifyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'有效性' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'AttachmentType', @level2type=N'COLUMN',@level2name=N'ValidStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序号' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'AttachmentType', @level2type=N'COLUMN',@level2name=N'SortNo'
GO
EXEC sys.sp_addextendedproperty @name=N'CnName', @value=N'附件类型' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'AttachmentType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'附件类型' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'AttachmentType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'BaseTypes', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类型名称' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'BaseTypes', @level2type=N'COLUMN',@level2name=N'TypeName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类型ID' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'BaseTypes', @level2type=N'COLUMN',@level2name=N'TypeID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类型值' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'BaseTypes', @level2type=N'COLUMN',@level2name=N'TypeValue'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'BaseTypes', @level2type=N'COLUMN',@level2name=N'Creater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'BaseTypes', @level2type=N'COLUMN',@level2name=N'CreatTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'BaseTypes', @level2type=N'COLUMN',@level2name=N'Modifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'BaseTypes', @level2type=N'COLUMN',@level2name=N'ModifiyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'删除状态' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'BaseTypes', @level2type=N'COLUMN',@level2name=N'IsDel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他1' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'BaseTypes', @level2type=N'COLUMN',@level2name=N'Temp1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他2' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'BaseTypes', @level2type=N'COLUMN',@level2name=N'Temp2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'基础类型表' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'BaseTypes'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编码' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'BusinessType', @level2type=N'COLUMN',@level2name=N'Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'父编码' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'BusinessType', @level2type=N'COLUMN',@level2name=N'ParentCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'简码' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'BusinessType', @level2type=N'COLUMN',@level2name=N'SimpleCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'中文名' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'BusinessType', @level2type=N'COLUMN',@level2name=N'CnName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'英文名' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'BusinessType', @level2type=N'COLUMN',@level2name=N'EnName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'BusinessType', @level2type=N'COLUMN',@level2name=N'Creator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'BusinessType', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'BusinessType', @level2type=N'COLUMN',@level2name=N'Modifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'BusinessType', @level2type=N'COLUMN',@level2name=N'ModifyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'有效性' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'BusinessType', @level2type=N'COLUMN',@level2name=N'ValidStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序号' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'BusinessType', @level2type=N'COLUMN',@level2name=N'SortNo'
GO
EXEC sys.sp_addextendedproperty @name=N'CnName', @value=N'商家分类' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'BusinessType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商家分类' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'BusinessType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编码' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Company', @level2type=N'COLUMN',@level2name=N'Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商家分类编码' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Company', @level2type=N'COLUMN',@level2name=N'BusinessTypeCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'审核状态编码' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Company', @level2type=N'COLUMN',@level2name=N'AuditStatusCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'中文名' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Company', @level2type=N'COLUMN',@level2name=N'CnName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'详细地址' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Company', @level2type=N'COLUMN',@level2name=N'Address'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'营业执照注册号' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Company', @level2type=N'COLUMN',@level2name=N'BusinessLicenseNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'法人姓名' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Company', @level2type=N'COLUMN',@level2name=N'LegalPersonName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系人手机号' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Company', @level2type=N'COLUMN',@level2name=N'LegalPersonMobilePhone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'法人证件号' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Company', @level2type=N'COLUMN',@level2name=N'LegalPersonIdentityCardNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'县编码' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Company', @level2type=N'COLUMN',@level2name=N'CountyCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'省市区' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Company', @level2type=N'COLUMN',@level2name=N'Location'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序号' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Company', @level2type=N'COLUMN',@level2name=N'SortNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类别 1.个人,2.商家' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Company', @level2type=N'COLUMN',@level2name=N'Category'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系人' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Company', @level2type=N'COLUMN',@level2name=N'ContactPerson'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'有效性' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Company', @level2type=N'COLUMN',@level2name=N'ValidStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Company', @level2type=N'COLUMN',@level2name=N'Number'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'评价人数' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Company', @level2type=N'COLUMN',@level2name=N'EvaluationCount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'评价总分' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Company', @level2type=N'COLUMN',@level2name=N'TotalScore'
GO
EXEC sys.sp_addextendedproperty @name=N'CnName', @value=N'商家信息' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Company'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商家信息' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Company'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编码' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'CompanyUser', @level2type=N'COLUMN',@level2name=N'Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户编码' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'CompanyUser', @level2type=N'COLUMN',@level2name=N'UserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商家编码' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'CompanyUser', @level2type=N'COLUMN',@level2name=N'CompanyCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'有效性' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'CompanyUser', @level2type=N'COLUMN',@level2name=N'ValidStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否管理员' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'CompanyUser', @level2type=N'COLUMN',@level2name=N'IsManager'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'CompanyUser', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'EnrollUser', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报名时间' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'EnrollUser', @level2type=N'COLUMN',@level2name=N'EnrollTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报名展会ID' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'EnrollUser', @level2type=N'COLUMN',@level2name=N'ExhibitionCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'昵称' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'EnrollUser', @level2type=N'COLUMN',@level2name=N'NickName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'姓名' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'EnrollUser', @level2type=N'COLUMN',@level2name=N'SName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'手机号' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'EnrollUser', @level2type=N'COLUMN',@level2name=N'SPhone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'门票状态(0未验票，1已验票)' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'EnrollUser', @level2type=N'COLUMN',@level2name=N'TicketStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密码验票码' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'EnrollUser', @level2type=N'COLUMN',@level2name=N'PwdTicket'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'EnrollUser', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'EnrollUser', @level2type=N'COLUMN',@level2name=N'Creater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'EnrollUser', @level2type=N'COLUMN',@level2name=N'CreatTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'EnrollUser', @level2type=N'COLUMN',@level2name=N'Modifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'EnrollUser', @level2type=N'COLUMN',@level2name=N'ModifiyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'删除状态' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'EnrollUser', @level2type=N'COLUMN',@level2name=N'IsDel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他1' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'EnrollUser', @level2type=N'COLUMN',@level2name=N'Temp1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他2' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'EnrollUser', @level2type=N'COLUMN',@level2name=N'Temp2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报名表' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'EnrollUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Exhibition', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'展会名称' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Exhibition', @level2type=N'COLUMN',@level2name=N'ExhibitionName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'展会类型(引用基础类型表)2' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Exhibition', @level2type=N'COLUMN',@level2name=N'BaseTypesCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'展会分类去展会分类表中查询' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Exhibition', @level2type=N'COLUMN',@level2name=N'nocolumn'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'开始时间' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Exhibition', @level2type=N'COLUMN',@level2name=N'StartTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'结束时间' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Exhibition', @level2type=N'COLUMN',@level2name=N'EndTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'展会地址1(手动输入)' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Exhibition', @level2type=N'COLUMN',@level2name=N'Address1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'展会地址2(地图获取)' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Exhibition', @level2type=N'COLUMN',@level2name=N'Address2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'展会地址经度' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Exhibition', @level2type=N'COLUMN',@level2name=N'Longitude'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'展会地址纬度' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Exhibition', @level2type=N'COLUMN',@level2name=N'Latitude'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'展会详情' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Exhibition', @level2type=N'COLUMN',@level2name=N'Detailes'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'招募状态' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Exhibition', @level2type=N'COLUMN',@level2name=N'RecruitStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报名状态' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Exhibition', @level2type=N'COLUMN',@level2name=N'EnrollStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主办方ID' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Exhibition', @level2type=N'COLUMN',@level2name=N'BusinessID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主办方名称' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Exhibition', @level2type=N'COLUMN',@level2name=N'BusinessName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'展会发布时间' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Exhibition', @level2type=N'COLUMN',@level2name=N'PublishedTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'招募截止时间' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Exhibition', @level2type=N'COLUMN',@level2name=N'RecruitEndTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报名开始时间' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Exhibition', @level2type=N'COLUMN',@level2name=N'EnrollStartTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报名结束时间' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Exhibition', @level2type=N'COLUMN',@level2name=N'EnrollEndTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'展品最低促销折扣' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Exhibition', @level2type=N'COLUMN',@level2name=N'LowDiscount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'展品销售分成比例' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Exhibition', @level2type=N'COLUMN',@level2name=N'SaleProportion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Exhibition', @level2type=N'COLUMN',@level2name=N'Creater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Exhibition', @level2type=N'COLUMN',@level2name=N'CreatTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Exhibition', @level2type=N'COLUMN',@level2name=N'Modifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Exhibition', @level2type=N'COLUMN',@level2name=N'ModifiyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'删除状态' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Exhibition', @level2type=N'COLUMN',@level2name=N'IsDel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他1' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Exhibition', @level2type=N'COLUMN',@level2name=N'Temp1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他2' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Exhibition', @level2type=N'COLUMN',@level2name=N'Temp2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'展会表' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Exhibition'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'ExhibitionProduct', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属商家ID' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'ExhibitionProduct', @level2type=N'COLUMN',@level2name=N'SellerCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属展会ID' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'ExhibitionProduct', @level2type=N'COLUMN',@level2name=N'ExhibitionCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'远薪产品ID' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'ExhibitionProduct', @level2type=N'COLUMN',@level2name=N'YXProductCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单位' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'ExhibitionProduct', @level2type=N'COLUMN',@level2name=N'Unit'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'展品类型' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'ExhibitionProduct', @level2type=N'COLUMN',@level2name=N'ExhibitionProductClassCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'现价' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'ExhibitionProduct', @level2type=N'COLUMN',@level2name=N'NPrice'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'原价' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'ExhibitionProduct', @level2type=N'COLUMN',@level2name=N'Oprice'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数量' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'ExhibitionProduct', @level2type=N'COLUMN',@level2name=N'Quantity'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品详情' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'ExhibitionProduct', @level2type=N'COLUMN',@level2name=N'PDetails'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上下架状态' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'ExhibitionProduct', @level2type=N'COLUMN',@level2name=N'PStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'ExhibitionProduct', @level2type=N'COLUMN',@level2name=N'Creater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'ExhibitionProduct', @level2type=N'COLUMN',@level2name=N'CreatTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'ExhibitionProduct', @level2type=N'COLUMN',@level2name=N'Modifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'ExhibitionProduct', @level2type=N'COLUMN',@level2name=N'ModifiyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'删除状态' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'ExhibitionProduct', @level2type=N'COLUMN',@level2name=N'IsDel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'ExhibitionProduct', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他1' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'ExhibitionProduct', @level2type=N'COLUMN',@level2name=N'Temp1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他2' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'ExhibitionProduct', @level2type=N'COLUMN',@level2name=N'Temp2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'展品中间表' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'ExhibitionProduct'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'ExhibitionProductClass', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分类名称' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'ExhibitionProductClass', @level2type=N'COLUMN',@level2name=N'ClassName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'展会ID' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'ExhibitionProductClass', @level2type=N'COLUMN',@level2name=N'ExhibitionCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'ExhibitionProductClass', @level2type=N'COLUMN',@level2name=N'ClassRemark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'ExhibitionProductClass', @level2type=N'COLUMN',@level2name=N'Creater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'ExhibitionProductClass', @level2type=N'COLUMN',@level2name=N'CreatTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'ExhibitionProductClass', @level2type=N'COLUMN',@level2name=N'Modifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'ExhibitionProductClass', @level2type=N'COLUMN',@level2name=N'ModifiyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'删除状态' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'ExhibitionProductClass', @level2type=N'COLUMN',@level2name=N'IsDel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他1' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'ExhibitionProductClass', @level2type=N'COLUMN',@level2name=N'Temp1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他2' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'ExhibitionProductClass', @level2type=N'COLUMN',@level2name=N'Temp2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'展品分类表' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'ExhibitionProductClass'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'ExhibitionTag', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标签名称' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'ExhibitionTag', @level2type=N'COLUMN',@level2name=N'TagName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'ExhibitionTag', @level2type=N'COLUMN',@level2name=N'TagRemark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'ExhibitionTag', @level2type=N'COLUMN',@level2name=N'Creater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'ExhibitionTag', @level2type=N'COLUMN',@level2name=N'CreatTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'ExhibitionTag', @level2type=N'COLUMN',@level2name=N'Modifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'ExhibitionTag', @level2type=N'COLUMN',@level2name=N'ModifiyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'删除状态' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'ExhibitionTag', @level2type=N'COLUMN',@level2name=N'IsDel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他1' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'ExhibitionTag', @level2type=N'COLUMN',@level2name=N'Temp1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他2' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'ExhibitionTag', @level2type=N'COLUMN',@level2name=N'Temp2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'展会标签' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'ExhibitionTag'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'FollowMoment', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关注时间' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'FollowMoment', @level2type=N'COLUMN',@level2name=N'FollowTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关注人' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'FollowMoment', @level2type=N'COLUMN',@level2name=N'FollowUserCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所在展会' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'FollowMoment', @level2type=N'COLUMN',@level2name=N'ExhibitionCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'动态ID' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'FollowMoment', @level2type=N'COLUMN',@level2name=N'MomentCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'删除状态' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'FollowMoment', @level2type=N'COLUMN',@level2name=N'IsDel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他1' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'FollowMoment', @level2type=N'COLUMN',@level2name=N'Temp1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他2' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'FollowMoment', @level2type=N'COLUMN',@level2name=N'Temp2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'动态关注表' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'FollowMoment'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'门店编号' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Goods', @level2type=N'COLUMN',@level2name=N'SellerCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Goods', @level2type=N'COLUMN',@level2name=N'GoodsName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'支持预定' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Goods', @level2type=N'COLUMN',@level2name=N'IsReserve'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分类编码' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Goods', @level2type=N'COLUMN',@level2name=N'GoodsTypeCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单位编码' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Goods', @level2type=N'COLUMN',@level2name=N'GoodsUnitCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'原件' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Goods', @level2type=N'COLUMN',@level2name=N'OldPrice'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'现价' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Goods', @level2type=N'COLUMN',@level2name=N'Price'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'介绍 长度改为1024' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Goods', @level2type=N'COLUMN',@level2name=N'Intruduction'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Goods', @level2type=N'COLUMN',@level2name=N'IsShelves'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'快递费用' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Goods', @level2type=N'COLUMN',@level2name=N'ExpressCharge'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Goods', @level2type=N'COLUMN',@level2name=N'Creator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Goods', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Goods', @level2type=N'COLUMN',@level2name=N'Modifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Goods', @level2type=N'COLUMN',@level2name=N'ModifyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'有效性' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Goods', @level2type=N'COLUMN',@level2name=N'ValidStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'点赞数' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Goods', @level2type=N'COLUMN',@level2name=N'LinkNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'总销量' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Goods', @level2type=N'COLUMN',@level2name=N'MonthSalesNum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品库存' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Goods', @level2type=N'COLUMN',@level2name=N'StockCount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Intruduction字段长度改为1024' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Goods'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'无误' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'GoodsUnit'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Moment', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发布时间' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Moment', @level2type=N'COLUMN',@level2name=N'PubTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发布内容' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Moment', @level2type=N'COLUMN',@level2name=N'PubContent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发布类型(用户发布还是展商发布)' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Moment', @level2type=N'COLUMN',@level2name=N'Types'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'展商ID或用户ID' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Moment', @level2type=N'COLUMN',@level2name=N'PublisherCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'展会ID' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Moment', @level2type=N'COLUMN',@level2name=N'ExhibitionCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Moment', @level2type=N'COLUMN',@level2name=N'Creater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Moment', @level2type=N'COLUMN',@level2name=N'CreatTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Moment', @level2type=N'COLUMN',@level2name=N'Modifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Moment', @level2type=N'COLUMN',@level2name=N'ModifiyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'删除状态' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Moment', @level2type=N'COLUMN',@level2name=N'IsDel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他1' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Moment', @level2type=N'COLUMN',@level2name=N'Temp1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他2' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Moment', @level2type=N'COLUMN',@level2name=N'Temp2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'动态' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Moment'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'MomentReply', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'回复时间' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'MomentReply', @level2type=N'COLUMN',@level2name=N'ReplyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'回复内容' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'MomentReply', @level2type=N'COLUMN',@level2name=N'ReplyContent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'动态ID' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'MomentReply', @level2type=N'COLUMN',@level2name=N'MomentCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'父级ID' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'MomentReply', @level2type=N'COLUMN',@level2name=N'ParentID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'MomentReply', @level2type=N'COLUMN',@level2name=N'Creater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'MomentReply', @level2type=N'COLUMN',@level2name=N'CreatTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'MomentReply', @level2type=N'COLUMN',@level2name=N'Modifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'MomentReply', @level2type=N'COLUMN',@level2name=N'ModifiyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'删除状态' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'MomentReply', @level2type=N'COLUMN',@level2name=N'IsDel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他1' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'MomentReply', @level2type=N'COLUMN',@level2name=N'Temp1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他2' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'MomentReply', @level2type=N'COLUMN',@level2name=N'Temp2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'动态回复' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'MomentReply'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'MyFavorites', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收藏时间' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'MyFavorites', @level2type=N'COLUMN',@level2name=N'FavoritesTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收藏人' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'MyFavorites', @level2type=N'COLUMN',@level2name=N'UserCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收藏展会或展品ID' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'MyFavorites', @level2type=N'COLUMN',@level2name=N'FavoritesCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收藏类型(展会还是展品)' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'MyFavorites', @level2type=N'COLUMN',@level2name=N'Types'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'MyFavorites', @level2type=N'COLUMN',@level2name=N'Creater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'MyFavorites', @level2type=N'COLUMN',@level2name=N'CreatTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'MyFavorites', @level2type=N'COLUMN',@level2name=N'Modifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'MyFavorites', @level2type=N'COLUMN',@level2name=N'ModifiyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'删除状态' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'MyFavorites', @level2type=N'COLUMN',@level2name=N'IsDel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他1' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'MyFavorites', @level2type=N'COLUMN',@level2name=N'Temp1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他2' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'MyFavorites', @level2type=N'COLUMN',@level2name=N'Temp2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'我的收藏' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'MyFavorites'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Notify', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'消息时间' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Notify', @level2type=N'COLUMN',@level2name=N'NotifyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'消息类型' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Notify', @level2type=N'COLUMN',@level2name=N'NotifyType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'消息内容' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Notify', @level2type=N'COLUMN',@level2name=N'NotifyContent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'信息所属用户ID' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Notify', @level2type=N'COLUMN',@level2name=N'UserCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Notify', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Notify', @level2type=N'COLUMN',@level2name=N'Creater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Notify', @level2type=N'COLUMN',@level2name=N'CreatTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Notify', @level2type=N'COLUMN',@level2name=N'Modifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Notify', @level2type=N'COLUMN',@level2name=N'ModifiyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'删除状态' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Notify', @level2type=N'COLUMN',@level2name=N'IsDel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他1' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Notify', @level2type=N'COLUMN',@level2name=N'Temp1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他2' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Notify', @level2type=N'COLUMN',@level2name=N'Temp2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'消息表' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Notify'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编码' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Order', @level2type=N'COLUMN',@level2name=N'Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单号' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Order', @level2type=N'COLUMN',@level2name=N'OrderNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户编码' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Order', @level2type=N'COLUMN',@level2name=N'BusinessUserCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'门店编码' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Order', @level2type=N'COLUMN',@level2name=N'SellerCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Order', @level2type=N'COLUMN',@level2name=N'SellerName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单类型' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Order', @level2type=N'COLUMN',@level2name=N'OrderType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'客户名称' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Order', @level2type=N'COLUMN',@level2name=N'CustomerName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'客户电话' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Order', @level2type=N'COLUMN',@level2name=N'Telephone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'送餐地址编码' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Order', @level2type=N'COLUMN',@level2name=N'BusinessUserAddress'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'下单时间' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Order', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'客户要求时间' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Order', @level2type=N'COLUMN',@level2name=N'CustomerDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'客户要求时间段' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Order', @level2type=N'COLUMN',@level2name=N'CustomerTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单来源' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Order', @level2type=N'COLUMN',@level2name=N'OrderFrom'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'支付方式' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Order', @level2type=N'COLUMN',@level2name=N'PyteType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'运费/服务费' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Order', @level2type=N'COLUMN',@level2name=N'ServiceCharge'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'小计' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Order', @level2type=N'COLUMN',@level2name=N'Charge'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'总金额' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Order', @level2type=N'COLUMN',@level2name=N'TotalCharge'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'账户余额抵消金额' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Order', @level2type=N'COLUMN',@level2name=N'BalancePay'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'卡券抵用金额' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Order', @level2type=N'COLUMN',@level2name=N'CardVoucherPay'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'实际支付金额' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Order', @level2type=N'COLUMN',@level2name=N'RealPay'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'派送时间' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Order', @level2type=N'COLUMN',@level2name=N'SendTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'完成时间' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Order', @level2type=N'COLUMN',@level2name=N'CompleteTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'快递单号' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Order', @level2type=N'COLUMN',@level2name=N'ExpressNum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'客户留言' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Order', @level2type=N'COLUMN',@level2name=N'CustomerMessage'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'就餐人数' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Order', @level2type=N'COLUMN',@level2name=N'PeopleNum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'桌号编码' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Order', @level2type=N'COLUMN',@level2name=N'DeskNumCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Order', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单明细总数' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Order', @level2type=N'COLUMN',@level2name=N'Quantity'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否开发票' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Order', @level2type=N'COLUMN',@level2name=N'NeedInvoice'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'下单人' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Order', @level2type=N'COLUMN',@level2name=N'Creator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'门店优惠编码' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Order', @level2type=N'COLUMN',@level2name=N'SellerDiscountCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商家接单时间' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Order', @level2type=N'COLUMN',@level2name=N'ConfirmTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'优惠金额' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Order', @level2type=N'COLUMN',@level2name=N'DiscountCharge'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'无误' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Order'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'OpenID' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'OrderDetail', @level2type=N'COLUMN',@level2name=N'OpenID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'OrderDetail', @level2type=N'COLUMN',@level2name=N'GoodsName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'无误' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'OrderDetail'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Schedule', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日期' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Schedule', @level2type=N'COLUMN',@level2name=N'STime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'开始时间' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Schedule', @level2type=N'COLUMN',@level2name=N'StartTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'结束时间' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Schedule', @level2type=N'COLUMN',@level2name=N'EndTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日程名称' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Schedule', @level2type=N'COLUMN',@level2name=N'ScheduleName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日程描述' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Schedule', @level2type=N'COLUMN',@level2name=N'ScheduleDesc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'展会ID' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Schedule', @level2type=N'COLUMN',@level2name=N'ExhibitionCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Schedule', @level2type=N'COLUMN',@level2name=N'Creater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Schedule', @level2type=N'COLUMN',@level2name=N'CreatTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Schedule', @level2type=N'COLUMN',@level2name=N'Modifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Schedule', @level2type=N'COLUMN',@level2name=N'ModifiyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'删除状态' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Schedule', @level2type=N'COLUMN',@level2name=N'IsDel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他1' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Schedule', @level2type=N'COLUMN',@level2name=N'Temp1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他2' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Schedule', @level2type=N'COLUMN',@level2name=N'Temp2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'展会日程' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'Schedule'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'SeatNo', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'展位设置ID' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'SeatNo', @level2type=N'COLUMN',@level2name=N'SeatSetCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'展位号' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'SeatNo', @level2type=N'COLUMN',@level2name=N'SeatNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'SeatNo', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'SeatNo', @level2type=N'COLUMN',@level2name=N'Creater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'SeatNo', @level2type=N'COLUMN',@level2name=N'CreatTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'SeatNo', @level2type=N'COLUMN',@level2name=N'Modifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'SeatNo', @level2type=N'COLUMN',@level2name=N'ModifiyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'删除状态' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'SeatNo', @level2type=N'COLUMN',@level2name=N'IsDel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他1' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'SeatNo', @level2type=N'COLUMN',@level2name=N'Temp1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他2' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'SeatNo', @level2type=N'COLUMN',@level2name=N'Temp2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'展位号' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'SeatNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'SeatSet', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'展会ID' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'SeatSet', @level2type=N'COLUMN',@level2name=N'ExhibitionCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'展位类型' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'SeatSet', @level2type=N'COLUMN',@level2name=N'BaseTypesCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'展位费用' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'SeatSet', @level2type=N'COLUMN',@level2name=N'SeatPrice'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'展位规格' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'SeatSet', @level2type=N'COLUMN',@level2name=N'SeatScale'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'SeatSet', @level2type=N'COLUMN',@level2name=N'Creater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'SeatSet', @level2type=N'COLUMN',@level2name=N'CreatTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'SeatSet', @level2type=N'COLUMN',@level2name=N'Modifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'SeatSet', @level2type=N'COLUMN',@level2name=N'ModifiyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'删除状态' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'SeatSet', @level2type=N'COLUMN',@level2name=N'IsDel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他1' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'SeatSet', @level2type=N'COLUMN',@level2name=N'Temp1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他2' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'SeatSet', @level2type=N'COLUMN',@level2name=N'Temp2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'展位设置' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'SeatSet'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'SellerOrder', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报名时间' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'SellerOrder', @level2type=N'COLUMN',@level2name=N'EnrollTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'展位设置ID' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'SellerOrder', @level2type=N'COLUMN',@level2name=N'SeatSetCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'姓名' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'SellerOrder', @level2type=N'COLUMN',@level2name=N'SName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'手机号' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'SellerOrder', @level2type=N'COLUMN',@level2name=N'SPhone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'总价格' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'SellerOrder', @level2type=N'COLUMN',@level2name=N'TotalPrice'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'支付方式' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'SellerOrder', @level2type=N'COLUMN',@level2name=N'PayType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'支付账号' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'SellerOrder', @level2type=N'COLUMN',@level2name=N'PayAccount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'远新平台报名商家ID' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'SellerOrder', @level2type=N'COLUMN',@level2name=N'SellerID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'SellerOrder', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单号自动生成' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'SellerOrder', @level2type=N'COLUMN',@level2name=N'OrderNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'展会ID' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'SellerOrder', @level2type=N'COLUMN',@level2name=N'ExhibitionID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'参展商介绍' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'SellerOrder', @level2type=N'COLUMN',@level2name=N'SellerIntro'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单状态(0未确认，1已确认，2已拒绝)' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'SellerOrder', @level2type=N'COLUMN',@level2name=N'OrderStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'SellerOrder', @level2type=N'COLUMN',@level2name=N'CreatTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'SellerOrder', @level2type=N'COLUMN',@level2name=N'Creater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'SellerOrder', @level2type=N'COLUMN',@level2name=N'ModifiyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'SellerOrder', @level2type=N'COLUMN',@level2name=N'Modifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'删除状态' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'SellerOrder', @level2type=N'COLUMN',@level2name=N'IsDel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他1' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'SellerOrder', @level2type=N'COLUMN',@level2name=N'Temp1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他2' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'SellerOrder', @level2type=N'COLUMN',@level2name=N'Temp2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'参展商订单(商家)' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'SellerOrder'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'SellerOrderDetails', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'展商订单ID' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'SellerOrderDetails', @level2type=N'COLUMN',@level2name=N'SellerOrderCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所选展位ID' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'SellerOrderDetails', @level2type=N'COLUMN',@level2name=N'SeatNoCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'SellerOrderDetails', @level2type=N'COLUMN',@level2name=N'CreatTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'SellerOrderDetails', @level2type=N'COLUMN',@level2name=N'Creater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'SellerOrderDetails', @level2type=N'COLUMN',@level2name=N'ModifiyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'SellerOrderDetails', @level2type=N'COLUMN',@level2name=N'Modifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'删除状态' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'SellerOrderDetails', @level2type=N'COLUMN',@level2name=N'IsDel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他1' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'SellerOrderDetails', @level2type=N'COLUMN',@level2name=N'Temp1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他2' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'SellerOrderDetails', @level2type=N'COLUMN',@level2name=N'Temp2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'参展商订单详情' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'SellerOrderDetails'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'TicketsSet', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'姓名是否必填' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'TicketsSet', @level2type=N'COLUMN',@level2name=N'NameRequire'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'手机是否必填' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'TicketsSet', @level2type=N'COLUMN',@level2name=N'PhoneRequire'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'展会ID' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'TicketsSet', @level2type=N'COLUMN',@level2name=N'ExhibitionCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'TicketsSet', @level2type=N'COLUMN',@level2name=N'Creater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'TicketsSet', @level2type=N'COLUMN',@level2name=N'CreatTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'TicketsSet', @level2type=N'COLUMN',@level2name=N'Modifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'TicketsSet', @level2type=N'COLUMN',@level2name=N'ModifiyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'删除状态' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'TicketsSet', @level2type=N'COLUMN',@level2name=N'IsDel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他1' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'TicketsSet', @level2type=N'COLUMN',@level2name=N'Temp1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他2' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'TicketsSet', @level2type=N'COLUMN',@level2name=N'Temp2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'门票设置' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'TicketsSet'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'TicketsType', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'门票类型或名称' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'TicketsType', @level2type=N'COLUMN',@level2name=N'TicketName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'门票费用' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'TicketsType', @level2type=N'COLUMN',@level2name=N'Price'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名额' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'TicketsType', @level2type=N'COLUMN',@level2name=N'Quota'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'特权说明' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'TicketsType', @level2type=N'COLUMN',@level2name=N'Privilege'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'门票设置ID' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'TicketsType', @level2type=N'COLUMN',@level2name=N'TicketsSetCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'TicketsType', @level2type=N'COLUMN',@level2name=N'Creater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'TicketsType', @level2type=N'COLUMN',@level2name=N'CreatTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'TicketsType', @level2type=N'COLUMN',@level2name=N'Modifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'TicketsType', @level2type=N'COLUMN',@level2name=N'ModifiyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'删除状态' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'TicketsType', @level2type=N'COLUMN',@level2name=N'IsDel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他1' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'TicketsType', @level2type=N'COLUMN',@level2name=N'Temp1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他2' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'TicketsType', @level2type=N'COLUMN',@level2name=N'Temp2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'门票类型' , @level0type=N'SCHEMA',@level0name=N'Business', @level1type=N'TABLE',@level1name=N'TicketsType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编码' , @level0type=N'SCHEMA',@level0name=N'zc', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'昵称' , @level0type=N'SCHEMA',@level0name=N'zc', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'Nickname'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'头像' , @level0type=N'SCHEMA',@level0name=N'zc', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'HeadImage'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'手机号' , @level0type=N'SCHEMA',@level0name=N'zc', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'Phone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'邮箱' , @level0type=N'SCHEMA',@level0name=N'zc', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'Email'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'性别' , @level0type=N'SCHEMA',@level0name=N'zc', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'Gender'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'省份' , @level0type=N'SCHEMA',@level0name=N'zc', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'Province'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'市区' , @level0type=N'SCHEMA',@level0name=N'zc', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'City'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'个人签名' , @level0type=N'SCHEMA',@level0name=N'zc', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'Signature'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'真实姓名' , @level0type=N'SCHEMA',@level0name=N'zc', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'RealName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'身份证号' , @level0type=N'SCHEMA',@level0name=N'zc', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'IDNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0-普通用户，1-企业用户，2-平台用户' , @level0type=N'SCHEMA',@level0name=N'zc', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'UserType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0-草稿箱，1-审核中，2-审核未通过，3-审核通过' , @level0type=N'SCHEMA',@level0name=N'zc', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'AuditStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'zc', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'Creator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'zc', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'有效性' , @level0type=N'SCHEMA',@level0name=N'zc', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'IsValid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'粉丝个数' , @level0type=N'SCHEMA',@level0name=N'zc', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'FollowerNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关注用户个数' , @level0type=N'SCHEMA',@level0name=N'zc', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'FocusNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收藏项目个数' , @level0type=N'SCHEMA',@level0name=N'zc', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'CollectNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发起项目个数' , @level0type=N'SCHEMA',@level0name=N'zc', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'LaunchNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'支持项目个数' , @level0type=N'SCHEMA',@level0name=N'zc', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'SupportNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'积分合计' , @level0type=N'SCHEMA',@level0name=N'zc', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'PointTotal'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'信息数量' , @level0type=N'SCHEMA',@level0name=N'zc', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'NewMessage'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'点赞数' , @level0type=N'SCHEMA',@level0name=N'zc', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'PraiseNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'好友个数' , @level0type=N'SCHEMA',@level0name=N'zc', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'FriendNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'申请数' , @level0type=N'SCHEMA',@level0name=N'zc', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'ApplayNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最近查看动态时间' , @level0type=N'SCHEMA',@level0name=N'zc', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'DynamicTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最近查看任务时间' , @level0type=N'SCHEMA',@level0name=N'zc', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'TaskTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'银行卡数量' , @level0type=N'SCHEMA',@level0name=N'zc', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'BankCardNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否是生活家' , @level0type=N'SCHEMA',@level0name=N'zc', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'IsLifer'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户信息' , @level0type=N'SCHEMA',@level0name=N'zc', @level1type=N'TABLE',@level1name=N'UserInfo'
GO
USE [master]
GO
ALTER DATABASE [YuanXinBusiness] SET  READ_WRITE 
GO
