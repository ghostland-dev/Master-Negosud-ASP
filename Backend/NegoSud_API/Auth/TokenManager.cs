using System.Collections.ObjectModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NegoSud_API.Data;
using NegoSud_API.Models;
using NegoSud_API.Controllers;
using Microsoft.AspNetCore.Http.HttpResults;

namespace NegoSud_API.Auth
{
    public class TokenManager
    {
        
        private readonly string key;


        private readonly IDictionary<string, string> users = new Dictionary<string, string>()
        {
            {"Stanislas","123"},
            {"Ismail","123"},
            {"hacker","hacker"}
        };

        public TokenManager(string key)
        {
            this.key = key;
        }

         

        public string Authenticate(string? username, string? password)
        {
             
            if (users.Any(u => u.Key == username && u.Value == password))
            {
                return "{ message : 'no user with these creditials !'}";
            }

            JwtSecurityTokenHandler tokenHandler = new();
            var tokenkey = Encoding.ASCII.GetBytes(key);

            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new ClaimsIdentity(new Claim[]
                    {
                new Claim(ClaimTypes.Name,  username)
                    }),

                Expires = DateTime.UtcNow.AddHours(1),

                SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(tokenkey),
                        SecurityAlgorithms.HmacSha256Signature

                        )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);



            return "Bearer " + tokenHandler.WriteToken(token);

        }




    }


}
