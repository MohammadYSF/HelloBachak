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
public class LessonController : ControllerBase
{
    private readonly UnitOfWork _db;
    private readonly ILogger<LessonController> _logger;
    private readonly LessonBusiness _lessonBusiness;
    private readonly IConfiguration _config;
    private readonly IConfigurationRoot _configRoot;
    private readonly IWebHostEnvironment _webHostEnvironment;
    public LessonController(ILogger<LessonController> logger, IConfiguration config, IWebHostEnvironment webHostEnvironment, HelloBachakContext context)
    {
        // _userBusiness = new UserBusiness(new UserServiceE);
        _db = new UnitOfWork(context);
        _logger = logger;
        _lessonBusiness = new LessonBusiness(new lessonRepository(context));
        _config = config;
        _configRoot = new ConfigurationBuilder().AddUserSecrets<LessonController>().Build();
        _webHostEnvironment = webHostEnvironment;
    }

    [Route("GetAllLessons")]
    [HttpGet]
    public IEnumerable<LessonDto> GetAllLessons()
    {
        
        var result = _lessonBusiness.GetAllLessons();
        return result;
    }
}
