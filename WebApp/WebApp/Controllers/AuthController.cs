using Microsoft.IdentityModel.Tokens;
using System;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Web.Http;

namespace WebApp.Controllers
{
    public class AuthController : ApiController
    {
        // GET: api/Auth
        [HttpGet]
        public IHttpActionResult Get()
        {
            // Definimos los privilegios
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, "user"),
                new Claim("Valor", "123546"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            // Generamos el Token
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken
            (
                issuer: ConfigurationManager.AppSettings["Issuer"],
                audience: ConfigurationManager.AppSettings["Audience"],
                expires: DateTime.UtcNow.AddMinutes(600),
                claims: claims,
                notBefore: DateTime.UtcNow,
                signingCredentials: creds
            );
            // Retornamos el token
            return Ok(new { response = new JwtSecurityTokenHandler().WriteToken(token) });
        }
    }
}
