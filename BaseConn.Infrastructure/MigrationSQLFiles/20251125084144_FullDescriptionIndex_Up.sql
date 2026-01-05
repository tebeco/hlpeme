IF  EXISTS (SELECT * FROM sys.fulltext_indexes fti WHERE fti.object_id = OBJECT_ID(N'[dbo].[problems]'))
ALTER FULLTEXT INDEX ON [dbo].[problems] DISABLE

GO
IF  EXISTS (SELECT * FROM sys.fulltext_indexes fti WHERE fti.object_id = OBJECT_ID(N'[dbo].[problems]'))
BEGIN
	DROP FULLTEXT INDEX ON [dbo].[problems]
End

Go
IF EXISTS (SELECT * FROM sys.fulltext_catalogs WHERE [name]='FTCProblem')
BEGIN
	DROP FULLTEXT CATALOG FTCProblem 
END

CREATE FULLTEXT CATALOG FTCProblem AS DEFAULT;
CREATE FULLTEXT INDEX ON dbo.problems(problem_description) KEY INDEX PK_problems ON FTCProblem WITH STOPLIST = OFF, CHANGE_TRACKING AUTO;