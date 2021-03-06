GO
/****** Object:  Table [dbo].[tblCountry]    Script Date: 17/04/2018 11:29:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCountry](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NULL,
	[Code] [nvarchar](3) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
 CONSTRAINT [PK_tblCountry] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblCountry] ON 
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (1, N'Afghanistan', N'AFG', 1, 0, CAST(N'2018-04-17T11:25:13.350' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.350' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (2, N'Åland Islands', N'ALA', 1, 0, CAST(N'2018-04-17T11:25:13.497' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.497' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (3, N'Albania', N'ALB', 1, 0, CAST(N'2018-04-17T11:25:13.497' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.497' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (4, N'Algeria', N'DZA', 1, 0, CAST(N'2018-04-17T11:25:13.497' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.497' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (5, N'American Samoa', N'ASM', 1, 0, CAST(N'2018-04-17T11:25:13.497' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.497' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (6, N'Andorra', N'AND', 1, 0, CAST(N'2018-04-17T11:25:13.497' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.497' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (7, N'Angola', N'AGO', 1, 0, CAST(N'2018-04-17T11:25:13.497' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.497' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (8, N'Anguilla', N'AIA', 1, 0, CAST(N'2018-04-17T11:25:13.497' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.497' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (9, N'Antarctica', N'ATA', 1, 0, CAST(N'2018-04-17T11:25:13.500' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.500' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (10, N'Antigua and Barbuda', N'ATG', 1, 0, CAST(N'2018-04-17T11:25:13.500' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.500' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (11, N'Argentina', N'ARG', 1, 0, CAST(N'2018-04-17T11:25:13.500' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.500' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (12, N'Armenia', N'ARM', 1, 0, CAST(N'2018-04-17T11:25:13.500' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.500' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (13, N'Aruba', N'ABW', 1, 0, CAST(N'2018-04-17T11:25:13.500' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.500' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (14, N'Australia', N'AUS', 1, 0, CAST(N'2018-04-17T11:25:13.500' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.500' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (15, N'Austria', N'AUT', 1, 0, CAST(N'2018-04-17T11:25:13.500' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.500' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (16, N'Azerbaijan', N'AZE', 1, 0, CAST(N'2018-04-17T11:25:13.500' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.500' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (17, N'Bahamas', N'BHS', 1, 0, CAST(N'2018-04-17T11:25:13.500' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.500' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (18, N'Bahrain', N'BHR', 1, 0, CAST(N'2018-04-17T11:25:13.500' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.500' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (19, N'Bangladesh', N'BGD', 1, 0, CAST(N'2018-04-17T11:25:13.503' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.503' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (20, N'Barbados', N'BRB', 1, 0, CAST(N'2018-04-17T11:25:13.503' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.503' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (21, N'Belarus', N'BLR', 1, 0, CAST(N'2018-04-17T11:25:13.503' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.503' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (22, N'Belgium', N'BEL', 1, 0, CAST(N'2018-04-17T11:25:13.503' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.503' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (23, N'Belize', N'BLZ', 1, 0, CAST(N'2018-04-17T11:25:13.503' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.503' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (24, N'Benin', N'BEN', 1, 0, CAST(N'2018-04-17T11:25:13.503' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.503' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (25, N'Bermuda', N'BMU', 1, 0, CAST(N'2018-04-17T11:25:13.503' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.503' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (26, N'Bhutan', N'BTN', 1, 0, CAST(N'2018-04-17T11:25:13.503' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.503' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (27, N'Bolivia (Plurinational State of)', N'BOL', 1, 0, CAST(N'2018-04-17T11:25:13.503' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.503' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (28, N'Bonaire, Sint Eustatius and Saba', N'BES', 1, 0, CAST(N'2018-04-17T11:25:13.503' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.503' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (29, N'Bosnia and Herzegovina', N'BIH', 1, 0, CAST(N'2018-04-17T11:25:13.507' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.507' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (30, N'Botswana', N'BWA', 1, 0, CAST(N'2018-04-17T11:25:13.507' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.507' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (31, N'Bouvet Island', N'BVT', 1, 0, CAST(N'2018-04-17T11:25:13.507' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.507' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (32, N'Brazil', N'BRA', 1, 0, CAST(N'2018-04-17T11:25:13.507' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.507' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (33, N'British Indian Ocean Territory', N'IOT', 1, 0, CAST(N'2018-04-17T11:25:13.507' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.507' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (34, N'United States Minor Outlying Islands', N'UMI', 1, 0, CAST(N'2018-04-17T11:25:13.507' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.507' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (35, N'Virgin Islands (British)', N'VGB', 1, 0, CAST(N'2018-04-17T11:25:13.507' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.507' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (36, N'Virgin Islands (U.S.)', N'VIR', 1, 0, CAST(N'2018-04-17T11:25:13.507' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.507' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (37, N'Brunei Darussalam', N'BRN', 1, 0, CAST(N'2018-04-17T11:25:13.507' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.507' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (38, N'Bulgaria', N'BGR', 1, 0, CAST(N'2018-04-17T11:25:13.510' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.510' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (39, N'Burkina Faso', N'BFA', 1, 0, CAST(N'2018-04-17T11:25:13.510' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.510' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (40, N'Burundi', N'BDI', 1, 0, CAST(N'2018-04-17T11:25:13.510' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.510' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (41, N'Cambodia', N'KHM', 1, 0, CAST(N'2018-04-17T11:25:13.510' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.510' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (42, N'Cameroon', N'CMR', 1, 0, CAST(N'2018-04-17T11:25:13.510' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.510' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (43, N'Canada', N'CAN', 1, 0, CAST(N'2018-04-17T11:25:13.510' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.510' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (44, N'Cabo Verde', N'CPV', 1, 0, CAST(N'2018-04-17T11:25:13.510' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.510' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (45, N'Cayman Islands', N'CYM', 1, 0, CAST(N'2018-04-17T11:25:13.510' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.510' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (46, N'Central African Republic', N'CAF', 1, 0, CAST(N'2018-04-17T11:25:13.510' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.510' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (47, N'Chad', N'TCD', 1, 0, CAST(N'2018-04-17T11:25:13.510' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.510' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (48, N'Chile', N'CHL', 1, 0, CAST(N'2018-04-17T11:25:13.510' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.510' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (49, N'China', N'CHN', 1, 0, CAST(N'2018-04-17T11:25:13.510' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.510' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (50, N'Christmas Island', N'CXR', 1, 0, CAST(N'2018-04-17T11:25:13.510' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.510' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (51, N'Cocos (Keeling) Islands', N'CCK', 1, 0, CAST(N'2018-04-17T11:25:13.513' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.513' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (52, N'Colombia', N'COL', 1, 0, CAST(N'2018-04-17T11:25:13.513' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.513' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (53, N'Comoros', N'COM', 1, 0, CAST(N'2018-04-17T11:25:13.513' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.513' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (54, N'Congo', N'COG', 1, 0, CAST(N'2018-04-17T11:25:13.513' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.513' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (55, N'Congo (Democratic Republic of the)', N'COD', 1, 0, CAST(N'2018-04-17T11:25:13.513' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.513' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (56, N'Cook Islands', N'COK', 1, 0, CAST(N'2018-04-17T11:25:13.513' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.513' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (57, N'Costa Rica', N'CRI', 1, 0, CAST(N'2018-04-17T11:25:13.513' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.513' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (58, N'Croatia', N'HRV', 1, 0, CAST(N'2018-04-17T11:25:13.513' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.513' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (59, N'Cuba', N'CUB', 1, 0, CAST(N'2018-04-17T11:25:13.513' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.513' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (60, N'Curaçao', N'CUW', 1, 0, CAST(N'2018-04-17T11:25:13.513' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.513' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (61, N'Cyprus', N'CYP', 1, 0, CAST(N'2018-04-17T11:25:13.513' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.513' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (62, N'Czech Republic', N'CZE', 1, 0, CAST(N'2018-04-17T11:25:13.517' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.517' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (63, N'Denmark', N'DNK', 1, 0, CAST(N'2018-04-17T11:25:13.517' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.517' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (64, N'Djibouti', N'DJI', 1, 0, CAST(N'2018-04-17T11:25:13.517' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.517' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (65, N'Dominica', N'DMA', 1, 0, CAST(N'2018-04-17T11:25:13.517' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.517' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (66, N'Dominican Republic', N'DOM', 1, 0, CAST(N'2018-04-17T11:25:13.517' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.517' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (67, N'Ecuador', N'ECU', 1, 0, CAST(N'2018-04-17T11:25:13.517' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.517' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (68, N'Egypt', N'EGY', 1, 0, CAST(N'2018-04-17T11:25:13.517' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.517' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (69, N'El Salvador', N'SLV', 1, 0, CAST(N'2018-04-17T11:25:13.517' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.517' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (70, N'Equatorial Guinea', N'GNQ', 1, 0, CAST(N'2018-04-17T11:25:13.517' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.517' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (71, N'Eritrea', N'ERI', 1, 0, CAST(N'2018-04-17T11:25:13.517' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.517' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (72, N'Estonia', N'EST', 1, 0, CAST(N'2018-04-17T11:25:13.520' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.520' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (73, N'Ethiopia', N'ETH', 1, 0, CAST(N'2018-04-17T11:25:13.520' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.520' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (74, N'Falkland Islands (Malvinas)', N'FLK', 1, 0, CAST(N'2018-04-17T11:25:13.520' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.520' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (75, N'Faroe Islands', N'FRO', 1, 0, CAST(N'2018-04-17T11:25:13.520' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.520' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (76, N'Fiji', N'FJI', 1, 0, CAST(N'2018-04-17T11:25:13.520' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.520' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (77, N'Finland', N'FIN', 1, 0, CAST(N'2018-04-17T11:25:13.520' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.520' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (78, N'France', N'FRA', 1, 0, CAST(N'2018-04-17T11:25:13.520' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.520' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (79, N'French Guiana', N'GUF', 1, 0, CAST(N'2018-04-17T11:25:13.520' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.520' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (80, N'French Polynesia', N'PYF', 1, 0, CAST(N'2018-04-17T11:25:13.520' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.520' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (81, N'French Southern Territories', N'ATF', 1, 0, CAST(N'2018-04-17T11:25:13.520' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.520' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (82, N'Gabon', N'GAB', 1, 0, CAST(N'2018-04-17T11:25:13.523' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.523' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (83, N'Gambia', N'GMB', 1, 0, CAST(N'2018-04-17T11:25:13.523' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.523' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (84, N'Georgia', N'GEO', 1, 0, CAST(N'2018-04-17T11:25:13.523' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.523' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (85, N'Germany', N'DEU', 1, 0, CAST(N'2018-04-17T11:25:13.523' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.523' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (86, N'Ghana', N'GHA', 1, 0, CAST(N'2018-04-17T11:25:13.523' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.523' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (87, N'Gibraltar', N'GIB', 1, 0, CAST(N'2018-04-17T11:25:13.523' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.523' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (88, N'Greece', N'GRC', 1, 0, CAST(N'2018-04-17T11:25:13.523' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.523' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (89, N'Greenland', N'GRL', 1, 0, CAST(N'2018-04-17T11:25:13.523' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.523' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (90, N'Grenada', N'GRD', 1, 0, CAST(N'2018-04-17T11:25:13.523' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.523' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (91, N'Guadeloupe', N'GLP', 1, 0, CAST(N'2018-04-17T11:25:13.527' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.527' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (92, N'Guam', N'GUM', 1, 0, CAST(N'2018-04-17T11:25:13.527' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.527' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (93, N'Guatemala', N'GTM', 1, 0, CAST(N'2018-04-17T11:25:13.527' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.527' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (94, N'Guernsey', N'GGY', 1, 0, CAST(N'2018-04-17T11:25:13.527' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.527' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (95, N'Guinea', N'GIN', 1, 0, CAST(N'2018-04-17T11:25:13.527' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.527' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (96, N'Guinea-Bissau', N'GNB', 1, 0, CAST(N'2018-04-17T11:25:13.527' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.527' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (97, N'Guyana', N'GUY', 1, 0, CAST(N'2018-04-17T11:25:13.527' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.527' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (98, N'Haiti', N'HTI', 1, 0, CAST(N'2018-04-17T11:25:13.527' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.527' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (99, N'Heard Island and McDonald Islands', N'HMD', 1, 0, CAST(N'2018-04-17T11:25:13.527' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.527' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (100, N'Holy See', N'VAT', 1, 0, CAST(N'2018-04-17T11:25:13.530' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.530' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (101, N'Honduras', N'HND', 1, 0, CAST(N'2018-04-17T11:25:13.530' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.530' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (102, N'Hong Kong', N'HKG', 1, 0, CAST(N'2018-04-17T11:25:13.530' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.530' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (103, N'Hungary', N'HUN', 1, 0, CAST(N'2018-04-17T11:25:13.530' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.530' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (104, N'Iceland', N'ISL', 1, 0, CAST(N'2018-04-17T11:25:13.530' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.530' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (105, N'India', N'IND', 1, 0, CAST(N'2018-04-17T11:25:13.530' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.530' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (106, N'Indonesia', N'IDN', 1, 0, CAST(N'2018-04-17T11:25:13.530' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.530' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (107, N'Côte d''Ivoire', N'CIV', 1, 0, CAST(N'2018-04-17T11:25:13.530' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.530' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (108, N'Iran (Islamic Republic of)', N'IRN', 1, 0, CAST(N'2018-04-17T11:25:13.530' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.530' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (109, N'Iraq', N'IRQ', 1, 0, CAST(N'2018-04-17T11:25:13.530' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.530' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (110, N'Ireland', N'IRL', 1, 0, CAST(N'2018-04-17T11:25:13.530' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.530' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (111, N'Isle of Man', N'IMN', 1, 0, CAST(N'2018-04-17T11:25:13.530' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.530' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (112, N'Israel', N'ISR', 1, 0, CAST(N'2018-04-17T11:25:13.533' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.533' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (113, N'Italy', N'ITA', 1, 0, CAST(N'2018-04-17T11:25:13.533' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.533' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (114, N'Jamaica', N'JAM', 1, 0, CAST(N'2018-04-17T11:25:13.533' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.533' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (115, N'Japan', N'JPN', 1, 0, CAST(N'2018-04-17T11:25:13.533' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.533' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (116, N'Jersey', N'JEY', 1, 0, CAST(N'2018-04-17T11:25:13.533' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.533' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (117, N'Jordan', N'JOR', 1, 0, CAST(N'2018-04-17T11:25:13.533' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.533' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (118, N'Kazakhstan', N'KAZ', 1, 0, CAST(N'2018-04-17T11:25:13.533' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.533' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (119, N'Kenya', N'KEN', 1, 0, CAST(N'2018-04-17T11:25:13.533' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.533' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (120, N'Kiribati', N'KIR', 1, 0, CAST(N'2018-04-17T11:25:13.533' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.533' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (121, N'Kuwait', N'KWT', 1, 0, CAST(N'2018-04-17T11:25:13.533' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.533' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (122, N'Kyrgyzstan', N'KGZ', 1, 0, CAST(N'2018-04-17T11:25:13.537' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.537' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (123, N'Lao People''s Democratic Republic', N'LAO', 1, 0, CAST(N'2018-04-17T11:25:13.537' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.537' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (124, N'Latvia', N'LVA', 1, 0, CAST(N'2018-04-17T11:25:13.537' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.537' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (125, N'Lebanon', N'LBN', 1, 0, CAST(N'2018-04-17T11:25:13.537' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.537' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (126, N'Lesotho', N'LSO', 1, 0, CAST(N'2018-04-17T11:25:13.537' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.537' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (127, N'Liberia', N'LBR', 1, 0, CAST(N'2018-04-17T11:25:13.537' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.537' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (128, N'Libya', N'LBY', 1, 0, CAST(N'2018-04-17T11:25:13.537' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.537' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (129, N'Liechtenstein', N'LIE', 1, 0, CAST(N'2018-04-17T11:25:13.537' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.537' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (130, N'Lithuania', N'LTU', 1, 0, CAST(N'2018-04-17T11:25:13.537' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.537' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (131, N'Luxembourg', N'LUX', 1, 0, CAST(N'2018-04-17T11:25:13.537' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.537' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (132, N'Macao', N'MAC', 1, 0, CAST(N'2018-04-17T11:25:13.540' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.540' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (133, N'Macedonia (the former Yugoslav Republic of)', N'MKD', 1, 0, CAST(N'2018-04-17T11:25:13.540' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.540' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (134, N'Madagascar', N'MDG', 1, 0, CAST(N'2018-04-17T11:25:13.540' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.540' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (135, N'Malawi', N'MWI', 1, 0, CAST(N'2018-04-17T11:25:13.540' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.540' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (136, N'Malaysia', N'MYS', 1, 0, CAST(N'2018-04-17T11:25:13.540' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.540' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (137, N'Maldives', N'MDV', 1, 0, CAST(N'2018-04-17T11:25:13.540' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.540' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (138, N'Mali', N'MLI', 1, 0, CAST(N'2018-04-17T11:25:13.540' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.540' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (139, N'Malta', N'MLT', 1, 0, CAST(N'2018-04-17T11:25:13.540' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.540' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (140, N'Marshall Islands', N'MHL', 1, 0, CAST(N'2018-04-17T11:25:13.540' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.540' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (141, N'Martinique', N'MTQ', 1, 0, CAST(N'2018-04-17T11:25:13.540' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.540' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (142, N'Mauritania', N'MRT', 1, 0, CAST(N'2018-04-17T11:25:13.540' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.540' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (143, N'Mauritius', N'MUS', 1, 0, CAST(N'2018-04-17T11:25:13.543' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.543' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (144, N'Mayotte', N'MYT', 1, 0, CAST(N'2018-04-17T11:25:13.543' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.543' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (145, N'Mexico', N'MEX', 1, 0, CAST(N'2018-04-17T11:25:13.543' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.543' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (146, N'Micronesia (Federated States of)', N'FSM', 1, 0, CAST(N'2018-04-17T11:25:13.543' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.543' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (147, N'Moldova (Republic of)', N'MDA', 1, 0, CAST(N'2018-04-17T11:25:13.543' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.543' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (148, N'Monaco', N'MCO', 1, 0, CAST(N'2018-04-17T11:25:13.543' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.543' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (149, N'Mongolia', N'MNG', 1, 0, CAST(N'2018-04-17T11:25:13.543' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.543' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (150, N'Montenegro', N'MNE', 1, 0, CAST(N'2018-04-17T11:25:13.543' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.543' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (151, N'Montserrat', N'MSR', 1, 0, CAST(N'2018-04-17T11:25:13.543' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.543' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (152, N'Morocco', N'MAR', 1, 0, CAST(N'2018-04-17T11:25:13.543' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.543' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (153, N'Mozambique', N'MOZ', 1, 0, CAST(N'2018-04-17T11:25:13.547' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.547' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (154, N'Myanmar', N'MMR', 1, 0, CAST(N'2018-04-17T11:25:13.547' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.547' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (155, N'Namibia', N'NAM', 1, 0, CAST(N'2018-04-17T11:25:13.547' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.547' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (156, N'Nauru', N'NRU', 1, 0, CAST(N'2018-04-17T11:25:13.547' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.547' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (157, N'Nepal', N'NPL', 1, 0, CAST(N'2018-04-17T11:25:13.547' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.547' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (158, N'Netherlands', N'NLD', 1, 0, CAST(N'2018-04-17T11:25:13.547' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.547' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (159, N'New Caledonia', N'NCL', 1, 0, CAST(N'2018-04-17T11:25:13.547' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.547' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (160, N'New Zealand', N'NZL', 1, 0, CAST(N'2018-04-17T11:25:13.547' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.547' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (161, N'Nicaragua', N'NIC', 1, 0, CAST(N'2018-04-17T11:25:13.547' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.547' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (162, N'Niger', N'NER', 1, 0, CAST(N'2018-04-17T11:25:13.547' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.547' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (163, N'Nigeria', N'NGA', 1, 0, CAST(N'2018-04-17T11:25:13.550' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.550' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (164, N'Niue', N'NIU', 1, 0, CAST(N'2018-04-17T11:25:13.550' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.550' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (165, N'Norfolk Island', N'NFK', 1, 0, CAST(N'2018-04-17T11:25:13.550' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.550' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (166, N'Korea (Democratic People''s Republic of)', N'PRK', 1, 0, CAST(N'2018-04-17T11:25:13.550' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.550' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (167, N'Northern Mariana Islands', N'MNP', 1, 0, CAST(N'2018-04-17T11:25:13.550' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.550' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (168, N'Norway', N'NOR', 1, 0, CAST(N'2018-04-17T11:25:13.550' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.550' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (169, N'Oman', N'OMN', 1, 0, CAST(N'2018-04-17T11:25:13.550' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.550' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (170, N'Pakistan', N'PAK', 1, 0, CAST(N'2018-04-17T11:25:13.550' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.550' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (171, N'Palau', N'PLW', 1, 0, CAST(N'2018-04-17T11:25:13.550' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.550' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (172, N'Palestine, State of', N'PSE', 1, 0, CAST(N'2018-04-17T11:25:13.550' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.550' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (173, N'Panama', N'PAN', 1, 0, CAST(N'2018-04-17T11:25:13.550' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.550' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (174, N'Papua New Guinea', N'PNG', 1, 0, CAST(N'2018-04-17T11:25:13.550' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.550' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (175, N'Paraguay', N'PRY', 1, 0, CAST(N'2018-04-17T11:25:13.550' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.550' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (176, N'Peru', N'PER', 1, 0, CAST(N'2018-04-17T11:25:13.553' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.553' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (177, N'Philippines', N'PHL', 1, 0, CAST(N'2018-04-17T11:25:13.553' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.553' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (178, N'Pitcairn', N'PCN', 1, 0, CAST(N'2018-04-17T11:25:13.553' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.553' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (179, N'Poland', N'POL', 1, 0, CAST(N'2018-04-17T11:25:13.553' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.553' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (180, N'Portugal', N'PRT', 1, 0, CAST(N'2018-04-17T11:25:13.553' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.553' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (181, N'Puerto Rico', N'PRI', 1, 0, CAST(N'2018-04-17T11:25:13.553' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.553' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (182, N'Qatar', N'QAT', 1, 0, CAST(N'2018-04-17T11:25:13.553' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.553' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (183, N'Republic of Kosovo', N'KOS', 1, 0, CAST(N'2018-04-17T11:25:13.553' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.553' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (184, N'Réunion', N'REU', 1, 0, CAST(N'2018-04-17T11:25:13.553' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.553' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (185, N'Romania', N'ROU', 1, 0, CAST(N'2018-04-17T11:25:13.553' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.553' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (186, N'Russian Federation', N'RUS', 1, 0, CAST(N'2018-04-17T11:25:13.553' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.553' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (187, N'Rwanda', N'RWA', 1, 0, CAST(N'2018-04-17T11:25:13.557' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.557' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (188, N'Saint Barthélemy', N'BLM', 1, 0, CAST(N'2018-04-17T11:25:13.557' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.557' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (189, N'Saint Helena, Ascension and Tristan da Cunha', N'SHN', 1, 0, CAST(N'2018-04-17T11:25:13.557' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.557' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (190, N'Saint Kitts and Nevis', N'KNA', 1, 0, CAST(N'2018-04-17T11:25:13.557' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.557' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (191, N'Saint Lucia', N'LCA', 1, 0, CAST(N'2018-04-17T11:25:13.557' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.557' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (192, N'Saint Martin (French part)', N'MAF', 1, 0, CAST(N'2018-04-17T11:25:13.557' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.557' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (193, N'Saint Pierre and Miquelon', N'SPM', 1, 0, CAST(N'2018-04-17T11:25:13.557' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.557' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (194, N'Saint Vincent and the Grenadines', N'VCT', 1, 0, CAST(N'2018-04-17T11:25:13.560' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.560' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (195, N'Samoa', N'WSM', 1, 0, CAST(N'2018-04-17T11:25:13.560' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.560' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (196, N'San Marino', N'SMR', 1, 0, CAST(N'2018-04-17T11:25:13.560' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.560' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (197, N'Sao Tome and Principe', N'STP', 1, 0, CAST(N'2018-04-17T11:25:13.560' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.560' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (198, N'Saudi Arabia', N'SAU', 1, 0, CAST(N'2018-04-17T11:25:13.560' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.560' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (199, N'Senegal', N'SEN', 1, 0, CAST(N'2018-04-17T11:25:13.560' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.560' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (200, N'Serbia', N'SRB', 1, 0, CAST(N'2018-04-17T11:25:13.560' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.560' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (201, N'Seychelles', N'SYC', 1, 0, CAST(N'2018-04-17T11:25:13.560' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.560' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (202, N'Sierra Leone', N'SLE', 1, 0, CAST(N'2018-04-17T11:25:13.560' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.560' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (203, N'Singapore', N'SGP', 1, 0, CAST(N'2018-04-17T11:25:13.560' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.560' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (204, N'Sint Maarten (Dutch part)', N'SXM', 1, 0, CAST(N'2018-04-17T11:25:13.560' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.560' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (205, N'Slovakia', N'SVK', 1, 0, CAST(N'2018-04-17T11:25:13.560' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.560' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (206, N'Slovenia', N'SVN', 1, 0, CAST(N'2018-04-17T11:25:13.563' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.563' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (207, N'Solomon Islands', N'SLB', 1, 0, CAST(N'2018-04-17T11:25:13.563' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.563' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (208, N'Somalia', N'SOM', 1, 0, CAST(N'2018-04-17T11:25:13.563' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.563' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (209, N'South Africa', N'ZAF', 1, 0, CAST(N'2018-04-17T11:25:13.563' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.563' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (210, N'South Georgia and the South Sandwich Islands', N'SGS', 1, 0, CAST(N'2018-04-17T11:25:13.563' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.563' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (211, N'Korea (Republic of)', N'KOR', 1, 0, CAST(N'2018-04-17T11:25:13.563' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.563' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (212, N'South Sudan', N'SSD', 1, 0, CAST(N'2018-04-17T11:25:13.563' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.563' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (213, N'Spain', N'ESP', 1, 0, CAST(N'2018-04-17T11:25:13.563' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.563' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (214, N'Sri Lanka', N'LKA', 1, 0, CAST(N'2018-04-17T11:25:13.563' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.563' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (215, N'Sudan', N'SDN', 1, 0, CAST(N'2018-04-17T11:25:13.563' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.563' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (216, N'Suriname', N'SUR', 1, 0, CAST(N'2018-04-17T11:25:13.567' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.567' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (217, N'Svalbard and Jan Mayen', N'SJM', 1, 0, CAST(N'2018-04-17T11:25:13.567' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.567' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (218, N'Swaziland', N'SWZ', 1, 0, CAST(N'2018-04-17T11:25:13.567' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.567' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (219, N'Sweden', N'SWE', 1, 0, CAST(N'2018-04-17T11:25:13.567' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.567' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (220, N'Switzerland', N'CHE', 1, 0, CAST(N'2018-04-17T11:25:13.567' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.567' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (221, N'Syrian Arab Republic', N'SYR', 1, 0, CAST(N'2018-04-17T11:25:13.567' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.567' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (222, N'Taiwan', N'TWN', 1, 0, CAST(N'2018-04-17T11:25:13.567' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.567' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (223, N'Tajikistan', N'TJK', 1, 0, CAST(N'2018-04-17T11:25:13.567' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.567' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (224, N'Tanzania, United Republic of', N'TZA', 1, 0, CAST(N'2018-04-17T11:25:13.567' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.567' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (225, N'Thailand', N'THA', 1, 0, CAST(N'2018-04-17T11:25:13.567' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.567' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (226, N'Timor-Leste', N'TLS', 1, 0, CAST(N'2018-04-17T11:25:13.570' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.570' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (227, N'Togo', N'TGO', 1, 0, CAST(N'2018-04-17T11:25:13.570' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.570' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (228, N'Tokelau', N'TKL', 1, 0, CAST(N'2018-04-17T11:25:13.570' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.570' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (229, N'Tonga', N'TON', 1, 0, CAST(N'2018-04-17T11:25:13.570' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.570' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (230, N'Trinidad and Tobago', N'TTO', 1, 0, CAST(N'2018-04-17T11:25:13.570' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.570' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (231, N'Tunisia', N'TUN', 1, 0, CAST(N'2018-04-17T11:25:13.570' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.570' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (232, N'Turkey', N'TUR', 1, 0, CAST(N'2018-04-17T11:25:13.570' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.570' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (233, N'Turkmenistan', N'TKM', 1, 0, CAST(N'2018-04-17T11:25:13.570' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.570' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (234, N'Turks and Caicos Islands', N'TCA', 1, 0, CAST(N'2018-04-17T11:25:13.570' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.570' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (235, N'Tuvalu', N'TUV', 1, 0, CAST(N'2018-04-17T11:25:13.570' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.570' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (236, N'Uganda', N'UGA', 1, 0, CAST(N'2018-04-17T11:25:13.570' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.570' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (237, N'Ukraine', N'UKR', 1, 0, CAST(N'2018-04-17T11:25:13.570' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.570' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (238, N'United Arab Emirates', N'ARE', 1, 0, CAST(N'2018-04-17T11:25:13.570' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.570' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (239, N'United Kingdom of Great Britain and Northern Ireland', N'GBR', 1, 0, CAST(N'2018-04-17T11:25:13.570' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.570' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (240, N'United States of America', N'USA', 1, 0, CAST(N'2018-04-17T11:25:13.573' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.573' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (241, N'Uruguay', N'URY', 1, 0, CAST(N'2018-04-17T11:25:13.573' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.573' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (242, N'Uzbekistan', N'UZB', 1, 0, CAST(N'2018-04-17T11:25:13.573' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.573' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (243, N'Vanuatu', N'VUT', 1, 0, CAST(N'2018-04-17T11:25:13.573' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.573' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (244, N'Venezuela (Bolivarian Republic of)', N'VEN', 1, 0, CAST(N'2018-04-17T11:25:13.573' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.573' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (245, N'Viet Nam', N'VNM', 1, 0, CAST(N'2018-04-17T11:25:13.573' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.573' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (246, N'Wallis and Futuna', N'WLF', 1, 0, CAST(N'2018-04-17T11:25:13.573' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.573' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (247, N'Western Sahara', N'ESH', 1, 0, CAST(N'2018-04-17T11:25:13.573' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.573' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (248, N'Yemen', N'YEM', 1, 0, CAST(N'2018-04-17T11:25:13.577' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.577' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (249, N'Zambia', N'ZMB', 1, 0, CAST(N'2018-04-17T11:25:13.577' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.577' AS DateTime), 1)
GO
INSERT [dbo].[tblCountry] ([Id], [Name], [Code], [IsActive], [IsDeleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (250, N'Zimbabwe', N'ZWE', 1, 0, CAST(N'2018-04-17T11:25:13.577' AS DateTime), 1, CAST(N'2018-04-17T11:25:13.577' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[tblCountry] OFF
GO
