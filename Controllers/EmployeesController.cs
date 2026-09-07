using EmployeeManagementApi.DTOs;
using EmployeeManagementApi.Models;
using EmployeeManagementApi.Services;
using Microsoft.AspNetCore.Mvc;


namespace EmployeeManagementApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeesController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetEmployees() // create => GET /api/employees
    {
        var employees = await _employeeService.GetEmployeesAsync();
        var dtos = employees.Select(employee => new EmployeeDto
        {
            Id = employee.Id,
            Name = employee.Name,
            Email = employee.Email,
            Salary = employee.Salary
        }
        ).ToList();

        return Ok(dtos);
    }

    [HttpPost]
    public async Task<IActionResult> CreateEmployee(CreateEmployeeDto dto)
    {
        var employee = new Employee
        {
            Name = dto.Name,
            Email = dto.Email,
            Salary = dto.Salary
        };

        var createdEmployee =
            await _employeeService.CreateEmployeeAsync(employee);

        var employeeDto = new EmployeeDto
        {
            Id = createdEmployee.Id,
            Name = createdEmployee.Name,
            Email = createdEmployee.Email,
            Salary = createdEmployee.Salary
        };

        return CreatedAtAction(
            nameof(GetEmployee),
            new { id = createdEmployee.Id },
            employeeDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEmployee(int id)
    {
        var employee = await _employeeService.GetEmployeeAsync(id);

        if (employee == null)
        {
            return NotFound();
        }

        var dto = new EmployeeDto()
        {
            Id = employee.Id,
            Name = employee.Name,
            Email = employee.Email,
            Salary = employee.Salary
        };
        return Ok(dto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEmployee(
        int id,
        UpdateEmployeeDto dto)
    {
        var employee = new Employee
        {
            Id = id,
            Name = dto.Name,
            Email = dto.Email,
            Salary = dto.Salary
        };

        var updatedEmployee =
            await _employeeService.UpdateEmployeeAsync(id, employee);

        if (updatedEmployee == null)
        {
            return NotFound();
        }

        var employeeDto = new EmployeeDto
        {
            Id = updatedEmployee.Id,
            Name = updatedEmployee.Name,
            Email = updatedEmployee.Email,
            Salary = updatedEmployee.Salary
        };

        return Ok(employeeDto);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        var deleted = await _employeeService.DeleteEmployeeAsync(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}