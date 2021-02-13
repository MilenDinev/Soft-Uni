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
