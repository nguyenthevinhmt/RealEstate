using RealEstate.Application.UserModule.Dtos;

namespace RealEstate.Application.UserModule.Abstracts
{
    public interface IUserService
    {
        UserDto FindCurrentUserInfo();
    }
}
