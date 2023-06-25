using DataAccess.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace xCredidentials.App.Features.Utils;

public class JwtUtil
{
    private readonly IConfiguration _configuration;

    public JwtUtil(IConfiguration configuration) { _configuration = configuration; }

    public string GeneratingIdentityJwtToken(UserModel user, string secretKey)
    {

        var tokenHandler = new JwtSecurityTokenHandler();
        SecurityKey securityKey;
        if (secretKey != null)
        { securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration.GetSection("SecretKey").Value)); }
        else
        { securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey)); }

        var credidentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[] {
                new Claim("UserId",  user.UserId.ToString()),
                new Claim("Email", user.Email),
                new Claim("FirstName", user.FirstName),
                new Claim("LastName",user.LastName)
                };
        var token = new SecurityTokenDescriptor
        {

            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(10),
            SigningCredentials = credidentials
        };

        var t = tokenHandler.CreateToken(token);


        return tokenHandler.WriteToken(t);
    }
    public bool Validate(string token, string stringKey)
    {
        if (token == null) return false;

        var tokenHandler = new JwtSecurityTokenHandler();
        //  var byteKey = Encoding.ASCII.GetBytes(stringKey);
        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidateAudience = false,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(stringKey))
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;

            return tokenHandler.CanReadToken(jwtToken.ToString());

        }
        catch (Exception)
        {
            return false;
        }
    }
}
