using DataAccess.Repositories;
using Entity.Context;
using Entity.Models;
using Entity.Models.FunctionModels;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Data.SqlClient;

namespace DataAccess.Services;

public class DutyRepository : IDutyRepository
{
    private readonly HelloBachakContext _db;
    public DutyRepository(HelloBachakContext db)
    {
        _db = db;
    }
    public string Create(Duty duty)
    {
        try
        {
            _db.Duties.Add(duty);
            return "";
        }
        catch (System.Exception e)
        {

            throw e;
        }
    }

    public string CreateDutyReply(DutyReply dutyReply)
    {
        try
        {
            _db.DutyReplies.Add(dutyReply);
            return "";
        }
        catch (Exception e)
        {

            throw e;
        }
    }

    public string Delete(Duty duty)
    {
        try
        {
            _db.Duties.Remove(duty);
            return "";
        }
        catch (System.Exception e)
        {

            throw e;
        }
    }

    public Duty Find(int id)
    {
        var duty = _db.Duties.Find(id);
        if (duty == null)
        {
            return null;
        }
        else
        {
            return duty;
        }
    }

    public IQueryable<Func_Get_Previous_Duty> Func_Get_Previous_Duty(int dutyId)
    {
        var pDutyId = new NpgsqlParameter("@DutyId", dutyId);
        var data = _db.Func_Get_Previous_Duty.FromSqlRaw("SELECT * from func_get_previous_duties(@DutyId)", pDutyId);
        return data;
    }

    public IQueryable<Func_Report_Student_Related_Duty> Func_Report_Student_Related_Duty(int userId)
    {
        var pUserId = new NpgsqlParameter("@UserId", userId);
        var data = _db.Func_Report_Student_Related_Duty.FromSqlRaw("SELECT * from func_Report_Student_related_duties(@UserId)", pUserId);
        return data;
    }

    public IQueryable<Duty> Get()
    {
        return _db.Duties;
    }

    public IQueryable<Duty> GetAllStudents()
    {
        return _db.Duties.Include(a=> a.Lesson).Include(a=> a.Consultant).Include(a=> a.Student);
    }

    public IQueryable<int> GetConsultantIds()
    {
        int roleIdForBeingConsultant = _db.Roles.First(a => a.Title == "consultant").Id;
        var result = _db.UserRoles.Where(a => a.RoleId == roleIdForBeingConsultant).Select(a => a.UserId);
        return result;
    }

    public IQueryable<int> GetDutyIds()
    {
        return _db.Duties.Select(a => a.Id);
    }

    public IQueryable<int> GetLessonIds()
    {
        return _db.Lessons.Select(a => a.Id);
    }

    public IQueryable<int> GetStudentIds()
    {
        int ruleIdForBeingStudent = _db.Roles.First(a => a.Title == "student").Id;
        var result = _db.UserRoles.Where(a=> a.RoleId == ruleIdForBeingStudent).Select(a=> a.UserId);
        return result;
    }

    public int Save()
    {
        return _db.SaveChanges();
    }

    public string Update(Duty duty)
    {
        throw new NotImplementedException();
    }

}
