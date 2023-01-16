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

    public ChangePasswordDtoValidationResult ChangePassword(ChangePasswordDto changePasswordDto)
    {
        var ChangePasswordDtoValidator = new ChangePasswordDtoValidator(_userRepository.Find(changePasswordDto.UserId) , _userRepository.GetHashedUsersPasswords());
        ValidationResult result = ChangePasswordDtoValidator.Validate(changePasswordDto);
        var isValid = result.IsValid;
        var validationResult = new ChangePasswordDtoValidationResult(result);
        if (isValid){
             _userRepository.ChangeUserPassword(changePasswordDto.UserId , Helper.ComputeSHA256Hash(changePasswordDto.NewPassword));
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
}
