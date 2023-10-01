using Core.DTOs.User;
using Core.Helpers;
using Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AccountService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }
        public async Task<IdentityUser> Get(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                return user;
            }
            else
                throw new CustomHttpException(ErrorMessages.UserNotFoundById, HttpStatusCode.NotFound);
        }

        public async Task <string>Login(LoginDTO loginDTO)
        {
            var user = await _userManager.FindByNameAsync(loginDTO.Email);
            var pass = await _userManager.CheckPasswordAsync(user, loginDTO.Password);
            if (user == null || !pass)
            {
                throw new CustomHttpException(ErrorMessages.ErrorLoginorPassword, HttpStatusCode.BadRequest);
            }

            await _signInManager.SignInAsync(user, true);
            var claimsList = new List<Claim>()
            { 
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, loginDTO.Email)
            };
            var jwtOptions = _configuration.GetSection("Jwt").Get<JwtOptions>();
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions!.Key));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                issuer: jwtOptions.Issuer,
                audience: jwtOptions.Audience,
                claims: claimsList,
                expires: DateTime.Now.AddMinutes(jwtOptions.LifeTime),
                signingCredentials: signinCredentials
            );


            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return tokenString;
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
