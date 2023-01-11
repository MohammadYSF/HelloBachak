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

namespace Test;
class RegisterUserDtoParameters : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]{
            new RegisterUserDto{
                Username="Askhan Mogadas",
                Password = "1234",
                SexId = 1,
                Age=20,
                GradeId = 1,
                Email = "ashk1@gmail.com"
            }
            //because password is so simple or is repeated
        };
        yield return new object[]{
            new RegisterUserDto{
                Username="Askhan Mogadas",
                Password = "ashk*&^1234A",
                SexId = 1,
                Age=20,
                GradeId = 1,
                Email = "asdsa"
            }
            //because email is not valid or repeated
        };
        yield return new object[]{
            new RegisterUserDto{
                Username="Askhan Mogadas",
                Password = "ashk*&^1234A",
                SexId = 1,
                Age=0,
                GradeId = 1,
                Email = "asdsa"
            }
            //because age is not valid
        };
        yield return new object[]{
            new RegisterUserDto{
                Username="Askhan Mogadas",
                Password = "ashk*&^1234A",
                SexId = 1,
                Age=-10,
                GradeId = 1,
                Email = "asdsa"
            }
            //because age is not valid
        };
        yield return new object[]{
            new RegisterUserDto{
                Username="Mohammad",
                Password = "ashk*&^1234A",
                SexId = 1,
                Age=20,
                GradeId = 1,
                Email = "aa.yosefiyan7@gmail.com"
            }
            //because username is not valid or it is repeadted
        };
        yield return new object[]{
            new RegisterUserDto{
                Username="darkArmy123",
                Password = "ashk*&^1234A",
                SexId = 100,
                Age=20,
                GradeId = 1,
                Email = "aa.yosefiyan7@gmail.com"
            }
            //because sex id is not valid
        };
        yield return new object[]{
            new RegisterUserDto{
                Username="darkArmy123",
                Password = "ashk*&^1234A",
                SexId = 1,
                Age=20,
                GradeId = 100,
                Email = "aa.yosefiyan7@gmail.com"
            }
            //because grade id is not valid
        };

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
            Password = "jamil1234@",
            SexId = 1,
            GradeId = 1,
        };
        var result = _userBusiness.RegisterUser(userDto);
        var expected = "";
        result.Should().Be(expected);

    }
    [Theory]
    [ClassData(typeof(RegisterUserDtoParameters))]
    public void Should_Not_Register_Invalid_User_Dto( RegisterUserDto dto)
    {
        var result = _userBusiness.RegisterUser(dto);
        var unExpected = "";
        result.Should().NotBe(unExpected);
        
    }
}