namespace DataAccess.Repositories;
using System.Collections;
using System;
using System.Linq;
using Entity.Models;
using System.Collections.Generic;

public interface IDutyRepository
{
    public IQueryable<Entity.Models.Duty> Get();
    string Create(Entity.Models.Duty duty);
    string Update(Entity.Models.Duty duty);
    string Delete(Entity.Models.Duty duty);
    Duty Find (int id);
    IQueryable<int> GetLessonIds();
    IQueryable<int> GetStudentIds();
    IQueryable<int> GetConsultantIds();
    IQueryable<int> GetDutyIds();
    int Save();
    IQueryable<Duty> GetAllStudents();
}
