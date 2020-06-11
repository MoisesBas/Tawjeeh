USE [tawjeeh]
GO

/****** Object:  Table [dbo].[tblCampaignDocument]    Script Date: 12/04/2018 11:49:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblCampaignDocument](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CampaignId] [bigint] NULL,
	[InitiativeId] [bigint] NULL,
	[DocumentTitle] [nvarchar](max) NULL,
	[DocumentPath] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
 CONSTRAINT [PK_tblCampaignDocument] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[tblCampaignDocument] ADD  CONSTRAINT [DF_tblCampaignDocument_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO

ALTER TABLE [dbo].[tblCampaignDocument] ADD  CONSTRAINT [DF_tblCampaignDocument_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO


