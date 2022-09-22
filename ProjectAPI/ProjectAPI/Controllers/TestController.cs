using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model;

namespace ProjectAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TestController : ControllerBase
  {
/*    private static List<User> users = new List<User> {
          new User { Id = 1,
            FirstName = "Ayaz",
            LastName = "Bikineev",
            Login ="bikineev",
            Password= "1234"},
          new User { Id = 2,
            FirstName = "Danya",
            LastName = "Timushev",
            Login ="timushev",
            Password= "4321"}
      };*/
    private readonly DataContext _context;

    public TestController(DataContext context)
    {
      _context = context; 
    }

    [Route("Get")]
    [HttpGet]
    public async Task<ActionResult<List<User>>> Get()
    {
      var user = await _context.Users.ToListAsync(); 
      return Ok(user);
    }

    [Route("Get/{id}")]
    [HttpGet]
    public async Task<ActionResult<User>> GetId(int id)
    {
      var user = await _context.Users.Where(x => x.UserId == id).ToListAsync();
      if (!user.Any())
        return BadRequest("User not found");
      return Ok(user);
    }

    [HttpPost]
    [Route("AddTest")]
    public async Task<ActionResult<List<User>>> AddTest(User user)
    {

      _context.Users.Add(user);
      await _context.SaveChangesAsync();
      return Ok(await _context.Users.ToListAsync());
    }


    [Route("UpdateTest")]
    [HttpPut]
    public async Task<ActionResult<List<User>>> UpdateTest(User request)
    {
      var user = await _context.Users.FindAsync(request.UserId);
      if (user == null)
        return BadRequest("User not found");

      user.FirstName = request.FirstName;
      user.LastName = request.LastName;
      user.Login = request.Login;
      user.Password = request.Password;

      await _context.SaveChangesAsync();

      return Ok(await _context.Users.ToListAsync());

    }

    [Route("Delete/{id}")]
    [HttpDelete]
    public async Task<ActionResult<List<User>>> Delete(int id)
    {
      var user = await _context.Users.FindAsync(id);
      if (user == null)
        return BadRequest("User not found");

      _context.Users.Remove(user);
      await _context.SaveChangesAsync();

      return Ok(await _context.Users.ToListAsync());
    }
  }
}
