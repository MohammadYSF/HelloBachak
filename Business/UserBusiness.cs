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
using System.Security.Claims;
using Business.Auth;
using Business.Helpers.EmailService;
using System.Net.Mail;
using Entity.Models.FunctionModels;

namespace Business;

public class UserBusiness
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;
    public UserBusiness(IUserRepository userRepository, ITokenService tokenService)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
    }

    public ChangePasswordDtoValidationResult ChangePassword(ChangePasswordDto changePasswordDto, ref int httpCode)
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
        else
            httpCode = 400;
        return validationResult;
    }
    public Tuple<LoginUserDtoValidationResult, string, string , string> LoginUser(LoginUserDto loginUserDto, ref int httpCode)
    {
        string token = "", refreshToken = "",username ="";
        var loginUserDtoValidator = new LoginUserDtoValidator(_userRepository.Get());
        ValidationResult result = loginUserDtoValidator.Validate(loginUserDto);
        var validationResult = new LoginUserDtoValidationResult(result);
        var isValid = result.IsValid;
        if (isValid)
        {
            var user = _userRepository.FindUserByEmail(loginUserDto.Email);
            var roles = _userRepository.GetRolesByUserId(user.Id);

            var claims = new[]
            {
        new Claim(ClaimTypes.Name, user.Username),
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(ClaimTypes.Role, string.Join(',',roles.Select(a=> a.Title)))
            };
            username = user.Username;
            token = _tokenService.GenerateAccessToken(claims);
            refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;

            _userRepository.Update(user);
            _userRepository.Save();

        }
        else
            httpCode = 400;
        return new Tuple<LoginUserDtoValidationResult, string, string, string>(validationResult, token, refreshToken , username);

    }
    public RegisterUserDtoValidationResult RegisterUser(RegisterUserDto userDto, ref int httpCode)
    {
        var userDtoValidator = new UserDtoValidator(_userRepository.GetUsersEmails(),
        _userRepository.GetHashedUsersPasswords(), _userRepository.GetSexIds(),
         _userRepository.GetGradeIds(), _userRepository.GetUsersUsernames()
         , _userRepository.GetUsersPhoneNumbers());
        ValidationResult result = userDtoValidator.Validate(userDto);
        var isValid = result.IsValid;
        var validationResult = new RegisterUserDtoValidationResult(result);
        var roleIdStudent = _userRepository.FindRoleByTitle("student").Id;
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
                CreationDate = DateTime.Now,
                PhoneNumber = userDto.PhoneNumber,
                IsActive = false,

            };
            UserRole userRole = new UserRole
            {
                RoleId = roleIdStudent,
                User = user

            };
            _userRepository.CreateUserRole(userRole);
            _userRepository.Save();
        }
        else
            httpCode = 400;
        return validationResult;

    }
    public List<Func_Report_Manage_Student> GetAllStudents()
    {
        var answer = _userRepository.Func_Report_ManageStudent().ToList();
        return answer;
    }
    public SendActivationCodeDtoValidationResult SendActivationCode(SendActivationCodeDto sendActivationCodeDto, IEmailService emailService, IConfiguration config, string baseUrl, string redirectedLink, ref int httpCode)
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
            var mailMessage = new MailMessage
            {
                Subject = "Hello Bachak activation code",
                Body = emailMessage,
                IsBodyHtml = true
            };
            emailService.Send(mailMessage, email);
        }
        else
            httpCode = 400;
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
    public List<Func_Report_Related_Student> GetConsultantRelatedStudents(int consultantId, ref int httpCode)
    {
        var consultant = _userRepository.Find(consultantId);
        if (consultant == null)
        {
            httpCode = 400;
            return null;
        }
        var data = _userRepository.Func_Report_Related_Students(consultantId);
        return data.ToList();
    }
    public ChangeConsultantResult ChangeConsultant(int studentId, int newConsultantId, ref int httpCode)
    {
        bool success = true;
        ChangeConsultantResult result;
        string studentIdError = "";
        string consultantIdError = "";
        var student = _userRepository.Find(studentId);
        if (student == null)
        {
            success = false;
            httpCode = 400;
            studentIdError = "invalid-studentId";
            result = new ChangeConsultantResult(Language.Persian, false, studentIdError, consultantIdError);

        }
        var newConsultant = _userRepository.Find(newConsultantId);
        if (newConsultant == null)
        {
            success = false;
            httpCode = 400;
            consultantIdError = "invalid-consultantid";
            result = new ChangeConsultantResult(Language.Persian, false, studentIdError, consultantIdError);

        }
        if (success)
        {
            student.ConsultantId = newConsultantId;
            _userRepository.Update(student);
            _userRepository.Save();
            result = new ChangeConsultantResult(Language.Persian, true);
        }
        else
        {
            result = new ChangeConsultantResult(Language.Persian,false, studentIdError, consultantIdError);
        }
        return result;
    }

}
