USE [tawjeeh]
GO

/****** Object:  Table [dbo].[tblArticleTrans]    Script Date: 12/04/2018 11:45:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblArticleTrans](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NULL,
	[Description] [ntext] NULL,
	[ArticleId] [bigint] NULL,
	[ArticleNo] [nvarchar](100) NULL,
	[LangId] [int] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
 CONSTRAINT [PK_tblArticleTrans] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[tblArticleTrans] ADD  CONSTRAINT [DF_tblArticleTrans_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO

ALTER TABLE [dbo].[tblArticleTrans] ADD  CONSTRAINT [DF_tblArticleTrans_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO


