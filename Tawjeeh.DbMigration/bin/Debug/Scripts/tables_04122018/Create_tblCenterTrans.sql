USE [tawjeeh]
GO

/****** Object:  Table [dbo].[tblCenterTrans]    Script Date: 12/04/2018 11:51:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblCenterTrans](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[LocationAddress] [nvarchar](100) NULL,
	[CenterId] [bigint] NULL,
	[LangId] [int] NULL,
	[EmiratesId] [bigint] NULL,
	[TradeLicense] [nvarchar](100) NULL,
	[TradeLicenseExpiryDate] [datetime] NULL,
	[FaxNo] [nvarchar](50) NULL,
	[PhoneNo] [nvarchar](50) NULL,
	[WebSite] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Longitude] [float] NULL,
	[Latitude] [float] NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
 CONSTRAINT [PK_tblCenterTrans] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


