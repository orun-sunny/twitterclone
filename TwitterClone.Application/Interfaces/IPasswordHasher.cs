using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Application.Dtos;

namespace TwitterClone.Application.Interfaces
{
    public interface IPasswordHasher
    {
        bool VerifyPassword(string password, string passwordHash, string passwordHash1);
        bool VerifyPassword(UserDto userDto, string password, string passwordHash);
    }
}
