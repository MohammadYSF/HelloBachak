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
    public List<LessonDto> GetAllLessons()
    {
        return _lessonRepository.Func_Report_Lesson().Select(a => new LessonDto
        {
            Id = a.Id,
            Title = a.Title
        }).ToList();

    }
    public UpdateLessonResult UpdateLesson(LessonDto dto, ref int httpCode)
    {
        bool success = true;
        string result = "";
        string lessonIdErrorMessage = "";
        string lessonTitleErrorMessage = "";
        Lesson lesson = _lessonRepository.Find(dto.Id);
        if (lesson == null)
        {
            success = false;
            httpCode = 400;
            lessonIdErrorMessage = "invalid-lessonId";
        }
        if (dto.Title.Length > 50)
        {
            success = false;
            httpCode = 400;
            lessonTitleErrorMessage = "invalid-title";
        }
        if (success)
        {
            lesson.Title = dto.Title;
            result = _lessonRepository.Update(lesson);
            _lessonRepository.Save();
            return new UpdateLessonResult(Language.Persian, true);
        }
        else
        {
            return new UpdateLessonResult(Language.Persian, success, lessonIdErrorMessage, lessonTitleErrorMessage);
        }
    }

    public FindLessonResult FindLesson(int lessonId, ref int httpCode)
    {
        string lessonIdErrorMessage = "";
        LessonDto result = null;
        bool success = true;
        var lesson = _lessonRepository.Find(lessonId);
        if (lesson == null)
        {
            httpCode = 400;
            success = false;
            lessonIdErrorMessage = "invalid-lessonid";
        }
        else
        {
            result = new LessonDto
            {
                Id = lesson.Id,
                Title = lesson.Title
            };
        }
        return new FindLessonResult(Language.Persian, success, lessonIdErrorMessage, result);


    }


}
