using AutoMapper;
using EFCoreMocking.API.Contracts;
using EFCoreMocking.API.Entities.DataTransferObjects;
using EFCoreMocking.API.Entities.Models;
using EFCoreMocking.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreMocking.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private ILoggerManager _logger;
    private IRepositoryWrapper _repository;
    private IMapper _mapper;

    //private readonly EmployeeDbContext _employeeDbContext;

    //public EmployeeController(EmployeeDbContext employeeDbContext)
    //{
    //    _employeeDbContext = employeeDbContext;
    //}

    public EmployeeController(IRepositoryWrapper repository, IMapper mapper, ILoggerManager logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllEmployees()
    {
        try
        {
            _logger.LogInfo("Fetching all Employees from storage.");

            var employees = await _repository.Employee.GetAllEmployeesAsync();

            _logger.LogInfo($"Returning {employees.Count()} employees.");

            var employeesResult = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return Ok(employeesResult);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside GetAllEmployees action: {ex.Message}");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpGet("{id}", Name = "EmployeeById")]
    public async Task<IActionResult> GetEmployeeById(int id)
    {
        try
        {
            var employee = await _repository.Employee.GetEmployeeByIdAsync(id);

            if (employee is null)
            {
                _logger.LogError($"Employee with id: {id}, hasn't been found in db.");
                return NotFound();
            }
            else
            {
                _logger.LogInfo($"Returned employee with id: {id}");

                var employeeResult = _mapper.Map<EmployeeDto>(employee);
                return Ok(employeeResult);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside GetEmployeeById action: {ex.Message}");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPost]
    public IActionResult CreateEmployee([FromBody] EmployeeForCreationDto employee)
    {
        try
        {
            if (employee is null)
            {
                _logger.LogError("Employee object sent from client is null.");
                return BadRequest("Employee object is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid employee object sent from client.");
                return BadRequest("Invalid model object");
            }

            var employeeEntity = _mapper.Map<Employee>(employee);

            _repository.Employee.CreateEmployee(employeeEntity);
            _repository.SaveAsync();

            var createdEmployee = _mapper.Map<EmployeeDto>(employeeEntity);

            return CreatedAtRoute("EmployeeById", new { id = createdEmployee.Id }, createdEmployee);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside CreateEmployee action: {ex.Message}");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEmployee(int id, [FromBody] EmployeeForUpdateDto employee)
    {
        try
        {
            if (employee is null)
            {
                _logger.LogError("Employee object sent from client is null.");
                return BadRequest("Employee object is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid employee object sent from client.");
                return BadRequest("Invalid model object");
            }

            var employeeEntity = await _repository.Employee.GetEmployeeByIdAsync(id);
            if (employeeEntity is null)
            {
                _logger.LogError($"Employee with id: {id}, hasn't been found in db.");
                return NotFound();
            }

            _mapper.Map(employee, employeeEntity);

            _repository.Employee.UpdateEmployee(employeeEntity);
            await _repository.SaveAsync();

            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside UpdateEmployee action: {ex.Message}");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        try
        {
            var employee = await _repository.Employee.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                _logger.LogError($"Employee with id: {id}, hasn't been found in db.");
                return NotFound();
            }

            _repository.Employee.DeleteEmployee(employee);
            await _repository.SaveAsync();

            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside DeleteEmployee action: {ex.Message}");
            return StatusCode(500, "Internal server error");
        }
    }
}

