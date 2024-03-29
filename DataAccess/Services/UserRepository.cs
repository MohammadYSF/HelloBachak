using DataAccess.Repositories;
using Entity.Context;
using Entity.Models;
using Entity.Models.FunctionModels;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Data.SqlClient;
using System.Linq;

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

        try
        {
            var u = _db.Users.Find(user.Id);
            u = user;
            return "";
        }
        catch (Exception e)
        {
            return e.InnerException.Message;
            throw e;
        }
        
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

    public User FindUserByEmail(string email)
    {
        return _db.Users.FirstOrDefault(a=> a.Email == email);
    }

    public Role FindRole(int roleId)
    {
       var role = _db.Roles.First(a=> a.Id == roleId);
       if (role == null){
        throw new NullReferenceException();
       }
       return role;
    }

    public IQueryable<User> GetAllStudents()
    {
        var roleIdForBeingStudent = _db.Roles.First(a => a.Title == "student").Id;
        var userIds = _db.UserRoles.Where(a=> a.RoleId == roleIdForBeingStudent).Select(a=> a.UserId);
        var result = _db.Users.Where(a => userIds.Contains(a.Id));
        return result;
    }

    public User FindUserByUsername(string username)
    {
        return _db.Users.SingleOrDefault(a => a.Username == username);
    }

    public IQueryable<Role> GetRolesByUserId(int userId)
    {
        var roleIds = _db.UserRoles.Where(a => a.UserId == userId).Select(a => a.RoleId);
        return _db.Roles.Where(a => roleIds.Contains(a.Id));
    }

    public IQueryable<Func_Report_Related_Student> Func_Report_Related_Students(int userId)
    {
        var pUserId = new NpgsqlParameter("@UserId", userId);
        var data = _db.Func_Report_Related_Student.FromSqlRaw("SELECT * From func_report_related_students(@UserId)" , pUserId);
        return data;
    }

    public IQueryable<Func_Report_Manage_Student> Func_Report_ManageStudent()
    { 
        var data = _db.Func_Report_Manage_Student.FromSqlRaw("SELECT * From func_report_manage_students()");
        return data;
    }

    public string CreateUserRole(UserRole userRole)
    {
        try
        {
            _db.UserRoles.Add(userRole);
            return "";
        }
        catch (Exception e)
        {

            throw e;
            return "error";
        }
    }
}
