using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Blog.Extensions;
using Microsoft.IdentityModel.Tokens;
using Blog.Models;


namespace Blog.Services;

public class TokenService
{
     public string GererateToken(User user)
     {
          var tokenHandler = new JwtSecurityTokenHandler();
          var key = Encoding.ASCII.GetBytes(Configuration.JwtKey);
          var claims = user.GetClaims(); 
          var tokenDescription = new SecurityTokenDescriptor
          {
               Subject = new ClaimsIdentity(claims),
               Expires = DateTime.UtcNow.AddHours(8),
               SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature) 
          };
          var token = tokenHandler.CreateToken(tokenDescription);
          return tokenHandler.WriteToken(token);
     }
}