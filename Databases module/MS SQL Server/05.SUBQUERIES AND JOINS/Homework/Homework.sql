----1
--SELECT TOP(5) e.EmployeeID, e.JobTitle, e.AddressID, a.AddressText
--FROM Employees AS e
--JOIN Addresses AS a ON e.AddressID = a.AddressID
--ORDER BY AddressID ASC

----2
--SELECT TOP(50) e.FirstName, e.LastName, t.[Name] AS Town, a.AddressText
--FROM Employees e 
--JOIN Addresses a ON a.AddressID = e.AddressID
--JOIN Towns t ON t.TownID = a.TownID
--ORDER BY e.FirstName, e.LastName

----3
--SELECT e.EmployeeID, e.FirstName, e.LastName, d.[Name] AS DepartmentName
--FROM Employees e
--JOIN Departments d ON e.DepartmentID = d.DepartmentID
--WHERE d.[Name] = 'SALES'

----4

--SELECT TOP(5) e.EmployeeID, e.FirstName, e.Salary, d.Name AS DepartmentName
--FROM Employees AS e
--JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
--ORDER BY d.DepartmentID ASC

----5

--SELECT TOP(3) e.EmployeeID, e.FirstName
--FROM Employees AS e
--LEFT JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
--WHERE ep.ProjectID IS NULL
--ORDER BY e.EmployeeID ASC


----6
--SELECT e.FirstName, e.LastName, e.HireDate, d.[Name] AS DeptName
--FROM Employees e
--JOIN Departments d ON e.DepartmentID = d.DepartmentID
--WHERE d.[Name] = 'SALES' OR d.[Name] = 'Finance' 
--		AND DATEPART(YEAR, e.HireDate) > 1998

----7

--SELECT TOP(5) e.EmployeeID, e.FirstName, p.[Name] AS ProjectName
--FROM Employees AS e
--JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
--JOIN Projects AS p ON ep.ProjectID = p.ProjectID
--WHERE p.StartDate > CONVERT(smalldatetime,'13/08/2002', 103) AND p.EndDate IS NULL
--ORDER BY e.EmployeeID ASC

----8


--SELECT e.EmployeeID, e.FirstName,
-- --IIF(DATEPART(YEAR,p.StartDate) >= 2005, NULL, p.[Name]) AS ProjectName
--CASE
--WHEN DATEPART(YEAR,p.StartDate) >= 2005 THEN NULL 
--ELSE p.[Name]
--END
--AS ProjectName
--FROM Employees AS e
--JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
--JOIN Projects AS p ON ep.ProjectID = p.ProjectID
--WHERE ep.EmployeeID = 24

----9

--SELECT e.EmployeeID, e.FirstName, m.EmployeeID, m.FirstName AS ManagerName

--FROM Employees AS e
-- JOIN Employees AS m ON m.EmployeeID = e.ManagerID
-- WHERE e.ManagerID IN (3, 7)
-- ORDER BY e.EmployeeID ASC

----10

 
--SELECT TOP(50) e.EmployeeID, e.FirstName + ' ' + e.LastName AS EmployeeName,
--		m.FirstName + ' ' + m.LastName AS ManagerName,
--		d.[Name] AS DepartmentName 
--FROM Employees AS e
--LEFT JOIN Employees AS m ON m.EmployeeID = e.ManagerID
--LEFT JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
--ORDER BY e.EmployeeID ASC

--SELECT* FROM Employees AS e
-- WHERE e.DepartmentID IN 
--  (
--   SELECT d.DepartmentID     
--   FROM Departments AS d
--    WHERE d.[Name] = 'Finance'
--  )

----11
--SELECT TOP(1) (SELECT AVG(Salary)
--		FROM Employees AS e
--		WHERE e.DepartmentID = d.DepartmentID) AS MinAverageSalary
--FROM Departments AS d
--ORDER BY MinAverageSalary


--12
SELECT c.CountryCode, m.MountainRange, p.PeakName, p.Elevation
FROM Countries AS c
 JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
 JOIN Mountains AS m ON mc.MountainId = m.Id
 JOIN Peaks as p ON m.Id = p.MountainId
 WHERE c.CountryCode = 'BG' AND p.Elevation > 2835
 ORDER BY p.Elevation DESC

 --13
 SELECT c.CountryCode, COUNT(mc.CountryCode)
 FROM Countries AS c
 JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
 WHERE c.CountryCode IN ('RU','BG','US')
GROUP BY c.CountryCode

--14
SELECT TOP(5) c.CountryName, r.RiverName
FROM Countries AS c
LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
WHERE c.ContinentCode = 'AF'
ORDER BY c.CountryName

--15

SELECT MostUsedCurrency.ContinentCode, MostUsedCurrency.CurrencyCode, MostUsedCurrency.CurrencyUsage
FROM(
SELECT c.ContinentCode, 
	   c.CurrencyCode, 
	   COUNT(c.CurrencyCode) AS CurrencyUsage,
	   DENSE_RANK() OVER (PARTITION BY c.ContinentCode ORDER BY COUNT(c.CurrencyCode)
	   DESC) AS [CurrencyRank]
FROM Countries AS c
GROUP BY c.ContinentCode, c.CurrencyCode
HAVING COUNT(c.CurrencyCode) > 1) AS MostUsedCurrency
WHERE MostUsedCurrency.CurrencyRank = 1
ORDER BY MostUsedCurrency.ContinentCode, MostUsedCurrency.CurrencyUsage

--16
SELECT COUNT(c.CountryName) AS [Count]
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode 
LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
WHERE m.MountainRange IS NULL


--17
SELECT TOP(5) c.CountryName, MAX(p.Elevation) AS HighestPeakElevation, MAX(r.Length) AS LongestRiverLength
FROM Countries AS c
JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
JOIN Rivers AS r ON cr.RiverId = r.Id
JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode 
JOIN Mountains AS m ON mc.MountainId = m.Id 
JOIN Peaks AS p ON m.Id = p.MountainId 
GROUP BY c.CountryName
ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC, c.CountryName ASC



