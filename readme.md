This solution demonstares the idea of Test Driven Development and covers basic ways to implement test cases.

-- CalculatorTests.cs contains different test cases to test Add method at
   various levels as development progreses using Tests
   
-- Calculator.cs class implements a method to add numbers available in 
   input string(assuming the numbers are seperated by a delimiter)
   1. Add_Step1 method fullfils basic unit test cases
   2. Add_Step2 method covers more scenarios and it's a refactor of Add_Step1
   3. Add_Step3 method covers more scenarios and it's a refactor of Add_Step2


Calculator class doesn't cover the part where we try to get/update data from some database.
That is taken care in TDDDemo.Employee.Business.MangeEmployee.cs where it's corresponding tests are written in TDDDemo.Employee.DataAccess.Tests.Business.MangeEmployeeTests.cs


-- TDDDemo.EmployeeManagement webapi communicates with Database via Business --> Repository --> DataAccess
-- Demonstarted the implementation of Dependency Injection, Repository and UnitofWork and Tests(for now only for Business layer)