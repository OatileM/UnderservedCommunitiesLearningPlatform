using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UnderservedCommunitiesLearningPlatform.Data;
using UnderservedCommunitiesLearningPlatform.Models;


namespace UnderservedCommunitiesLearningPlatform.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class UsersController: ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var students = await _context.Students.ToListAsync();
            var teachers = await _context.Teachers.ToListAsync();
            var users = students.Cast<User>().Concat(teachers.Cast<User>()).ToList();
            return users;
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(string id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                return student;
            }

            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher != null)
            {
                return teacher;
            }

            return NotFound();
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(string id, User user)
        {
            if (id != user.UserID)
            {
                return BadRequest();
            }

            if (user is Student student)
            {
                _context.Entry(student).State = EntityState.Modified;
            }
            else if (user is Teacher teacher)
            {
                _context.Entry(teacher).State = EntityState.Modified;
            }
            else
            {
                return BadRequest("Invalid user type");
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            if (user is Student student)
            {
                _context.Students.Add(student);
            }
            else if (user is Teacher teacher)
            {
                _context.Teachers.Add(teacher);
            }
            else
            {
                return BadRequest("Invalid user type");
            }

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.UserID }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
                return NoContent();
            }

            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher != null)
            {
                _context.Teachers.Remove(teacher);
                await _context.SaveChangesAsync();
                return NoContent();
            }

            return NotFound();
        }
        private bool UserExists(string id)
        {
            return _context.Students.Any(e => e.UserID == id) || _context.Teachers.Any(e => e.UserID == id);
        }
    }
}

