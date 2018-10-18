using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using forex4u.Models;
using forex4u.Infrastructure;
using forex4u.Repositories;
using Microsoft.Extensions.Configuration;

namespace forex4u.Controllers
{
    [Produces("application/json")]
    [Route("api/Token")]
    public class TokenController : Controller
    {
        private IConfiguration _config;

        IUserRepository repository;
        public TokenController(IConfiguration config, IUserRepository _repository)
        {
            repository = _repository;
            _config = config;
        } 

        [AllowAnonymous]
        [HttpPost]
        public IActionResult RequestToken([FromBody] TokenRequest request)
        {
            IActionResult response = Unauthorized();
            var user = repository.CheckAccount(request.Username, request.Password);
            if (user!=null)
            {
                var token = BuildToken(user);
                response = Ok(new { token = token });
            }

            return response;
        }
        private string BuildToken(StockUser user)
        {
            var claims = new[]
                {
                   new Claim(ClaimTypes.Name, user.MobileNumber)
                };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(StaticValues.SecurityKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: StaticValues.Issuer,
                audience: StaticValues.Issuer,
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);            
        }
        
    }
}