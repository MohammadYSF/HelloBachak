namespace DataAccess.Repositories;
using System.Collections;
using System;
using System.Linq;
using Entity.Models;
public interface IUserRepository
{
    public IQueryable<User> Get();
    string Create(User user);
    string Update(User user);
    string Delete(User user);
    User Find (int id);
    Sex FindSex(int sexId);
    Grade FindGrade(int gradeId);
    List<int>GetSexIds();
    List<int> GetGradeIds();
    List<string> GetUsersEmails();
    List<string> GetUsersPasswords();
    List<string> GetUsersPhoneNumbers();
    int Save();
}
