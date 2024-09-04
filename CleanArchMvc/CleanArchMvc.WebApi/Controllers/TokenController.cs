using CleanArchMvc.Domain.Account;
using CleanArchMvc.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController(IAuthenticate authenticate) : ControllerBase
    {
        private readonly IAuthenticate _authenticate = authenticate ??
                                                       throw new ArgumentException(nameof(authenticate));

        [HttpPost("LoginUser")]
        public async Task<ActionResult<UserToken>> Login([FromBody] LoginModel userInfo)
        {
            var result = await _authenticate.Authenticate(userInfo.Email, userInfo.Password);

            if (result)
            {
                //return GenerateToken(userInfo);
                return Ok("sucesso");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt");

                return BadRequest();
            }
        }
    }
}
