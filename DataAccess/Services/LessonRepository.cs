using DataAccess.Repositories;
using Entity.Context;
using Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Services;

public class lessonRepository : ILessonRepository
{
    private readonly HelloBachakContext _db;
    public lessonRepository(HelloBachakContext db)
    {
        _db = db;
    }
    public string Create(Lesson lesson)
    {
        try
        {
            _db.Lessons.Add(lesson);
            return "";
        }
        catch (System.Exception e)
        {

            throw e;
        }
    }

    public string Delete(Lesson lesson)
    {
        try
        {
            _db.Lessons.Remove(lesson);
            return "";
        }
        catch (System.Exception e)
        {

            throw e;
        }
    }

    public Lesson Find(int id)
    {
        var lesson = _db.Lessons.Find(id);
        if (lesson == null)
        {
            return null;
        }
        else
        {
            return lesson;
        }
    }



    public IQueryable<Lesson> Get()
    {
        return _db.Lessons;
    }

    public int Save()
    {
        return _db.SaveChanges();
    }

    public string Update(Lesson lesson)
    {
        throw new NotImplementedException();
    }
}