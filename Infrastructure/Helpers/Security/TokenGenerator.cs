using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Helpers.Security
{
    public class TokenGenerator
    {
        public static string getToken(string configuration, string login)
        {
            try
            {
                var claim = new List<Claim> {
                new Claim(JwtRegisteredClaimNames.UniqueName, login),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                DateTime expire = DateTime.Now.AddHours(+1);

                JwtSecurityToken token = new JwtSecurityToken(issuer: null, audience: null, claims: claim, expires: expire, signingCredentials: creds);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }
}
