--T-SQL declaring variable types
DECLARE @Year SMALLINT;-- = 2021;
SELECT @Year
SET @Year = 1
SELECT @Year
SET @Year += 1
SELECT @Year

DECLARE @MyTempTable TABLE(Id INT PRIMARY KEY IDENTITY, [Name] NVARCHAR(MAX))
INSERT INTO @MyTempTable ([Name]) 
VALUES ('Niki')

SELECT *
FROM @MyTempTable

--GO -- приключване на скоуп в този контекст по принцип разделител

-- Conditional Statements
IF (DATEPART(YEAR,(GETDATE())) = 2023)
	SET @Year = 2024;
ELSE IF (YEAR(GETDATE())  = 2021)
  BEGIN -- начало на тяло
	  SET @Year = 2021;
	  INSERT INTO @MyTempTable ([Name])
	  VALUES('2021')
  END -- край на тяло
ELSE 
	SET @Year = -2000; 

SELECT CASE @Year
		WHEN 2020 THEN '2020'
		WHEN 2021 THEN '2025'
		ELSE 'Unknown year'
	END
SELECT *
FROM @MyTempTable

GO 
--Loops
--DECLARE @Year SMALLINT = 2000;

SELECT @Year, COUNT(*) 
	FROM Employees 
	WHERE YEAR(HireDate) = @Year
SET @Year +=1
SELECT @Year, COUNT(*) 
	FROM Employees 
	WHERE YEAR(HireDate) = @Year

DECLARE @Year SMALLINT = 1996;
WHILE (@Year < 2008)
BEGIN
	SELECT @Year, COUNT(*) 
		FROM Employees 
		WHERE YEAR(HireDate) = @YEAR
		SET @Year +=1
END
GO
--- Functions and Stored Procedures
 --CONVERT / CAST

DECLARE @Year  INT= (SELECT COUNT(*) FROM Employees);
SELECT @Year;
SET @Year +=1;
SELECT @Year
GO

--SELECT BIGPOWER(2,10)
--SELECT *  FROM udf_MyDataTable
-- Функциите не могат да променят таблици, те могат само да връщат резултати.
-- Функциите не могат да връщат повече от едно нещо - една таблица или едно число.
-- Функциите не позволяват да се пише динамичен SQL или да използват temp tables, но можем да декларираме временни таблици.
-- Не можем да извикваме други функции или собствената функция повече от 32 пъти
-- Нe поддържат TRY CATCH въобще обработката на грешки е доста ограничена. Функциите не би трябвало да хвърлят грешки, по добре е да върне резултат.


--DECLARE @Base INT = 2;
--DECLARE @Exp INT = 30;
--DECLARE @Result;
-- Първи вариант
--SET @Result = POWER(@Base, @Exp)



SELECT dbo.udf_BigPower(3,79)

-- Дефиниране на функция
--CREATE FUNCTION udf_BigPower  (@Base INT, @Exp INT)
--RETURNS DECIMAL(38)
--AS
--	BEGIN
--	DECLARE @Result DECIMAL(38) = 1;

--	WHILE (@Exp > 0)
--	 BEGIN
--		SET @Result = @Result * @Base;
--		SET @Exp = @Exp - 1;
--	 END
--	 RETURN @Result
--END

CREATE OR ALTER FUNCTION ufn_GetSalaryLevel(@Salary MONEY)
RETURNS NVARCHAR(20)
AS
BEGIN
	IF @Salary IS NULL
		RETURN NULL
	IF (@Salary < 30000)
		RETURN 'Low'
	ELSE IF @Salary <= 50000
		RETURN 'Average'
	ELSE 
		RETURN 'High'

	RETURN NULL
END


SELECT FirstName,LastName, Salary,  dbo.ufn_GetSalaryLevel(Salary) AS Salary
FROM Employees

CREATE FUNCTION udf_EmployeesByYear(@Year SMALLINT)
RETURNS TABLE
AS
RETURN
(
SELECT * 
FROM Employees
WHERE YEAR(HireDate) = @Year
)

SELECT * FROM udf_EmployeesByYear(1999)


CREATE OR  ALTER FUNCTION udf_AllPowers(@MaxPower INT)
RETURNS @Table TABLE (Id INT IDENTITY PRIMARY KEY, [Square] BIGINT)
AS
BEGIN
	DECLARE @I INT = 1;
	WHILE(@MaxPower >= @I)
	BEGIN
		INSERT INTO @Table ([Square]) VALUES (@I * @I)
		SET @I +=1;
	END
	RETURN
END

SELECT * FROM dbo.udf_AllPowers(10)
WHERE [Square] % 2 = 1
ORDER BY [Square] DESC

SELECT * FROM udf_EmployeesByYear(1999)

---- Stored Procedures

CREATE PROC sp_TwoSelects
AS
	SELECT COUNT(*) AS EmployeesCout
	FROM Employees
		SELECT COUNT(*) AS AddressesCount
	FROM Addresses
GO


EXEC sp_TwoSelects

----------------------------------------------------------------------------------------------

CREATE PROC sp_AddAndMultiply(
							@FirstNumber INT, @SecondNumber INT,
							@Sum INT OUTPUT, @Product INT OUTPUT)
AS
	SET @Sum = @FirstNumber + @SecondNumber 
	SET @Product = @FirstNumber * @SecondNumber
GO


DECLARE @Sum INT;
DECLARE @Prod INT;

EXEC sp_AddAndMultiply 2, 3, @Sum OUTPUT, @Prod OUTPUT

SELECT @Sum AS Sum

SELECT @Prod AS Prod

------------------------------------------------------------------------------------

EXEC sp_monitor


----- Error Handling

CREATE OR ALTER FUNCTION udf_HoursToComplete
	(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
AS
BEGIN 
	IF @StartDate IS NULL AND @EndDate IS NULL
		RETURN 0
		---THROW 5001, 'Start date and end date are both NULL!', 1
	IF @StartDate IS NULL
		RETURN 0
	IF @EndDate IS NULL
		RETURN 0
	RETURN DATEDIFF(hour, @StartDate, @EndDate)
	
END

CREATE OR ALTER PROC sp_AddEmployeeToPRoject(@EmployeeId INT, @ProjectId INT)
AS
	DECLARE @CountEmployeeProject INT = 
			(SELECT COUNT(*) FROM EmployeesProjects
				WHERE EmployeeID = @EmployeeId
					AND ProjectID = @ProjectId);
	IF @CountEmployeeProject > 0
		THROW 50001, 'This Employee is already in the project', 1
	
	INSERT INTO EmployeesProjects(EmployeeID, ProjectID)
		VALUES (@EmployeeId, @ProjectId);
GO

EXEC sp_AddEmployeeToPRoject 1, 104

BEGIN TRY 
	SELECT 1/0
END TRY
BEGIN CATCH
	SELECT @@ERROR, ERROR_NUMBER(), ERROR_LINE(), ERROR_PROCEDURE(), 
			ERROR_MESSAGE(), ERROR_STATE(),ERROR_SEVERITY()
END CATCH


