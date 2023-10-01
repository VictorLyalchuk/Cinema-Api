using Core.DTOs.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IAccountService
    {
        Task<IdentityUser> Get(string id);
        Task<string> Login(LoginDTO loginDTO);
        Task Registration(RegistrationDTO registrationDTO);
        Task Logout();
    }
}
