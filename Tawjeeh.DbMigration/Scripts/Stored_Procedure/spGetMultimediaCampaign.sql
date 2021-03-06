GO
/****** Object:  StoredProcedure [dbo].[spGetMultimediaCampaign]    Script Date: 24/04/2018 09:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Moises B. Bas
-- Create date: 23-04-2018
-- Description:	
-- =============================================
ALTER PROCEDURE [dbo].[spGetMultimediaCampaign] 
	-- Add the parameters for the stored procedure here
	@campaignId BIGINT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @Multimedia AS TABLE
(
 ID BIGINT,
 Type VARCHAR(100),
 NAME NVARCHAR(190),
 DECSCRIPTION NVARCHAR(190),
 FileURL NVARCHAR(190),
 VIDEOURL NVARCHAR(150),
 FILETYPE NVARCHAR(10),
 LANGID INT
 )

INSERT INTO @Multimedia
SELECT * from dbo.vwSearchMobile sm where sm.Type IN ('Article Multimedia','Decision Multimedia')

SELECT cd.Id,
(CASE WHEN cd.Type = 1 THEN
					   CASE WHEN cd.MultimediaId <> 0 THEN
								(SELECT TOP 1 m.NAME FROM @Multimedia m WHERE (m.ID = cd.MultimediaId)) 
					   WHEN cd.MultimediaId = 0 THEN
					           (SELECT TOP 1 doc.DocumentTitle FROM tblCampaignDocument doc WHERE (doc.CampaignDetailsId = cd.Id))
					   END
     WHEN cd.Type = 2 THEN
					  CASE WHEN cd.MultimediaId <> 0 THEN
							   (SELECT TOP 1 m.NAME FROM @Multimedia m WHERE (m.ID = cd.MultimediaId)) 
	                       WHEN cd.MultimediaId = 0 THEN
		                       (SELECT TOP 1 doc.DocumentTitle FROM tblCampaignDocument doc WHERE (doc.CampaignDetailsId = cd.Id))
                      END
	ELSE  (SELECT TOP 1 doc.DocumentTitle FROM tblCampaignDocument doc WHERE (doc.CampaignDetailsId = cd.Id))	    
 END) AS [FileName],
 (CASE WHEN cd.Type = 1 THEN
					   CASE WHEN cd.MultimediaId <> 0 THEN
								(SELECT TOP 1 m.FileURL FROM @Multimedia m WHERE (m.ID = cd.MultimediaId)) 
					   WHEN cd.MultimediaId = 0 THEN
					           (SELECT TOP 1 doc.DocumentPath FROM tblCampaignDocument doc WHERE (doc.CampaignDetailsId = cd.Id))
					   END
     WHEN cd.Type = 2 THEN
					  CASE WHEN cd.MultimediaId <> 0 THEN
							   (SELECT TOP 1 m.FileURL FROM @Multimedia m WHERE (m.ID = cd.MultimediaId)) 
	                       WHEN cd.MultimediaId = 0 THEN
		                       (SELECT TOP 1 doc.DocumentPath FROM tblCampaignDocument doc WHERE (doc.CampaignDetailsId = cd.Id))
                      END
	ELSE  (SELECT TOP 1 doc.DocumentPath FROM tblCampaignDocument doc WHERE (doc.CampaignDetailsId = cd.Id))	    
 END) AS [FileUrl],
 (CASE WHEN cd.Type = 1 THEN
					   CASE WHEN cd.MultimediaId <> 0 THEN
								(SELECT TOP 1 m.VIDEOURL FROM @Multimedia m WHERE (m.ID = cd.MultimediaId)) 
					   WHEN cd.MultimediaId = 0 THEN
					           (SELECT TOP 1 doc.DocumentPath FROM tblCampaignDocument doc WHERE (doc.CampaignDetailsId = cd.Id))
					   END
     WHEN cd.Type = 2 THEN
					  CASE WHEN cd.MultimediaId <> 0 THEN
							   (SELECT TOP 1 m.VIDEOURL FROM @Multimedia m WHERE (m.ID = cd.MultimediaId)) 
	                       WHEN cd.MultimediaId = 0 THEN
		                       (SELECT TOP 1 doc.DocumentPath FROM tblCampaignDocument doc WHERE (doc.CampaignDetailsId = cd.Id))
                      END
	ELSE  (SELECT TOP 1 doc.DocumentPath FROM tblCampaignDocument doc WHERE (doc.CampaignDetailsId = cd.Id))	    
 END) AS [VideoUrl],
 cd.CampaignId,
 cd.Type,
 cd.SubTypeId,
 cd.MultimediaId,
 cd.IsActive,
 cd.IsDeleted,
 cd.CreatedBy,
 cd.CreatedOn,
 cd.UpdatedBy,
 cd.UpdatedOn 
FROM tblCampaignDetails cd 
WHERE cd.CampaignId = @campaignId;
End
