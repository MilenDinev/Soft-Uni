SELECT FirstName, LastName
FROM Employees
WHERE FirstName LIKE 'sa%'


SELECT FirstName, LastName
FROM Employees
WHERE LastName LIKE '%ei%'

SELECT FirstName
FROM Employees
WHERE (DepartmentID = 3 OR DepartmentID = 10) 
	  AND DATEPART(YEAR,HireDate) BETWEEN 1995 AND 2005

SELECT FirstName, LastName
FROM Employees
WHERE JobTitle NOT LIKE '%engineer%'

SELECT [Name]
FROM Towns
WHERE LEN([Name]) BETWEEN 5 AND 6
ORDER BY [Name] ASC

SELECT *
FROM Towns
WHERE [Name] NOT LIKE'[R,B,D]%' --търсене по първа буква в колона
--WHERE LEFT([Name],1) IN ('M','K','B','E')
ORDER BY [Name] ASC




CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName, LastName
FROM Employees
WHERE  DATEPART(YEAR,HireDate) > 2000 -- връщане на по голяма дата
--WHERE HireDate > '2001'


SELECT FirstName, LastName 
FROM Employees
WHERE LEN(Lastname) = 5


SELECT EmployeeID, FirstName, LastName, Salary, DENSE_RANK() OVER (PARTITION BY Salary
 ORDER BY EmployeeID ) 

  FROM Employees
 WHERE Salary BETWEEN 10000 AND 50000
ORDER BY Salary DESC


SELECT * FROM
(
SELECT EmployeeID, FirstName, LastName, Salary, DENSE_RANK() OVER (PARTITION BY Salary
 ORDER BY EmployeeID) AS Ranked 
  FROM Employees
 WHERE Salary BETWEEN 10000 AND 50000
) AS Result
WHERE Ranked = 2
ORDER BY Salary DESC

SELECT CountryName, IsoCode
FROM Countries
WHERE CountryName LIKE '%a%a%a%'
ORDER BY IsoCode

SELECT PeakName, RiverName,
 LOWER(LEFT(PeakName, LEN(PeakName) - 1 ) + RiverName) AS Mix
FROM Peaks, Rivers
WHERE RIGHT(PeakName, 1) = LEFT(RiverName, 1)
ORDER BY Mix

SELECT TOP(50) [Name], FORMAT([Start], 'yyyy-MM-dd') AS [Start]
  FROM Games
  WHERE DATEPART(YEAR,[Start]) BETWEEN 2011 AND 2012
ORDER BY [Start], [Name]

--15
SELECT Username, SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email)) AS EmailProvider
FROM Users
ORDER BY EmailProvider, Username

SELECT Username, IpAddress
FROM Users
WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username


SELECT [Name],
	CASE
	 WHEN DATEPART(HOUR,[Start]) BETWEEN 0 AND 11 THEN 'Morning'
	 WHEN DATEPART(HOUR,[Start]) BETWEEN 12 AND 17 THEN 'Afternoon'
	 WHEN DATEPART(HOUR,[Start]) BETWEEN 18 AND 23 THEN 'Evening'
	END
	 AS [Part of the Day], 
	CASE
	 WHEN Duration <= 3 THEN 'Extra Short'
	 WHEN Duration BETWEEN 4 AND 6 THEN 'Short'
	 WHEN Duration > 6 THEN 'Long'
	 ELSE 'Extra Long'
	END
	AS [Duration]
 FROM Games
ORDER BY [Name], [Duration],[Part of the Day]


SELECT ProductName,
	   OrderDate,
	   DATEADD(DAY, 3, OrderDate) AS [Pay Due],
	   DATEADD(MONTH, 1, OrderDate) AS [Delivery Due]
FROM Orders

