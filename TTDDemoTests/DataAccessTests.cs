using Autofac.Extras.Moq;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TDDDemoConsole;
using Xunit;

namespace TTDDemoTests
{

    public class DataAccessTests
    {
        [Fact]
        public void GetAllEmployees_Valid() 
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IEmployeeContext>()
                    .Setup(x => x.Employees)
                    .Returns(GetSampleEmployees());

                var cls = mock.Create<DataAccess>();
                var expected = GetSampleEmployees();
                var actual = cls.GetAllEmployees();


                Assert.NotNull(actual);
                Assert.Equal(actual.Count, expected.Count);
                for (int i = 1; i < actual.Count; i++)
                {
                    Assert.Equal(actual[i].EmployeeName, expected[i].EmployeeName);
                    Assert.Equal(actual[i].Age, expected[i].Age);
                }
            }
        }

        [Theory]
        [InlineData("Tony Stark Tony Tony Tony Tony Tony Stark Stark Stark Tony Stark Tony Tony Tony Tony Tony Stark Stark Stark Tony Stark Tony Tony Tony Tony Tony Stark Stark Stark", 45)]
        public void SaveEmployee_InValidEmployeeName(string employeeName, int employeeAge)
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IEmployeeContext>()
                    .Setup(x => x.SaveChanges());

                var cls = mock.Create<DataAccess>();

                Action action = () => cls.SaveEmployee(employeeName, employeeAge);

                //Assert
                action.Should().Throw<Exception>()
                    .WithMessage($"Input params has invalid param: {nameof(employeeName)} - {employeeName}");
            }
        }


        [Theory]
        [InlineData("Tony Stark", 145)]
        [InlineData("Tony Stark", 5)]
        public void SaveEmployee_InValidEmployeeAge(string employeeName, int employeeAge)
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IEmployeeContext>()
                    .Setup(x => x.SaveChanges());

                var cls = mock.Create<DataAccess>();

                Action action = () => cls.SaveEmployee(employeeName, employeeAge);

                //Assert
                action.Should().Throw<Exception>()
                    .WithMessage($"Input params has invalid param: {nameof(employeeAge)} - {employeeAge}");
            }
        }

        [Theory]
        [InlineData("Tony Stark Tony Tony Tony Tony Tony Stark Stark Stark Tony Stark Tony Tony Tony Tony Tony Stark Stark Stark Tony Stark Tony Tony Tony Tony Tony Stark Stark Stark", 145)]
        public void SaveEmployee_InValidDetails(string employeeName, int employeeAge)
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IEmployeeContext>()
                    .Setup(x => x.SaveChanges());

                var cls = mock.Create<DataAccess>();

                Action action = () => cls.SaveEmployee(employeeName, employeeAge);

                //Assert
                action.Should().Throw<Exception>()
                    .WithMessage($"Input params has invalid params: {nameof(employeeName)} - {employeeName}, {nameof(employeeAge)} - {employeeAge}");
            }
        }

        [Theory]
        [InlineData("Tony Stark", 45)]
        public void SaveEmployee_ValidDetails(string employeeName, int employeeAge)
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IEmployeeContext>()
                    .Setup(x => x.SaveChanges());

                var cls = mock.Create<DataAccess>();

                cls.SaveEmployee(employeeName, employeeAge);

                mock.Mock<IEmployeeContext>()
                    .Verify(x => x.SaveChanges(), Times.Exactly(1));
            }
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
