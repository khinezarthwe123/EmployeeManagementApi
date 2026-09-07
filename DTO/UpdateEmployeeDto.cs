using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementApi.DTOs;

public class UpdateEmployeeDto
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Range(0, double.MaxValue)]
    public decimal Salary { get; set; }
}