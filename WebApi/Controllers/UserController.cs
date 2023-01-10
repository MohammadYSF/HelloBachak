using Microsoft.AspNetCore.Mvc;
using Entity.Models;
using Entity.Context;
using DataAccess;
using Business;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UnitOfWork _db;
    private readonly ILogger<UserController> _logger;
    private readonly UserBusiness _userBusiness;
    public UserController(ILogger<UserController> logger , HelloBachakContext context)
    {
        _userBusiness = new UserBusiness();
         _db = new UnitOfWork(context);
        _logger = logger;
    }
    [Route("ShowUsers")]
    [HttpGet]
    public async Task< IEnumerable<User>> ShowUsers(){
        var data  = await _db.UserRepository.Get().ToListAsync();
        _db.Dispose();
        return data;
    }
    [Route("SayHello")]
    [HttpGet]
    public string SayHello(){
        return "HelloWorld!";
    }
}
