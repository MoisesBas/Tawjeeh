USE [tawjeeh]
GO

/****** Object:  Table [dbo].[tblDecisionTrans]    Script Date: 12/04/2018 12:19:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblDecisionTrans](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [ntext] NULL,
	[DecisionId] [bigint] NULL,
	[DecisionNo] [nvarchar](100) NULL,
	[ArticleId] [bigint] NULL,
	[LangId] [int] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
 CONSTRAINT [PK_tblDecisionTrans] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[tblDecisionTrans] ADD  CONSTRAINT [DF_tblDecisionTrans_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO

ALTER TABLE [dbo].[tblDecisionTrans] ADD  CONSTRAINT [DF_tblDecisionTrans_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO


