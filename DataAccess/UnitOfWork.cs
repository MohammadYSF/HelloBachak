using DataAccess.Repositories;
using DataAccess.Services;
using Entity.Context;
namespace DataAccess;

public class UnitOfWork:IDisposable
{
    private HelloBachakContext _context;
    public UnitOfWork( HelloBachakContext context)
    {
        _context = context;
    }

    private UserRepository _userRepository;

    public IUserRepository UserRepository
    {
        get
        {
            if (_userRepository == null)
            {
                _userRepository = new UserRepository(_context);
            }
            return _userRepository;
        }
        
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
