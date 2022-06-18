/*
 * By: voidotexe
 * https://www.github.com/voidotexe
*/

using AccountMicroService.Data;
using AccountMicroService.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AccountMicroService.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        
        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody] Account account)
        {
            await _accountService.SignUp(account);

            return NoContent();
        }

        [HttpPost]
        public IActionResult Login([FromBody] Account account)
        {
            return _accountService.Login(account) ? StatusCode(204) : StatusCode(500);
        }
    }
}