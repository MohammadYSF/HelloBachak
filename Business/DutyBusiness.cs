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

public class DutyBusiness
{
    private readonly IDutyRepository _dutyRepository;
    public DutyBusiness(IDutyRepository dutyRepository)
    {
        _dutyRepository = dutyRepository;
    }
    public DutyDtoValidationResult CreateDuty(DutyDto dutyDto)
    {
        var dutyDtoValidator = new DutyDtoValidator(_dutyRepository.GetLessonIds().ToList(), _dutyRepository.GetStudentIds().ToList(), _dutyRepository.GetConsultantIds().ToList(), _dutyRepository.GetDutyIds().ToList());
        ValidationResult result = dutyDtoValidator.Validate(dutyDto);
        var isValid = result.IsValid;
        var validationResult = new DutyDtoValidationResult(result);
        if (isValid)
        {
            Entity.Models.Duty duty = new Entity.Models.Duty
            {
                Title = dutyDto.Title,
                Description = dutyDto.Description,
                ArrangedDate = dutyDto.ArrangedDate,
                CreationDate = DateTime.Now,
                ConsultantId = dutyDto.ConsultantId,
                StudentId = dutyDto.StudentId,
                LessonId = dutyDto.LessonId,
                IsActive = true,
                OlderDutyId = null

            };
            _dutyRepository.Create(duty);
            _dutyRepository.Save();
        }
        return validationResult;
    }

    public DutyReplyDtoValidationResult CreateDutyReply(DutyReplyDto dutyReplyDto)
    {
        var dutyReplyDtoValidator = new DutyReplyDtoValidator(_dutyRepository.GetDutyIds().ToList());
        ValidationResult result = dutyReplyDtoValidator.Validate(dutyReplyDto);
        var isValid = result.IsValid;
        var validationResult = new DutyReplyDtoValidationResult(result);
        if (isValid)
        {
            DutyReply dutyReply = new DutyReply()
            {
                DutyId = dutyReplyDto.DutyId,
                Description = dutyReplyDto.Description,
                CreationDate = DateTime.Now,
                IsSucceed = true
            };
            _dutyRepository.CreateDutyReply(dutyReply);
            _dutyRepository.Save();
        }
        return validationResult;

    }

    public List<DutyDto> GetAllDuties()
    {
        var answer = _dutyRepository.Get()
        .Select(b => new DutyDto
        {
            Id = b.Id,
            Title = b.Title,
            IsActive = b.IsActive,
            StudentTitle = b.Student.Username,
            ConsultantTitle = b.Consultant.Username,
            ArrangedDate = b.ArrangedDate,
            LessonTitle = b.Lesson.Title

        }).ToList();
        return answer;
    }
    public List<DutyDto> GetActiveDutiesByStudentId(int studentId)
    {
        var answer = _dutyRepository.Get().Where(a=> a.IsActive).Select(b => new DutyDto
        {
            Id = b.Id,
            Title = b.Title,
            ArrangedDate = b.ArrangedDate
        }).ToList();
        return answer;
    }
}
