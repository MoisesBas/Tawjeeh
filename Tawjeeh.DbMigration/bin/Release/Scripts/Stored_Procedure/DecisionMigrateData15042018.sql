WITH Decision AS (SELECT * FROM tblDecision a 
WHERE a.Id NOT IN (SELECT at.DecisionId 
FROM tblDecisionTrans at 
WHERE at.LangId = 2))

INSERT INTO [dbo].[tblDecisionTrans]
([Name],
 [Description],
 [DecisionId],
 [DecisionNo],
 [ArticleId],
 [LangId],
 [IsActive],
 [IsDeleted],
 [CreatedOn],
 [CreatedBy],
 [UpdatedOn],
 [UpdatedBy]
)
SELECT a.Name,
       a.Description,
	   a.Id,
	   a.DecisionNo,
	   a.ArticleId,
	   2,
	   1,
	   0,
	   GetDate(),
	   1,
	   GetDate(),
	   1
FROM Decision a