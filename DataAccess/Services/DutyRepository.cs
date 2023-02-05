using DataAccess.Repositories;
using Entity.Context;
using Entity.Models;
using Microsoft.EntityFrameworkCore;

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



    public IQueryable<Duty> Get()
    {
        return _db.Duties;
    }

    public IQueryable<int> GetConsultantIds()
    {
        var y = _db.Roles.ToList();
        var x =_db.Users.Include(a => a.Role).Where(a => a.Role.Title.ToLower() == "consultant").Select(a => a.Id).ToList(); 
        return _db.Users.Include(a => a.Role).Where(a => a.Role.Title.ToLower() == "consultant").Select(a => a.Id);
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
        return _db.Users.Include(a => a.Role).Where(a => a.Role.Title.ToLower() == "student").Select(a => a.Id);


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
