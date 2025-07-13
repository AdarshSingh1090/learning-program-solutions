using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using EmployeeApi.Models;
using EmployeeApi.Filters;

namespace EmployeeApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[CustomAuthFilter]                 // optional auth filter
[Produces("application/json")]     // Swagger clarity
public class EmployeeController : ControllerBase
{
    // ────────────────────────────────────────────────────────────────
    // Hard‑coded data store (in‑memory list)
    // ────────────────────────────────────────────────────────────────
    private static readonly List<Employee> _employees = new()
    {
        new Employee
        {
            Id = 1,
            Name = "Emma",
            Salary = 950000,
            Permanent = true,
            Department = new Department(1, "Finance"),
            Skills = new() { new Skill(1, "Excel"), new Skill(2, "SQL") },
            DateOfBirth = new DateTime(1990, 5, 12)
        },
        new Employee
        {
            Id = 2,
            Name = "Liam",
            Salary = 850000,
            Permanent = false,
            Department = new Department(2, "HR"),
            Skills = new() { new Skill(3, "Negotiation") },
            DateOfBirth = new DateTime(1995, 3, 22)
        }
    };

    // ────────────────────────────────────────────────────────────────
    // READ
    // ────────────────────────────────────────────────────────────────
    [AllowAnonymous]
    [HttpGet("standard")]
    [ProducesResponseType(typeof(List<Employee>), 200)]
    public ActionResult<List<Employee>> GetStandard() => Ok(_employees);

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(Employee), 200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public ActionResult<Employee> Get(int id)
    {
        if (id <= 0)
            return BadRequest("Invalid employee id");

        var emp = _employees.FirstOrDefault(e => e.Id == id);
        return emp is null ? NotFound() : Ok(emp);
    }

    // ────────────────────────────────────────────────────────────────
    // CREATE
    // ────────────────────────────────────────────────────────────────
    [HttpPost]
    [ProducesResponseType(typeof(Employee), 201)]
    public ActionResult<Employee> Post([FromBody] Employee employee)
    {
        employee.Id = _employees.Max(e => e.Id) + 1;
        _employees.Add(employee);
        return CreatedAtAction(nameof(Get), new { id = employee.Id }, employee);
    }

    // ────────────────────────────────────────────────────────────────
    // UPDATE (objective focus)
    // ────────────────────────────────────────────────────────────────
    [HttpPut("{id:int}")]
    [ProducesResponseType(typeof(Employee), 200)]
    [ProducesResponseType(400)]
    public ActionResult<Employee> Put(int id, [FromBody] Employee input)
    {
        if (id <= 0)
            return BadRequest("Invalid employee id");

        var idx = _employees.FindIndex(e => e.Id == id);
        if (idx == -1)
            return BadRequest("Invalid employee id");

        // Update the record
        input.Id           = id;                // preserve id
        _employees[idx]    = input;             // overwrite with new data

        return Ok(_employees[idx]);
    }

    // ────────────────────────────────────────────────────────────────
    // DELETE (optional, completes CRUD)
    // ────────────────────────────────────────────────────────────────
    [HttpDelete("{id:int}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public IActionResult Delete(int id)
    {
        if (id <= 0)
            return BadRequest("Invalid employee id");

        var emp = _employees.FirstOrDefault(e => e.Id == id);
        if (emp is null)
            return BadRequest("Invalid employee id");

        _employees.Remove(emp);
        return NoContent();
    }
}
