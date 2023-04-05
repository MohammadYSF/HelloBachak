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
using Business.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration.Memory;
using Business.Auth;
using Microsoft.Extensions.Options;
using Business.Helpers.EmailService;
using Entity.Models.FunctionModels;
using System.Linq.Expressions;
using AutoMapper.Configuration.Annotations;
using FluentAssertions.Execution;

namespace Test;
class DutyDtoParameters : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]{
        new DutyDto{
            Title= "Lorem ipsum dolor sit amet consectetur adipiscing elit, nullam penatibus magnis aliquet curabitur nisl etiam, orci placerat facilisis ultricies ultrices pharetra est, senectus tincidunt nulla pulvinar per venenatis. Ut pretium litora enim dictum nunc porta rhoncus, lobortis congue metus dignissim aptent diam blandit, egestas nibh conubia auctor neque nam. Velit integer faucibus gravida in interdum dis ornare, eleifend condimentum cum vel fermentum elementum, dui himenaeos ante euismod fringilla ad. Maecenas sapien lacus ac eget mollis class laoreet mattis, nostra eu convallis platea ridiculus ligula sollicitudin, molestie primis taciti quis vehicula torquent nisi. Tristique duis imperdiet parturient quam, sagittis urna hac."
            ,StudentId = 2,
            ConsultantId=1,
            ArrangedDate = DateTime.Now,
            LessonId = 1,
            OlderDutyId = null
        },"invalid-title"
       };
        yield return new object[]{
        new DutyDto{
            Title = "Hello",
            StudentId = 100,
            ConsultantId = 1,
            ArrangedDate = DateTime.Now,
            LessonId = 1,
            OlderDutyId = null
        },"invalid-studentId"
       };
        yield return new object[]{
        new DutyDto{
            Title = "Hello",
            StudentId = 2,
            ConsultantId = 100,
            ArrangedDate = DateTime.Now,
            LessonId = 1,
            OlderDutyId = null
        },"invalid-consultantId"
       };
        yield return new object[]{
        new DutyDto{
            Title = "Hello",
            StudentId = 2,
            ConsultantId = 1,
            ArrangedDate = DateTime.Now,
            LessonId = 1000,
            OlderDutyId = null
        },"invalid-lessonId"
       };
        yield return new object[]{
        new DutyDto{
            Title = "Hello",
            StudentId = 2,
            ConsultantId = 1,
            ArrangedDate = DateTime.Now,
            LessonId = 1,
            OlderDutyId = 1000
        },"invalid-olderDutyId"
       };
        yield return new object[]{
        new DutyDto{
            Title = "Hello",
            StudentId = 2,
            ConsultantId = 1,
            ArrangedDate = default(DateTime),
            LessonId = 1,
            OlderDutyId = 1000
        },"invalid-arrangedDate"
       };

    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
class SendActivationCodeDtoParameters : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {

        yield return new object[]{
            new SendActivationCodeDto{
                Email = "asdaf"
            },"invalid-email"
        };
        yield return new object[]{
            new SendActivationCodeDto{
                Email = "SomeValidEmailThatDoesNotExist@gmail.com"
            },"not-found-email"
        };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
class ChangePasswordDtoParameters : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        //suppose that we have a user like this : 
        /*{
            id = 1
            Username = "mohyou"
            Password="f0af0f555fe5e3d4f0f60415138deb7710fa9dd5058671c179cfbb4384139460" -> Mm#12345
            Email = "aa.yosefiyan7@gmail.com"
            PhoneNumber = 09924300159
            SexId = 1
            GradeId=1
        }*/
        yield return new object[]{
            new ChangePasswordDto{
                UserId = 10,
                CurrentPassword="Mm#12345",
                NewPassword="8723Mmmfas@"
            } , "invalid-userId"
        };
        yield return new object[]{
            new ChangePasswordDto{
                UserId = 1,
                CurrentPassword = "Mfasfg462@",
                NewPassword = "98Uufas@#$"
            } , "invalid-currentPassword"
        };
        yield return new object[]{
            new ChangePasswordDto{
                UserId = 1,
                CurrentPassword = "Mm#12345",
                NewPassword = "1234"
            },"invalid-newPassword"
        };
        yield return new object[]{
            new ChangePasswordDto{
                UserId = 1,
                CurrentPassword = "Mm#12345",
                NewPassword = "Ff123**ff"
            } , "duplicate-newPassword"
        };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
class RegisterUserDtoParameters : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        //suppose that we have on user in our data base like this : 
        /*
        {
            id = 1
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
class LoginUserDtoParameters : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new LoginUserDto
            {
                Email = "aa.yosefiyan7@gmail.com",
                Password = "wrong password"
            },"wrong-password"
        };
        yield return new object[]
        {
            new LoginUserDto
            {
                Email = "notexisitingemail@gmail.com",
                Password = "Whateverpassword"
            },"notexist-email"
        };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}

class DutyReplyDtoParameters : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
           new DutyReplyDto
           {
               DutyId = 10000

           }
       ,"invalid-dutyId"};

    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}


public class BusinessTest
{
    private LessonBusiness _lessonBusiness;
    private UserBusiness _userBusiness;
    private DutyBusiness _dutyBusiness;
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
        Username = "Mohammad",
        Password = "f0af0f555fe5e3d4f0f60415138deb7710fa9dd5058671c179cfbb4384139460",
        Email = "aa.yosefiyan7@gmail.com"
        //,RoleId= 1
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
    private Lesson _newLesson = new Lesson
    {
        Title = "lesson new"
    };
    private Lesson _updatedLesson = new Lesson
    {
        Id = 1,
        Title = "updated lesson 1"
        //CreationDate = DateTime.Now,
    };
    private List<DutyDto> _duties = new List<DutyDto>{
        new DutyDto{
            Id = 1,
        Title = "duty 1",
        ArrangedDate = DateTime.Today,
        IsActive = true,
        LessonTitle = "title lesson 1",
        StudentTitle = "Fateme",
        ConsultantTitle = "Mohammad",
        StudentId = 3,
        ConsultantId = 2

        },
        new DutyDto
        {
                Id = 2,
        Title = "continue duty 1",
        ArrangedDate = DateTime.Today,
        IsActive = true,
        LessonTitle = "title lesson 1",
        StudentTitle = "Fateme",
        ConsultantTitle = "Mohammad",
        StudentId = 3,
        ConsultantId = 2,
        OlderDutyId = 1

        }
    };
    private List<Lesson> _lessons = new List<Lesson>{
            new Lesson{
                Id = 1,
                Title = "lesson 1"
            }
        };
    private Entity.Models.Duty _newDuty = new Entity.Models.Duty()
    {
        Title = "new duty",
        Description = "some des for the new duty",
        ArrangedDate = DateTime.Today,
        CreationDate = DateTime.Now,
        ConsultantId = 1,
        StudentId = 1,
        OlderDutyId = null,
        IsActive = true,
        LessonId = 1
    };
    private Entity.Models.Duty _updatedDuty = new Entity.Models.Duty
    {
        Id = 1,
        Title = "updated duty",
        Description = "some des for updated duty",
        ArrangedDate = DateTime.Today,
        CreationDate = DateTime.Now,
        ConsultantId = 1,
        StudentId = 1,
        OlderDutyId = null,
        IsActive = true,
        LessonId = 1
    };
    private List<UserRole> _userRoles = new List<UserRole>()
    {
        new UserRole
        {
            Id = 1,
            RoleId = 1,
            UserId = 1
        },
        new UserRole
        {
            Id = 2,
            RoleId = 2,
            UserId = 2
        },

    };
    private List<User> _users = new List<User>(){
            new User
        {
            Id = 1,
            Username = "Mohammad",
            Password = "f0af0f555fe5e3d4f0f60415138deb7710fa9dd5058671c179cfbb4384139460",
            //RoleId = 1,
            Email ="aa.yosefiyan7@gmail.com"


        },
        new User
        {
            Id = 2,
            Username = "Fateme",
            Password = "27a29d2f7061c41cb255e141dc2636bbd8f810fdbd16d8d654c66c11811c9c77",
            //RoleId = 2,
            Age = 16,
            GradeId = 1,
            CreationDate = DateTime.Now,
            Description = "توضیحات",
            Email = "testemail@gmail.com",
            PhoneNumber = "09985434455",
            SexId = 1         
            //Ff123**ff
        },
        new User
        {
            Id = 3,
            Username = "MaryamJahan**123",
            Password="e9ea449842656e5557783455c439cd718883cdb256a08f4ae0ca529d23d4ab4e",
            ConsultantId = 2
        }


        };
    private List<Role> _roles = new List<Role>{
            new Role{
                Id = 1,
                Title = "consultant"
            },
            new Role{
                Id = 2,
                Title = "student"
            }
        };
    private IConfigurationRoot _configRoot;
    private Mock<IUserRepository> _userRepositoryServiceMock;
    private Mock<IDutyRepository> _dutyRepositoryServiceMock;
    private Mock<ILessonRepository> _lessonRepositoryServiceMock;
    private Mock<ITokenService> _tokenServiceMock;
    public BusinessTest()
    {
        _configRoot = new ConfigurationBuilder().AddUserSecrets<BusinessTest>().Build();


        var duties = new List<Entity.Models.Duty>{
            new Entity.Models.Duty{
                Id = 1,
                Title = "duty number 1",
                Description = "some des",
                ArrangedDate = DateTime.Today,
                CreationDate = DateTime.Now,
                ConsultantId = 1,
                StudentId = 1,
                OlderDutyId = null,
                IsActive = true,
                LessonId = 1
            },
            new Duty{
                Id =2,
                Title ="continue duty 1",
                StudentId = 3,
                OlderDutyId = 1
            }
        };

        _lessonRepositoryServiceMock = new Mock<ILessonRepository>();
        _lessonRepositoryServiceMock.Setup(a => a.Get()).Returns(_lessons.AsQueryable());
        _lessonRepositoryServiceMock.Setup(a => a.Func_Report_Lesson()).Returns(_lessons.Select(b => new Func_Report_Lesson { Id = b.Id, Title = b.Title }).AsQueryable());
        _lessonRepositoryServiceMock.Setup(a => a.Create(_newLesson)).Returns("");
        _lessonRepositoryServiceMock.Setup(a => a.Find(_lessons[0].Id)).Returns(_lessons[0]);
        //_lessonRepositoryServiceMock.Setup(a => a.Update(_updatedLesson)).Returns("");
        _lessonRepositoryServiceMock.Setup(a => a.Update(It.IsAny<Lesson>())).Returns("");
        _dutyRepositoryServiceMock = new Mock<IDutyRepository>();
        _dutyRepositoryServiceMock.Setup(a => a.GetLessonIds()).Returns(_lessons.Select(e => e.Id).AsQueryable());
        _dutyRepositoryServiceMock.Setup(a => a.GetStudentIds()).Returns(_userRoles.Where(a => a.RoleId == 2).Select(a => a.UserId).Distinct().AsQueryable());
        _dutyRepositoryServiceMock.Setup(a => a.GetConsultantIds()).Returns(_userRoles.Where(a => a.RoleId == 1).Select(a => a.UserId).Distinct().AsQueryable());
        _dutyRepositoryServiceMock.Setup(a => a.Get()).Returns(duties.AsQueryable());
        _dutyRepositoryServiceMock.Setup(a => a.Find(duties[0].Id)).Returns(duties[0]);
        _dutyRepositoryServiceMock.Setup(a => a.Find(duties[1].Id)).Returns(duties[1]);
        _dutyRepositoryServiceMock.Setup(a => a.Create(_newDuty)).Returns("");
        _dutyRepositoryServiceMock.Setup(a => a.Update(_updatedDuty)).Returns("");
        _dutyRepositoryServiceMock.Setup(a => a.GetDutyIds()).Returns(new List<int>() { 1 }.AsQueryable<int>());
        _dutyRepositoryServiceMock.Setup(a => a.Func_Report_Student_Related_Duty(_duties[0].StudentId)).Returns(_duties.Where(a => a.StudentId == _duties[0].StudentId).Select(a => new Func_Report_Student_Related_Duty { Id = a.Id, Title = a.Title }).AsQueryable());
        _dutyRepositoryServiceMock.Setup(a => a.Func_Get_Previous_Duty(_duties[0].Id)).Returns(_duties.Where(a => a.OlderDutyId == _duties[0].Id).Select(a => new Func_Get_Previous_Duty { Id = a.Id, OlderDutyId = a.Id, Title = a.Title }).AsQueryable());

        _userRepositoryServiceMock = new Mock<IUserRepository>();
        _userRepositoryServiceMock.Setup(a => a.Get()).Returns(_users.AsQueryable<User>);
        _userRepositoryServiceMock.Setup(a => a.Find(_user.Id)).Returns(_user);
        _userRepositoryServiceMock.Setup(a => a.Find(_users[1].Id)).Returns(_users[1]);
        _userRepositoryServiceMock.Setup(a => a.Find(_users[2].Id)).Returns(_users[2]);
        _userRepositoryServiceMock.Setup(a => a.FindUserByUsername(_user.Username)).Returns(_user);
        _userRepositoryServiceMock.Setup(a => a.Create(_newUser)).Returns("");
        _userRepositoryServiceMock.Setup(a => a.Update(_updatedUser)).Returns("");
        _userRepositoryServiceMock.Setup(a => a.Update(_users[2])).Returns("");
        _userRepositoryServiceMock.Setup(a => a.FindSex(_sex.Id)).Returns(_sex);
        _userRepositoryServiceMock.Setup(a => a.FindGrade(_grade.Id)).Returns(_grade);
        _userRepositoryServiceMock.Setup(a => a.GetSexIds()).Returns(new List<int>() { 1, 2 });
        _userRepositoryServiceMock.Setup(a => a.GetGradeIds()).Returns(new List<int>() { 1 });
        _userRepositoryServiceMock.Setup(a => a.GetRoleIds()).Returns(new List<int>() { 1, 2 });
        _userRepositoryServiceMock.Setup(a => a.GetUsersEmails()).
        Returns(new List<string>() { "aa.yosefiyan7@gmail.com", "f.yosefiyan7@gmail.com" });
        _userRepositoryServiceMock.Setup(a => a.GetHashedUsersPasswords()).
        Returns(new List<string>() { "f0af0f555fe5e3d4f0f60415138deb7710fa9dd5058671c179cfbb4384139460",
        "27a29d2f7061c41cb255e141dc2636bbd8f810fdbd16d8d654c66c11811c9c77" });
        _userRepositoryServiceMock.Setup(a => a.GetUsersUsernames()).
        Returns(new List<string>() { "mohyou", "fateme" });
        _userRepositoryServiceMock.Setup(a => a.GetUsersPhoneNumbers()).
        Returns(new List<string>() { "09924300159", "09148026935" });
        _userRepositoryServiceMock.Setup(a => a.FindRoleByTitle("student"))
        .Returns(new Role
        {
            Id = 2,
            Title = "student",
            CreationDate = new DateTime(2022, 02, 02)
        });

        _userRepositoryServiceMock.Setup(a => a.ChangeUserPassword(_user.Id, Helper.ComputeSHA256Hash("Mrx*77798")))
        .Returns("");

        _userRepositoryServiceMock.Setup(a => a.FindUserByEmail(_user.Email)).Returns(_user);
        _userRepositoryServiceMock.Setup(a => a.FindRole(_roles[1].Id)).Returns(_roles[1]);
        _userRepositoryServiceMock.Setup(a => a.FindRole(_roles[0].Id)).Returns(_roles[0]);
        _userRepositoryServiceMock.Setup(a => a.GetAllStudents()).Returns(new List<User>{   new User
        {
            Id = 2,
            Username = "Fateme",
            Password = "27a29d2f7061c41cb255e141dc2636bbd8f810fdbd16d8d654c66c11811c9c77"
            //,RoleId = 2
            //Ff123**ff
        }}.AsQueryable());
        _userRepositoryServiceMock.Setup(a => a.Func_Report_ManageStudent()).Returns(new List<Func_Report_Manage_Student>{   new Func_Report_Manage_Student
        {
            Id = 2,
            Username = "Fateme",
            //Age = 1,
            
            //Password = "27a29d2f7061c41cb255e141dc2636bbd8f810fdbd16d8d654c66c11811c9c77"
            //,RoleId = 2
            //Ff123**ff
        }}.AsQueryable());

        _tokenServiceMock = new Mock<ITokenService>();
        JwtSettings jwtSettings = new JwtSettings();
        jwtSettings.Audience = "http://localhost:7243/api/";
        jwtSettings.AccessTokenDurationInMinutes = 1;
        jwtSettings.Issuer = "http://localhost:7243/api/";
        jwtSettings.Key = "0123456789ABCDEF";

        var options = Options.Create(jwtSettings);
        _userBusiness = new UserBusiness(_userRepositoryServiceMock.Object, new TokenService(options));
        _dutyBusiness = new DutyBusiness(_dutyRepositoryServiceMock.Object, _userRepositoryServiceMock.Object);
        _lessonBusiness = new LessonBusiness(_lessonRepositoryServiceMock.Object);

        _dutyRepositoryServiceMock.Setup(a => a.Get()).Returns(new List<Duty>{new Duty{
            Id = 1,
            Title = "duty 1",
            Student =new User{
                Id=1,
                Username="Fateme"
            },
            Consultant = new User{
                Id=2,
                Username="Mohammad"
            },
            ArrangedDate=DateTime.Today,
            IsActive=true,
            Lesson = new Lesson{
                Id=1,
                Title = "title lesson 1"
            }


        }}.AsQueryable());
    }
    [Fact]
    public void Should_Login_User_Dto()
    {
        var loginUserDto = new LoginUserDto
        {
            Email = "aa.yosefiyan7@gmail.com",
            Password = "Mm#12345"
        };
        int testHttpCode = 200;
        var result = _userBusiness.LoginUser(loginUserDto, ref testHttpCode);
        result.Item1.Success.Should().BeTrue();
    }
    [Theory]
    [ClassData(typeof(LoginUserDtoParameters))]
    public void Should_Not_Login_Invalid_User_Dto(LoginUserDto dto, string reason)
    {
        int testHttpCode = 200;

        var result = _userBusiness.LoginUser(dto, ref testHttpCode);
        // var unExpected = "";
        result.Item1.Success.Should().BeFalse();
        switch (reason)
        {
            case "wrong-password": result.Item1.PasswordErrorMessages.Should().Contain(reason); break;
            case "notexist-email": result.Item1.EmailErrorMessages.Should().Contain(reason); break;
        }
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
        int testHttpCode = 200;

        var result = _userBusiness.RegisterUser(userDto, ref testHttpCode);

        result.Success.Should().BeTrue();

    }
    [Theory]
    [ClassData(typeof(RegisterUserDtoParameters))]
    public void Should_Not_Register_Invalid_User_Dto(RegisterUserDto dto, string reason)
    {
        int testHttpCode = 200;

        var result = _userBusiness.RegisterUser(dto, ref testHttpCode);
        // var unExpected = "";
        result.Success.Should().BeFalse();
        switch (reason)
        {
            case "invalid-password": result.PasswordErrorMessages.Should().Contain(reason); break;
            case "duplicate-password": result.PasswordErrorMessages.Should().Contain(reason); break;
            case "invalid-email": result.EmailErrorMessages.Should().Contain(reason); break;
            case "duplicate-email": result.EmailErrorMessages.Should().Contain(reason); break;
            case "invalid-username": result.UsernameErrorMessages.Should().Contain(reason); break;
            case "duplicate-username": result.UsernameErrorMessages.Should().Contain(reason); break;
            case "invalid-gradeId": result.GradeIdErrorMessages.Should().Contain(reason); break;
            case "invalid-sexId": result.SexIdErrorMessages.Should().Contain(reason); break;
            case "invalid-phoneNumber": result.PhoneNumberErrorMessages.Should().Contain(reason); break;
            case "duplicate-phoneNumber": result.PhoneNumberErrorMessages.Should().Contain(reason); break;


        }

    }
    [Fact]
    public void Should_Change_Password()
    {
        int testHttpCode = 200;

        var correct_input = new ChangePasswordDto
        {
            UserId = 1,
            CurrentPassword = "Mm#12345",
            NewPassword = "Mrx*77798"
        };
        var result = _userBusiness.ChangePassword(correct_input, ref testHttpCode);
        result.Success.Should().BeTrue();
    }
    [Theory]
    [ClassData(typeof(ChangePasswordDtoParameters))]
    public void Shoud_Not_Change_Password(ChangePasswordDto dto, string reason)
    {
        int testHttpCode = 200;

        var result = _userBusiness.ChangePassword(dto, ref testHttpCode);
        result.Success.Should().BeFalse();
        switch (reason)
        {
            case "invalid-userId": result.UserIdErrorMessages.Should().Contain(reason); break;
            case "invalid-currentPassword": result.CurrentPasswordErrorMessages.Should().Contain(reason); break;
            case "invalid-newPassword": result.NewPasswordErrorMessages.Should().Contain(reason); break;
            case "duplicate-newPassword": result.NewPasswordErrorMessages.Should().Contain(reason); break;
        }
    }
    [Fact]
    public void Shoud_Send_Activation_Code()
    {
        var testHttpCode = 200;
        var correct_input = new SendActivationCodeDto
        {
            Email = "aa.yosefiyan7@gmail.com"
        };
        var inMemorySettings = new Dictionary<string, string> {
            {"Smtp:Host", _configRoot.GetSection("Smtp").GetSection("Host").Value},
            {"Smtp:Port", _configRoot.GetSection("Smtp").GetSection("Port").Value},
            {"Smtp:Username", _configRoot.GetSection("Smtp").GetSection("Username").Value},
            {"Smtp:Password", _configRoot.GetSection("Smtp").GetSection("Password").Value},
            {"JWTSettings:Key","0123456789ABCDEF" },
            {"JWTSettings:Issuer","http://localhost:7243/api/" },
            {"JWTSettings:Audience" ,"http://localhost:7243/api/"},
            {"JWTSettings:AccessTokenDurationInMinutes","1" }
            //...populate as needed for the test
        };
        IConfiguration config = new ConfigurationBuilder().AddInMemoryCollection(inMemorySettings).Build();
        IEmailService emailService = new MockEmailService();
        var result = _userBusiness.SendActivationCode(correct_input, emailService, config, "/", "Account/ActivateAccount", ref testHttpCode);
        result.Success.Should().BeTrue();
    }
    [Theory]
    [ClassData(typeof(SendActivationCodeDtoParameters))]
    public void Should_Not_Send_Activation_Code(SendActivationCodeDto dto, string reason)
    {
        var testHttpCode = 200;

        var inMemorySettings = new Dictionary<string, string> {
            {"Smtp:Host", _configRoot.GetSection("Smtp").GetSection("Host").Value},
            {"Smtp:Port", _configRoot.GetSection("Smtp").GetSection("Port").Value},
            {"Smtp:Username", _configRoot.GetSection("Smtp").GetSection("Username").Value},
            {"Smtp:Password", _configRoot.GetSection("Smtp").GetSection("Password").Value}
            //...populate as needed for the test
        };
        IConfiguration config = new ConfigurationBuilder().AddInMemoryCollection(inMemorySettings).Build();
        IEmailService emailService = new MockEmailService();

        var result = _userBusiness.SendActivationCode(dto, emailService, config, "/", "/Account/ActivateAccout", ref testHttpCode);
        result.Success.Should().BeFalse();
        switch (reason)
        {
            case "invalid-email": result.EmailErrorMessages.Should().Contain(reason); break;
            case "not-found-email": result.EmailErrorMessages.Should().Contain(reason); break;
        }
    }
    [Fact]
    public void Should_Create_Duty()
    {
        var correct_input = new DutyDto
        {
            ConsultantId = 1,
            StudentId = 2,
            Description = "some random description",
            ArrangedDate = DateTime.Now,
            Title = "the title of the test new duty",
            LessonId = 1,
            OlderDutyId = null
        };
        int testHttpCode = 200;
        var result = _dutyBusiness.CreateDuty(correct_input, ref testHttpCode);
        result.Success.Should().BeTrue();
    }
    [Theory]
    [ClassData(typeof(DutyDtoParameters))]
    public void Shoud_Not_Create_Duty(DutyDto dto, string reason)
    {
        int testHttpCode = 200;

        var result = _dutyBusiness.CreateDuty(dto, ref testHttpCode);
        // var unExpected = "";
        result.Success.Should().BeFalse();
        switch (reason)
        {
            case "invalid-title": result.TitleErrorMessage.Should().Contain(reason); break;
            case "invalid-lessonId": result.LessonIdErrorMessage.Should().Contain(reason); break;
            case "invalid-studentId": result.StudentIdErrorMessage.Should().Contain(reason); break;
            case "invalid-consultantId": result.ConsultantIdErrorMessage.Should().Contain(reason); break;
            case "invalid-arrangedDate": result.ArrangedDateErrorMessage.Should().Contain(reason); break;
            case "invalid-olderDutyId": result.OlderDutyIdErrorMessage.Should().Contain(reason); break;


        }

    }
    [Fact]
    public void Should_Get_All_Lessons()
    {
        var result = _lessonBusiness.GetAllLessons();
        result.Should().BeEquivalentTo(_lessons.Select(a => new LessonDto
        {
            Id = a.Id,
            Title = a.Title
        }).ToList());
    }
    [Fact]
    public void Should_Get_All_Students()
    {
        var result = _userBusiness.GetAllStudents();
        var roleIdForBeingStudent = _roles.First(a => a.Title.ToLower() == "student").Id;
        var studentIds = _userRoles.Where(a => a.RoleId == roleIdForBeingStudent).Select(a => a.UserId).Distinct();
        result.Should().BeEquivalentTo(_users.Where(a => studentIds.Contains(a.Id)).Select(a => new UserDto
        {
            Id = a.Id,
            Username = a.Username
        }).ToList());

    }
    [Fact(Skip = "no need any more")]
    public void Should_Get_All_Duties()
    {
        List<DutyDto> result = _dutyBusiness.GetAllDuties();
        result.Should().BeEquivalentTo(_duties.Select(a => new DutyDto
        {
            ArrangedDate = a.ArrangedDate,
            Id = a.Id,
            IsActive = a.IsActive,
            Title = a.Title,
            ConsultantTitle = a.ConsultantTitle,
            LessonTitle = a.LessonTitle,
            StudentTitle = a.StudentTitle
        }));
    }
    [Fact]
    public void Should_Create_Duty_Reply()
    {
        int testHttpCode = 200;
        var correct_input = new DutyReplyDto
        {
            DutyId = 1,
            IsSucceed = true,
            Description = "some test description"
        };
        var result = _dutyBusiness.CreateDutyReply(correct_input, ref testHttpCode);
        result.Success.Should().BeTrue();
    }
    [Theory]
    [ClassData(typeof(DutyReplyDtoParameters))]
    public void Shoud_Not_Create_DutyReply(DutyReplyDto dto, string reason)
    {
        int testHttpCode = 200;

        var result = _dutyBusiness.CreateDutyReply(dto, ref testHttpCode);
        // var unExpected = "";
        result.Success.Should().BeFalse();
        switch (reason)
        {
            case "invalid-dutyId": result.DutyIdErrorMessage.Should().Contain(reason); break;

        }

    }
    [Fact(Skip = "no need any more")]

    public void Should_Get_ActiveDuties_By_StudentId()
    {
        int studentId = 1;
        List<DutyDto> result = _dutyBusiness.GetActiveDutiesByStudentId(studentId);
        result.Should().BeEquivalentTo(_duties.Where(a => a.IsActive).Select(a => new DutyDto
        {
            ArrangedDate = a.ArrangedDate,
            Id = a.Id,
            Title = a.Title,
        }));
    }
    [Fact]
    public void Should_Get_Student_Detail()
    {
        int studentId = 2;
        SingleStudentDetailDto result = _userBusiness.GetStudentDetail(studentId);
        User expected = _users.First(a => a.Id == studentId);
        result.Id.Should().Be(expected.Id);
        result.PhoneNumber.Should().Be(expected.PhoneNumber);
        result.Email.Should().Be(expected.Email);
        result.Description.Should().Be(expected.Description);
        result.Username.Should().Be(expected.Username);


    }
    [Fact]
    public void Should_Get_Consultant_Related_Students()
    {
        int testHttpCode = 200;
        int consultantId = 2;
        List<Func_Report_Related_Student> result = _userBusiness.GetConsultantRelatedStudents(consultantId, ref testHttpCode);
        var roleIdForBeingStudent = _roles.First(a => a.Title.ToLower() == "student").Id;
        var studentIds = _userRoles.Where(a => a.RoleId == roleIdForBeingStudent).Select(a => a.UserId).Distinct();
        result.Select(a => new UserDto { Id = a.Id, Username = a.Username }).Should().BeEquivalentTo(_users.Where(a => studentIds.Contains(a.Id) && a.ConsultantId == consultantId).Select(a => new UserDto
        {
            Id = a.Id,
            Username = a.Username
        }).ToList());

    }
    [Fact]
    public void Should_Not_Get_Consultant_Related_Students()
    {
        int testHttpCode = 200;
        int consultantId = 3000;
        var result = _userBusiness.GetConsultantRelatedStudents(consultantId, ref testHttpCode);
        result.Should().BeNull();

    }
    [Fact]
    public void Should_Get_Student_Related_Duties()
    {
        int testHttpCode = 200;

        int studentId = 3;
        var result = _dutyBusiness.GetStudentRelatedDuties(studentId, ref testHttpCode);
        result.Select(a => new DutyDto { Id = a.Id, Title = a.Title }).ToList().Should()
            .BeEquivalentTo(_duties.Where(a => a.StudentId == studentId).Select(a => new DutyDto
            {
                Id = a.Id,
                Title = a.Title
            }));

    }
    [Fact]
    public void Should_Not_Get_Student_Related_Duties()
    {
        int testHttpCode = 200;

        int studentId = 300;
        var result = _dutyBusiness.GetStudentRelatedDuties(studentId, ref testHttpCode);
        result.Should().BeNull();

    }
    [Fact]
    public void Should_Get_Parent_Duties()
    {
        int dutyId = 2;
        int testHttpCode = 200;
        var result = _dutyBusiness.GetParentDuties(dutyId, ref testHttpCode);
        result.Select(a => new DutyDto { Id = a.Id, OlderDutyId = a.Id, Title = a.Title }).Should()
            .BeEquivalentTo(_duties.Where(a => a.OlderDutyId == dutyId));
    }
    [Fact]
    public void Should_Not_Get_Parent_Duties()
    {
        int dutyId = 300;
        int testHttpCode = 200;
        var result = _dutyBusiness.GetParentDuties(dutyId, ref testHttpCode);
        result.Should().BeNull();
    }
    [Fact]
    public void Should_Update_Lesson()
    {
        int testHttpCode = 200;
        var input = new LessonDto
        {
            Id = 1,
            Title = "updated lesson 1"

        };
        var result = _lessonBusiness.UpdateLesson(input, ref testHttpCode);
        result.IsSuccess.Should().BeTrue();

    }
    [Theory]
    [InlineData(300,"some title","invalid-lessonid" , "")]
    [InlineData(1, "abcde12345abcde12345abcde12345abcde12345abcde12345abcde12345abcde12345abcde12345abcde12345abcde12345", "","invalid-title")]
    [InlineData(300, "abcde12345abcde12345abcde12345abcde12345abcde12345abcde12345abcde12345abcde12345abcde12345abcde12345", "invalid-lessonid","invalid-title")]

    public void Should_Not_Update_Lesson(int id , string title, string idReason,string titleReason)
    {
        int testHttpCode = 200;
        var input = new LessonDto
        {
            Id = id,
            Title = title
        };
        var result = _lessonBusiness.UpdateLesson(input, ref testHttpCode);
        result.IsSuccess.Should().BeFalse();
        if (idReason == "invalid-lessonid")
        {
            result.LessonIdErrorMessage.Should().NotBe("");
        }
        if (titleReason == "invalid-title")
        {
            result.LessonTitleErrorMessage.Should().NotBe("");
        }        
    }
    [Fact]
    public void Should_Change_Consultant()
    {
        int studentId = 3;
        int consultantId = 2;
        int testHttpCode = 200;
        var result = _userBusiness.ChangeConsultant(studentId, consultantId , ref testHttpCode);
        result.IsSuccess.Should().BeTrue();
    }
    [Theory]
    [InlineData(3,300 , "","invalid-consultantid")]
    [InlineData(300,2 , "invalid-studentid","")]
    [InlineData(300,301 , "invalid-studentid" , "invalid-consultantid")]
    public void Should_Not_Change_Consultant(int studentId , int newConsultantId , string reasonStudentId , string reasonConsultantId)
    {
        int testHttpCode = 200;
        var result = _userBusiness.ChangeConsultant(studentId , newConsultantId , ref testHttpCode);
        result.IsSuccess.Should().BeFalse();
        if (reasonStudentId == "invalid-studentid")
        {
            result.StudentIdErrorMessage.Should().NotBe("");
        }
        if (reasonConsultantId == "invalid-consultantid")
        {
            result.ConsultantIdErrorMessage.Should().NotBe("");
        }

    }
}