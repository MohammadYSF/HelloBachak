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
                GradeId = 21,
                Email = "ashk1@gmail.com"
            },
            false
            //because password is so simple or is repeated
        };
        yield return new object[]{
            new RegisterUserDto{
                Username="Askhan Mogadas",
                Password = "ashk*&^1234A",
                SexId = 1,
                Age=20,
                GradeId = 21,
                Email = "asdsa"
            },
            false
            //because email is not valid or repeated
        };
        yield return new object[]{
            new RegisterUserDto{
                Username="Askhan Mogadas",
                Password = "ashk*&^1234A",
                SexId = 1,
                Age=0,
                GradeId = 21,
                Email = "asdsa"
            },
            false
            //because age is not valid
        };
        yield return new object[]{
            new RegisterUserDto{
                Username="Askhan Mogadas",
                Password = "ashk*&^1234A",
                SexId = 1,
                Age=-10,
                GradeId = 21,
                Email = "asdsa"
            },
            false
            //because age is not valid
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
    private User _user = new User
    {
        Id = 1,
        Username = "Mohammad"
    };
    private User _updatedUser = new User{
        Id=1,
        Username="Asma"
    };
    private User _newUser = new User
    {
        Username = "Zahra"

    };
    private Mock<IUserRepository> _userRepositoryServiceMock;
    public BusinessTest()
    {
        var users = new List<User>();
        users.Add(new User
        {
            Id = 1,
            Username = "Mohammad"
        });
        users.Add(new User
        {
            Id = 2,
            Username = "Fateme"
        });
        _userRepositoryServiceMock = new Mock<IUserRepository>();
        _userRepositoryServiceMock.Setup(a => a.Get()).Returns(users.AsQueryable<User>);
        _userRepositoryServiceMock.Setup(a => a.Find(_user.Id)).Returns(_user);
        _userRepositoryServiceMock.Setup(a => a.Create(_newUser)).Returns("");
        _userRepositoryServiceMock.Setup(a => a.Update(_updatedUser)).Returns("");
        _userBusiness = new UserBusiness(_userRepositoryServiceMock.Object);
    }
    [Fact]
    public void Should_Register_Valid_User_Dto(){
        var userDto = new RegisterUserDto{
            Username = "Jamil",
            Age = 22,
            Email = "jamil@yahoo.com",
            Password="jamil1234@",
            SexId = 1,
            GradeId = 3,
        };
        var result = _userBusiness.RegisterUser(userDto);
        var expected = "";
        result.Should().Be(expected);

    }
    [Theory]
    [InlineData(new RegisterUserDto{
        Username = "Mohammad",
        Age=10,
        Email="aa.yosefiyan7@gmail.com",
        Password="1234",
        SexId=1,
        GradeId=4,
    })]
    public void Should_Not_Register_Invalid_User_Dto(RegisterUserDto dto){
        
    }   
}