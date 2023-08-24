using System;
using System.Security.Principal;
using EFCoreMocking.API.Repositories;

namespace EFCoreMocking.Tests.Mocks
{
    internal class MockIEmployeeRepository
    {
        public static Mock<IEmployeeRepository> GetMock()
        {
            var mock = new Mock<IEmployeeRepository>();

            mock.Setup(m => m.GetAllEmployeesAsync()).ReturnsAsync(() => FakeEmployeeDb.employees);

            mock.Setup(m => m.GetEmployeeByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((int id) => FakeEmployeeDb.employees.FirstOrDefault(o => o.Id == id));

            //mock.Setup(x => x.GetEmployeeByIdAsync(It.IsAny<int>()))
            //    .ReturnsAsync(FakeEmployeeDb.employees.First());

            //    return this;
            //}

            mock.Setup(x => x.GetEmployeeByIdAsync(It.IsAny<int>()))
            .ReturnsAsync(default(Employee));

            



            ////mock.Setup(m => m.GetEmployeeWithDetails(It.IsAny<Guid>()))
            ////    .Returns((Guid id) => FakeEmployeeDb.employees.FirstOrDefault(o => o.Id == id));

            //mock.Setup(m => m.CreateEmployee(It.IsAny<Employee>()))
            //    .Callback(() => { return; });

            //mock.Setup(m => m.UpdateEmployee(It.IsAny<Employee>()))
            //   .Callback(() => { return; });

            //mock.Setup(m => m.DeleteEmployee(It.IsAny<Employee>()))
            //   .Callback(() => { return; });


            return mock;
        }
       
    }
}

// another example
//var employees = new List<Employee>()
//        {
//            new Employee()
//            {
//                Id = Guid.Parse("0f8fad5b-d9cb-469f-a165-70867728950e"),
//                Name = "John",
//                DateOfBirth = DateTime.Now.AddYears(-20),
//                Accounts = new List<Account>()
//                {
//                    new Account()
//                    {
//                        Id = new Guid(),
//                        AccountType = "",
//                        DateCreated = DateTime.Now
//                    }
//                }
//            }
//        };