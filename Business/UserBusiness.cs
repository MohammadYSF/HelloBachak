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
namespace Business;

public class UserBusiness
{
    private readonly IUserRepository _userRepository;
    public UserBusiness(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public RegisterUserDtoResult RegisterUser(RegisterUserDto userDto)
    {
        var userDtoValidator = new UserDtoValidator(_userRepository.GetUsersEmails(),
        _userRepository.GetHashedUsersPasswords(), _userRepository.GetSexIds(),
         _userRepository.GetGradeIds(), _userRepository.GetUsersUsernames());
        ValidationResult result = userDtoValidator.Validate(userDto);
        var isValid = result.IsValid;
        var validationResult = new RegisterUserDtoResult(result);
//         var configuration = new MapperConfiguration(cfg =>
//         {
//             cfg.CreateMap<RegisterUserDto, User>();
//         });
// #if DEBUG
//         configuration.AssertConfigurationIsValid();
// #endif
//         var mapper = configuration.CreateMapper();
        User user = new User{
            Age = userDto.Age,
            Email = userDto.Email,
            Password = Helper.ComputeSHA256Hash(userDto.Password),
            Username = userDto.Username,
            GradeId = userDto.GradeId,
            SexId = userDto.SexId,
            RoleId = _userRepository.FindRoleByTitle("student").Id,
            CreationDate = DateTime.Now
        };
        _userRepository.Create(user);
        _userRepository.Save();
        return validationResult;
    }
}
