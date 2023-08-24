using System;
using EFCoreMocking.API.Repositories;

namespace EFCoreMocking.Tests.Mocks
{
    internal class MockIRepositoryWrapper
    {
        public static Mock<IRepositoryWrapper> GetMock()
        {
            var mock = new Mock<IRepositoryWrapper>();
            var employeeRepoMock = MockIEmployeeRepository.GetMock();

            // Setup the mock
            mock.Setup(m => m.Employee).Returns(() => employeeRepoMock.Object);
            //mock.Setup(m => m.SaveAsync()).Callback(() => { return; });

            return mock;
        }
    }
}

