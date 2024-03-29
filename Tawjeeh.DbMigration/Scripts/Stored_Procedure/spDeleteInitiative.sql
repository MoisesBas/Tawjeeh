GO
/****** Object:  StoredProcedure [dbo].[spDeleteInitiative]    Script Date: 02/05/2018 11:42:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Moises B. Bas
-- Create date: 
-- Description:	
-- =============================================
ALTER PROCEDURE [dbo].[spDeleteInitiative]  
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
