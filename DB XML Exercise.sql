DECLARE @Projects AS Table (
    ProjectID bigint not null,
    ProjectNumber nvarchar(200) not null
)

DECLARE @Submissions AS Table (
    SubmissionID bigint not null,
    ProjectID bigint not null,
    SubmissionNumber nvarchar(200) not null,
    SubmissionType nvarchar(100) not null
)

INSERT INTO @Projects (ProjectID, ProjectNumber) 
SELECT 1234, 'Test Project 1' UNION
SELECT 5678, 'Test Project 2' UNION
SELECT 9999, 'Test Project 3'

INSERT INTO @Submissions (SubmissionID, ProjectID, SubmissionNumber, SubmissionType)
SELECT 1, 1234, 'ABC_XYZ', 'Primary Submission' UNION
SELECT 1, 1234, 'ABC_XYZ_2', 'Secondary Submission' UNION
SELECT 1, 5678, 'BlahBlah', 'Primary Submission' UNION
SELECT 1, 5678, 'NadaNada', 'Secondary Submission'


SELECT( SELECT p.ProjectID as ProjectID,
			ProjectNumber as ProjectNumber,
			(select SubmissionType AS '@Type',
				(Select SubmissionID) as SubmissionID,
				(select	SubmissionNumber) as SubmissionNumber
				from @Submissions
				where ProjectID = p.ProjectID
			 for xml path('Sub'),type) as AllSubmissions
			from @Projects p 
		FOR
		XML PAth('Proj'),type,
ROOT('AllProjects'))
GO