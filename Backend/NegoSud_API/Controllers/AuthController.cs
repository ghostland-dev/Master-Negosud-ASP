using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Akavache;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using Microsoft.AspNetCore.Authorization;
using NegoSud_API.Auth;
using NegoSud_API.Models;

namespace NegoSud_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        

        

        private readonly TokenManager TokenManager;

        public AuthController(TokenManager TokenManager)
        {
            this.TokenManager = TokenManager;
        }



        [AllowAnonymous]
        [HttpPost("Authorize")]

        public IActionResult AuthUser([FromBody] Utilisateur utilisateur)
        {
            var token = TokenManager.Authenticate(utilisateur.NomUtilisateur, utilisateur.MotDePasse);
            if (token == null)
            {
                return Unauthorized("You don't have the permession to access this data set.");
            }
            return Ok(token);
        }


    }
}
