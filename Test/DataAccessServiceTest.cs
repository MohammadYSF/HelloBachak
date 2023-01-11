using Xunit;
using Moq;
using System;
using Business;
using DataAccess.Repositories;
using DataAccess.Services;
using Entity.Models;
using FluentAssertions;
namespace Test;

public class DataAccessServiceTest
{
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
    public DataAccessServiceTest()
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

    }
    [Fact]
    public void Should_Return_All_Users()
    {
        var result = _userRepositoryServiceMock.Object.Get();
        List<User> users = new List<User>();
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
        var expected = users.AsQueryable<User>();
        result.Should().HaveCount(expected.Count());
        //Console.WriteLine(result.GetType().ToString()); : System.Linq.EnumerableQuery
        result.Should().BeEquivalentTo(expected);
    }
    [Fact]
    public void Should_Return_User_By_Given_UserId()
    {
        var result = _userRepositoryServiceMock.Object.Find(_user.Id);
        var expected = _user;
        result.Should().BeEquivalentTo(expected);
    }
    [Fact]
    public void Should_Create_New_User()
    {
        var newUser = this._newUser;
        var result = _userRepositoryServiceMock.Object.Create(newUser);
        var expected = "";
        result.Should().Be(expected);

    }
    [Fact]
    public void Should_Update_User()
    {
        var user = this._user;
        var result = _userRepositoryServiceMock.Object.Update(_updatedUser);
        var expected = "";
        result.Should().Be(expected);
    }
}