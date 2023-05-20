using System.Threading.Tasks;
using BrowserTravel.Library.Entities.Dto.Auth;
using BrowserTravel.Library.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BrowserTravel.Library.API.Controllers.V1
{
    [Route("api/V1/[controller]")]
    public class AccountController : Controller
    {
        private readonly IRegisterService _registerService;
        private readonly IAccountService _accountService;

        public AccountController(IRegisterService registerService, IAccountService accountService)
        {
            _registerService = registerService;
            _accountService = accountService;
        }

        // POST api/values
        [Route("Register")]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RegisterDto registerDto)
        {
            RegisterResponseDto registerResponseDto = await _registerService.Register(registerDto);
            return Ok(registerResponseDto);
        }

        [Route("SingIn")]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserSignInDto userSignInDto)
        {
            UserDto userDto = await _accountService.SignIn(userSignInDto);

            if(userDto == null)
                return BadRequest("User or password incorrect");
            else
                return Ok(userDto);
        }
    }
}
