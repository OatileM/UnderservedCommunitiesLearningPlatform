using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UnderservedCommunitiesLearningPlatform.Data;
using UnderservedCommunitiesLearningPlatform.Models;

namespace UnderservedCommunitiesLearningPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgressController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProgressController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Progress
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentModule>>> GetProgress()
        {
            return await _context.StudentModules.ToListAsync();
        }

        // GET: api/Progress/5
        [HttpGet("{studentId}")]
        public async Task<ActionResult<IEnumerable<StudentModule>>> GetProgressByStudent(string studentId)
        {
            var progress = await _context.StudentModules
                .Where(sm => sm.StudentID == studentId)
                .ToListAsync();

            if (progress == null || !progress.Any())
            {
                return NotFound();
            }

            return progress;
        }

        // POST: api/Progress
        [HttpPost]
        public async Task<ActionResult<StudentModule>> PostProgress(StudentModule studentModule)
        {
            _context.StudentModules.Add(studentModule);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProgressByStudent", new { studentId = studentModule.StudentID }, studentModule);
        }

        // DELETE: api/Progress/5
        [HttpDelete("{studentId}/{moduleId}")]
        public async Task<IActionResult> DeleteProgress(string studentId, string moduleId)
        {
            var studentModule = await _context.StudentModules
                .FirstOrDefaultAsync(sm => sm.StudentID == studentId && sm.ModuleID == moduleId);
            if (studentModule == null)
            {
                return NotFound();
            }

            _context.StudentModules.Remove(studentModule);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
