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
    public DutyDtoValidationResult CreateDuty(DutyDto dutyDto){
        var dutyDtoValidator = new DutyDtoValidator(_dutyRepository.GetLessonIds().ToList() , _dutyRepository.GetStudentIds().ToList() , _dutyRepository.GetConsultantIds().ToList() , _dutyRepository.GetDutyIds().ToList());
        ValidationResult result = dutyDtoValidator.Validate(dutyDto);
        var isValid = result.IsValid;
        var validationResult = new DutyDtoValidationResult(result);
        if (isValid){
            Entity.Models.Duty duty = new Entity.Models.Duty{
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
   

  
}
