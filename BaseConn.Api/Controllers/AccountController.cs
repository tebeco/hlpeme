using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BaseConn.Application.Modules.User.Commands;
using BaseConn.Application.Modules.User.Queries;
using BaseConn.Domain.Utilities.RequestFeatures;
using Newtonsoft.Json;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using BaseConn.Infrastructure;
using Microsoft.EntityFrameworkCore;


[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{

    private readonly IMediator _mediator;
    private readonly IConfiguration _configuration;
    private readonly ApplicationContext _context;



    public AccountController(IMediator mediator, IConfiguration configuration, ApplicationContext applicationContext)
    {
        _mediator = mediator;
        _configuration = configuration;
        _context = applicationContext;
    }








    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var command = new RegisterCommand(request.Username, request.Email, request.Password,serviceId:request.ServiceId);
        var result = await _mediator.Send(command);

        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }

        return Ok(new { message = "User registered successfully" });
    }







    [HttpGet("users")]
    // [Authorize(Policy = nameof(Permissions.PERMISSIONS_ADMIN_USERS_LIST))]
    public virtual async Task<IActionResult> getUsers([FromQuery] RequestParameters requestParameters)
    {
        var query = new GetUsersQuery
        {
            RequestParameters = requestParameters
        };

        var users = await _mediator.Send(query);

        Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(users.MetaData));

        return Ok(users);
    }









    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var command = new LoginCommand(request.Username, request.Password, request.Email);
        var result = await _mediator.Send(command);

        if (!result.IsAuthenticated)
        {
            return Unauthorized(result.Errors);
        }
        // Set the token as an HTTP-only cookie
        Response.Cookies.Append(
            "auth_token",
            result.Token,
            new CookieOptions
            {
                HttpOnly = true,
                SameSite = SameSiteMode.Lax,
                Expires = DateTime.UtcNow.AddDays(1),
                Secure = false,
                Path = "/"
            });


        return Ok(new { Token = result.Token, Roles = string.Join(",", result.Roles), UserName = result.Username, UserId = result.UserId, Email = result.Email,ServiceId= result.ServiceId,ServiceName = result.ServiceName });
    }


    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {

        Response.Cookies.Delete("auth_token");
        return Ok("COOKIE Deleted");

    }




















    [HttpPost("assignrole")]
    public async Task<IActionResult> AssignRole(string userId, string role)
    {
        var command = new AssignRoleCommand(userId, role);
        var result = await _mediator.Send(command);

        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }

        return Ok("Role assigned successfully.");
    }













    [HttpGet("admin")]
    [Authorize(Roles = "admin")]
    public IActionResult AdminEndpoint()
    {
        return Ok("This is an admin-only endpoint.");
    }


















    [HttpGet("protected")]
    [Authorize]
    public IActionResult ProtectedEndpoint()
    {
        return Ok(new { message = "You have accessed a protected endpoint no matter what role" });

    }



    [HttpGet("verifyAuth")]
    [Authorize]
    public IActionResult VerifyAuth()
    {
        return Ok(new { message = "you are authentifcated , token not expired yet " });
    }




    public class TokenRequest
    {
        public string Token { get; set; }
    }








    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }



}

public class RegisterRequest
{
    public string Username { get; set; }
    public string Email { get; set; }

    public Guid ServiceId {get;set;}
    public string Password { get; set; }
}
