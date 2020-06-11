USE [tawjeeh]
GO

/****** Object:  Table [dbo].[tblCampaign]    Script Date: 12/04/2018 11:46:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblCampaign](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](150) NOT NULL,
	[FromDate] [datetime] NOT NULL,
	[ToDate] [datetime] NOT NULL,
	[Target] [int] NOT NULL,
	[CampaignStatus] [int] NOT NULL,
	[Budget] [bigint] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
 CONSTRAINT [PK_tblCampaign] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tblCampaign] ADD  CONSTRAINT [DF_tblCampaign_CampaignStatus]  DEFAULT ((1)) FOR [CampaignStatus]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1-Active, 2-Cancel, 3-Finish' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblCampaign', @level2type=N'COLUMN',@level2name=N'CampaignStatus'
GO


