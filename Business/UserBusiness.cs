using Entity.Models;
using DataAccess;
using DataAccess.Repositories;
using Dto.Models;

namespace Business;

public class UserBusiness
{
    private readonly IUserRepository _userRepository;
    public UserBusiness(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public object RegisterUser(RegisterUserDto userDto)
    {
        throw new NotImplementedException();
    }
}
