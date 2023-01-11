using Entity.Models;
using DataAccess;
using DataAccess.Repositories;

namespace Business;

public class UserBusiness
{
    private readonly IUserRepository _userRepository;
    public UserBusiness(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public List<User> GetAllUsers()
    {
        return _userRepository.Get().ToList();
    }
}
