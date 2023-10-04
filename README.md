# EFCoreMocking

### Overview

This app is an .net Web API, version 7.0 using EF Core with a SqliteDB.  The subject is an employee db and includes mocking of repository and controller tests.

### Structure
Solution Name: EFCoreMocking

Projects:
- EFCoreMocking.Api
  Contains all data and logic-related folders, including all models, view models, services and database context for local Sqlite db.  Question and Answer data must be added to the database with required information.  A method is run at the beginning of the survey session to load all currently available questions and answers.
       - MappingProfile.cs
       - nlog.config
  
  - /Contracts
         - IEmployeeRepository.cs
         - ILoggerManager.cs
         - IRepositoryBase.cs
         - IRepositoryWrapper.cs

  - /Controllers
         - EmployeeController.cs

  - /Data
         - Datacontext

  - /Entities
       - /DataTransferObjects
            - EmployeeDto.cs
            - EmployeeForCreationDto.cs
            - EmployeeForUpdateDto.cs
       -  /Models
            - Employee.cs
  - /Extensions
       - ServiceExtensions.cs
  - /Repositories
       - EmployeeRepository.cs
       - RepositoryBase.cs
       - RepositoryWrapper.cs
  -  /Services
       - LoggerManager.cs 
  
- EFCoreMocking.Tests
    -  TestDataHelper.cs
    - /Mocks
         - FakeEmployeeDb.cs
         - MockIEmployeeRepository.cs
         - MockIRepositoryWrapper.cs
   -  /Tests
         - EmployeeControllerCreateTests.cs
         - EmployeeControllerDeleteTests.cs
         - EmployeeControllerReadTests.cs
         - EmployeeControllerUpdateTests.cs
         - EmployeesControllerTestWithMockQueryable
         - EmployeesControllerTestWithMoq_EntityFrameworkCore.cs
         - ModelValidationTests.cs

### Libraries

- EFCoreMocking.Api
  
  - Microsoft.AspNetCore.OpenApi
  - Swashbuckle.AspNetCore
  - Microsoft.EntityFrameworkCore.Tools
  - Microsoft.Data.Sqlite.Core
  - Microsoft.EntityFrameworkCore.Sqlite.Core
  - sqlite-net-pcl
  - SQLitePCLRaw.bundle_green
  - SQLitePCLRaw.provider.dynamic_cdecl
  - Microsoft.EntityFrameworkCore
  - NLog.Extensions.Logging
  - AutoMapper.Extensions.Microsoft.DependencyInjection
 
 
- EFCoreMocking.Tests

  - Microsoft.NET.Test.Sdk
  - xunit
  - xunit.runner.visualstudio
  - coverlet.collector
  - Moq.EntityFrameworkCore
  - MockQueryable.Moq
  - Microsoft.AspNetCore.Mvc.Testing
  - FluentAssertions"
 
### Other Features
  - .Api
    - Data Transfer Objects
    - Repository Base Wrapper
  - .Tests
      - Mocks
      - Separate Controller CRUD tests

