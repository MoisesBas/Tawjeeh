USE [tawjeeh]
GO

/****** Object:  Table [dbo].[tblEmailSMSTemplate]    Script Date: 12/04/2018 12:19:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblEmailSMSTemplate](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TemplateType] [int] NULL,
	[Template] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
 CONSTRAINT [PK_tblEmailSMSTemplate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[tblEmailSMSTemplate] ADD  CONSTRAINT [DF_tblEmailSMSTemplate_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO

ALTER TABLE [dbo].[tblEmailSMSTemplate] ADD  CONSTRAINT [DF_tblEmailSMSTemplate_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO


