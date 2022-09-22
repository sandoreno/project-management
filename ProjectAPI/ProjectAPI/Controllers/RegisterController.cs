using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectAPI.Data;
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
  public class RegisterController : ControllerBase
  {
    private readonly DataContext _context;

    public RegisterController(DataContext context)
    {
        _context = context;
    }

        [HttpPost]
        public async Task<ActionResult<List<User>>> Register(User user)
        {
            try
            {
                var login = await _context.Users.Where(x => x.Login == user.Login).FirstOrDefaultAsync();
                if (login != null)
                {
                    return BadRequest(JsonSerializer.Serialize("ѕользователь с таким логином уже существует"));
                }
                user.AccessLevelId = 1; 
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return Ok(JsonSerializer.Serialize(true));
            }
            catch(Exception ex) 
            {
                return BadRequest(ex);
            }
        }
    }
}
