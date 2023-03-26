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
using Microsoft.EntityFrameworkCore;

namespace Business;

public class UserBusiness
{
    private readonly IUserRepository _userRepository;
    public UserBusiness(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public ChangePasswordDtoValidationResult ChangePassword(ChangePasswordDto changePasswordDto)
    {
        var ChangePasswordDtoValidator = new ChangePasswordDtoValidator(_userRepository.Find(changePasswordDto.UserId), _userRepository.GetHashedUsersPasswords());
        ValidationResult result = ChangePasswordDtoValidator.Validate(changePasswordDto);
        var isValid = result.IsValid;
        var validationResult = new ChangePasswordDtoValidationResult(result);
        if (isValid)
        {
            _userRepository.ChangeUserPassword(changePasswordDto.UserId, Helper.ComputeSHA256Hash(changePasswordDto.NewPassword));
            _userRepository.Save();
        }
        return validationResult;
    }

    public RegisterUserDtoValidationResult RegisterUser(RegisterUserDto userDto)
    {
        var userDtoValidator = new UserDtoValidator(_userRepository.GetUsersEmails(),
        _userRepository.GetHashedUsersPasswords(), _userRepository.GetSexIds(),
         _userRepository.GetGradeIds(), _userRepository.GetUsersUsernames()
         , _userRepository.GetUsersPhoneNumbers());
        ValidationResult result = userDtoValidator.Validate(userDto);
        var isValid = result.IsValid;
        var validationResult = new RegisterUserDtoValidationResult(result);
        if (isValid)
        {
            User user = new User
            {
                Age = userDto.Age,
                Email = userDto.Email,
                Password = Helper.ComputeSHA256Hash(userDto.Password),
                Username = userDto.Username,
                GradeId = userDto.GradeId,
                SexId = userDto.SexId,
                RoleId = _userRepository.FindRoleByTitle("student").Id,
                CreationDate = DateTime.Now,
                PhoneNumber = userDto.PhoneNumber,
                IsActive = false
            };
            _userRepository.Create(user);
            _userRepository.Save();
        }
        return validationResult;

    }
    public List<UserDto> GetAllStudents()
    {

        var answer = _userRepository.GetAllStudents()
        .Select(b => new UserDto
        {
            Id = b.Id,
            Username = b.Username
        }).ToList();
        return answer;
    }
    public SendActivationCodeDtoValidationResult SendActivationCode(SendActivationCodeDto sendActivationCodeDto, IConfiguration config, string baseUrl, string redirectedLink)
    {
        var sendActivationCodeDtoValidator = new SendActivationCodeDtoValidator(_userRepository.GetUsersEmails());
        string email = sendActivationCodeDto.Email;
        ValidationResult result = sendActivationCodeDtoValidator.Validate(sendActivationCodeDto);
        var isValid = result.IsValid;
        var validationResult = new SendActivationCodeDtoValidationResult(result);
        if (isValid)
        {
            User user = _userRepository.FindUserByEmail(email);
            var g = Guid.NewGuid().ToString();
            user.ActivationCode = g;
            _userRepository.Update(user);
            _userRepository.Save();
            //send email code
            var emailMessage = $"<h1>Activating Hello Bachak acount</h1><p> Just click the link below</p><a href=\"{baseUrl}/{redirectedLink}/{g}\">click here</a>";
            Helper.SendEmail(config, email, emailMessage);
        }
        return validationResult;
    }
    public SingleStudentDetailDto GetStudentDetail(int userId)
    {
        var result = _userRepository.Find(userId);
        var gradeTitle = _userRepository.FindGrade(result.GradeId).Title;
        var sexTitle = _userRepository.FindSex(result.SexId).Title;
        if (result == null)
            return null;
        var answer = new SingleStudentDetailDto
        {
            Id = result.Id,
            Description = result.Description,
            Email = result.Email,
            GradeTitle = gradeTitle,
            PhoneNumber = result.PhoneNumber,
            SexTitle = sexTitle,
            Username = result.Username,
            RegisterDateString = Helper.ToPersianDateString(result.CreationDate)
        };
        return answer;

    }
}
