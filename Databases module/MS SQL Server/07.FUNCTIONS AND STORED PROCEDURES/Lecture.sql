--T-SQL declaring variable types
DECLARE @Year SMALLINT;--  = 2021;
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
	SET @Year = 2024
ELSE IF (YEAR(GETDATE())  = 2021)
  BEGIN -- начало на тяло
	  SET @Year = 2021
	  INSERT INTO @MyTempTable ([Name])
	  VALUES('2021')
  END -- край на тяло
ELSE 
	SET @Year = -2000

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



SELECT dbo.udf_BigPower(2,100)

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
RETURNS NVARCHAR(MAX)
AS
BEGIN
	IF @Salary IS NULL
		RETURN NULL
	IF (@Salary < 30000)
		RETURN N'Low'
	ELSE IF @Salary <= 50000
		RETURN N'Average'
	ELSE 
		RETURN N'High'

	RETURN NULL
END


SELECT FirstName,LastName, Salary,  dbo.ufn_GetSalaryLevel(Salary) AS Salary
FROM Employees
