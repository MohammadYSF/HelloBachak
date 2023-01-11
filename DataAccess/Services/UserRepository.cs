using DataAccess.Repositories;
using Entity.Context;
using Entity.Models;

namespace DataAccess.Services;

public class UserRepository : IUserRepository
{
    private readonly HelloBachakContext _db;
    public UserRepository(HelloBachakContext db)
    {
        _db = db;
    }
    public string Create(User user)
    {
        throw new NotImplementedException();
    }

    public string Delete(User user)
    {
        throw new NotImplementedException();
    }

    public User Find(int id)
    {
        throw new NotImplementedException();
    }

    public IQueryable<User> Get()
    {
        throw new NotImplementedException();
    }

    public string Update(User user)
    {
        throw new NotImplementedException();
    }
}
