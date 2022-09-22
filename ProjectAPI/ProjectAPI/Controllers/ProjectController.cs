using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectAPI.Data;
using ProjectAPI.Model;
using ProjectAPI.VievModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using WebAPI.Model;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : Controller
    {
        private readonly DataContext _context;
        //private readonly IMapper _mapper;

        //private int UserId = int.Parse(User.Claims.Single(x => x.Type == ClaimTypes.NameIdentifier).Value);

        //int UserId = Users.Claims.Single(ClaimTypes.NameIdentifier)?.Value;
        //private int userId = int.Parse(User.Claims.Single(x => x.Type == ClaimTypes.NameIdentifier).Value);

        public ProjectController(DataContext context) //IMapper mapper)
        {
            _context = context;
           // _mapper = mapper;
            //userId = int.Parse(User.Claims.Single(x => x.Type == ClaimTypes.NameIdentifier).Value);

        }

        /* [Authorize]
         [Route("GetProjetcs")]
         [HttpGet]
         public async Task<ActionResult<Project>> GetProjetcs()
         {
             string ssss = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
             int userId = int.Parse(User.Claims.Single(x => x.Type == ClaimTypes.NameIdentifier).Value);

             var data = await _context.Projects.Where(x => x.UserId == userId).Where(x=> !x.Deleted).ToListAsync();
             if (!data.Any())
                 return BadRequest(JsonSerializer.Serialize("project not found"));
             return Ok(JsonSerializer.Serialize(data));
         }*/


        [HttpGet("UserProject/{id}")]
        public async Task<ActionResult<Project>> GetProjetcs(int id)
        {
            try
            {
                var data = await _context.Projects.Where(x => x.UserId == id).Where(x => !x.Deleted).ToListAsync();
            
                if (!data.Any())
                    return BadRequest(JsonSerializer.Serialize("project not found"));
                var model = data
                       .Select(x => new ProjectModel(x))
                       .ToList();
                return Ok(JsonSerializer.Serialize(model));
            }
            catch (Exception ex)
            {
                return BadRequest(JsonSerializer.Serialize(false));
            }
        }

        [Route("ProjectAdd")]
        [HttpPost]
        public async Task<ActionResult<bool>> ProjectAdd(ProjectModel model)
        {
            try
            {
                var data = new Project()
                {
                    //User = user,
                    UserId = model.UserId,
                    Name = model.Name,
                    Description = model.Description,
                    BeginDate = Convert.ToDateTime(model.BeginDate),
                    EndDate = Convert.ToDateTime(model.EndDate)
                };
                _context.Projects.Add(data);
                await _context.SaveChangesAsync();

                return Ok(JsonSerializer.Serialize(true));
            }
            catch (Exception ex)
            {
                return BadRequest(JsonSerializer.Serialize(false));
            }
        }


        [HttpGet("ProjectDelete/{id}")]
        public async Task<ActionResult<bool>> ProjectDelete(int id)
        {
            try
            {
                var data = await _context.Projects.FindAsync(id);
                if (data == null)
                    return BadRequest(JsonSerializer.Serialize("project not found"));

                data.Deleted = true;

                await _context.SaveChangesAsync();

                return Ok(JsonSerializer.Serialize(true));
            }
            catch (Exception ex)
            {
                return BadRequest(JsonSerializer.Serialize(false));
            }
        }

        [HttpGet("GetProject/{id}")]
        public async Task<ActionResult<Project>> GetProjet(int id)
        {
            try
            {
                var data = await _context.Projects.Where(x => x.ProjectId == id).Where(x => !x.Deleted).ToListAsync();

                if (!data.Any())
                    return BadRequest(JsonSerializer.Serialize("project not found"));

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                return BadRequest(JsonSerializer.Serialize(false));
            }
        }
    }
}
