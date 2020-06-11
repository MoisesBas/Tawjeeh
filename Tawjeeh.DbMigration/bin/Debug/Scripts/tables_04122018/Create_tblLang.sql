USE [tawjeeh]
GO

/****** Object:  Table [dbo].[tblLang]    Script Date: 12/04/2018 12:46:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblLang](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](90) NULL,
	[Code] [nvarchar](3) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
 CONSTRAINT [PK_tblLang] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tblLang] ADD  CONSTRAINT [DF_tblLang_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO

ALTER TABLE [dbo].[tblLang] ADD  CONSTRAINT [DF_tblLang_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO


