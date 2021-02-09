--CREATE DATABASE WMS
--USE WMS

--1

CREATE TABLE Clients
(
	ClientId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Phone CHAR(12) CHECK (LEN(Phone) = 12) NOT NULL
)

CREATE TABLE Mechanics
(
	MechanicId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Address VARCHAR(255) NOT NULL,
)


CREATE TABLE Models
(
	ModelId INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Jobs
(
	JobId INT PRIMARY KEY IDENTITY,
	ModelId INT FOREIGN KEY REFERENCES Models(ModelId) NOT NULL,
	[Status] VARCHAR(11) DEFAULT 'Pending' CHECK 
								([Status] IN ('Pending','In Progress','Finished')) NOT NULL,
	ClientId INT FOREIGN KEY REFERENCES Clients(ClientId) NOT NULL,
	MechanicId INT FOREIGN KEY REFERENCES Mechanics(MechanicId),
	IssueDate DATE NOT NULL,
	FinishDate DATE
)

CREATE TABLE Orders
(
	OrderId INT PRIMARY KEY IDENTITY,
	JobId INT FOREIGN KEY REFERENCES Jobs(JobId) NOT NULL,
	IssueDate DATE,
	Delivered BIT DEFAULT 0 NOT NULL
)

CREATE TABLE Vendors
(
	VendorId INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Parts
(
	PartId INT PRIMARY KEY IDENTITY,
	SerialNumber VARCHAR(50) UNIQUE NOT NULL,
	[Description] VARCHAR(255),
	Price DECIMAL (6, 2) CHECK (PRICE > 0) NOT NULL,
	VendorId INT FOREIGN KEY REFERENCES Vendors(VendorId),
	StockQty INT DEFAULT 0 CHECK (StockQty >= 0) NOT NULL
)

CREATE TABLE OrderParts
(
	OrderId INT,
	PartId INT
	CONSTRAINT PK_Orders_Parts PRIMARY KEY(OrderId, PartId),
	CONSTRAINT FK_Orders FOREIGN KEY (OrderId) REFERENCES Orders(OrderId),
	CONSTRAINT FK_Parts FOREIGN KEY (PartId) REFERENCES Parts(PartId),
	Quantity INT DEFAULT 1 CHECK (Quantity > 0) 
)


CREATE TABLE PartsNeeded
(
	JobId INT,
	PartId INT,
	CONSTRAINT PK_PartsNeeded PRIMARY KEY (JobId, PartId),
	CONSTRAINT FK_JobId FOREIGN KEY (JobId) REFERENCES Jobs(JobId),
	CONSTRAINT FK_PartsId FOREIGN KEY (PartId) REFERENCES Parts(PartId),
	Quantity INT DEFAULT 1 CHECK (Quantity > 0) 
)

--2

INSERT INTO Clients (FirstName, LastName, Phone)
VALUES
('Teri','Ennaco','570-889-5187'),
('Merlyn','Lawler','201-588-7810'),
('Georgene','Montezuma','925-615-5185'),
('Jettie','Mconnell','908-802-3564'),
('Lemuel','Latzke','631-748-6479'),
('Melodie','Knipp','805-690-1682'),
('Candida','Corbley','908-275-8357')

INSERT INTO Parts (SerialNumber, [Description], Price, VendorId)
VALUES

('WP8182119','Door Boot Seal', 117.86, 2),
('W10780048','Suspension Rod', 42.81, 1),
('W10841140','Silicone Adhesive', 6.77, 4),
('WPY055980','High Temperature Adhesive', 13.94, 3)

--3

UPDATE Jobs
SET MechanicId = 3 , [Status] = 'In Progress'
WHERE [Status] = 'Pending'

--4
DELETE FROM OrderParts WHERE OrderId = 19
DELETE FROM Orders WHERE OrderId = 19


--5

SELECT CONCAT(c.FirstName,' ', c.LastName) AS Client, 
		DATEDIFF(DAY,j.IssueDate, 
		CONVERT(datetime, '24/04/2017', 103)) AS [Days going],
		j.[Status]	
FROM Clients AS c
Join Jobs AS j ON c.ClientId = j.ClientId
WHERE j.[Status] != 'Finished'
ORDER BY [Days going] DESC, c.ClientId ASC



--6

SELECT CONCAT(m.FirstName,' ', m.LastName) AS FullName, j.[Status], j.IssueDate
FROM Mechanics as m
Join Jobs as j ON m.MechanicId = j.MechanicId
ORDER BY m.MechanicId, j.IssueDate, j.JobId

--7



--8

SELECT m.FirstName + ' ' + m.LastName AS Available
FROM Mechanics AS m
LEFT JOIN Jobs AS j ON j.MechanicId = m.MechanicId
WHERE j.JobId IS NULL OR (SELECT COUNT(JobId)
								FROM Jobs
								WHERE [Status] <> 'Finished' AND MechanicId = m.MechanicId
								GROUP BY MechanicId, [Status]) IS NULL
GROUP BY m.MechanicId , (m.FirstName + ' ' + m.LastName)

--9

SELECT j.JobId, ISNULL(SUM(p.Price * op.Quantity), 0)
FROM Jobs AS j
LEFT JOIN Orders AS o ON j.JobId = o.JobId
LEFT JOIN OrderParts AS op ON o.OrderId = op.OrderId
LEFT JOIN Parts AS p ON op.PartId = p.PartId
WHERE j.Status = 'Finished'
GROUP BY j.JobId
ORDER BY SUM(p.Price) DESC, j.JobId ASC 

--10

SELECT p.PartId, p.[Description], pn.Quantity AS [Required], p.StockQty AS [In Stock], 
		 IIF(o.Delivered = 0, op.Quantity, 0) AS [Ordered]
	FROM Parts p
LEFT JOIN PartsNeeded AS pn ON p.PartId = pn.PartId
LEFT JOIN OrderParts AS op ON p.PartId = op.PartId
LEFT JOIN Jobs AS j ON pn.JobId = j.JobId
LEFT JOIN Orders AS o ON j.JobId = o.JobId
WHERE  j.[Status] <> 'Finished' AND p.StockQty + IIF(o.Delivered = 0, op.Quantity, 0) < pn.Quantity
ORDER BY p.PartId ASC

SELECT *

FROM Parts p
LEFT JOIN PartsNeeded AS pn ON p.PartId = pn.PartId
LEFT JOIN OrderParts AS op ON pn.PartId = op.PartId 
WHERE (p.StockQty + op.Quantity) - pn.Quantity < 0