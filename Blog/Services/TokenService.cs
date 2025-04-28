using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Blog.Models;


namespace Blog.Services;

public class TokenService
{
     public string GererateToken(User user)
     {
          var tokenHandler = new JwtSecurityTokenHandler();
          var key = Encoding.ASCII.GetBytes(Configuration.JwtKey);
          var tokenDescription = new SecurityTokenDescriptor
          {
               Subject = new ClaimsIdentity(new Claim[]
               {
                    new (ClaimTypes.Name, "andrebaltieri"), //User.Identity.Name
                    new (ClaimTypes.Role, "admin"), //User.IsInRole
                    new (ClaimTypes.Role, "user"), //User.IsInRole
                    new ("fruta", "banana" ),
                    
               }),
               Expires = DateTime.UtcNow.AddHours(2),
               SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature) 
          };
          var token = tokenHandler.CreateToken(tokenDescription);
          return tokenHandler.WriteToken(token);
     }
}