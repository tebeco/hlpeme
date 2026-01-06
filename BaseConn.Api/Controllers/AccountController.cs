using BaseConn.Api.Db;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaseConn.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController(ApplicationContext applicationContext) : ControllerBase
{
    [HttpGet]
    public async Task<Ok<int>> GetUserCount()
        => TypedResults.Ok(await applicationContext.Users.CountAsync());
}
