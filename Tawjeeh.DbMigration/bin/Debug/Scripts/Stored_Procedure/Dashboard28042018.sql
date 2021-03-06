GO
/****** Object:  StoredProcedure [dbo].[Dashbord]    Script Date: 28/04/2018 17:12:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Moises B. Bas
-- Create date: 01-04-2018
-- Description:	
-- =============================================
ALTER PROCEDURE [dbo].[Dashbord] 
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	DECLARE  @TotalLaws INT, 
			 @TotalArticle INT, 
			 @TotalDecisions INT,
			 @TotalDecisionsImage INT,
			 @TotalDecisionsVideo INT, 
			 @TotalArticleVideo INT,
			 @TotalArticleImage INT;


	SET @TotalLaws = (SELECT count(1) FROM [dbo].[tblLaw] l WHERE l.IsDeleted =0);
	SET @TotalArticle = (SELECT count(1) FROM [dbo].[tblArticle] a WHERE a.IsDeleted =0);
	SET @TotalDecisions = (SELECT count(1) FROM [dbo].[tblDecision] d WHERE d.IsDeleted =0);
	SET @TotalDecisionsVideo = (SELECT count(1) FROM [dbo].[tblDecisionMultimedia] d WHERE d.IsDeleted =0 AND d.FileType = 1); 
    SET @TotalDecisionsImage = (SELECT count(1) FROM [dbo].[tblDecisionMultimedia] d WHERE d.IsDeleted =0 AND d.FileType = 3); 
	SET @TotalArticleVideo = (SELECT count(1) FROM [dbo].[tblArticleMultimedia] d WHERE d.IsDeleted =0 AND d.FileType = 1); 
    SET @TotalArticleImage = (SELECT count(1) FROM [dbo].[tblArticleMultimedia] d WHERE d.IsDeleted =0 AND d.FileType = 3); 

	SELECT @TotalLaws as Laws, 
	@TotalArticle as Article, 
	@TotalDecisions as Decisions,
	@TotalDecisionsImage as DecisionImages,
	@TotalDecisionsVideo as DecisionVideos,
	@TotalArticleVideo as ArticleVideos,
    @TotalArticleImage as ArticleImage;
	
END

