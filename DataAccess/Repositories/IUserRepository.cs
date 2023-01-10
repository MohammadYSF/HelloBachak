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
    User Find (User user);
}
