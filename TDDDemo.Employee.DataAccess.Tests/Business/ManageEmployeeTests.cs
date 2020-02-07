namespace TDDDemo.Employee.DataAccess.Tests.Business
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;
    using Moq;
    using TDDDemo.Employee.Business;
    using TDDDemo.Employee.Modals;
    using TDDDemo.Employee.Repository;
    using Xunit;
    public class ManageEmployeeTests
    {
        [Fact]
        public void GetAllEmployees_Valid()
        {
            var empRepositoryMock = new Mock<IEmployeeRepository>();
            empRepositoryMock.Setup(x => x.GetAll()).Returns(GetSampleEmployees());
            var mngEmp = new ManageEmployee(empRepositoryMock.Object);
            var expected = GetSampleEmployees();
            var actual = mngEmp.GetAllEmployees().ToList();

            Assert.NotNull(actual);
            Assert.Equal(actual.Count, expected.Count);
            for (int i = 1; i < actual.Count; i++)
            {
                Assert.Equal(actual[i].EmployeeName, expected[i].EmployeeName);
                Assert.Equal(actual[i].Age, expected[i].Age);
            }
        }

        [Theory]
        [InlineData("Tony Stark Tony Tony Tony Tony Tony Stark Stark Stark Tony Stark Tony Tony Tony Tony Tony Stark Stark Stark Tony Stark Tony Tony Tony Tony Tony Stark Stark Stark", 45)]
        public void SaveEmployee_InValidEmployeeName(string employeeName, int employeeAge)
        {
            var emp = GetEmployee(employeeName, employeeAge);

            var empRepositoryMock = new Mock<IEmployeeRepository>();
            empRepositoryMock.Setup(x => x.Add(emp));

            var mngEmp = new ManageEmployee(empRepositoryMock.Object);

            Action action = () => mngEmp.SaveEmployee(emp);

            //Assert
            action.Should().Throw<Exception>()
                .WithMessage($"Input params has invalid param: {nameof(employeeName)} - {employeeName}");
        }

        [Theory]
        [InlineData("Tony Stark", 145)]
        [InlineData("Tony Stark", 5)]
        public void SaveEmployee_InValidEmployeeAge(string employeeName, int employeeAge)
        {
            var emp = GetEmployee(employeeName, employeeAge);

            var empRepositoryMock = new Mock<IEmployeeRepository>();
            empRepositoryMock.Setup(x => x.Add(emp));

            var mngEmp = new ManageEmployee(empRepositoryMock.Object);

            Action action = () => mngEmp.SaveEmployee(emp);

            //Assert
            action.Should().Throw<Exception>()
                .WithMessage($"Input params has invalid param: {nameof(emp.Age)} - {emp.Age}");
        }

        [Theory]
        [InlineData("Tony Stark Tony Tony Tony Tony Tony Stark Stark Stark Tony Stark Tony Tony Tony Tony Tony Stark Stark Stark Tony Stark Tony Tony Tony Tony Tony Stark Stark Stark", 145)]
        public void SaveEmployee_InValidDetails(string employeeName, int employeeAge)
        {
            var emp = GetEmployee(employeeName, employeeAge);

            var empRepositoryMock = new Mock<IEmployeeRepository>();
            empRepositoryMock.Setup(x => x.Add(emp));

            var mngEmp = new ManageEmployee(empRepositoryMock.Object);

            Action action = () => mngEmp.SaveEmployee(emp);

            //Assert
            action.Should().Throw<Exception>()
                .WithMessage($"Input params has invalid params: {nameof(emp.EmployeeName)} - {employeeName}, {nameof(emp.Age)} - {employeeAge}");
        }

        [Theory]
        [InlineData("Tony Stark", 45)]
        public void SaveEmployee_ValidDetails(string employeeName, int employeeAge)
        {
            var emp = GetEmployee(employeeName, employeeAge);

            var empRepositoryMock = new Mock<IEmployeeRepository>();
            empRepositoryMock.Setup(x => x.Add(emp));

            var mngEmp = new ManageEmployee(empRepositoryMock.Object);

            mngEmp.SaveEmployee(emp);

            empRepositoryMock.Verify(x => x.Add(emp), Times.Exactly(1));
        }

        private Employee GetEmployee(string employeeName, int employeeAge)
        {
            return new Employee()
            {
                EmployeeName = employeeName,
                Age = employeeAge
            };
        }
        private List<Employee> GetSampleEmployees()
        {
            return new List<Employee>
            {
                new Employee
                {
                    EmployeeName = "Sam",
                    Age=30
                },
                new Employee
                {
                    EmployeeName = "Peter",
                    Age=31
                },
                new Employee
                {
                    EmployeeName = "Tony",
                    Age=27
                },
                new Employee
                {
                    EmployeeName = "Dave",
                    Age=28
                }
            };
        }
    }
}
