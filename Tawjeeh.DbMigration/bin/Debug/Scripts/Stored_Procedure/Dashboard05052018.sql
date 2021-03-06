USE [tawjeeh]
GO
/****** Object:  StoredProcedure [dbo].[Dashbord]    Script Date: 05/05/2018 09:09:12 ******/
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
	@year int = null,
	@type int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	DECLARE  @TotalLaws INT = 0, 
			 @TotalArticle INT = 0, 
			 @TotalDecisions INT = 0,
			 @TotalDecisionsImage INT = 0,
			 @TotalDecisionsVideo INT = 0, 
			 @TotalArticleVideo INT = 0,
			 @TotalArticleImage INT = 0,

			 @TotalDecisionsImageLike INT = 0,
			 @TotalDecisionsVideoLike INT = 0, 
			 @TotalArticleVideoLike INT = 0,
			 @TotalArticleImageLike INT = 0,		

			 @TotalDecisionsImageViews INT = 0,
			 @TotalDecisionsVideoViews INT = 0, 
			 @TotalArticleVideoViews INT = 0,
			 @TotalCampaigns INT = 0,
			 @TotalUsers INT = 0,
			 @TotalInitiatives INT = 0,
			 @EmailSend INT = 0,
			 @NotificationSend INT = 0,
			 @NotificationRecieve INT = 0,
			 @TotalArticleImageViews INT = 0,
			 @TotalLikes INT =0,
			 @TotalDisLikes INT =0,
			 @CompanyRegister INT =0,
			 @UserRegister INT =0;


			 --year
              IF @type = 1 
			       BEGIN
						SET @TotalLaws = (SELECT COUNT(1) FROM [dbo].[tblLaw] l WHERE l.IsDeleted =0);
						SET @TotalCampaigns = (SELECT COUNT(1) FROM [dbo].[tblCampaign] l WHERE l.IsDeleted =0 AND year(l.CreatedOn) = @year);
						SET @TotalUsers = (SELECT COUNT(1) FROM [dbo].[tblUser] l WHERE l.IsDeleted =0 AND year(l.CreatedOn) = @year);								
				   END
			  --law
			  IF @type = 2
			       BEGIN				        
						SET @TotalArticle = (SELECT COUNT(1) FROM [dbo].[tblArticle] a WHERE a.IsDeleted =0);
						SET @TotalDecisions = (SELECT COUNT(1) FROM [dbo].[tblDecision] d WHERE d.IsDeleted =0);
						SET @TotalDecisionsVideo = (SELECT COUNT(1) FROM [dbo].[tblDecisionMultimedia] d WHERE d.IsDeleted =0 AND d.FileType = 1); 
						SET @TotalDecisionsImage = (SELECT COUNT(1) FROM [dbo].[tblDecisionMultimedia] d WHERE d.IsDeleted =0 AND d.FileType = 3); 
						SET @TotalArticleVideo = (SELECT COUNT(1) FROM [dbo].[tblArticleMultimedia] d WHERE d.IsDeleted =0 AND d.FileType = 1); 
						SET @TotalArticleImage = (SELECT COUNT(1) FROM [dbo].[tblArticleMultimedia] d WHERE d.IsDeleted =0 AND d.FileType = 3); 
				   END

               --campaign
			  IF @type = 3
			       BEGIN
				       SET @TotalCampaigns = (SELECT COUNT(1) FROM [dbo].[tblCampaign] l WHERE l.IsDeleted =0);
					   SET @TotalInitiatives = (SELECT COUNT(1) FROM [dbo].[tblInitiative] l WHERE l.IsDeleted =0);
					   SET @EmailSend = (SELECT SUM(l.EmailSendCnt) FROM [dbo].[tblPushNotificationLogs] l WHERE l.IsDeleted =0);
					   SET @NotificationSend = (SELECT SUM(l.NotificationSendCnt) FROM [dbo].[tblPushNotificationLogs] l WHERE l.IsDeleted =0);
					   SET @NotificationRecieve =  (SELECT SUM(l.NotificationRecieveCnt) FROM [dbo].[tblPushNotificationLogs] l WHERE l.IsDeleted =0);
				   END
			  --users
			 IF @type = 4
			 	   BEGIN
				       SET @TotalLikes = (SELECT SUM(a.likes) FROM (SELECT SUM(l.CntLikes) as likes FROM [dbo].[tblDecisionMultimedia] l WHERE l.IsDeleted =0
					                      UNION ALL 
										  SELECT SUM(l.CntLikes) as likes FROM [dbo].[tblArticleMultimedia] l WHERE l.IsDeleted =0)as a);

					   SET @TotalDisLikes = (SELECT SUM(a.DisLikes) FROM (SELECT SUM(l.CntDisLikes) as DisLikes FROM [dbo].[tblDecisionMultimedia] l WHERE                              l.IsDeleted =0
					                      UNION ALL 
										  SELECT SUM(l.CntDisLikes) as DisLikes FROM [dbo].[tblArticleMultimedia] l WHERE l.IsDeleted =0)as a);
					   SET @CompanyRegister = (SELECT Count(1) FROM [dbo].tblCompany l WHERE l.IsDeleted =0);
					   SET @UserRegister = (SELECT count(1) FROM [dbo].[tblUser] l WHERE l.IsDeleted = 0 AND l.UserTypeId = 4);
					   
				   END		


	SELECT   @TotalLaws AS Laws, 
			 @TotalArticle AS Article, 
			 @TotalDecisions AS Decisions,
			 @TotalDecisionsImage AS DecisionImages,
			 @TotalDecisionsVideo AS DecisionVideos,
			 @TotalArticleVideo AS ArticleVideos,
			 @TotalArticleImage AS ArticleImages,			
			 @TotalArticleImageViews AS TotalArticleImageViews,			 			
			 @TotalDecisionsImageViews AS TotalDecisionsImageViews,
			 @TotalDecisionsVideoViews AS TotalDecisionsVideoViews, 
			 @TotalArticleVideoViews AS TotalArticleVideoViews,
			 @TotalInitiatives AS TotalInitiatives,
			 @TotalCampaigns AS TotalCampaigns,
			 @TotalUsers AS TotalUsers,		
			 @EmailSend AS TotalEmailSend,
			 @NotificationSend AS TotalNotificationSend,
			 @NotificationRecieve AS TotalNotificationRecieve,
			 @TotalLikes As TotalLikes,
			 @TotalDisLikes As TotalDisLikes,
			 @CompanyRegister As CompanyRegister,
			 @UserRegister As UserRegister;
			
	
END

