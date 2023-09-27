using Core.DTOs.User;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountControllers : Controller
    {
        private readonly IAccountService _accountService;
        public AccountControllers(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpGet("{id:int}")]
        public async Task <IActionResult> Get(string id)
        {
            var user = await _accountService.Get(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpPost("Registration")]
        public async Task<IActionResult> Registration(RegistrationDTO registrationDTO)
        {
            await _accountService.Registration(registrationDTO);
            return Ok();
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            await _accountService.Login(loginDTO);
            return Ok();
        }
        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _accountService.Logout();
            return Ok();
        }
    }
}
