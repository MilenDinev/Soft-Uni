--CREATE DATABASE Minions

--CREATE TABLE Minions
--(
--	Id INT PRIMARY KEY,
--	[Name] VARCHAR(30),
--	Age INT
--)

--CREATE TABLE Towns -- създаване на таблица
--(
--	Id INT PRIMARY KEY,
--	[Name] VARCHAR(50)
--)

--ALTER TABLE Minions -- промяна на таблица, в случая добавяне на колоната TownId
--ADD TownId INT

--ALTER TABLE Minions
--ADD FOREIGN KEY (TownId) REFERENCES Towns(Id) -- създаване на рефернция от едната таблица към друга


--INSERT INTO Towns (Id, Name) 
--VALUES
--(1, 'Sofia'),
--(2, 'Plovdiv'),
--(3, 'Varna')

--INSERT INTO Minions (Id, Name, Age, TownId) -- добавяне на записи в таблица
--VALUES
--(1, 'Kevin', 22, 1),
--(2, 'Bob', 15, 3),
--(3, 'Steward', NULL, 2)

--SELECT * FROM Towns

--SELECT * FROM Minions -- показва всички записи в дадена колона

--DELETE FROM Minions - триене на всички данни от таблица
--DROP TABLE Minions - изтриване на таблица 
--DROP TABLE Towns


--CREATE TABLE Users
--(
--	Id BIGINT PRIMARY KEY IDENTITY,
--	Username VARCHAR(30) NOT NULL,
--	[Password] VARCHAR (26) NOT NULL,
--	ProfilePicture VARCHAR(MAX),
--	LastLoginTime DATETIME,
--	IsDeleted BIT
--)


--CREATE TABLE Users
--(
--	Id BIGINT PRIMARY KEY IDENTITY,
--	Username VARCHAR(30) NOT NULL,
--	[Password] VARCHAR (26) NOT NULL,
--	ProfilePicture VARCHAR(MAX),
--	LastLoginTime DATETIME,
--	IsDeleted BIT
--)


--INSERT INTO Users (Username,[Password], ProfilePicture, LastLoginTime, IsDeleted)
--VALUES
--('stoshop', 'strongpass123', 'https://www.google.com/search?q=pictures&sxsrf=ALeKk022KXaMBTUW1g-SXhfH0yeESNXJ_Q:1610474538946&source=lnms&tbm=isch&sa=X&ved=2ahUKEwiDy8CW_ZbuAhVBzKQKHQphDSsQ_AUoAXoECBQQAw&biw=1536&bih=722&dpr=1.25#imgrc=YXgcNflll9kS8M', '1/12/2021', 0),
--('dads', 'strongpass123', 'https://www.google.com/search?q=pictures&sxsrf=ALeKk022KXaMBTUW1g-SXhfH0yeESNXJ_Q:1610474538946&source=lnms&tbm=isch&sa=X&ved=2ahUKEwiDy8CW_ZbuAhVBzKQKHQphDSsQ_AUoAXoECBQQAw&biw=1536&bih=722&dpr=1.25#imgrc=YXgcNflll9kS8M', '5/10/2021',  0),
--('dads', 'strongpass123', 'https://www.google.com/search?q=pictures&sxsrf=ALeKk022KXaMBTUW1g-SXhfH0yeESNXJ_Q:1610474538946&source=lnms&tbm=isch&sa=X&ved=2ahUKEwiDy8CW_ZbuAhVBzKQKHQphDSsQ_AUoAXoECBQQAw&biw=1536&bih=722&dpr=1.25#imgrc=YXgcNflll9kS8M', '5/10/2021',  0),
--('dadrefe', 'strongfdf3123', 'https://www.google.com/search?q=pictures&sxsrf=ALeKk022KXaMBTUW1g-SXhfH0yeESNXJ_Q:1610474538946&source=lnms&tbm=isch&sa=X&ved=2ahUKEwiDy8CW_ZbuAhVBzKQKHQphDSsQ_AUoAXoECBQQAw&biw=1536&bih=722&dpr=1.25#imgrc=YXgcNflll9kS8M', '5/12/2021',  0),
--('darer', 'strongpass123', 'https://www.google.com/search?q=pictures&sxsrf=ALeKk022KXaMBTUW1g-SXhfH0yeESNXJ_Q:1610474538946&source=lnms&tbm=isch&sa=X&ved=2ahUKEwiDy8CW_ZbuAhVBzKQKHQphDSsQ_AUoAXoECBQQAw&biw=1536&bih=722&dpr=1.25#imgrc=YXgcNflll9kS8M', '5/10/2021',  0)


--ALTER TABLE Users
--DROP CONSTRAINT PK__Users__3214EC070A75EF3D - изтриване на PRIMARY KEY със заявка

--ALTER TABLE Users
--ADD PRIMARY KEY (Id) - създаване на PRIMARY KEY 


--ALTER TABLE Users
--ADD CONSTRAINT PK_IdUserName PRIMARY KEY (Id, Username) - създаване на композитен PRIMARY KEY от две колони създаваме уникален ключ


--ALTER TABLE Users
--ADD CONSTRAINT CH_PasswordISATleast5Symbols CHECK (LEN(Password) > 5) - Проверка дали парола е поне 5 символа


--ALTER TABLE Users
--ADD CONSTRAINT DF_LastLoginTime DEFAULT GETDATE() FOR LastLoginTime - слагане на LastLoginTime с Default стойсност текуща дата.



--CREATE TABLE People
--(
--	Id BIGINT PRIMARY KEY IDENTITY,
--	Username VARCHAR(200) NOT NULL,
--	ProfilePicture VARCHAR(MAX),
--	Height DECIMAL(10,2),
--	[Weight] DECIMAL(10,2),
--	Gender BIT NOT NULL,
--	Birthdate DATETIME NOT NULL,
--	Biography VARCHAR(MAX)
--)


--INSERT INTO People (Username, ProfilePicture, Height, [Weight], Gender, Birthdate, Biography)
--VALUES
--('Rustyn', 'https://www.shorturl.at/img/shorturl-square.png', 1.89 , 80 , 0 ,11/07/1992,'random'),
--('Rustyn', 'https://www.shorturl.at/img/shorturl-square.png', 1.89 , 80 , 0 ,11/07/1992,'random'),
--('Rustyn', 'https://www.shorturl.at/img/shorturl-square.png', 1.89 , 80 , 0 ,11/07/1992,'random'),
--('Rustyn', 'https://www.shorturl.at/img/shorturl-square.png', 1.89 , 80 , 0 ,11/07/1992, NULL),
--('Rustyn', 'https://www.shorturl.at/img/shorturl-square.png', 1.89 , 80 , 0 ,11/07/1992, NULL)

--CREATE DATABASE Movies

--CREATE TABLE Directors
--(
--	Id BIGINT PRIMARY KEY IDENTITY,
--	DirectorName VARCHAR(50) NOT NULL,
--	Notes VARCHAR(MAX)
--)


--CREATE TABLE Genres
--(
--	Id BIGINT PRIMARY KEY IDENTITY,
--	GerneName VARCHAR(50) NOT NULL,
--	Notes VARCHAR(MAX)
--)


--CREATE TABLE Categories
--(
--	Id BIGINT PRIMARY KEY IDENTITY,
--	CategoryName VARCHAR(50) NOT NULL,
--	Notes VARCHAR(MAX)
--)


--CREATE TABLE Movies
--(
--	Id BIGINT PRIMARY KEY IDENTITY,
--	Title VARCHAR(90) NOT NULL,
--	DirectorId BIGINT NOT NULL,
--	CopyrightYear DATE NOT NULL,
--	Lenght VARCHAR(10) NOT NULL,
--	GenreId BIGINT NOT NULL,
--	CategoryId BIGINT NOT NULL,
--	Rating INT,
--	Notes VARCHAR(MAX)
--)

--INSERT INTO Directors (DirectorName, Notes)
--VALUES
--('Gosho', 'random notes'),
--('Ivan', NULL),
--('Petko', 'random notes'),
--('Mitko', NULL),
--('Ivanka', 'notes')

--INSERT INTO Genres (GerneName, Notes)
--VALUES
--('Comedy', 'random notes'),
--('Triller', NULL),
--('Sci-Fi', 'random notes'),
--('Action', NULL),
--('Fantasy', 'notes')

--INSERT INTO Categories(CategoryName, Notes)
--VALUES
--('Random category', 'random notes'),
--('Vyzrastni', NULL),
--('Deca', 'random notes'),
--('Seemen', NULL),
--('random', 'notes')

--INSERT INTO Movies (Title, DirectorId, CopyrightYear, Lenght, GenreId, CategoryId, Rating,Notes)
--VALUES
--('Ironman', 1, '2021', '2:45', 3, 2, 10,'random notes'),
--('Spiderman', 2, '2020', '2:05', 1, 4, 7,'random notes'),
--('Avengers', 3, '2014', '1:45', 2, 3, 5,'random notes'),
--('Sherlock', 5, '2005', '2:24', 4, 5, 9,'random notes'),
--('Fight Club', 4, '2000', '2:37', 5, 1, 6,'random notes')

--CREATE DATABASE CarRental

--USE CarRental 

--CREATE TABLE Categories
--(
--	Id BIGINT PRIMARY KEY IDENTITY,
--	CategoryName VARCHAR(30) NOT NULL, 
--	DailyRate DECIMAL(12,2) NOT NULL, 
--	WeeklyRate DECIMAL(12,2) NOT NULL, 
--	MonthlyRate DECIMAL(12,2) NOT NULL, 
--	WeekendRate DECIMAL(12,2) NOT NULL
--)

--CREATE TABLE Cars
--(
--	Id BIGINT PRIMARY KEY IDENTITY,
--	PlateNumber VARCHAR(10) NOT NULL, 
--	Manufacturer VARCHAR(20) NOT NULL, 
--	Model VARCHAR(20) NOT NULL, 
--	CarYear DATE NOT NULL, 
--	CategoryId BIGINT NOT NULL, 
--	Doors SMALLINT NOT NULL, 
--	Picture VARCHAR(100), 
--	Condition VARCHAR(20) NOT NULL, 
--	Available BIT NOT NULL
--)

--CREATE TABLE Employees
--(
--	Id BIGINT PRIMARY KEY IDENTITY, 
--	FirstName VARCHAR(90) NOT NULL,
--	LastName VARCHAR(90)NOT NULL, 
--	Title VARCHAR(30), 
--	Notes VARCHAR(MAX)
--)

--CREATE TABLE Customers
--(
--    Id BIGINT PRIMARY KEY IDENTITY,
--    DriverLicenceNumber VARCHAR(MAX) NOT NULL, 
--    FullName VARCHAR(90) NOT NULL, 
--    [Address] VARCHAR(MAX) NOT NULL, 
--    City VARCHAR(MAX) NOT NULL, 
--    ZIPCode VARCHAR(MAX) NOT NULL, 
--    Notes VARCHAR(MAX)
--)

--CREATE TABLE RentalOrders
--(
--	Id BIGINT PRIMARY KEY IDENTITY,
--	EmployeeId BIGINT NOT NULL, 
--	CustomerId BIGINT NOT NULL, 
--	CarId BIGINT NOT NULL, 
--	TankLevel VARCHAR(10) NOT NULL, 
--	KilometrageStart INT NOT NULL, 
--	KilometrageEnd INT NOT NULL, 
--	TotalKilometrage INT NOT NULL, 
--	StartDate DATE NOT NULL, 
--	EndDate DATE NOT NULL, 
--	TotalDays INT NOT NULL, 
--	RateApplied VARCHAR(20) NOT NULL, 
--	TaxRate DECIMAL(12,2) NOT NULL, 
--	OrderStatus VARCHAR(30) NOT NULL, 
--	Notes VARCHAR(MAX)
--)

--INSERT INTO Categories (CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
--VALUES
--('Sedan', 5.20, 30.00, 120.00, 10.50),
--('SUV', 9.20, 50.00, 250.00, 15.50),
--('Coupe', 10.20, 60.00, 280.00, 25.50)

--INSERT INTO Cars (PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available)
--VALUES
--('CT6403RK', 'Lexus', 'IS250', '2006', 3, 4, 'www.lexus.com', 'good', 0),
--('C262303RK', 'Tesla', 'Model S', '2012', 1, 4, 'www.tesla.com', 'new', 1),
--('346403RK', 'Honda', 'Civic', '2010', 3, 4, 'www.honda.com', 'good', 0)

--INSERT INTO Employees (FirstName, LastName, Title, Notes)
--VALUES
--('Ivan', 'Petrov', 'manager', NULL),
--('Georgi', 'Ivanov', 'consultant', NULL),
--('Ivan', 'Georgiev', 'HR', 'random notes')

--INSERT INTO Customers (DriverLicenceNumber, FullName, [Address], City, ZIPCode, Notes)
--VALUES
--('12334VF435323', 'Gosho Ivanov', 'Middle Earth', 'Gondor', '23412c', NULL),
--('12334V3d215323', 'Gosho Ivanov', 'End of the Earth', 'Kaspichan', '23421412c', NULL),
--('132d353672123', 'Gosho Ivanov', '5th avenue', 'Plovdiv', '23sda2c', 'Random notes')

--INSERT INTO RentalOrders (EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)
--VALUES
--(23, 43, 2, 'full', 23000, 24000, 24000, '10/2/2020', GETDATE(), 10, 'weekly', 20.00, 'completed', NULL),
--(23, 43, 2, 'full', 23000, 24000, 24000, '10/2/2020', GETDATE(), 2 , 'weekly', 20.00, 'completed', NULL),
--(23, 43, 2, 'full', 23000, 24000, 24000, '10/2/2020', GETDATE(), 5 , 'weekly', 20.00, 'completed', NULL)

--CREATE DATABASE Hotel

--USE Hotel

--CREATE TABLE Employees
--(
--	Id INT PRIMARY KEY IDENTITY,
--	FirstName VARCHAR(90) NOT NULL,
--	LastName VARCHAR(90)NOT NULL,
--	Title VARCHAR(50) NOT NULL,
--	Notes VARCHAR(MAX)
--)

--CREATE TABLE Customers
--(
--	AccountNumber INT PRIMARY KEY,
--	FirstName VARCHAR(90) NOT NULL,
--	LastName VARCHAR(90) NOT NULL,
--	PhoneNumber CHAR(10) NOT NULL,
--	EmergencyName VARCHAR(90) NOT NULL,
--	EmergencyPhone CHAR(10) NOT NULL,
--	Notes VARCHAR(MAX)

--)

--CREATE TABLE RoomStatus
--(
--	Id BIGINT PRIMARY KEY IDENTITY,
--	RoomStatus VARCHAR(20) NOT NULL,
--	Notes VARCHAR(MAX)
--)

--CREATE TABLE RoomTypes
--(
--	Id BIGINT PRIMARY KEY IDENTITY,
--	RoomType VARCHAR(20) NOT NULL,
--	Notes VARCHAR(MAX)
--)

--CREATE TABLE BedTypes
--(
--	Id BIGINT PRIMARY KEY IDENTITY,
--	BedType VARCHAR(20) NOT NULL,
--	Notes VARCHAR(MAX)

--)

--CREATE TABLE Rooms
--(
--	RoomNumber INT PRIMARY KEY NOT NULL,
--	RoomType VARCHAR(20) NOT NULL,
--	BedType VARCHAR(20) NOT NULL,
--	Rate INT,
--	RoomStatus VARCHAR(20) NOT NULL,
--	Notes VARCHAR(MAX)

--)

--CREATE TABLE Payments
--(
--	Id INT PRIMARY KEY IDENTITY,
--	EmployeeId INT NOT NULL,
--	PaymentDate DATETIME NOT NULL,
--	AccountNumber INT NOT NULL,
--	FirstDateOccupied DATETIME NOT NULL,
--	LastDateOccupied DATETIME NOT NULL,
--	TotalDays INT NOT NULL,
--	AmountCharged DECIMAL (15,2),
--	TaxRate INT,
--	TaxAmount INT,
--	PaymentTotal DECIMAL(15,2),
--	Notes VARCHAR(MAX)
--)

--CREATE TABLE Occupancies
--(
--	Id INT PRIMARY KEY IDENTITY,
--	EmployeeId INT NOT NULL,
--	DateOccupied DATETIME NOT NULL,
--	AccountNumber INT NOT NULL,
--	RoomNumber INT NOT NULL,
--	RateApplied INT,
--	PhoneCharge DECIMAL(15,2),
--	Notes VARCHAR(MAX)
--)

--INSERT INTO Employees (FirstName, LastName, Title, Notes)
--VALUES
--('Gosho', 'Goshec', 'CEO', NULL),
--('Ivan', 'Petrov', 'CFO', 'random note'),
--('Gosho', 'Goshec', 'CEO', NULL)
--INSERT INTO Customers 
--VALUES
--(120,'Gosho', 'Goshec', '1234567890', 'T', '1234567890', NULL),
--(121,'Petyr', 'Ivanov', '1244567890', 'T', '1244567890', NULL),
--(124,'Goshov', 'Goshedc', '1235567890', 'T', '1235567890', NULL)

--INSERT INTO RoomStatus VALUES
--('occupied', NULL),
--('occupied', NULL),
--('occupied', NULL)

--INSERT INTO RoomTypes VALUES
--('two bed room', NULL),
--('two bed room', NULL),
--('two bed room', NULL)

--INSERT INTO BedTypes VALUES
--('single', NULL),
--('single', NULL),
--('kingsize', NULL)

--INSERT INTO Rooms (RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes)
--VALUES
--(220, 'two bed room', 'single', 4, 'Occupied', NULL),
--(222, 'two bed room', 'single', 4, 'Occupied', NULL),
--(224, 'two bed room', 'single', 4, 'Occupied', NULL)

--INSERT INTO Payments VALUES
--(1, GETDATE(), 120, '5/5/2020', '5/4/2012', 7, 214.23, NULL, NULL, 44.23, NULL),
--(23, GETDATE(), 120, '5/5/2020', '5/4/2012', 7, 214.23, NULL, NULL, 44.23, NULL),
--(45, GETDATE(), 120, '5/5/2020', '5/4/2012', 7, 214.23, NULL, NULL, 44.23, NULL)

--INSERT INTO Occupancies (EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes)
--VALUES
--(234, '10/12/2020', 234, 5, 10, 11.20, NULL),
--(232, '10/12/2020', 231, 5, 10, 11.20, NULL),
--(233, '10/12/2020', 232, 5, 10, 11.20, NULL)

--SELECT * FROM Towns ORDER BY [Name] ASC

--SELECT * FROM Departments ORDER BY [Name] ASC

--SELECT * FROM Employees ORDER BY Salary DESC

--SELECT BedType, Rate
--FROM Rooms 

--SELECT * FROM Rooms
--ORDER BY BedType, Rate DESC

--SELECT [Name] FROM Towns
--ORDER BY [Name] ASC

--SELECT [Name] FROM Departments
--ORDER BY [Name] ASC

--SELECT FirstName, LastName, JobTitle, Salary FROM Employees
--ORDER BY  Salary DESC
