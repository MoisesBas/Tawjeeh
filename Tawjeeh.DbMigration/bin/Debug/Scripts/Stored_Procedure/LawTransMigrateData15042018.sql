WITH LawTranslation AS (SELECT * FROM tblLaw a 
WHERE a.Id NOT IN (SELECT lt.LawId 
FROM tblLawTrans lt 
WHERE lt.LangId = 2))

INSERT INTO [dbo].[tblLawTrans]
([Name],
 [Description], 
 [LangId],
 [LawId],
 [IsActive],
 [IsDeleted],
 [CreatedOn],
 [CreatedBy],
 [UpdatedOn],
 [UpdatedBy]
)
SELECT a.Name,
       a.Description,	  	  
	   2,
	   a.Id,
	   1,
	   0,
	   GetDate(),
	   1,
	   GetDate(),
	   1
FROM LawTranslation a