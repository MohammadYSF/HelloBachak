using Xunit;
using Moq;
using System;
using Business;
using DataAccess.Repositories;
using DataAccess.Services;
using Entity.Models;
using FluentAssertions;
using Dto.Models;
using System.Collections;
using Business.Results;
namespace Test;
class RegisterUserDtoParameters : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        //suppose that we have on user in our data base like this : 
        /*
        {
            Username = "mohyou"
            Password="f0af0f555fe5e3d4f0f60415138deb7710fa9dd5058671c179cfbb4384139460" -> Mm#12345
            Email = "aa.yosefiyan7@gmail.com"
            PhoneNumber = 09924300159
            SexId = 1
            GradeId=1
        }



        */
        yield return new object[]{
            new RegisterUserDto{
                Username="AskhanMogadas",
                Password = "1234",
                SexId = 1,
                Age=20,
                GradeId = 1,
                Email = "ashk1@gmail.com",
                PhoneNumber = "09372898644"
            }
            //because password is so simple
        ,"invalid-password"};
        yield return new object[]{
            new RegisterUserDto{
                Username="AskhanMogadas",
                Password = "Mm#12345",
                SexId = 1,
                Age=20,
                GradeId = 1,
                Email = "ashk1@gmail.com",
                PhoneNumber = "09372898644"

            }
            //because password is duplicate
        ,"duplicate-password"};
        yield return new object[]{
            new RegisterUserDto{
                Username="AskhanMogadas",
                Password = "ashk*&^1234A",
                SexId = 1,
                Age=20,
                GradeId = 1,
                Email = "asdsa",
                PhoneNumber = "09372898644"

            }
            //because email is not valid
        ,"invalid-email"};
        yield return new object[]{
            new RegisterUserDto{
                Username="AskhanMogadas",
                Password = "ashk*&^1234A",
                SexId = 1,
                Age=20,
                GradeId = 1,
                Email = "aa.yosefiyan7@gmail.com",
                PhoneNumber = "09372898644"

            }
            //because email is duplicate
        ,"duplicate-email"};
        yield return new object[]{
            new RegisterUserDto{
                Username="AskhanMogadas",
                Password = "ashk*&^1234A",
                SexId = 1,
                Age=0,
                GradeId = 1,
                Email = "newaccout7@gmail.com",
                PhoneNumber = "09372898644"

            }
            //because age is not valid
        ,"invalid-age"};
        yield return new object[]{
            new RegisterUserDto{
                Username="AskhanMogadas",
                Password = "ashk*&^1234A",
                SexId = 1,
                Age=200,
                GradeId = 1,
                Email = "newaccout7@gmail.com",
                PhoneNumber = "09372898644"

            }
            //because age is not valid
        ,"invalid-age"};
        yield return new object[]{
            new RegisterUserDto{
                Username="AskhanMogadas",
                Password = "ashk*&^1234A",
                SexId = 1,
                Age=-10,
                GradeId = 1,
                Email = "newaccout7@gmail.com",
                PhoneNumber = "09372898644"

            }
            //because age is not valid
        ,"invalid-age"};
        yield return new object[]{
            new RegisterUserDto{
                Username="m",
                Password = "ashk*&^1234A",
                SexId = 1,
                Age=20,
                GradeId = 1,
                Email = "newaccout7@gmail.com",
                PhoneNumber = "09372898644"

            }
            //because username is not valid (because it is too short,it should be at least 3 character)
        ,"invalid-username"};
        yield return new object[]{
            new RegisterUserDto{
                Username="محمد",
                Password = "ashk*&^1234A",
                SexId = 1,
                Age=20,
                GradeId = 1,
                Email = "newaccout7@gmail.com",
                PhoneNumber = "09372898644"

            }
            //because username is not valid . because it is farsi
        ,"persian-username"};
        yield return new object[]{
            new RegisterUserDto{
                Username="mohyou",
                Password = "ashk*&^1234A",
                SexId = 1,
                Age=20,
                GradeId = 1,
                Email = "newaccout7@gmail.com",
                PhoneNumber = "09372898644"

            }
            //because username is not valid . because it is duplicate
        ,"duplicate-username"};
        yield return new object[]{
            new RegisterUserDto{
                Username="darkArmy123",
                Password = "ashk*&^1234A",
                SexId = 100,
                Age=20,
                GradeId = 1,
                Email = "newaccout7@gmail.com",
                PhoneNumber = "09372898644"

            }
            //because sex id is not valid
        ,"invalid-sexId"};
        yield return new object[]{
            new RegisterUserDto{
                Username="darkArmy123",
                Password = "ashk*&^1234A",
                SexId = 1,
                Age=20,
                GradeId = 100,
                Email = "newaccout7@gmail.com",
                PhoneNumber = "09372898644"

            }
            //because grade id is not valid
        ,"invalid-gradeId"};
        yield return new object[]{
            new RegisterUserDto{
                Username="darkArmy123",
                Password = "ashk*&^1234A",
                SexId = 1,
                Age=20,
                GradeId = 100,
                Email = "newaccout7@gmail.com",
                PhoneNumber = "0914245"

            }
            //because phone number is invalid
        ,"invalid-phoneNumber"};
        yield return new object[]{
            new RegisterUserDto{
                Username="darkArmy123",
                Password = "ashk*&^1234A",
                SexId = 1,
                Age=20,
                GradeId = 100,
                Email = "newaccout7@gmail.com",
                PhoneNumber = "09924300159"

            }
            //because phone number is duplicate
        ,"duplicate-phoneNumber"};

    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
public class BusinessTest
{
    private UserBusiness _userBusiness;
    private Sex _sex = new Sex
    {
        Id = 1,
        Title = "Male"
    };
    private Grade _grade = new Grade
    {
        Id = 1,
        Title = "12th"
    };
    private User _user = new User
    {
        Id = 1,
        Username = "Mohammad"
    };
    private User _updatedUser = new User
    {
        Id = 1,
        Username = "Asma"
    };
    private User _newUser = new User
    {
        Username = "Zahra"

    };

    private Mock<IUserRepository> _userRepositoryServiceMock;
    public BusinessTest()
    {
        var users = new List<User>(){
            new User
        {
            Id = 1,
            Username = "Mohammad"
        },
        new User
        {
            Id = 2,
            Username = "Fateme"
        }
        };


        _userRepositoryServiceMock = new Mock<IUserRepository>();
        _userRepositoryServiceMock.Setup(a => a.Get()).Returns(users.AsQueryable<User>);
        _userRepositoryServiceMock.Setup(a => a.Find(_user.Id)).Returns(_user);
        _userRepositoryServiceMock.Setup(a => a.Create(_newUser)).Returns("");
        _userRepositoryServiceMock.Setup(a => a.Update(_updatedUser)).Returns("");
        _userRepositoryServiceMock.Setup(a => a.FindSex(_sex.Id)).Returns(_sex);
        _userRepositoryServiceMock.Setup(a => a.FindGrade(_grade.Id)).Returns(_grade);
        _userRepositoryServiceMock.Setup(a => a.GetSexIds()).Returns(new List<int>() { 1, 2 });
        _userRepositoryServiceMock.Setup(a => a.GetGradeIds()).Returns(new List<int>() { 1 });
        _userRepositoryServiceMock.Setup(a => a.GetRoleIds()).Returns(new List<int>() { 1, 2 });
        _userRepositoryServiceMock.Setup(a => a.GetUsersEmails()).
        Returns(new List<string>() { "aa.yosefiyan7@gmail.com" });
        _userRepositoryServiceMock.Setup(a => a.GetHashedUsersPasswords()).
        Returns(new List<string>() { "f0af0f555fe5e3d4f0f60415138deb7710fa9dd5058671c179cfbb4384139460" });
        _userRepositoryServiceMock.Setup(a => a.GetUsersUsernames()).
        Returns(new List<string>() { "mohyou" });
        _userRepositoryServiceMock.Setup(a => a.GetUsersPhoneNumbers()).
        Returns(new List<string>() { "09924300159" });
        _userRepositoryServiceMock.Setup(a => a.FindRoleByTitle("student"))
        .Returns(new Role
        {
            Id = 2,
            Title = "student",
            CreationDate = new DateTime(2022, 02, 02)
        });
        _userBusiness = new UserBusiness(_userRepositoryServiceMock.Object);
    }
    [Fact]
    public void Should_Register_Valid_User_Dto()
    {
        var userDto = new RegisterUserDto
        {
            Username = "Jamil",
            Age = 22,
            Email = "jamil@yahoo.com",
            Password = "Jamil1234@",
            SexId = 1,
            GradeId = 1,
            PhoneNumber = "09372898644"
        };
        var result = _userBusiness.RegisterUser(userDto);

        result.Success.Should().BeTrue();

    }
    [Theory]
    [ClassData(typeof(RegisterUserDtoParameters))]
    public void Should_Not_Register_Invalid_User_Dto(RegisterUserDto dto, string reason)
    {
        var result = _userBusiness.RegisterUser(dto);
        // var unExpected = "";
        result.Success.Should().BeFalse();
        switch (reason)
        {
            case "invalid-password": result.PasswordErrorMessage.Should().Be(reason); break;
            case "duplicate-password": result.PasswordErrorMessage.Should().Be(reason); break;
            case "invalid-email": result.EmailErrorMessage.Should().Be(reason); break;
            case "duplicate-email": result.EmailErrorMessage.Should().Be(reason); break;
            case "invalid-username": result.UsernameErrorMessage.Should().Be(reason); break;
            case "duplicate-username": result.UsernameErrorMessage.Should().Be(reason); break;
            case "invalid-gradeId": result.GradeIdErrorMessage.Should().Be(reason); break;
            case "invalid-sexId": result.SexIdErrorMessage.Should().Be(reason); break;
            case "invalid-phoneNumber": result.PhoneNumberErrorMessage.Should().Be(reason); break;
            case "duplicate-phoneNumber": result.PhoneNumberErrorMessage.Should().Be(reason); break;


        }

    }
}