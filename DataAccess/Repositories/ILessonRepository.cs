namespace DataAccess.Repositories;
using System.Collections;
using System;
using System.Linq;
using Entity.Models;
public interface ILessonRepository
{
    public IQueryable<Lesson> Get();
    public string Create(Lesson lesson);
    public string Update(Lesson lesson);
    public string Delete(Lesson lesson);
    public Lesson Find (int id);
    public int Save();
}
