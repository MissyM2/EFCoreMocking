using System;
using System.ComponentModel.DataAnnotations;
using EFCoreMocking.API.Entities.DataTransferObjects;

namespace EFCoreMocking.Tests.Tests
{
	public class ModelValidationTests
	{
        [Theory]
        [InlineData(null, null, null, false)]
        [InlineData(null, "TestEmail", null, false)]
        [InlineData(null, null, "301-770-6543", false)]
        [InlineData("TestName", null, null, false)]
        [InlineData(null, "TestEmail", "301-770-6543", false)]
        [InlineData("TestName", null, "301-770-6543", false)]
        [InlineData("TestName", "Test@Email", "301-770-6543", true)]
        [InlineData("TestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTest", "TestEmail", "301-770-6543", false)]
        public void EmployeeDtoTestModelValidation(string? name, string? email, string? phone, bool isValid)
        {
            var employee = new EmployeeDto()
            {
                Name = name,
                Email = email,
                Phone = phone
            };

            Assert.Equal(isValid, ValidateModel(employee));
        }

        

        [Theory]
        [InlineData(null, null, null, false)]
        [InlineData(null, "TestEmail", null, false)]
        [InlineData(null, null, "301-770-6543", false)]
        [InlineData("TestName", null, null, false)]
        [InlineData(null, "TestEmail", "301-770-6543", false)]
        [InlineData("TestName", null, "301-770-6543", false)]
        [InlineData("TestName", "Test@Email", "301-770-6543", true)]
        [InlineData("TestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTest", "TestEmail", "301-770-6543", false)]
        public void EmployeeForCreationTestValidation(string? name, string? email, string? phone, bool isValid)
        {
            var employee = new EmployeeForCreationDto()
            {
                Name = name,
                Email = email,
                Phone = phone
            };

            Assert.Equal(isValid, ValidateModel(employee));
        }

        [Theory]
        [InlineData(null, null, null, false)]
        [InlineData(null, "TestEmail", null, false)]
        [InlineData(null, null, "301-770-6543", false)]
        [InlineData("TestName", null, null, false)]
        [InlineData(null, "TestEmail", "301-770-6543", false)]
        [InlineData("TestName", null, "301-770-6543", false)]
        [InlineData("TestName", "Test@Email", "301-770-6543", true)]
        [InlineData("TestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTest", "TestEmail", "301-770-6543", false)]
        public void EmployeeForUpdateTestValidation(string? name, string? email, string? phone, bool isValid)
        {
            var employee = new EmployeeForUpdateDto()
            {
                Name = name,
                Email = email,
                Phone = phone
            };

            Assert.Equal(isValid, ValidateModel(employee));
        }

        private bool ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            return Validator.TryValidateObject(model, ctx, validationResults, true);
        }
    }
}

