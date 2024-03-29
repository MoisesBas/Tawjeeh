USE [tawjeeh_prod]

GO
/****** Object:  View [dbo].[vwSearchMobile]    Script Date: 14/04/2018 16:51:51 ******/
IF EXISTS(select * FROM sys.views where name = N'[dbo].[vwSearchMobile]')
BEGIN
           DROP VIEW [dbo].[vwSearchMobile]
           Print('Views dropped => [dbo].[vwSearchMobile]')
END

GO
/****** Object:  View [dbo].[vwSearchMobile]    Script Date: 14/04/2018 16:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vwSearchMobile]
AS
SELECT       at.Id AS SearchId, 'Article' AS [Type], at.Name as [Name], at.Description as [Description], '' AS FileUrl, '' AS VideoUrl, 'Recods' AS FileType, at.LangId
FROM            dbo.tblArticleTrans at
UNION ALL
SELECT        Id AS SearchId, 'Article Multimedia' AS Type, FileName, Description, FileUrl, VideoUrl,
 CASE am.FileType
 WHEN 1 THEN 'Video'
 WHEN 2 THEN 'Document'
 WHEN 3 THEN 'IMAGE'
 END AS [FileType], am.LangId
FROM            dbo.tblArticleMultimedia AS am
UNION ALL 
SELECT       dt.Id AS SearchId, 'Decision' AS [Type], dt.Name as [Name], dt.Description as [Description], '' AS FileUrl, '' AS VideoUrl, 'Recods' AS FileType,dt.LangId
FROM            dbo.tblDecisionTrans dt
UNION ALL 
SELECT        dm.Id AS SearchId, 'Decision Multimedia' AS Type, dm.FileName as [Name], dm.Description as [Description], dm.FileUrl, dm.VideoUrl,
 CASE dm.FileType
 WHEN 1 THEN 'Video'
 WHEN 2 THEN 'Document'
 WHEN 3 THEN 'IMAGE'
 END AS [FileType],dm.LangId
FROM            dbo.tblDecisionMultimedia AS dm
GO

