GO
/****** Object:  StoredProcedure [dbo].[Dashbord]    Script Date: 29/04/2018 09:26:17 ******/
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
	DECLARE  @TotalLaws INT, @TotalArticle INT, @TotalDecisions INT,@TotalDecisionsVideo INT, @TotalArticleVideo INT;
	SET @TotalLaws = (SELECT count(1) FROM [dbo].[tblLaw] l WHERE l.IsDeleted =0);
	SET @TotalArticle = (SELECT count(1) FROM [dbo].[tblArticle] a WHERE a.IsDeleted =0);
	SET @TotalDecisions = (SELECT count(1) FROM [dbo].[tblDecision] d WHERE d.IsDeleted =0);
	SELECT @TotalLaws as Laws, @TotalArticle as Article, @TotalDecisions as Decisions;
END
