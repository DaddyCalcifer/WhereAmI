using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhereAmI_API.Models;
using WhereAmI_API.Models.Requests;
using WhereAmI_API.Services;

namespace WhereAmI_API.Controllers;

[ApiController]
[Route("api/parent")]
public class UserController : ControllerBase
{
    private readonly UserService _service = new();
    private readonly ChildService _ChildService = new();

    [HttpGet("all")]
    //[Authorize]
    public async Task<JsonResult> GetAll()
    {
        return new JsonResult(await _service.GetAll());
    }
    [HttpPost("create")]
    public async Task<IActionResult> CreateUser([FromBody] User user)
    {
        return new OkObjectResult(await _service.CreateUser(user));
    }
    [HttpGet("all/{userId:guid}")]
    //[Authorize]
    public async Task<IActionResult> GetByInd(Guid userId)
    {
        var user_ = await _service.GetById(userId);
        if (user_ == null) return new NotFoundResult();
        return new OkObjectResult(user_);
    }
    [HttpPut("child")]
    //[Authorize]
    public async Task<JsonResult> AddChild([FromBody] AddChildRequest child)
    {
        var userObj = _service.GetById(child.ParentId);
        if (userObj.Result == null)
        {
            return new JsonResult(new { message = "Token is incorrect!" }) { StatusCode = 401 };
        }
        var child_ = await _ChildService.GetById(child.ChildId);
        if (child_ == null)
        {
            return new JsonResult(new { message = "Child is not found!" }) { StatusCode = 404 };
        }
        await _service.AddChild(child.ParentId, child_);
        return new JsonResult(new {message = "Data addiction success!"}) { StatusCode = StatusCodes.Status201Created };
    }
    [HttpPut("safezone")]
    //[Authorize]
    public async Task<JsonResult> AddSZ([FromBody] SafeZone safeZone)
    {
        if (safeZone.OwnerId != null)
        {
            var userObj = _service.GetById(safeZone.OwnerId);
            if (userObj.Result == null)
            {
                return new JsonResult(new { message = "Token is incorrect!" }) { StatusCode = 401 };
            }
        }

        await _service.AddSafeZone(safeZone);
        return new JsonResult(new {message = "Data addiction success!"}) { StatusCode = StatusCodes.Status201Created };
    }

    [HttpGet]
    //[Authorize]
    public async Task<JsonResult> Self()
    {
        var userIdClaim = HttpContext.User.FindFirst(ClaimTypes.Sid);
        if (userIdClaim == null || !Guid.TryParse(userIdClaim.Value, out var userId))
        {
            return new JsonResult(new { message = "Token is incorrect!" }) { StatusCode = 401 };
        }
        
        var user = await _service.GetById(userId);
        
        return user == null ? 
            new JsonResult(new {message = "Not found!" }) { StatusCode = StatusCodes.Status404NotFound } : 
            new JsonResult(user) { StatusCode = StatusCodes.Status200OK };
    }
}