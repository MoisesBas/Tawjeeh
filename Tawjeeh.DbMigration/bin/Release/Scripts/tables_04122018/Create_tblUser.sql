USE [tawjeeh]
GO

/****** Object:  Table [dbo].[tblUser]    Script Date: 12/04/2018 12:49:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblUser](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserTypeId] [bigint] NULL,
	[UserName] [varchar](100) NULL,
	[Password] [nvarchar](100) NULL,
	[FullName] [nvarchar](100) NULL,
	[OfficeNo] [nvarchar](100) NULL,
	[Department] [nvarchar](100) NULL,
	[JobTitle] [nvarchar](100) NULL,
	[MobileNo] [nvarchar](15) NULL,
	[Photo] [image] NULL,
	[Email] [nvarchar](100) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
 CONSTRAINT [PK_tblUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[tblUser] ADD  CONSTRAINT [DF_tblUser_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO

ALTER TABLE [dbo].[tblUser] ADD  CONSTRAINT [DF_tblUser_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO


