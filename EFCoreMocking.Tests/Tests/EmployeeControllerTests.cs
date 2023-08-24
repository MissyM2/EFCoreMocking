using System;
using AutoMapper;
using EFCoreMocking.API;
using EFCoreMocking.API.Entities.DataTransferObjects;
using EFCoreMocking.API.Services;
using EFCoreMocking.Tests.Mocks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreMocking.Tests.Tests
{
	public class EmployeeControllerTests
	{
        public IMapper GetMapper()
        {
            var mappingProfile = new MappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(mappingProfile));
            return new Mapper(configuration);
        }

        [Fact]
        public async Task WhenGettingAllEmployees_ThenAllEmployeesReturn()
        {
            var repositoryWrapperMock = MockIRepositoryWrapper.GetMock();
            var mapper = GetMapper();
            var logger = new LoggerManager();
            var employeeController = new EmployeeController(repositoryWrapperMock.Object, mapper,logger);

            var result = await employeeController.GetAllEmployees() as ObjectResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.IsAssignableFrom<IEnumerable<EmployeeDto>>(result.Value);
            Assert.NotEmpty(result.Value as IEnumerable<EmployeeDto>);
        }
    }
}

