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

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GanttChartController : ControllerBase
    {
        private readonly DataContext _context;

        public GanttChartController(DataContext context )
        {
            _context = context;
    
        }

        [HttpGet("GetTasks/{id}")]
        public async Task<ActionResult<Tasks>> GetTasks(int id)
        {
            try
            {
                var data = await _context.Tasks.Where(x => x.ProjectId == id).Where(x => !x.Deleted).ToListAsync();

                if (!data.Any())
                    return BadRequest(JsonSerializer.Serialize("tasks not found"));
                var model = data
                       .Select(x => new TaskModel(x))
                       .ToList();
                return Ok(JsonSerializer.Serialize(model));
            }
            catch (Exception ex)
            {
                return BadRequest(JsonSerializer.Serialize(false));
            }
        }

        [HttpGet("GetChart/{id}")]
        public async Task<ActionResult<Tasks>> GetChart(int id)
        {
            try
            {
                var data = await _context.Tasks.Where(x => x.ProjectId == id).Where(x => !x.Deleted).ToListAsync();

                if (!data.Any())
                    return BadRequest(JsonSerializer.Serialize("tasks not found"));
                var model = data
                       .Select(x => new ChartModel(x))
                       .ToList();
                return Ok(JsonSerializer.Serialize(model));
            }
            catch (Exception ex)
            {
                return BadRequest(JsonSerializer.Serialize(false));
            }
        }

        [HttpGet("GetConnection/{id}")]
        public async Task<ActionResult<Tasks>> GetConnection(int id)
        {
            try
            {
                var data = await _context.Tasks.Where(x => x.ProjectId == id).Where(x => !x.Deleted).ToListAsync();

                if (!data.Any())
                    return BadRequest(JsonSerializer.Serialize("tasks not found"));
                var model = data
                       .Select(x => new ConnectionModel(x))
                       .ToList();
                return Ok(JsonSerializer.Serialize(model));
            }
            catch (Exception ex)
            {
                return BadRequest(JsonSerializer.Serialize(false));
            }
        }

        [HttpGet("GetTask/{projectid}/{taskid}")]
        public async Task<ActionResult<Tasks>> GetTask(int projectid, int taskid)
        {
            try
            {
                var data = await _context.Tasks.Where(x => x.ProjectId == projectid).Where(x=> x.TasksId == taskid).Where(x => !x.Deleted).ToListAsync();

                if (!data.Any())
                    return BadRequest(JsonSerializer.Serialize("tasks not found"));
                var model = data
                       .Select(x => new TaskModel(x))
                       .ToList();
                return Ok(JsonSerializer.Serialize(model));
            }
            catch (Exception ex)
            {
                return BadRequest(JsonSerializer.Serialize(false));
            }
        }


        [Route("TaskAdd")]
        [HttpPost]
        public async Task<ActionResult<bool>> TaskAdd(TaskModel model)
        {
            try
            {
                var data = new Tasks()
                {
                    ProjectId = model.ProjectId,
                    Name = model.name,
                    Start = Convert.ToDateTime(model.start),
                    End = Convert.ToDateTime(model.end),
                    Progress = model.progress,
                    Dependecies = model.dependencies
                };
                _context.Tasks.Add(data);
                await _context.SaveChangesAsync();

                return Ok(JsonSerializer.Serialize(true));
            }
            catch (Exception ex)
            {
                return BadRequest(JsonSerializer.Serialize(false));
            }
        }

        [Route("TaskEdit")]
        [HttpPost]
        public async Task<ActionResult<bool>> TaskEdit(TaskModel model)
        {
            try
            {
                var data = await _context.Tasks
                    .Where(x => x.TasksId == Convert.ToInt32(model.id))
                    .Where(x => !x.Deleted)
                    .FirstOrDefaultAsync();

                if (data != null)
                    return BadRequest(JsonSerializer.Serialize("tasks not found"));
                data.Name = model.name;
                data.Start = Convert.ToDateTime(model.start);
                data.End = Convert.ToDateTime(model.end);
                data.Progress = model.progress;
                data.Dependecies = model.dependencies;

                await _context.SaveChangesAsync();
                return Ok(JsonSerializer.Serialize(true));
            }
            catch (Exception ex)
            {
                return BadRequest(JsonSerializer.Serialize(false));
            }
        }

        [HttpGet("TaskDelete/{id}")]
        public async Task<ActionResult<bool>> TaskDelete(int id)
        {
            try
            {
                var data = await _context.Tasks.FindAsync(id);
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
    }
}
