using System;
namespace EFCoreMocking.Tests.Mocks
{
	public static class FakeEmployeeDb
	{
        public static List<Employee> employees = new List<Employee>()
            {
                new Employee()
                {
                    Id = 77,
                    Name = "John",
                    Email = "john@email.com",
                    Phone = "410-654-9865"
                },
                new Employee()
                {
                    Id = 79,
                    Name = "Bill",
                    Email = "bill@email.com",
                    Phone = "490-654-9875"
                },
                new Employee()
                {
                    Id = 80,
                    Name = "Mary",
                    Email = "mary@email.com",
                    Phone = "490-654-9875"
                },
                new Employee()
                {
                    Id = 81,
                    Name = "Anne",
                    Email = "anne@email.com",
                    Phone = "490-654-9875"
                }
            };
    }
}

