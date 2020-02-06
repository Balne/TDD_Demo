This solution demonstares the idea of Test Driven Development and covers basic ways to implement test cases.

-- CalculatorTests.cs contains different test cases to test Add method at
   various levels as development progreses using Tests
   
-- Calculator.cs class implements a method to add numbers available in 
   input string(assuming the numbers are seperated by a delimiter)
   1. Add_Step1 method fullfils basic unit test cases
   2. Add_Step2 method covers more scenarios and it's a refactor of Add_Step1
   3. Add_Step3 method covers more scenarios and it's a refactor of Add_Step2



Calculator class doesn't cover the part where we try to get/update data from some database.
That is taken care by DataAccess.cs where it's corresponding tests are written in DAtAccessTests.cs

-- There is a repository pattern setup in DataAccess.cs file that holds modal class Employee, IEmployeeContext implements DbContext of EntityFramework.
   However this is not complete and will not actually fetch/update data in any repository.
   This is written to demonstrate the implementation on UNit test for such cases.

   -- DataAccess class holds methods to GetAllEmployees and SaveEmployee.
   -- DataAccessTests.cs tries to mock data and will cover some of the tests for the above methods.