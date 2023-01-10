using DataAccess.Repositories;
using DataAccess.Services;
namespace DataAccess;

public class UnitOfWork
{
    private UserRepository _userRepository;

    public UnitOfWork(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public IUserRepository UserRepository
    {
        get
        {
            if (_userRepository == null)
            {
                _userRepository = new UserRepository();
            }
            return _userRepository;
        }
        
    }

}
