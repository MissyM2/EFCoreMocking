using System;
using System.Net;
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

        #region GetById
        [Fact]
        public async Task GivenAnIdOfAnExistingEmployee_WhenGettingEmployeeById_ThenEmployeeReturns()
        {
            var repositoryWrapperMock = MockIRepositoryWrapper.GetMock();
            var mapper = GetMapper();
            var logger = new LoggerManager();
            var employeeController = new EmployeeController(repositoryWrapperMock.Object, mapper, logger);

            var id = 79;
            var result = await employeeController.GetEmployeeById(id) as ObjectResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.IsAssignableFrom<EmployeeDto>(result.Value);
            Assert.NotNull(result.Value as EmployeeDto);
        }

        [Fact]
        public async void Task_GetEmployeeById_Return_NotFoundResult()
        {
            //Arrange
            var repositoryWrapperMock = MockIRepositoryWrapper.GetMock();
            var mapper = GetMapper();
            var logger = new LoggerManager();
            var employeeController = new EmployeeController(repositoryWrapperMock.Object, mapper, logger);
            var id = 3;

            //Act  
            var result = await employeeController.GetEmployeeById(id) as ObjectResult;

            //Assert  
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async void Task_GetEmployeeById_Return_BadRequestResult()
        {
            //Arrange
            var repositoryWrapperMock = MockIRepositoryWrapper.GetMock();
            var mapper = GetMapper();
            var logger = new LoggerManager();
            var employeeController = new EmployeeController(repositoryWrapperMock.Object, mapper, logger);
            int? id = null;

            //Act  
            var result = await employeeController.GetEmployeeById(id.Value) as ObjectResult;

            //Assert  
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async void Task_GetEmployeeById_MatchResult()
        {
            //Arrange
            var repositoryWrapperMock = MockIRepositoryWrapper.GetMock();
            var mapper = GetMapper();
            var logger = new LoggerManager();
            var employeeController = new EmployeeController(repositoryWrapperMock.Object, mapper, logger);
            int? id = 1;

            //Act  
            var result = await employeeController.GetEmployeeById(id.Value) as ObjectResult;

            //Assert  
            Assert.IsType<OkObjectResult>(result);

            //var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            //var employee = okResult.Value.Should().BeAssignableTo<EmployeeViewModel>().Subject;

            //Assert.Equal("Test Title 1", employeeDto.;
            //Assert.Equal("Test Description 1", employee.Description);
        }

        #endregion

        #region Create Employee

        [Fact]
        public void GivenValidRequest_WhenCreatingEmployee_ThenCreatedReturns()
        {
            var repositoryWrapperMock = MockIRepositoryWrapper.GetMock();
            var mapper = GetMapper();
            var logger = new LoggerManager();
            var employeeController = new EmployeeController(repositoryWrapperMock.Object, mapper, logger);

            var employee = new EmployeeForCreationDto()
            {
                Name = "TestName",
                Email = "test@email.com",
                Phone = "301-678-0976"
            };
            var result = employeeController.CreateEmployee(employee) as ObjectResult;

            Assert.NotNull(result);
            Assert.IsAssignableFrom<CreatedAtRouteResult>(result);
            Assert.Equal((int)HttpStatusCode.Created, result!.StatusCode);
            Assert.Equal("EmployeeById", (result as CreatedAtRouteResult)!.RouteName);
        }

        #endregion
    }
}

