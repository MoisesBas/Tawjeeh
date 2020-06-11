USE [tawjeeh]
GO

/****** Object:  Table [dbo].[tblArticleMultimedia]    Script Date: 12/04/2018 11:41:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblArticleMultimedia](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ArticleId] [bigint] NULL,
	[LangId] [int] NULL,
	[FileName] [nvarchar](150) NULL,
	[FileUrl] [nvarchar](max) NULL,
	[VideoUrl] [nvarchar](max) NULL,
	[FileType] [int] NULL,
	[CntLikes] [bigint] NULL,
	[CntDisLikes] [bigint] NULL,
	[CntViews] [bigint] NULL,
	[Description] [text] NULL,
	[IsMobile] [bit] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
 CONSTRAINT [PK_tblMultimediaArticle] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[tblArticleMultimedia] ADD  CONSTRAINT [DF_tblMultimediaArticle_IsActive]  DEFAULT ((11)) FOR [IsActive]
GO

ALTER TABLE [dbo].[tblArticleMultimedia] ADD  CONSTRAINT [DF_tblMultimediaArticle_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO


