USE [tawjeeh_prod]
GO
/****** Object:  StoredProcedure [dbo].[spGetDecisionLangIdAndId]    Script Date: 14/04/2018 14:25:15 ******/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Moises B. Bas
-- Create date: 01-04-2018
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[Dashbord] 
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
GO
/****** Object:  StoredProcedure [dbo].[DeleteArticles]    Script Date: 14/04/2018 14:25:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Moises B. Bas
-- Create date: 31-03-2018
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[DeleteArticles] 
	-- Add the parameters for the stored procedure here
	@ArticleId BIGINT, 
	@UpdatedBy BIGINT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	BEGIN TRY
    BEGIN TRANSACTION DELETEARTICLES
				UPDATE DM
				SET DM.IsDeleted = 1,
					DM.UpdatedOn = GETDATE(),
					DM.UpdatedBy = @UpdatedBy
				FROM dbo.tblDecisionMultimedia AS DM
				INNER JOIN dbo.tblDecision AS D ON DM.DecisionId = D.Id
				INNER JOIN dbo.tblArticle AS A ON D.ArticleId = A.Id				
				WHERE A.Id = @ArticleId;

				UPDATE DM
				SET DM.IsDeleted = 1,
					DM.UpdatedOn = GETDATE(),
					DM.UpdatedBy = @UpdatedBy
				FROM dbo.tblDecisionTrans AS DM
				INNER JOIN dbo.tblDecision AS D ON DM.DecisionId = D.Id
				INNER JOIN dbo.tblArticle AS A ON D.ArticleId = A.Id				
				WHERE A.Id = @ArticleId;

				UPDATE DM
				SET DM.IsDeleted = 1,
					DM.UpdatedOn = GETDATE(),
					DM.UpdatedBy = @UpdatedBy
				FROM dbo.tblDecision AS DM
				INNER JOIN dbo.tblArticle AS A ON DM.ArticleId = A.Id				
				WHERE A.Id = @ArticleId;

				UPDATE AM
				SET AM.IsDeleted = 1,
					AM.UpdatedOn = GETDATE(),
					AM.UpdatedBy = @UpdatedBy
				FROM dbo.tblArticleMultimedia AS AM
				INNER JOIN dbo.tblArticle AS D ON AM.ArticleId = D.Id				
				WHERE D.Id = @ArticleId;

				UPDATE ATs
				SET ATs.IsDeleted = 1,
					ATs.UpdatedOn = GETDATE(),
					ATs.UpdatedBy = @UpdatedBy
				FROM dbo.tblArticleTrans AS ATs
				INNER JOIN dbo.tblArticle AS D ON ATs.ArticleId = D.Id				
				WHERE D.Id = @ArticleId;

				UPDATE A
				SET A.IsDeleted = 1,
					A.UpdatedOn = GETDATE(),
					A.UpdatedBy = @UpdatedBy
				FROM dbo.tblArticle AS A			
				WHERE A.Id = @ArticleId;
				
    COMMIT TRANSACTION DELETEARTICLES
    PRINT 'X rows deleted. Operation Successful Tara.' --calculation cut out.
	RETURN 1;
END TRY

BEGIN CATCH 
  IF (@@TRANCOUNT > 0)
   BEGIN
      ROLLBACK TRANSACTION DELETEARTICLES
      PRINT 'Error detected, all changes reversed'
	  RETURN 0;
   END 
    SELECT
        ERROR_NUMBER() AS ErrorNumber,
        ERROR_SEVERITY() AS ErrorSeverity,
        ERROR_STATE() AS ErrorState,
        ERROR_PROCEDURE() AS ErrorProcedure,
        ERROR_LINE() AS ErrorLine,
        ERROR_MESSAGE() AS ErrorMessage	
END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteArticlesTrans]    Script Date: 14/04/2018 14:25:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Moises B. Bas
-- Create date: 31-03-2018
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[DeleteArticlesTrans] 
	-- Add the parameters for the stored procedure here
	@ArticleTransId BIGINT, 
	@LangId INT,
	@UpdatedBy BIGINT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	BEGIN TRY
    BEGIN TRANSACTION DELETEARTICLES
				UPDATE DM
				SET DM.IsDeleted = 1,
					DM.UpdatedOn = GETDATE(),
					DM.UpdatedBy = @UpdatedBy
				FROM dbo.tblDecisionMultimedia AS DM
				INNER JOIN dbo.tblDecision AS D ON DM.DecisionId = D.Id
				INNER JOIN dbo.tblArticle AS A ON D.ArticleId = A.Id
				INNER JOIN dbo.tblArticleTrans AS ATs ON A.Id = Ats.ArticleId				
				WHERE ATs.Id = @ArticleTransId And Ats.LangId = @LangId;

				UPDATE DM
				SET DM.IsDeleted = 1,
					DM.UpdatedOn = GETDATE(),
					DM.UpdatedBy = @UpdatedBy
				FROM dbo.tblDecisionTrans AS DM
				INNER JOIN dbo.tblDecision AS D ON DM.DecisionId = D.Id
				INNER JOIN dbo.tblArticle AS A ON D.ArticleId = A.Id
				INNER JOIN dbo.tblArticleTrans AS ATs ON A.Id = Ats.ArticleId				
				WHERE ATs.Id = @ArticleTransId And Ats.LangId = @LangId;

				UPDATE DM
				SET DM.IsDeleted = 1,
					DM.UpdatedOn = GETDATE(),
					DM.UpdatedBy = @UpdatedBy
				FROM dbo.tblDecision AS DM
				INNER JOIN dbo.tblArticle AS A ON DM.ArticleId = A.Id				
				INNER JOIN dbo.tblArticleTrans AS ATs ON A.Id = Ats.ArticleId				
				WHERE ATs.Id = @ArticleTransId And Ats.LangId = @LangId;

				UPDATE AM
				SET AM.IsDeleted = 1,
					AM.UpdatedOn = GETDATE(),
					AM.UpdatedBy = @UpdatedBy
				FROM dbo.tblArticleMultimedia AS AM
				INNER JOIN dbo.tblArticle AS D ON AM.ArticleId = D.Id				
				INNER JOIN dbo.tblArticleTrans AS ATs ON D.Id = Ats.ArticleId				
				WHERE ATs.Id = @ArticleTransId And Ats.LangId = @LangId;

				UPDATE ATs
				SET ATs.IsDeleted = 1,
					ATs.UpdatedOn = GETDATE(),
					ATs.UpdatedBy = @UpdatedBy
				FROM dbo.tblArticleTrans AS ATs						
			    WHERE ATs.Id = @ArticleTransId And Ats.LangId = @LangId;
				
    COMMIT TRANSACTION DELETEARTICLES
    PRINT 'X rows deleted. Operation Successful Tara.' --calculation cut out.
	RETURN 1;
END TRY

BEGIN CATCH 
  IF (@@TRANCOUNT > 0)
   BEGIN
      ROLLBACK TRANSACTION DELETEARTICLES
      PRINT 'Error detected, all changes reversed'
	  RETURN 0;
   END 
    SELECT
        ERROR_NUMBER() AS ErrorNumber,
        ERROR_SEVERITY() AS ErrorSeverity,
        ERROR_STATE() AS ErrorState,
        ERROR_PROCEDURE() AS ErrorProcedure,
        ERROR_LINE() AS ErrorLine,
        ERROR_MESSAGE() AS ErrorMessage	
END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteDecision]    Script Date: 14/04/2018 14:25:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Moises B. Bas
-- Create date: 31-03-2018
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[DeleteDecision] 
	-- Add the parameters for the stored procedure here
	@DecisionId BIGINT, 
	@UpdatedBy BIGINT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	BEGIN TRY
    BEGIN TRANSACTION DELETEDECISIONS
				UPDATE DM
				SET DM.IsDeleted = 1,
					DM.UpdatedOn = GETDATE(),
					DM.UpdatedBy = @UpdatedBy
				FROM dbo.tblDecisionMultimedia AS DM
				INNER JOIN dbo.tblDecision AS D ON DM.DecisionId = D.Id					
				WHERE D.Id = @DecisionId;

				UPDATE DM
				SET DM.IsDeleted = 1,
					DM.UpdatedOn = GETDATE(),
					DM.UpdatedBy = @UpdatedBy
				FROM dbo.tblDecisionTrans AS DM
				INNER JOIN dbo.tblDecision AS D ON DM.DecisionId = D.Id				
				WHERE D.Id = @DecisionId;

				UPDATE DM
				SET DM.IsDeleted = 1,
					DM.UpdatedOn = GETDATE(),
					DM.UpdatedBy = @UpdatedBy
				FROM dbo.tblDecision AS DM								
				WHERE DM.Id = @DecisionId;			
				
    COMMIT TRANSACTION DELETEDECISIONS
    PRINT 'X rows deleted. Operation Successful Tara.' --calculation cut out.
	RETURN 1;
END TRY

BEGIN CATCH 
  IF (@@TRANCOUNT > 0)
   BEGIN
      ROLLBACK TRANSACTION DELETEDECISIONS
      PRINT 'Error detected, all changes reversed'
	  RETURN 0;
   END 
    SELECT
        ERROR_NUMBER() AS ErrorNumber,
        ERROR_SEVERITY() AS ErrorSeverity,
        ERROR_STATE() AS ErrorState,
        ERROR_PROCEDURE() AS ErrorProcedure,
        ERROR_LINE() AS ErrorLine,
        ERROR_MESSAGE() AS ErrorMessage	
END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteDecisionTrans]    Script Date: 14/04/2018 14:25:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Moises B. Bas
-- Create date: 31-03-2018
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[DeleteDecisionTrans] 
	-- Add the parameters for the stored procedure here
	@TransDecisionId BIGINT, 
	@LangId INT,
	@UpdatedBy BIGINT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	BEGIN TRY
    BEGIN TRANSACTION DELETEDECISIONS
				UPDATE DM
				SET DM.IsDeleted = 1,
					DM.UpdatedOn = GETDATE(),
					DM.UpdatedBy = @UpdatedBy
				FROM dbo.tblDecisionMultimedia AS DM
				INNER JOIN dbo.tblDecision AS D ON DM.DecisionId = D.Id		
				INNER JOIN dbo.tblDecisionTrans AS DTs ON D.Id = Dts.DecisionId					
				WHERE DM.Id = @TransDecisionId AND DM.LangId = @LangId;

				UPDATE DM
				SET DM.IsDeleted = 1,
					DM.UpdatedOn = GETDATE(),
					DM.UpdatedBy = @UpdatedBy
				FROM dbo.tblDecisionTrans AS DM
				INNER JOIN dbo.tblDecision AS D ON DM.DecisionId = D.Id				
				WHERE DM.Id = @TransDecisionId AND DM.LangId = @LangId;						
				
    COMMIT TRANSACTION DELETEDECISIONS
    PRINT 'X rows deleted. Operation Successful Tara.' --calculation cut out.
	RETURN 1;
END TRY

BEGIN CATCH 
  IF (@@TRANCOUNT > 0)
   BEGIN
      ROLLBACK TRANSACTION DELETEDECISIONS
      PRINT 'Error detected, all changes reversed'
	  RETURN 0;
   END 
    SELECT
        ERROR_NUMBER() AS ErrorNumber,
        ERROR_SEVERITY() AS ErrorSeverity,
        ERROR_STATE() AS ErrorState,
        ERROR_PROCEDURE() AS ErrorProcedure,
        ERROR_LINE() AS ErrorLine,
        ERROR_MESSAGE() AS ErrorMessage	
END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteLaws]    Script Date: 14/04/2018 14:25:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Moises B. Bas
-- Create date: 29-03-2018
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[DeleteLaws] 
	-- Add the parameters for the stored procedure here
	@LawId BIGINT, 
	@UpdatedBy BIGINT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	BEGIN TRY
    BEGIN TRANSACTION DELETELAWS
				UPDATE DM
				SET DM.IsDeleted = 1,
					DM.UpdatedOn = GETDATE(),
					DM.UpdatedBy = @UpdatedBy
				FROM dbo.tblDecisionMultimedia AS DM
				INNER JOIN dbo.tblDecision AS D ON DM.DecisionId = D.Id
				INNER JOIN dbo.tblArticle AS A ON D.ArticleId = A.Id
				INNER JOIN dbo.tblLaw AS L ON A.LawId = L.Id
				WHERE L.Id = @LawId;

				UPDATE DM
				SET DM.IsDeleted = 1,
					DM.UpdatedOn = GETDATE(),
					DM.UpdatedBy = @UpdatedBy
				FROM dbo.tblDecisionTrans AS DM
				INNER JOIN dbo.tblDecision AS D ON DM.DecisionId = D.Id
				INNER JOIN dbo.tblArticle AS A ON D.ArticleId = A.Id
				INNER JOIN dbo.tblLaw AS L ON A.LawId = L.Id
				WHERE L.Id = @LawId;

				UPDATE DM
				SET DM.IsDeleted = 1,
					DM.UpdatedOn = GETDATE(),
					DM.UpdatedBy = @UpdatedBy
				FROM dbo.tblDecision AS DM
				INNER JOIN dbo.tblArticle AS A ON DM.ArticleId = A.Id
				INNER JOIN dbo.tblLaw AS L ON A.LawId = L.Id
				WHERE L.Id = @LawId;

				UPDATE AM
				SET AM.IsDeleted = 1,
					AM.UpdatedOn = GETDATE(),
					AM.UpdatedBy = @UpdatedBy
				FROM dbo.tblArticleMultimedia AS AM
				INNER JOIN dbo.tblArticle AS D ON AM.ArticleId = D.Id
				INNER JOIN dbo.tblLaw AS L ON D.LawId = L.Id
				WHERE L.Id = @LawId;

				UPDATE ATs
				SET ATs.IsDeleted = 1,
					ATs.UpdatedOn = GETDATE(),
					ATs.UpdatedBy = @UpdatedBy
				FROM dbo.tblArticleTrans AS ATs
				INNER JOIN dbo.tblArticle AS D ON ATs.ArticleId = D.Id
				INNER JOIN dbo.tblLaw AS L ON D.LawId = L.Id
				WHERE L.Id = @LawId;

				UPDATE A
				SET A.IsDeleted = 1,
					A.UpdatedOn = GETDATE(),
					A.UpdatedBy = @UpdatedBy
				FROM dbo.tblArticle AS A
				INNER JOIN dbo.tblLaw AS L ON A.LawId = L.Id
				WHERE L.Id = @LawId;

				UPDATE A
				SET A.IsDeleted = 1,
					A.UpdatedOn = GETDATE(),
					A.UpdatedBy = @UpdatedBy
				FROM dbo.tblLawTrans AS A
				INNER JOIN dbo.tblLaw AS L ON A.LawId = L.Id
				WHERE L.Id = @LawId;

				UPDATE A
				SET A.IsDeleted = 1,
					A.UpdatedOn = GETDATE(),
					A.UpdatedBy = @UpdatedBy
				FROM dbo.tblLaw AS A
				WHERE A.Id = @LawId;
    COMMIT TRANSACTION DELETELAWS
    PRINT 'X rows deleted. Operation Successful Tara.' --calculation cut out.
	RETURN 1;
END TRY

BEGIN CATCH 
  IF (@@TRANCOUNT > 0)
   BEGIN
      ROLLBACK TRANSACTION DELETELAWS
      PRINT 'Error detected, all changes reversed'
	  RETURN 0;
   END 
    SELECT
        ERROR_NUMBER() AS ErrorNumber,
        ERROR_SEVERITY() AS ErrorSeverity,
        ERROR_STATE() AS ErrorState,
        ERROR_PROCEDURE() AS ErrorProcedure,
        ERROR_LINE() AS ErrorLine,
        ERROR_MESSAGE() AS ErrorMessage	
END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[spDeleteCampaign]    Script Date: 14/04/2018 14:25:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Moises B. Bas
-- Create date: 07-04-2018
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteCampaign] 
	-- Add the parameters for the stored procedure here
	@Id BIGINT,
	@UpdatedBy BIGINT	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	BEGIN TRY
    BEGIN TRANSACTION DELETECAMP
				UPDATE g
				SET g.IsDeleted = 1,
					g.UpdatedOn = GETDATE(),
					g.UpdatedBy = @UpdatedBy
				FROM dbo.tblGoal AS g				
				WHERE g.CampaignId = @Id;

				UPDATE cd
				SET cd.IsDeleted = 1,
					cd.UpdatedOn = GETDATE(),
					cd.UpdatedBy = @UpdatedBy
				FROM tblCampaignDetails AS cd				
				WHERE cd.CampaignId = @Id;

				UPDATE c
				SET c.IsDeleted = 1,
					c.UpdatedOn = GETDATE(),
					c.UpdatedBy = @UpdatedBy
				FROM tblCampaign AS c				
				WHERE c.Id = @Id;

				UPDATE ic
				SET ic.IsDeleted = 1,
					ic.UpdatedOn = GETDATE(),
					ic.UpdatedBy = @UpdatedBy
				FROM tblInitiativeCampaign AS ic				
				WHERE ic.CampaignId = @Id;

				
    COMMIT TRANSACTION DELETECAMP
    PRINT 'X rows deleted. Operation Successful.' --calculation cut out.
	RETURN 1;
END TRY

BEGIN CATCH 
  IF (@@TRANCOUNT > 0)
   BEGIN
      ROLLBACK TRANSACTION DELETECAMP
      PRINT 'Error detected, all changes reversed'
	  RETURN 0;
   END 
    SELECT
        ERROR_NUMBER() AS ErrorNumber,
        ERROR_SEVERITY() AS ErrorSeverity,
        ERROR_STATE() AS ErrorState,
        ERROR_PROCEDURE() AS ErrorProcedure,
        ERROR_LINE() AS ErrorLine,
        ERROR_MESSAGE() AS ErrorMessage	
END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[spDeleteInitiative]    Script Date: 14/04/2018 14:25:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Moises B. Bas
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteInitiative]  
	-- Add the parameters for the stored procedure here
	@Id BIGINT,
	@UpdatedBy BIGINT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

  BEGIN TRY
    BEGIN TRANSACTION DELETEINITIATIVE
				UPDATE ic
				SET ic.IsDeleted = 1,
					ic.UpdatedOn = GETDATE(),
					ic.UpdatedBy = @UpdatedBy
				FROM dbo.tblInitiativeCampaign AS ic				
				WHERE ic.CampaignId = @Id;

				UPDATE i
				SET i.IsDeleted = 1,
					i.UpdatedOn = GETDATE(),
					i.UpdatedBy = @UpdatedBy
				FROM tblInitiative AS i				
				WHERE i.Id = @Id;				

				
    COMMIT TRANSACTION DELETEINITIATIVE
    PRINT 'X rows deleted. Operation Successful.' --calculation cut out.
	RETURN 1;
END TRY

BEGIN CATCH 
  IF (@@TRANCOUNT > 0)
   BEGIN
      ROLLBACK TRANSACTION DELETEINITIATIVE
      PRINT 'Error detected, all changes reversed'
	  RETURN 0;
   END 
    SELECT
        ERROR_NUMBER() AS ErrorNumber,
        ERROR_SEVERITY() AS ErrorSeverity,
        ERROR_STATE() AS ErrorState,
        ERROR_PROCEDURE() AS ErrorProcedure,
        ERROR_LINE() AS ErrorLine,
        ERROR_MESSAGE() AS ErrorMessage	
END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[spGetAllByLangId]    Script Date: 14/04/2018 14:25:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Moises B. Bas
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[spGetAllByLangId] 
	-- Add the parameters for the stored procedure here
	@langId INT 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT c.* FROM tblCenters c;
                          SELECT e.* FROM tblEmirates e;
                          SELECT ct.* FROM tblCenterTrans ct
                                      WHERE ct.LangId = @langId
END
GO
/****** Object:  StoredProcedure [dbo].[spGetAllCenters]    Script Date: 14/04/2018 14:25:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Moises B. Bas
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[spGetAllCenters] 
	-- Add the parameters for the stored procedure here	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT c.* FROM tblCenters c where c.IsDeleted=0;
                          SELECT e.* FROM tblEmirates e where e.IsDeleted=0;
                          SELECT ct.* FROM tblCenterTrans ct where ct.IsDeleted=0;
                          SELECT cc.* FROM tblCenterContacts cc inner join 
                                           tblCenters c on cc.CenterId = c.Id
                          WHERE cc.IsDeleted=0 AND c.IsDeleted=0;
                          SELECT u.* FROM tblCenterContacts cc inner join tblUser u on cc.UserId = u.Id
                          WHERE cc.IsDeleted=0 AND u.IsDeleted=0 AND u.UserTypeId=3;
END
GO
/****** Object:  StoredProcedure [dbo].[spGetAllCentersByEmiratesId]    Script Date: 14/04/2018 14:25:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Moises B. Bas
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[spGetAllCentersByEmiratesId] 
	-- Add the parameters for the stored procedure here
	@emiratesId int,
	@langId int	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select c.* from tblCenters c WHERE c.EmiratesId =@emiratesId and c.IsDeleted=0;
    Select e.* from tblEmirates e WHERE e.Id = @emiratesId and e.IsDeleted=0;
    Select ct.* from tblCenterTrans ct WHERE ct.EmiratesId =@emiratesId and ct.LangId =@langId and ct.IsDeleted=0;
END
GO
/****** Object:  StoredProcedure [dbo].[spGetCentersAllByLangId]    Script Date: 14/04/2018 14:25:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Moises B. Bas
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[spGetCentersAllByLangId] 
	-- Add the parameters for the stored procedure here
	@langId INT 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT c.* FROM tblCenters c;
                          SELECT e.* FROM tblEmirates e;
                          SELECT ct.* FROM tblCenterTrans ct
                                      WHERE ct.LangId = @langId
END
GO
/****** Object:  StoredProcedure [dbo].[spGetDecisionAll]    Script Date: 14/04/2018 14:25:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Moises B. Bas
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[spGetDecisionAll] 
	-- Add the parameters for the stored procedure here	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT d.* FROM tblDecision d where d.IsDeleted=0;
    SELECT dt.* FROM tblDecisionTrans dt 
    inner join tblDecision d on dt.DecisionId = d.Id
    where dt.IsDeleted=0;
    SELECT dm.* FROM tblDecisionMultimedia dm
    inner join tblDecision d on dm.DecisionId = d.Id
    where dm.IsDeleted=0;
    SELECT a.* FROM tblArticle a inner join 
            tblDecision d on a.Id = d.ArticleId
    where a.IsDeleted=0;
    SELECT l.* FROM tblLaw l inner join 
            tblArticle a on l.Id = a.LawId
            inner join tblDecision d on a.Id = d.ArticleId
    where l.IsDeleted=0;
END
GO
/****** Object:  StoredProcedure [dbo].[spGetDecisionByArticleId]    Script Date: 14/04/2018 14:25:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Moises B. Bas
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[spGetDecisionByArticleId] 
	-- Add the parameters for the stored procedure here
	@articleId BIGINT
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT d.* FROM tblDecision d WHERE d.ArticleId = @articleId
           and d.IsDeleted=0;

    SELECT dt.* FROM tblDecisionTrans dt inner join 
    tblDecision d on dt.DecisionId = d.Id
    WHERE dt.ArticleId = @articleId and dt.IsDeleted=0;                          
                          
    SELECT dm.* FROM tblDecisionMultimedia dm
    inner join tblDecision d on dm.DecisionId = d.Id                          
    WHERE d.ArticleId = @articleId and dm.IsDeleted=0;

	SELECT a.* FROM tblArticle a WHERE a.Id = @articleId
           and a.IsDeleted=0;

	SELECT   TOP 1 l.*
             FROM  dbo.tblLaw l INNER JOIN
             dbo.tblArticle a ON l.Id = a.LawId
    WHERE a.Id = @articleId

END
GO
/****** Object:  StoredProcedure [dbo].[spGetDecisionByArticleIdAndLangId]    Script Date: 14/04/2018 14:25:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Moises B. Bas
-- Create date: 04-04-2018
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[spGetDecisionByArticleIdAndLangId] 
	-- Add the parameters for the stored procedure here
	@articleId BIGINT = 0, 
	@langId int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT d.* FROM tblDecision d 
    WHERE d.ArticleId = @articleId
    and d.IsDeleted=0;

    SELECT dt.* FROM tblDecisionTrans dt inner join 
    tblDecision d on dt.DecisionId = d.Id
    WHERE dt.ArticleId = @articleId and dt.LangId =@langId
    and dt.IsDeleted=0;                          
                          
    SELECT dm.* FROM tblDecisionMultimedia dm
    inner join tblDecision d on dm.DecisionId = d.Id 
    inner join tblDecisionTrans dt on d.Id = dt.DecisionId
    WHERE d.ArticleId = @articleId and dt.LangId =@langId
    and dm.IsDeleted=0;	

	SELECT a.* FROM tblArticle a WHERE a.Id = @articleId
           and a.IsDeleted=0;

	SELECT at.* FROM tblArticleTrans at WHERE at.ArticleId = @articleId
           AND at.IsDeleted=0 AND at.LangId =@langId;

	SELECT   TOP 1 l.*
             FROM  dbo.tblLaw l INNER JOIN
             dbo.tblArticle a ON l.Id = a.LawId
    WHERE a.Id = @articleId;

	SELECT   TOP 1 lt.*
             FROM  tblLawTrans lt INNER JOIN
             dbo.tblArticle a ON lt.Id = a.LawId
    WHERE a.Id = @articleId AND lt.LangId =@langId;
END
GO
/****** Object:  StoredProcedure [dbo].[spGetDecisionLangIdAndId]    Script Date: 14/04/2018 14:25:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Moises B. Bas
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[spGetDecisionLangIdAndId] 
	-- Add the parameters for the stored procedure here
	@id int, 
	@langId int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT d.* FROM tblDecision d  
    WHERE d.Id = @id and d.IsDeleted=0;

    SELECT dt.* FROM tblDecisionTrans dt inner join 
    tblDecision d on dt.DecisionId = d.Id
    WHERE d.Id = @id and dt.LangId =@langId and dt.IsDeleted=0;                          
                          
    SELECT dm.* FROM tblDecisionMultimedia dm
    inner join tblDecision d on dm.DecisionId = d.Id 
    inner join tblDecisionTrans dt on d.Id = dt.DecisionId
    WHERE d.Id = @id and dt.LangId =@langId and dm.IsDeleted=0;
END
GO
