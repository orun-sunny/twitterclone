using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces;
using TwitterClone.Application.Mappings;

namespace TwitterClone.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenService _tokenService;

        public AuthService(
            IUserRepository userRepository,
            IPasswordHasher passwordHasher,
            ITokenService tokenService)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
        }

        public AuthResponseDto? Login(LoginDto loginDto)
        {
            var user = _userRepository.GetUserByEmail(loginDto.Email);
            if (user is null || string.IsNullOrWhiteSpace(user.PasswordHash))
            {
                return null;
            }

            var userDto = user.ToDto();
            var userAuthorized = _passwordHasher.VerifyPassword(userDto, loginDto.Password, user.PasswordHash);

            if (userAuthorized)
            {
                var (token, expiryTime) = _tokenService.GetToken(userDto);

                return new AuthResponseDto
                {
                    AccessToken = token,
                    ExpiryAt = expiryTime,
                    UserDto = userDto
                };
            }

            return null;
        }
    }
}