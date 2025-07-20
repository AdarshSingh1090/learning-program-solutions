using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class SecureController : ControllerBase
{
    [Authorize(Roles = "POC")]
    [HttpGet("poc")]
    public IActionResult GetForPoc()
    {
        return Ok("Hello POC, you are authorized to view this!");
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("admin")]
    public IActionResult GetForAdmin()
    {
        return Ok("Hello Admin, you are authorized to view this!");
    }

    [Authorize]
    [HttpGet("all")]
    public IActionResult GetForAnyAuthenticatedUser()
    {
        return Ok("You are authenticated!");
    }
}
