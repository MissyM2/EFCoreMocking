using System;
using EFCoreMocking.API.Data;
using MockQueryable.Moq;

namespace EFCoreMocking.Tests.Tests
{
    public class EmployeesControllerTestWithMockQueryable
    {

        //[Fact]
        //public async Task GetEmployees_WhenCalled_ReturnsEmployeeListAsync()
        //{
        //    // Arrange
        //    var mock = TestDataHelper.GetFakeEmployeeList().BuildMock().BuildMockDbSet();
        //    var employeeContextMock = new Mock<EmployeeDbContext>();
        //    employeeContextMock.Setup(x => x.Employees).Returns(mock.Object);

        //    //Act
        //    EmployeeController employeeController = new(employeeContextMock.Object);
        //    var employees = (await employeeController.GetEmployees()).Value;

        //    //Assert
        //    Assert.NotNull(employees);
        //    Assert.Equal(2, employees.Count());
        //}

        //[Fact]
        //public async Task GetEmployeeById_WhenCalled_ReturnsEmployeeAsync()
        //{
        //    // Arrange
        //    var mock = TestDataHelper.GetFakeEmployeeList().BuildMock().BuildMockDbSet();
        //    mock.Setup(x => x.FindAsync(1)).ReturnsAsync(
        //        TestDataHelper.GetFakeEmployeeList().Find(e => e.Id == 1));

        //    var employeeContextMock = new Mock<EmployeeDbContext>();
        //    employeeContextMock.Setup(x => x.Employees)
        //        .Returns(mock.Object);

        //    //Act
        //    EmployeeController employeeController = new(employeeContextMock.Object);
        //    var employee = (await employeeController.GetEmployeeById(1)).Value;

        //    //Assert
        //    Assert.NotNull(employee);
        //    Assert.Equal(1, employee.Id);
        //}

    }
}

