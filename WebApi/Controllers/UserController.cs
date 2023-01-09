using Microsoft.AspNetCore.Mvc;
using Entity.Models;
using Entity.Context;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly HelloBachakContext _db;
    public UserController(ILogger<UserController> logger , HelloBachakContext db)
    {
        _db = db;
        _logger = logger;
    }
    [Route("ShowUsers")]
    [HttpGet]
    public IEnumerable<User> ShowUsers(){
        
        var data = _db.Users.ToList();
        return data;
    }
    [Route("SayHello")]
    [HttpGet]
    public string SayHello(){
        return "HelloWorld!";
    }
}
