using Entity.Models;
using DataAccess;
using DataAccess.Repositories;
using Dto.Models;
using FluentValidation;
using FluentValidation.Results;
using Business.Validation;
using AutoMapper;
using Business.Helpers;
using Business.Results;
using Microsoft.Extensions.Configuration;

namespace Business;

public class LessonBusiness
{
    private readonly ILessonRepository _lessonRepository;
    public LessonBusiness(ILessonRepository lessonRepository)
    {
        _lessonRepository = lessonRepository;
    }
    public List<LessonDto> GetAllLessons(){
        return _lessonRepository.Func_Report_Lesson().Select(a => new LessonDto
        {
            Id = a.Id,
            Title = a.Title
        }).ToList();
        
    }
   

  
}
