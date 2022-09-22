using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectAPI.Data;
using ProjectAPI.Model;
using ProjectAPI.VievModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WebAPI.Model;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly DataContext _context;
        public AdminController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("AllUsers/{id}")]
        public async Task<ActionResult<User>> GetUsers()
        {
            try
            {
                var data = await _context.Users.Include(x => x.AccessLevel).ToListAsync();

                if (!data.Any())
                    return BadRequest(JsonSerializer.Serialize("project not found"));
                var model = data
                       .Select(x => new UsersModel(x))
                       .ToList();
                return Ok(JsonSerializer.Serialize(model));
            }
            catch (Exception ex)
            {
                return BadRequest(JsonSerializer.Serialize(false));
            }
        }

        [Route("UsersEdit")]
        [HttpPost]
        public async Task<ActionResult<bool>> TaskEdit(UsersModel request)
        {
            try
            {
                var user = await _context.Users.FindAsync(request.userId);
                if (user == null)
                    return BadRequest("User not found");

                user.FirstName = request.firstName;
                user.LastName = request.lastName;
                user.Login = request.login;
                if (request.role != "User")
                    //user.AccessLevelId = await _context.AccessLevels.Where(x => x.Role == "Admin").Select(x => x.AccessLevelId);

                await _context.SaveChangesAsync();

                return Ok(await _context.Users.ToListAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(JsonSerializer.Serialize(false));
            }
        }
    }
}
