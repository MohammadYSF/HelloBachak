using Microsoft.AspNetCore.Mvc;
using Entity.Models;
using Entity.Context;
using DataAccess;
using Business;
using Microsoft.EntityFrameworkCore;
using Business.Results;
using Dto.Models;
using DataAccess.Services;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UnitOfWork _db;
    private readonly ILogger<UserController> _logger;
    private readonly UserBusiness _userBusiness;
    public UserController(ILogger<UserController> logger, HelloBachakContext context)
    {
        // _userBusiness = new UserBusiness(new UserServiceE);
        _db = new UnitOfWork(context);
        _logger = logger;
        _userBusiness = new UserBusiness(new UserRepository(context));
    }
    [Route("ShowUsers")]
    [HttpGet]
    public async Task<IEnumerable<User>> ShowUsers()
    {
        var data = await _db.UserRepository.Get().ToListAsync();
        _db.Dispose();
        return data;
    }
    [Route("SayHello")]
    [HttpGet]
    public string SayHello()
    {
        return "HelloWorld!";
    }
    [Route("RegisterUser")]
    [HttpPost]
    public RegisterUserResult RegisterUser(RegisterUserDto userDto)
    {
        
        var result = new RegisterUserResult(_userBusiness.RegisterUser(userDto) , Language.Persian);
        return result;
    }
}
