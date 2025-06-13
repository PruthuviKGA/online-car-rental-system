using backend.DTOs;
using backend.Models;

namespace backend.Services
{
    public interface IUserService
    {
        string Login(UserLoginDto dto);
        User GetByEmail(string email);
        List<User> GetAllActiveUsers();
        User GetUserById(int id);
        bool UpdateUserActiveStatus(int id, bool isActive);
        bool DeleteUser(int id);
        ServiceResponse RegisterUser(UserRegisterDto dto);
        bool UpdateUserProfile(int userId, UserUpdateDto dto);
    }
}
