--1
CREATE TABLE Users
(
	Id INT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(30) NOT NULL,
	Email VARCHAR(50) NOT NULL
)

CREATE TABLE Repositories
(
	Id INT PRIMARY KEY IDENTITY,
  [Name] VARCHAR(50) NOT NULL
)

CREATE TABLE RepositoriesContributors
(
	RepositoryId INT NOT NULL,
	ContributorId INT NOT NULL
	CONSTRAINT PK_Repositories_Contributors PRIMARY KEY(RepositoryId, ContributorId),
	CONSTRAINT FK_Repositories FOREIGN KEY (RepositoryId) REFERENCES Repositories(Id),
	CONSTRAINT FK_Contributors FOREIGN KEY (ContributorId) REFERENCES Users(Id)
)


CREATE TABLE Issues
(
	Id INT PRIMARY KEY IDENTITY,
	Title VARCHAR(255) NOT NULL,
	IssueStatus CHAR(6) NOT NULL,
	RepositoryId INT NOT NULL FOREIGN KEY REFERENCES Repositories(Id),
	AssigneeId INT NOT NULL FOREIGN KEY REFERENCES Users(Id)
)

CREATE TABLE Commits
(
	Id INT PRIMARY KEY IDENTITY,
	[Message] VARCHAR(255) NOT NULL,
	IssueId INT FOREIGN KEY REFERENCES Issues(Id),
	RepositoryId INT NOT NULL FOREIGN KEY REFERENCES Repositories(Id),
	ContributorId INT NOT NULL FOREIGN KEY REFERENCES Users(Id)
)


CREATE TABLE Files
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(100) NOT NULL,
	Size DECIMAL (18,2) NOT NULL,
	ParentId INT FOREIGN KEY REFERENCES Files(Id),
	CommitId INT NOT NULL FOREIGN KEY REFERENCES Commits(Id)
)


--2
INSERT INTO Files ([Name], Size, ParentId, CommitId)
VALUES
('Trade.idk', 2598.0, 1, 1),
('menu.net', 9238.31, 2, 2),
('Administrate.soshy', 1246.93,	3, 3),
('Controller.php', 7353.15,	4, 4),
('Find.java', 9957.86, 5, 5),
('Controller.json', 14034.87, 3, 6),
('Operate.xix', 7662.92, 7,	7)


INSERT INTO Issues (Title, IssueStatus, RepositoryId, AssigneeId)
VALUES
('Critical Problem with HomeController.cs file', 'open', 1, 4),
('Typo fix in Judge.html', 'open', 4, 3),
('Implement documentation for UsersService.cs', 'closed', 8, 2),
('Unreachable code in Index.cs', 'open', 9, 8)

--3
UPDATE Issues
SET IssueStatus = 'closed'
WHERE AssigneeId = 6


--4

DELETE FROM Issues
WHERE RepositoryId = 3

DELETE FROM RepositoriesContributors
WHERE RepositoryId = 3

--5
SELECT Id, [Message], RepositoryId, ContributorId
FROM Commits
ORDER BY Id ASC, [Message] ASC, RepositoryId ASC, ContributorId ASC

--6

SELECT Id, [Name], Size
FROM Files
WHERE Size > 1000 AND [Name] LIKE '%html%'
ORDER BY Size DESC, Id ASC, [Name] ASC

--7 
SELECT i.Id, CONCAT(u.Username,' ', ':',' ', i.Title) AS IssueAssignee
FROM Issues AS i
JOIN Users AS u ON i.AssigneeId = u.Id
ORDER BY i.Id DESC, IssueAssignee ASC

--9

SELECT TOP(5) r.Id, r.[Name], COUNT(c.Id) 
FROM RepositoriesContributors AS rc
JOIN Repositories AS r ON rc.RepositoryId = r.Id
JOIN Commits AS c ON r.Id = c.RepositoryId
GROUP BY r.Id, r.[Name]
ORDER BY COUNT(c.Id)  DESC, r.Id ASC, r.[Name] ASC

--10

SELECT u.Username ,SUM(f.Size) / COUNT(f.CommitId)  AS Size
FROM Users AS u
JOIN Commits AS c ON c.ContributorId = u.Id
JOIN Files AS f ON f.CommitId = c.Id
GROUP BY u.Username
ORDER BY SUM(f.Size) / COUNT(f.CommitId) DESC, u.Username ASC

--11

CREATE FUNCTION udf_AllUserCommits(@username VARCHAR(50)) 
RETURNS INT
AS
BEGIN
DECLARE @result INT = (SELECT COUNT(c.Id)
FROM Users AS u
JOIN Commits AS c ON c.ContributorId = u.Id
WHERE u.Username = @username)


RETURN @result
END