using EmployeeManagementApi.Models;

namespace EmployeeManagementApi.Services;

public interface IEmployeeService
{
    Task<List<Employee>> GetEmployeesAsync();
    Task<Employee?> GetEmployeeAsync(int id);
    Task<Employee> CreateEmployeeAsync(Employee employee);
    Task<Employee?> UpdateEmployeeAsync(int id, Employee employee);
    Task<bool> DeleteEmployeeAsync(int id);
}