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
    [Route("GetAllDuties")]
    public ActionResult<IEnumerable<DutyDto>> GetAllDuties()
    {
        var result = _dutyBusiness.GetAllDuties();
        return Ok(result);
    }
    [HttpPost]
    [Route("CreateDutyReply")]
    public ActionResult<DutyReplyDtoValidationResult> CreateDutyReply(DutyReplyDto dto)
    {
        var result = _dutyBusiness.CreateDutyReply(dto);
        if (result.Success)
            return Ok(result);
        else
            return BadRequest(result);


    }
    [Route("CreateDuty")]
    [HttpPost]
    public CreateDutyResult CreateDuty(DutyDto dutyDto)
    {
        var result = new CreateDutyResult(_dutyBusiness.CreateDuty(dutyDto), Language.Persian);
        return result;
    }
    [HttpGet]
    [Route("GetActiveDutiesByStudentId")]
    public ActionResult<DutyDto> GetActiveDutiesByStudentId(int userId)
    {
        var result = _dutyBusiness.GetActiveDutiesByStudentId(userId);
        return Ok(result);
    }
    
}
