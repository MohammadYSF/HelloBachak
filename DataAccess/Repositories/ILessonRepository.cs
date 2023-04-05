namespace DataAccess.Repositories;
using System.Collections;
using System;
using System.Linq;
using Entity.Models;
using Entity.Models.FunctionModels;

public interface ILessonRepository
{
    public IQueryable<Func_Report_Lesson> Func_Report_Lesson();
    public IQueryable<Lesson> Get();
    public string Create(Lesson lesson);
    public string Update(Lesson lesson);
    public string Delete(Lesson lesson);
    public Lesson Find (int id);
    public int Save();
}
