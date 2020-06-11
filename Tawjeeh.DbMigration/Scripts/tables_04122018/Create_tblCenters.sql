USE [tawjeeh]
GO

/****** Object:  Table [dbo].[tblCenters]    Script Date: 12/04/2018 11:50:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblCenters](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[LocationAddress] [nvarchar](100) NULL,
	[EmiratesId] [bigint] NULL,
	[TradeLicense] [nvarchar](100) NULL,
	[TradeLicenseExpiryDate] [datetime] NULL,
	[FaxNo] [nvarchar](50) NULL,
	[PhoneNo] [nvarchar](50) NULL,
	[WebSite] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Longitude] [float] NULL,
	[Latitude] [float] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
 CONSTRAINT [PK_tblCenterEmirates] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tblCenters] ADD  CONSTRAINT [DF_tblCenters_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO

ALTER TABLE [dbo].[tblCenters] ADD  CONSTRAINT [DF_tblCenters_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO


