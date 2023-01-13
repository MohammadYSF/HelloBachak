using Entity.Models;
using DataAccess;
using DataAccess.Repositories;
using Dto.Models;
using FluentValidation;
using FluentValidation.Results;
using Business.Validation;
using AutoMapper;
using Business.Helpers;

namespace Business;
public class RegisterUserDtoResult
{
    public RegisterUserDtoResult(ValidationResult validationResult)
    {
        var validationFailures = validationResult.Errors;
        this.Success = validationResult.IsValid;
        if (!validationResult.IsValid)
        {

            this.Success = false;
            this.EmailErrorMessage = validationFailures.Find(a => a.PropertyName == "Email").ErrorMessage;
            this.PasswordErrorMessage = validationFailures.Find(a => a.PropertyName == "Password").ErrorMessage;
            this.UsernameErrorMessage = validationFailures.Find(a => a.PropertyName == "Username").ErrorMessage;
            this.SexIdErrorMessage = validationFailures.Find(a => a.PropertyName == "SexId").ErrorMessage;
            this.GradeIdErrorMessage = validationFailures.Find(a => a.PropertyName == "GradeId").ErrorMessage;
        }
    }
    public bool Success { get; set; }
    public string UsernameErrorMessage { get; set; }
    public string EmailErrorMessage { get; set; }
    public string PasswordErrorMessage { get; set; }
    public string SexIdErrorMessage { get; set; }
    public string GradeIdErrorMessage { get; set; }
}
public class UserBusiness
{
    private readonly IUserRepository _userRepository;
    public UserBusiness(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public RegisterUserDtoResult RegisterUser(RegisterUserDto userDto)
    {
        var userDtoValidator = new UserDtoValidator(null, null, null, null);
        ValidationResult result = userDtoValidator.Validate(userDto);
        var isValid = result.IsValid;
        var validationResult = new RegisterUserDtoResult(result);
        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<User , RegisterUserDto>();
        });
        #if DEBUG
        configuration.AssertConfigurationIsValid();
        #endif
        var mapper = configuration.CreateMapper();
        User user = mapper.Map<User>(userDto);
        user.CreationDate = DateTime.Now;
        user.Password = Helper.ComputeSHA256Hash(userDto.Password);
        _userRepository.Create(user);
        _userRepository.Save();
        return validationResult;
    }
}
