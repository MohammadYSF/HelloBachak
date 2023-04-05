namespace DataAccess.Repositories;
using System.Collections;
using System;
using System.Linq;
using Entity.Models;
using System.Collections.Generic;
using Entity.Models.FunctionModels;

public interface IDutyRepository
{
    public IQueryable<Func_Get_Previous_Duty> Func_Get_Previous_Duty(int dutyId);
    public IQueryable<Func_Report_Student_Related_Duty> Func_Report_Student_Related_Duty(int userId);
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

    string CreateDutyReply(DutyReply dutyReply);
}
