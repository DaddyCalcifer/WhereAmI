using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhereAmI_API.Models;
using WhereAmI_API.Services;

namespace WhereAmI_API.Controllers;

[ApiController]
[Route("api/child")]
public class ChildController : ControllerBase
{
    private readonly ChildService _service = new();
    
    [HttpPost("create/{deviceId}")]
    public async Task<IActionResult> CreateChild(string deviceId)
    {
        return new OkObjectResult(await _service.CreateChild(deviceId));
    }
    [HttpGet("all/{userId:guid}")]
    //[Authorize]
    public async Task<IActionResult> GetByInd(Guid childId)
    {
        var child = await _service.GetById(childId);
        if (child == null) return new NotFoundResult();
        return new OkObjectResult(child);
    }
}