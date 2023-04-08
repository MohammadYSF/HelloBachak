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
using Entity.Models.FunctionModels;

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
    public ActionResult<IEnumerable<Func_Report_Manage_Student>> GetAllStudents()
    {
        var result = _userBusiness.GetAllStudents();
        
        return Ok(result);
    }
    [Route("GetConsultantRelatedStudents")]
    [HttpGet]
    [Authorize(Roles = "consultant")]
    public ActionResult<IEnumerable<Func_Report_Related_Student>> GetConsultantRelatedStudents(int consultantId)
    {
        int httpCode = 200;
        var result = _userBusiness.GetConsultantRelatedStudents(consultantId , ref httpCode);
        return StatusCode(httpCode, result);
    }

    [Route("RegisterUser")]
    [HttpPost]
    public ActionResult<RegisterUserResult> RegisterUser(RegisterUserDto userDto)
    {
        int httpCode = 200;
        var result = new RegisterUserResult(_userBusiness.RegisterUser(userDto , ref httpCode), Language.Persian);
        return StatusCode(httpCode, result);
    }
    [Route("ChangePassword")]
    [HttpPost]
    [Authorize(Roles = "admin,consultant,student")]

    public ActionResult<ChangePasswordResult> ChangePassword(ChangePasswordDto changePasswordDto)
    {
        int httpCode = 200;
        var result = new ChangePasswordResult(_userBusiness.ChangePassword(changePasswordDto , ref httpCode), Language.Persian);
        return StatusCode(httpCode, result);
    }
    [Route("SendActivationCode")]
    [HttpPost]
    public ActionResult<SendActivationCodeResult> SendActivationCode(SendActivationCodeDto sendActivationCodeDto)
    {
        int httpCode = 200;
        IEmailService emailService = new GmailService(_config);
        var result = new SendActivationCodeResult(_userBusiness.SendActivationCode(sendActivationCodeDto, emailService,
         _configRoot,_webHostEnvironment.ContentRootPath, _webHostEnvironment.ContentRootPath + "/api/User/SendActivationCode" , ref httpCode)
         , Language.Persian);
        return StatusCode(httpCode, result);
    }

    [HttpPost("Login")]
    public ActionResult<LoginUserResult> Login(LoginUserDto loginUserDto)
    {
        int httpCode = 200;
        var loginUserResult = _userBusiness.LoginUser(loginUserDto , ref httpCode);
        dynamic result = "";
        result = new LoginUserResult(loginUserResult.Item1, Language.Persian , loginUserResult.Item2 , loginUserResult.Item3 , loginUserResult.Item4, loginUserResult.Item5);
        return StatusCode(httpCode, result);


    }
    [HttpGet("ChangeConsultant")]
    [Authorize(Roles = "student")]
    public ActionResult<string> ChangeConsultant(int studentId , int newConsultantId)
    {
        int httpCode = 200;
        var result = _userBusiness.ChangeConsultant(studentId, newConsultantId, ref httpCode);
        return StatusCode(httpCode, result);
    }
    [HttpGet("GetStudentDetail")]
    [Authorize(Roles = "admin")]
    public ActionResult<SingleStudentDetailDto> GetStudentDetail(int studentId)
    {
        int httpCode = 200;
        var result = _userBusiness.GetStudentDetail(studentId , ref httpCode);
        return StatusCode(httpCode, result);
    }
}
