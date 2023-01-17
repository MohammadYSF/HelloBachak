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
        try
        {
            _db.Users.Add(user);
            return "";
        }
        catch (System.Exception e)
        {

            throw e;
        }
    }

    public string Delete(User user)
    {
        try
        {
            _db.Users.Remove(user);
            return "";
        }
        catch (System.Exception e)
        {

            throw e;
        }
    }

    public User Find(int id)
    {
        var user = _db.Users.Find(id);
        if (user == null)
        {
            return null;
        }
        else
        {
            return user;
        }
    }

    public Grade FindGrade(int gradeId)
    {
        var grade = _db.Grades.Find(gradeId);
        if (grade == null)
        {
            throw new NullReferenceException();
        }
        else
        {
            return grade;
        }
    }

    public Sex FindSex(int sexId)
    {
        var sex = _db.Sexes.Find(sexId);
        if (sex == null)
        {
            throw new NullReferenceException();
        }
        else
        {
            return sex;
        }
    }

    public IQueryable<User> Get()
    {
        return _db.Users;
    }

    public List<int> GetGradeIds()
    {
        return _db.Grades.Select(a => a.Id).ToList();
    }

    public List<int> GetSexIds()
    {
        return _db.Sexes.Select(a => a.Id).ToList();
    }

    public List<string> GetUsersEmails()
    {
        return _db.Users.Select(a => a.Email).ToList();
    }

    public List<string> GetHashedUsersPasswords()
    {
        return _db.Users.Select(a => a.Password).ToList();
    }

    public List<string> GetUsersPhoneNumbers()
    {
        return _db.Users.Select(a => a.Username).ToList();
    }

    public int Save()
    {
        return _db.SaveChanges();
    }

    public string Update(User user)
    {
        throw new NotImplementedException();
    }

    public List<int> GetRoleIds()
    {
        return _db.Users.Select(a => a.Id).ToList();
    }

    public Role FindRoleByTitle(string title)
    {
        var role = _db.Roles.First(a => a.Title == title);
        if (role == null)
        {
            throw new NullReferenceException();
        }
        return role;
    }

    public List<string> GetUsersUsernames()
    {
        return _db.Users.Select(a => a.Username).ToList();
    }

    public string ChangeUserPassword(int userId, string newHashedPassword)
    {
        try
        {
            var user = _db.Users.Find(userId);
            if (user == null)
            {
                return "error";
            }
            user.Password = newHashedPassword;            
            return "";            
        }
        catch (System.Exception e)
        {

            throw e;
        }
    }
}
