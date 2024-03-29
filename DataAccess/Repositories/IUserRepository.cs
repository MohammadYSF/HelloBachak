namespace DataAccess.Repositories;
using System.Collections;
using System;
using System.Linq;
using Entity.Models;
using Entity.Models.FunctionModels;

public interface IUserRepository
{
    public IQueryable<Func_Report_Related_Student> Func_Report_Related_Students(int userId);
    public IQueryable<Func_Report_Manage_Student> Func_Report_ManageStudent();

    public IQueryable<User> Get();
    public IQueryable<User>GetAllStudents();
    string Create(User user);
    string Update(User user);
    string Delete(User user);
    User Find (int id);
    Sex FindSex(int sexId);
    Grade FindGrade(int gradeId);
    List<int>GetSexIds();
    List<int> GetGradeIds();
    List<String>GetUsersUsernames();
    List<string> GetUsersEmails();
    List<string> GetHashedUsersPasswords();
    List<string> GetUsersPhoneNumbers();
    List<int>GetRoleIds();
    Role FindRoleByTitle(string title);
    int Save();
    string ChangeUserPassword(int userId, string newHashedPassword);
    User FindUserByEmail(string email);
    Role FindRole(int roleId);
    User FindUserByUsername(string username);
    IQueryable<Role> GetRolesByUserId(int userId);

    string CreateUserRole(UserRole userRole);
}
