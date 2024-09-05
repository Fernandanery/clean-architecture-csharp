using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CleanArchMvc.Domain.Account;
using CleanArchMvc.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace CleanArchMvc.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController(IAuthenticate authenticate, IConfiguration configuration) : ControllerBase
    {
        private readonly IAuthenticate _authenticate = authenticate ??
                                                       throw new ArgumentException(nameof(authenticate));

        private readonly IConfiguration _configuration = configuration;

        [HttpPost("CreateUser")]
        public async Task<ActionResult> CreateUser([FromBody] LoginModel userInfo)
        {
            var result = await _authenticate.RegisterUser(userInfo.Email, userInfo.Password);

            if (result)
            {
                return Ok($"User {userInfo.Email} was create successfully");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return BadRequest(ModelState);
            }
        }

        [HttpPost("LoginUser")]
        public async Task<ActionResult<UserToken>> Login([FromBody] LoginModel userInfo)
        {
            var result = await _authenticate.Authenticate(userInfo.Email, userInfo.Password);

            if (result)
            {
                return GenerateToken(userInfo);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt");

                return BadRequest();
            }
        }

        private UserToken GenerateToken(LoginModel userInfo)
        {
            // declarações do usuário
            var claims = new[]
            {
                new Claim("email", userInfo.Email),
                new Claim("meuValor", "qualquer coisa"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            // Gerar chave privada para assinar o token
            var privateKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));

            // Gerar a assinatura digital
            var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

            //Definir tempo de expiração do token
            var expirate = DateTime.UtcNow.AddMinutes(10);

            //Gerar o token
            var token = new JwtSecurityToken
            (
                // emissor
                issuer: _configuration["Jwt:Issuer"],
                // audiencia
                audience: _configuration["Jwt: Audience"],
                //claims
                claims: claims,
                // Data de expiração
                expires: expirate,
                // asinatura digital
                signingCredentials: credentials
            );

            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expirate
            };
        }
    }
}
