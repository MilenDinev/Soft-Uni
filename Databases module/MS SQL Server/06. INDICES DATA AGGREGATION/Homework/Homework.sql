--SELECT DepartmentID, SUM(Salary) As Salary 
--FROM Employees AS e
--GROUP BY DepartmentID  
--ORDER BY Salary

-- SELECT DepartmentID, MIN(Salary) AS MinSalary
-- FROM Employees
-- GROUP BY DepartmentID

 SELECT *
 FROM WizzardDeposits

--1

 SELECT COUNT(*) AS [Count]
 FROM WizzardDeposits

--2

 SELECT MAX(MagicWandSize) AS LongestMagicWand
 FROM WizzardDeposits

--3

 SELECT DepositGroup, MAX(MagicWandSize) AS LongestMagicWand
 FROM WizzardDeposits
 GROUP BY DepositGroup

--4

 SELECT DepositGroup, MAX(MagicWandSize) AS LongestMagicWand
 FROM WizzardDeposits
 GROUP BY DepositGroup

--5

 SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
 FROM WizzardDeposits
 GROUP BY DepositGroup

--6

 SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
 FROM WizzardDeposits
 GROUP BY DepositGroup, MagicWandCreator
 HAVING(MagicWandCreator) = 'Ollivander family'

--7

 SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
 FROM WizzardDeposits
 WHERE MagicWandCreator = 'Ollivander family'
 GROUP BY DepositGroup
 HAVING SUM(DepositAmount) < 150000
 ORDER BY TotalSum DESC

--8

 SELECT DepositGroup, MagicWandCreator, MIN(DepositCharge)
 FROM WizzardDeposits
 GROUP BY DepositGroup, MagicWandCreator
 ORDER BY MagicWandCreator, DepositGroup

--9

--10
SELECT DISTINCT LEFT(FirstName, 1) AS FirstLetter
FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
ORDER BY FirstLetter

--11
SELECT DepositGroup, IsDepositExpired, AVG(DepositInterest) AS AverageInterest
FROM WizzardDeposits
WHERE DepositStartDate > '01/01/1985'
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired ASC

--12

--13

