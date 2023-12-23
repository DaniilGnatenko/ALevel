use AdventureWorks2022

select * from Sales.Customer 

select * from Sales.Store order by [Name] asc 

select top 10 * from HumanResources.Employee as e where e.BirthDate >= '1989-09-28' 

select e.NationalIDNumber, e.LoginID, e.JobTitle from HumanResources.Employee as e where e.LoginID like '%0' order by e.JobTitle 

select * from Person.Person as p where p.ModifiedDate between '2008-01-01' and '2009-01-01' and p.MiddleName is not null and p.Title is null

select distinct d.[Name] from HumanResources.Department as d inner join HumanResources.EmployeeDepartmentHistory as ed on d.DepartmentID = ed.DepartmentID

select sum(s.CommissionPct) as Amount_CommissionPct, s.TerritoryID from Sales.SalesPerson as s where s.CommissionPct > 0  group by s.TerritoryID 

select * from HumanResources.Employee as e where e.VacationHours = (select max(e.VacationHours) from HumanResources.Employee as e)

select * from HumanResources.Employee as e where e.JobTitle = 'Sales Representative' or e.JobTitle = 'Network Administrator' or e.JobTitle = 'Network Manager'

select * from HumanResources.Employee as e left join Purchasing.PurchaseOrderHeader as p on e.BusinessEntityID = p.EmployeeID order by p.PurchaseOrderID