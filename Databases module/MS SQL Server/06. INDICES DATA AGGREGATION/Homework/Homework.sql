SELECT DepartmentID, SUM(Salary) As Salary 
FROM Employees AS e
GROUP BY DepartmentID  
ORDER BY Salary

 SELECT DepartmentID, MIN(Salary) AS MinSalary
 FROM Employees
 GROUP BY DepartmentID