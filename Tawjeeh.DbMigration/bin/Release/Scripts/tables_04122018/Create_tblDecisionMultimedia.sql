USE [tawjeeh]
GO

/****** Object:  Table [dbo].[tblDecisionMultimedia]    Script Date: 12/04/2018 12:11:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblDecisionMultimedia](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[DecisionId] [bigint] NULL,
	[LangId] [int] NULL,
	[FileName] [nvarchar](150) NULL,
	[VideoUrl] [nvarchar](max) NULL,
	[FileUrl] [nvarchar](max) NULL,
	[FileType] [int] NULL,
	[CntLikes] [bigint] NULL,
	[CntDisLikes] [bigint] NULL,
	[CntViews] [bigint] NULL,
	[Description] [ntext] NULL,
	[IsMobile] [bit] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
 CONSTRAINT [PK_tblDecisionMultimedia] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[tblDecisionMultimedia] ADD  CONSTRAINT [DF_tblDecisionMultimedia_IsActive]  DEFAULT ((11)) FOR [IsActive]
GO

ALTER TABLE [dbo].[tblDecisionMultimedia] ADD  CONSTRAINT [DF_tblDecisionMultimedia_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO


