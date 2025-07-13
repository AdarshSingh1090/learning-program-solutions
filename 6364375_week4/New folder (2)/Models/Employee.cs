namespace EmployeeApi.Models;

public class Employee
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public double Salary { get; set; }
    public bool Permanent { get; set; }
    public required Department Department { get; set; }
    public required List<Skill> Skills { get; set; }
    public DateTime DateOfBirth { get; set; }
}
