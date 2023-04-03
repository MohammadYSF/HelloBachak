using Microsoft.AspNetCore.Mvc;
using Entity.Models;
using Entity.Context;
using DataAccess;
using Business;
using Microsoft.EntityFrameworkCore;
using Business.Results;
using Dto.Models;
using DataAccess.Services;
using Microsoft.AspNetCore.Authorization;
using Entity.Models.FunctionModels;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DutyController : ControllerBase
{
    private readonly UnitOfWork _db;
    private readonly ILogger<UserController> _logger;
    private readonly UserBusiness _userBusiness;
    private readonly DutyBusiness _dutyBusiness;
    private readonly IConfiguration _config;
    private readonly IConfigurationRoot _configRoot;
    private readonly IWebHostEnvironment _webHostEnvironment;
    public DutyController(ILogger<UserController> logger, IConfiguration config, IWebHostEnvironment webHostEnvironment, HelloBachakContext context)
    {
        // _userBusiness = new UserBusiness(new UserServiceE);
        _db = new UnitOfWork(context);
        _logger = logger;
        _dutyBusiness = new DutyBusiness(new DutyRepository(context),new UserRepository(context));
        _config = config;
        _configRoot = new ConfigurationBuilder().AddUserSecrets<UserController>().Build();
        _webHostEnvironment = webHostEnvironment;
    }
    [HttpGet]
    [Route("GetRelatedStudentDuties")]
    [Authorize(Roles = "student,consultant")]
    public ActionResult<Func_Report_Student_Related_Duty> GetRelatedStudentDuties(int studentId)
    {
        int httpCode = 200;
        var result = _dutyBusiness.GetStudentRelatedDuties(studentId, ref studentId);
        return StatusCode(httpCode, result);
    }
    //[HttpGet]
    //[Route("GetAllDuties")]
    //public ActionResult<IEnumerable<DutyDto>> GetAllDuties()
    //{
    //    var result = _dutyBusiness.GetAllDuties();
    //    return Ok(result);
    //}
    [HttpPost]
    [Route("CreateDutyReply")]
    [Authorize(Roles = "student")]
    public ActionResult<DutyReplyDtoValidationResult> CreateDutyReply(DutyReplyDto dto)
    {
        int httpCode = 200;
        var result = _dutyBusiness.CreateDutyReply(dto , ref httpCode);
        return StatusCode(httpCode, result);


    }
    [Route("CreateDuty")]
    [Authorize(Roles = "consultant")]
    [HttpPost]
    public ActionResult<CreateDutyResult> CreateDuty(DutyDto dutyDto)
    {
        int httpCode = 200;
        var result = new CreateDutyResult(_dutyBusiness.CreateDuty(dutyDto , ref httpCode), Language.Persian);
        return StatusCode(httpCode, result);

    }
    //[HttpGet]
    //[Route("GetActiveDutiesByStudentId")]
    //public ActionResult<DutyDto> GetActiveDutiesByStudentId(int userId)
    //{
    //    var result = _dutyBusiness.GetActiveDutiesByStudentId(userId);
    //    return Ok(result);
    //}
    
}
