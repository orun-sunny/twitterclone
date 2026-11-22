
using TwitterClone.Application.Dtos;

namespace TwitterClone.Application.Interfaces
{
    public interface IAuthService
    {
        UserDto? CreateUser(CreateUserDto createUserDto);
        UserDto? GetUserById(Guid id);
        UserDto? UpdateUser(Guid id, UpdateUserDto updateUserDto);
        UserDto? UpdateUserPhoneNumber(Guid id, string phoneNumber);
        bool DeleteUser(Guid id);
        List<UserDto> GetUsers();
    }
}