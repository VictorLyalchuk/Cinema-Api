using Core.DTOs.User;
using Core.Helpers;
using Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Net;

namespace Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<IdentityUser> Get(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                return user;
            }
            else
                return null;
        }

        public async Task Login(LoginDTO loginDTO)
        {
            var user = await _userManager.FindByNameAsync(loginDTO.Email);
            var pass = await _userManager.CheckPasswordAsync(user, loginDTO.Password);
            if (user != null || pass)
            {
                await _signInManager.SignInAsync(user, true);
            }
            else
            {
                throw new CustomHttpException(ErrorMessages.ErrorLoginorPassword, HttpStatusCode.BadRequest);
            }
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task Registration(RegistrationDTO registrationDTO)
        {
            IdentityUser user = new IdentityUser()
            {
                Email = registrationDTO.Email,
                UserName = registrationDTO.UserName,
            };
            var result = await _userManager.CreateAsync(user, registrationDTO.Password);
            if (!result.Succeeded)
            {
                var messageError = string.Join(",", result.Errors.Select(er => er.Description));
                throw new CustomHttpException(messageError, System.Net.HttpStatusCode.BadRequest);
            }
        }
    }
}
