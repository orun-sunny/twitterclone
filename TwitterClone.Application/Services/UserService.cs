using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Services
{

    public class UserService : IUserService


    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public UserDto? CreateUser(CreateUserDto createUserDto)
        {
            if (string.IsNullOrWhiteSpace(createUserDto.FirstName) ||
                string.IsNullOrWhiteSpace(createUserDto.LastName) ||
                string.IsNullOrWhiteSpace(createUserDto.Email))
            {
                return null;
            }
            ;

            var existingUser = _userRepository.GetUserByEmail(createUserDto.Email);
            if (existingUser != null)
            {
                return null;
            }

            var createUser = _userRepository.AddUser(new User
            {
                FirstName = createUserDto.FirstName,
                LastName = createUserDto.LastName,
                Email = createUserDto.Email
            });

            return new UserDto
            {
                Id = createUser.Id,
                FirstName = createUser.FirstName,
                LastName = createUser.LastName,
                Email = createUser.Email
            };
        }

        public bool DeleteUser(Guid id)
        {
            throw new NotImplementedException();
        }




        public UserDto? GetUserById(Guid id)
        {
            var user = _userRepository.GetUserById(id);
            if (user == null)
            {
                return null;
            }


            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };
        }

        public UserDto? UpdateUser(Guid id, UpdateUserDto updateUserDto)
        {
            var user = _userRepository.GetUserById(id);

            if (user == null)
            {
                return null;
            }

            user.FirstName = updateUserDto.FirstName.Trim();
            user.LastName = updateUserDto.LastName.Trim();


            _userRepository.UpdateUser(user);

            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };


        }

        public UserDto? UpdateUserPhoneNumber(Guid id, string phoneNumber)
        {
            var user = _userRepository.GetUserById(id);

            if (user == null)
            {
                return null;
            }

            user.PhoneNumber = phoneNumber;

            _userRepository.UpdateUser(user);

            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };
        }

        public List<UserDto> GetUsers()
        {
            var users = _userRepository.GetUsers();

            return users.Select(user => new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            }).ToList();
        }


    }

}