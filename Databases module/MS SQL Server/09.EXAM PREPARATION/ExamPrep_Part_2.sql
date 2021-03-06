--CREATE DATABASE TripService
--USE TripService

--CREATE TABLE Cities
--(
--	Id INT PRIMARY KEY IDENTITY,
--	[Name] NVARCHAR(20) NOT NULL,
--	CountryCode CHAR(2) NOT NULL
--)

--CREATE TABLE Hotels
--(
--	Id INT PRIMARY KEY IDENTITY,
--	[Name] NVARCHAR(30) NOT NULL,
--	CityId INT FOREIGN KEY REFERENCES Cities(Id) NOT NULL,
--	EmployeeCount INT NOT NULL,
--	BaseRate DECIMAL(18,2)
--)

--CREATE TABLE Rooms
--(
--	Id INT PRIMARY KEY IDENTITY,
--	Price DECIMAL (18,2) NOT NULL,
--	[Type] NVARCHAR(20) NOT NULL,
--	Beds INT NOT NULL,
--	HotelId INT FOREIGN KEY REFERENCES Hotels(Id) NOT NULL
--)

--CREATE TABLE Trips
--(
--	Id INT PRIMARY KEY IDENTITY,
--	RoomId INT FOREIGN KEY REFERENCES Rooms(Id) NOT NULL,
--	BookDate DATE NOT NULL,
--	ArrivalDate DATE NOT NULL,
--	ReturnDate DATE NOT NULL,
--	CancelDate DATE,
--	CHECK (BookDate < ArrivalDate),
--	CHECK (ArrivalDate < ReturnDate)
--)

--CREATE TABLE Accounts 
--(
--	Id INT PRIMARY KEY IDENTITY,
--	FirstName NVARCHAR(50) NOT NULL,
--	MiddleName NVARCHAR(20),
--	LastName NVARCHAR(50) NOT NULL,
--	CityId INT FOREIGN KEY REFERENCES Cities(Id) NOT NULL,
--	BirthDate DATE NOT NULL,
--	Email VARCHAR(100) UNIQUE NOT NULL
--)

--CREATE TABLE AccountsTrips
--(
--	AccountId INT NOT NULL,
--	TripId INT NOT NULL,
--	Luggage INT CHECK (Luggage >= 0) NOT NULL

--	CONSTRAINT PK_Accounts_Trips PRIMARY KEY(AccountId, TripId),
--	CONSTRAINT FK_Accounts FOREIGN KEY (AccountId) REFERENCES Accounts(Id),
--	CONSTRAINT FK_Trips FOREIGN KEY (TripId) REFERENCES Trips(Id)
--)

--2 
INSERT INTO Accounts (FirstName, MiddleName, LastName, CityId, BirthDate, Email)
VALUES
('John', 'Smith', 'Smith', 34, '1975-07-21', 'j_smith@gmail.com'),
('Gosho', NULL, 'Petrov', 11, '1978-05-16', 'g_petrov@gmail.com'),
('Ivan', 'Petrovich', 'Pavlov', 59, '1849-09-26', 'i_pavlov@softuni.bg'),
('Friedrich', 'Wilhelm', 'Nietzsche', 2, '1844-10-15', 'f_nietzsche@softuni.bg')


INSERT INTO Trips (RoomId, BookDate, ArrivalDate, ReturnDate, CancelDate)
VALUES
(101, '2015-04-12', '2015-04-14', '2015-04-20',	'2015-02-02'),
(102, '2015-07-07', '2015-07-15', '2015-07-22',	'2015-04-29'),
(103, '2013-07-17', '2013-07-23', '2013-07-24',	NULL),
(104, '2012-03-17', '2012-03-31', '2012-04-01',	'2012-01-10'),
(109, '2017-08-07', '2017-08-28', '2017-08-29',	NULL)

--3
UPDATE Rooms
SET Price += Price * 0.14
WHERE HotelId IN (5, 7, 9)

--4
DELETE FROM AccountsTrips
WHERE AccountId = 47

--5
SELECT FirstName, LastName, CONVERT (VARCHAR, BirthDate, 110) AS BirthDate, c.[Name] AS Hometown, a.Email
FROM Accounts AS a
JOIN Cities AS c ON a.CityId = c.Id
WHERE Email LIKE 'e%'
ORDER BY c.[Name] ASC

--6

SELECT c.[Name], COUNT(h.Id)
FROM Cities AS c
JOIN Hotels AS h ON c.Id = h.CityId
GROUP BY c.[Name]
ORDER BY COUNT(h.Id) DESC, c.[Name]

--7

SELECT a.Id, CONCAT(a.FirstName,' ', a.LastName) AS FullName, 
			MAX(DATEDIFF(DAY,t.ArrivalDate, t.ReturnDate)) AS LongestTrip, 
			MIN(DATEDIFF(DAY,t.ArrivalDate, t.ReturnDate)) AS ShortestTrip
FROM Accounts AS a
JOIN AccountsTrips AS [at] ON a.Id = [at].AccountId
JOIN Trips AS t ON [at].TripId = t.Id
WHERE a.MiddleName IS NULL AND t.CancelDate IS NULL
GROUP BY a.Id, CONCAT(a.FirstName,' ', a.LastName)
ORDER BY LongestTrip DESC, ShortestTrip ASC

--8

SELECT TOP(10) c.Id, c.[Name], c.CountryCode, COUNT(a.Id)
FROM Accounts AS a
JOIN Cities AS c ON a.CityId = c.Id
GROUP BY c.Id, c.[Name], c.CountryCode
ORDER BY COUNT(a.Id) DESC

--9

SELECT a.Id, a.Email, c.[Name], COUNT(t.Id)
FROM Accounts AS a
JOIN AccountsTrips AS [at] ON a.Id = [at].AccountId
JOIN Trips AS t ON [at].TripId = t.Id
JOIN Rooms AS r ON t.RoomId = r.Id
JOIN Hotels AS h ON r.HotelId = h.Id
JOIN Cities AS c ON h.CityId = c.Id
WHERE a.CityId = h.CityId
GROUP BY a.Id, a.Email, c.Name
ORDER BY COUNT(t.Id) DESC, a.Id


--10 

SELECT t.Id, a.FirstName + ' ' + IIF(MiddleName IS NULL,'', MiddleName + ' ') + LastName AS [Full Name], 
			ca.[Name] AS [From], c.[Name] AS [To],
			IIF(t.CancelDate IS NULL, CONCAT(CAST(DATEDIFF(DAY,t.ArrivalDate, t.ReturnDate) AS VARCHAR(10)), ' ', 'days') , 'Canceled') AS Duration
FROM Accounts AS a
JOIN AccountsTrips AS [at] ON a.Id = [at].AccountId
JOIN Trips AS t ON [at].TripId = t.Id
JOIN Rooms AS r ON t.RoomId = r.Id
JOIN Hotels AS h ON r.HotelId = h.Id
JOIN Cities AS c ON h.CityId = c.Id
JOIN Cities AS ca ON a.CityId = ca.Id
GROUP BY t.Id, a.FirstName + ' ' + IIF(MiddleName IS NULL,'', MiddleName + ' ') + LastName, ca.[Name], c.[Name], DATEDIFF(DAY,t.ArrivalDate, t.ReturnDate), t.CancelDate
ORDER BY [Full Name], t.Id