using DataAccess.Repositories;
using Entity.Context;
using Entity.Models;

namespace DataAccess.Services;

public class UserRepository : IUserRepository
{
    private readonly HelloBachakContext _db;
    public UserRepository(HelloBachakContext db)
    {
        _db = db;
    }
    public string Create(User user)
    {
        throw new NotImplementedException();
    }

    public string Delete(User user)
    {
        throw new NotImplementedException();
    }

    public User Find(int id)
    {
        throw new NotImplementedException();
    }

    public Grade FindGrade(int gradeId)
    {
        throw new NotImplementedException();
    }

    public Sex FindSex(int sexId)
    {
        throw new NotImplementedException();
    }

    public IQueryable<User> Get()
    {
        throw new NotImplementedException();
    }

    public List<int> GetGradeIds()
    {
        throw new NotImplementedException();
    }

    public List<int> GetSexIds()
    {
        throw new NotImplementedException();
    }

    public List<string> GetUsersEmails()
    {
        throw new NotImplementedException();
    }

    public List<string> GetHashedUsersPasswords()
    {
        throw new NotImplementedException();
    }

    public List<string> GetUsersPhoneNumbers()
    {
        throw new NotImplementedException();
    }

    public int Save()
    {
        throw new NotImplementedException();
    }

    public string Update(User user)
    {
        throw new NotImplementedException();
    }

    public List<int> GetRoleIds()
    {
        throw new NotImplementedException();
    }

    public Role FindRoleByTitle(string title)
    {
        throw new NotImplementedException();
    }
}
