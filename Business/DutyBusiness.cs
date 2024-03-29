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
using DataAccess.Services;
using Entity.Models.FunctionModels;

namespace Business;

public class DutyBusiness
{
    private readonly IDutyRepository _dutyRepository;
    private readonly IUserRepository _userRepository;
    public DutyBusiness(IDutyRepository dutyRepository , IUserRepository userRepository)
    {
        _userRepository = userRepository;
        _dutyRepository = dutyRepository;
    }
    public DutyDtoValidationResult CreateDuty(DutyDto dutyDto , ref int httpCode)
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
        else
            httpCode = 400;
        return validationResult;
    }

    public DutyReplyDtoValidationResult CreateDutyReply(DutyReplyDto dutyReplyDto , ref int httpCode)
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
        else
            httpCode = 400;
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
    public List<Func_Report_Student_Related_Duty> GetStudentRelatedDuties(int studentId , ref int httpCode)
    {
        var student = _userRepository.Find(studentId);
        if (student == null) {
            httpCode = 400;
            return null;
        }
        var data = _dutyRepository.Func_Report_Student_Related_Duty(studentId);
        return data.ToList();
    }
    
    public List<Func_Get_Previous_Duty> GetParentDuties(int dutyId , ref int httpCode)
    {
        var duty = _dutyRepository.Find(dutyId);
        if (duty == null)
        {
            httpCode = 400;
            return null;
        }
        var data = _dutyRepository.Func_Get_Previous_Duty(dutyId);
        return data.ToList();
    }
    public ShowDutyDetailResult ShowDutyDetail(int dutyId,int userId , string role , ref int httpCode)
    {
        bool success = true;
        string dutyIdErrorMessage = "";
        string userIdErrorMessage = "";

        var duty=_dutyRepository.Find(dutyId);
        if (duty == null)
        {
            success = false;
            httpCode = 400;
            dutyIdErrorMessage = "invalid-dutyid";
        }
        var user = _userRepository.Find(userId);
        if (user == null)
        {
            success = false;
            httpCode = 400;
            userIdErrorMessage = "invalid-userid";
        }
        if (success)
        {
            if (!((duty.StudentId == userId && role == "student") || (duty.ConsultantId == userId && role=="consultant")))
            {
                success = false;
                httpCode = 400;
                userIdErrorMessage = "no-access";
            }            
        }

        if (success)
        {
            var dto = new DutyDto
            {
                Id = duty.Id,
                Description = duty.Description,
                ArrangedDateString = Helper.ToPersianDateString(duty.ArrangedDate)
            };
            return new ShowDutyDetailResult(Language.Persian, true, "", "", dto);

        }
        else
            return new ShowDutyDetailResult(Language.Persian, false, dutyIdErrorMessage, userIdErrorMessage, null);


    }
}
