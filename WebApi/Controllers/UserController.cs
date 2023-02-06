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
    private readonly DutyBusiness _dutyBusiness;
    private readonly IConfiguration _config;
    private readonly IConfigurationRoot _configRoot;
    private readonly IWebHostEnvironment _webHostEnvironment;
    public UserController(ILogger<UserController> logger, IConfiguration config , IWebHostEnvironment webHostEnvironment, HelloBachakContext context)
    {
        // _userBusiness = new UserBusiness(new UserServiceE);
        _db = new UnitOfWork(context);
        _logger = logger;
        _userBusiness = new UserBusiness(new UserRepository(context));
        _dutyBusiness = new DutyBusiness(new DutyRepository(context));
        _config = config;
        _configRoot = new ConfigurationBuilder().AddUserSecrets<UserController>().Build();
        _webHostEnvironment = webHostEnvironment;
    }
    [Route("GetAllStudents")]
    [HttpGet]
    public IEnumerable<UserDto> GetAllStudents()
    {
        var result = _userBusiness.GetAllStudents();
        
        return result;
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

        var result = new RegisterUserResult(_userBusiness.RegisterUser(userDto), Language.Persian);
        return result;
    }
    [Route("ChangePassword")]
    [HttpPost]
    public ChangePasswordResult ChangePassword(ChangePasswordDto changePasswordDto)
    {
        var result = new ChangePasswordResult(_userBusiness.ChangePassword(changePasswordDto), Language.Persian);
        return result;
    }
    [Route("SendActivationCode")]
    [HttpPost]
    public SendActivationCodeResult SendActivationCode(SendActivationCodeDto sendActivationCodeDto)
    {
        var result = new SendActivationCodeResult(_userBusiness.SendActivationCode(sendActivationCodeDto,
         _configRoot,_webHostEnvironment.ContentRootPath, _webHostEnvironment.ContentRootPath + "/api/User/SendActivationCode")
         , Language.Persian);
        return result;
    }
    [Route("CreateDuty")]
    [HttpPost]
    public CreateDutyResult CreateDuty(DutyDto dutyDto){
        var result = new CreateDutyResult(_dutyBusiness.CreateDuty(dutyDto) , Language.Persian);
        return result;
    }
}
