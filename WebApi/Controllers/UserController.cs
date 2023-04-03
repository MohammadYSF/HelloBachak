using Microsoft.AspNetCore.Mvc;
using Entity.Models;
using Entity.Context;
using DataAccess;
using Business;
using Microsoft.EntityFrameworkCore;
using Business.Results;
using Dto.Models;
using DataAccess.Services;
using System.Security.Claims;
using System.Security.Claims;
using Business.Auth;
using Microsoft.AspNetCore.Authorization;
using Business.Helpers.EmailService;

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
    public UserController(ILogger<UserController> logger, IConfiguration config , IWebHostEnvironment webHostEnvironment, HelloBachakContext context , ITokenService tokenService)
    {
        // _userBusiness = new UserBusiness(new UserServiceE);
        _db = new UnitOfWork(context);
        _logger = logger;
        _userBusiness = new UserBusiness(new UserRepository(context) , tokenService);
        _dutyBusiness = new DutyBusiness(new DutyRepository(context), new UserRepository(context));
        _config = config;
        _configRoot = new ConfigurationBuilder().AddUserSecrets<UserController>().Build();
        _webHostEnvironment = webHostEnvironment;        
    }
    [Route("GetAllStudents")]
    [HttpGet]
    [Authorize(Roles = "admin")]
    public IEnumerable<UserDto> GetAllStudents()
    {
        var result = _userBusiness.GetAllStudents();
        
        return result;
    }
    [Route("GetConsultantRelatedStudents")]
    [HttpGet]
    [Authorize(Roles = "consultant")]
    public IEnumerable<UserDto> GetConsultantRelatedStudents(int consultantId)
    {
        return null;
        //var result = _userBusiness.GetConsultantRelatedStudents(consultantId);
        //return result;
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
    [Authorize(Roles = "admin,consultant,student")]

    public ChangePasswordResult ChangePassword(ChangePasswordDto changePasswordDto)
    {
        var result = new ChangePasswordResult(_userBusiness.ChangePassword(changePasswordDto), Language.Persian);
        return result;
    }
    [Route("SendActivationCode")]
    [Authorize(Roles = "admin,consultant,student")]
    [HttpPost]
    public SendActivationCodeResult SendActivationCode(SendActivationCodeDto sendActivationCodeDto)
    {
        IEmailService emailService = new GmailService(_config);
        var result = new SendActivationCodeResult(_userBusiness.SendActivationCode(sendActivationCodeDto, emailService,
         _configRoot,_webHostEnvironment.ContentRootPath, _webHostEnvironment.ContentRootPath + "/api/User/SendActivationCode")
         , Language.Persian);
        return result;
    }

    [HttpPost("Login")]
    public ActionResult<LoginUserResult> Login(LoginUserDto loginUserDto)
    {
        var loginUserResult = _userBusiness.LoginUser(loginUserDto);
        dynamic result = "";
        result = new LoginUserResult(loginUserResult.Item1, Language.Persian , loginUserResult.Item2 , loginUserResult.Item3);
        if (result.Success)
            return StatusCode(200, result);
        else
            return StatusCode(500, result);

    }
}
