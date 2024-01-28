using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskTrackerApi.Data;
using TaskTrackerApi.Models;

namespace TaskTrackerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TasksController(ApplicationContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Получение всех задач
        /// </summary>
        // GET: api/Tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Task>>> GetTasks()
        {
            if (_context.Tasks == null)
            {
                return NotFound();
            }

            return await _context.Tasks.ToListAsync();
        }

        /// <summary>
        /// Создание задачи
        /// </summary>
        // POST: api/Tasks
        [HttpPost]
        public async Task<ActionResult<Models.Task>> AddTask(TaskDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (_context.Tasks == null)
            {
                return Problem("Entity set is null");
            }

            Models.Task task = new()
            {
                Title = dto.Title,
                Description = dto.Description,
            };

            _context.Tasks.Add(task);
            
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTask", new { id = task.Id }, task);
        }

        /// <summary>
        /// Получение задачи по идентификатору
        /// </summary>
        // GET: api/Tasks/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Task>> GetTask(int id)
        {
            if (_context.Tasks == null)
            {
                return NotFound();
            }

            var task = await _context.Tasks.FindAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            return task;
        }

        /// <summary>
        /// Редактирование задачи
        /// </summary>
        // PUT: api/Tasks/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTask(int id, TaskDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var task = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == id);

            if (task == null)
            {
                return NotFound();
            }

            task.Update(dto);

            _context.Entry(task).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return CreatedAtAction("PutTask", task);
        }

        /// <summary>
        /// Удаление задачи
        /// </summary>
        // DELETE: api/Tasks/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            if (_context.Tasks == null)
            {
                return NotFound();
            }
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
