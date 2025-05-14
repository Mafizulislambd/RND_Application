using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FlatRentTracker.Models
{
    // Helpers/JwtHelper.cs
    public static class JwtHelper
    {
        //public static string GenerateToken(IConfiguration config, UserLoginResult user)
        //{
        //    var jwtSettings = config.GetSection("Jwt");
        //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
        //    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //    var claims = new[]
        //    {
        //    new Claim(JwtRegisteredClaimNames.Sub, user.UserId ?? ""),
        //    new Claim(ClaimTypes.Name, user.UserName ?? ""),
        //    new Claim(ClaimTypes.Email, user.UserEmail ?? ""),
        //    new Claim(ClaimTypes.Role, user.UserType.ToString())
        //};

        //    var token = new JwtSecurityToken(
        //        issuer: jwtSettings["Issuer"],
        //        audience: jwtSettings["Audience"],
        //        claims: claims,
        //        expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtSettings["ExpireMinutes"])),
        //        signingCredentials: creds
        //    );

        //    return new JwtSecurityTokenHandler().WriteToken(token);
        //}
        public static string GenerateToken(IConfiguration config, UserLoginResult user)
        {
            var jwtConfig = config.GetSection("Jwt");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig["Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
        new Claim(JwtRegisteredClaimNames.Sub, user.UserId),
        new Claim(ClaimTypes.Name, user.UserName),
        new Claim(ClaimTypes.Email, user.UserEmail),
        new Claim(ClaimTypes.Role, user.UserType.ToString())
    };

            var token = new JwtSecurityToken(
                issuer: jwtConfig["Issuer"],
                audience: jwtConfig["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(60),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }

}
