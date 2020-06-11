USE [tawjeeh]
GO

/****** Object:  Table [dbo].[tblCenterContacts]    Script Date: 12/04/2018 11:50:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblCenterContacts](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CenterId] [bigint] NULL,
	[UserId] [bigint] NULL,
	[ContactTypeId] [int] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
 CONSTRAINT [PK_tblContactCenters] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tblCenterContacts] ADD  CONSTRAINT [DF_tblCenterContacts_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO

ALTER TABLE [dbo].[tblCenterContacts] ADD  CONSTRAINT [DF_tblCenterContacts_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO


