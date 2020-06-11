WITH Article AS (SELECT * FROM tblArticle a 
WHERE a.Id NOT IN (SELECT at.ArticleId 
FROM tblArticleTrans at 
WHERE at.LangId = 2))

INSERT INTO [dbo].[tblArticleTrans]
([Name],
 [Description],
 [ArticleId],
 [ArticleNo],
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
	   a.ArticleNo,
	   2,
	   1,
	   0,
	   GetDate(),
	   1,
	   GetDate(),
	   1
FROM Article a