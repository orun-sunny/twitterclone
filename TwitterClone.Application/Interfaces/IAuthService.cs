using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Application.Dtos;

namespace TwitterClone.Application.Interfaces
{
    internal interface IAuthService
    {
        AuthResponseDto? Login(LoginDto loginDto);
    }
}
