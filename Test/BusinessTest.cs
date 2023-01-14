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
                Username="Askhan Mogadas",
                Password = "1234",
                SexId = 1,
                Age=20,
                GradeId = 1,
                Email = "ashk1@gmail.com",
            }
            //because password is so simple
        };
        yield return new object[]{
            new RegisterUserDto{
                Username="Askhan Mogadas",
                Password = "Mm#12345",
                SexId = 1,
                Age=20,
                GradeId = 1,
                Email = "ashk1@gmail.com"
            }
            //because password is duplicate
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
                Username="AskhanMogadas",
                Password = "ashk*&^1234A",
                SexId = 1,
                Age=20,
                GradeId = 1,
                Email = "aa.yosefiyan7@gmail.com"
            }
            //because email is duplicate
        };
        yield return new object[]{
            new RegisterUserDto{
                Username="Askhan Mogadas",
                Password = "ashk*&^1234A",
                SexId = 1,
                Age=0,
                GradeId = 1,
                Email = "newaccout7@gmail.com"
            }
            //because age is not valid
        };
        yield return new object[]{
            new RegisterUserDto{
                Username="Askhan Mogadas",
                Password = "ashk*&^1234A",
                SexId = 1,
                Age=200,
                GradeId = 1,
                Email = "newaccout7@gmail.com"
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
                Email = "newaccout7@gmail.com"
            }
            //because age is not valid
        };
        yield return new object[]{
            new RegisterUserDto{
                Username="m",
                Password = "ashk*&^1234A",
                SexId = 1,
                Age=20,
                GradeId = 1,
                Email = "newaccout7@gmail.com"
            }
            //because username is not valid (because it is too short,it should be at least 3 character)
        };  
        yield return new object[]{
            new RegisterUserDto{
                Username="محمد",
                Password = "ashk*&^1234A",
                SexId = 1,
                Age=20,
                GradeId = 1,
                Email = "newaccout7@gmail.com"
            }
            //because username is not valid . because it is farsi
        };
        yield return new object[]{
            new RegisterUserDto{
                Username="mohyou",
                Password = "ashk*&^1234A",
                SexId = 1,
                Age=20,
                GradeId = 1,
                Email = "newaccout7@gmail.com"
            }
            //because username is not valid . because it is duplicate
        };  
        yield return new object[]{
            new RegisterUserDto{
                Username="darkArmy123",
                Password = "ashk*&^1234A",
                SexId = 100,
                Age=20,
                GradeId = 1,
                Email = "newaccout7@gmail.com"
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
                Email = "newaccout7@gmail.com"
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
        _userRepositoryServiceMock.Setup(a=> a.GetSexIds()).Returns(new List<int>(){1,2});
        _userRepositoryServiceMock.Setup(a=> a.GetGradeIds()).Returns(new List<int>() {1});
        _userRepositoryServiceMock.Setup(a=> a.GetRoleIds()).Returns(new List<int>(){1,2});
        _userRepositoryServiceMock.Setup(a=> a.FindRoleByTitle("student"))
        .Returns(new Role{
            Id = 2,
            Title="student",
            CreationDate =  new DateTime(2022,02,02)
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