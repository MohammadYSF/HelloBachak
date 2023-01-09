using Microsoft.AspNetCore.Mvc;
using Entity.Models;
namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }
    [Route("ShowUsers")]
    [HttpGet]
    public IEnumerable<User> ShowUsers(){
        var data = new List<User>();
        data.Add(
            new User(){
                Id = 1,
                Age = 20,
                Username = "Mohammad"
            }
        );
        data.Add(
            new User(){
                Id = 2,
                Age = 30,
                Username = "Aghil"
            }
        );
        return data;
    }
    [Route("SayHello")]
    [HttpGet]
    public string SayHello(){
        return "HelloWorld!";
    }
}
