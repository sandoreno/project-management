using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProjectAPI.Auth;
using ProjectAPI.Data;
using ProjectAPI.VievModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using WebAPI.Model;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly DataContext _context;

        private readonly IOptions<AuthOptions> _authOptions;

        public AuthController(DataContext context, IOptions<AuthOptions> authOptions)
        {
            _authOptions = authOptions;
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<List<User>>> Auth(LoginPasswordModel model)
        {
            var user = await _context.Users
                .Where(x => x.Login == model.UserName && x.Password == model.Password)
                .FirstOrDefaultAsync();
            if (user == null)
                return BadRequest(JsonSerializer.Serialize("User not found"));
            return Ok(JsonSerializer.Serialize(Convert.ToString(user.UserId)));
        }
    }
}

/*        [HttpPost]
        public async Task<ActionResult<List<User>>> Auth(LoginPasswordModel model)
        {
            var user = await _context.Users
                .Where(x => x.Login == model.UserName && x.Password == model.Password)
                .FirstOrDefaultAsync();

            if (user != null)
            {
                var token = GenerateJWT(user);

                return Ok(JsonSerializer.Serialize(new { acces_token = token }));
            }

            return Unauthorized();
        }

        private string GenerateJWT(User user)
        {
            var authParams = _authOptions.Value;

            var secretKey = authParams.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>() {
                new Claim(JwtRegisteredClaimNames.Email, user.Login),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString())
            };

            var token = new JwtSecurityToken(authParams.ISSUER,
                authParams.AUDIENCE,
                claims,
                expires: DateTime.Now.AddMinutes(authParams.LIFETIME), 
                signingCredentials : credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);     
        }*/


