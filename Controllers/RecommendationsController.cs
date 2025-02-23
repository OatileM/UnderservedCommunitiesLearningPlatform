using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UnderservedCommunitiesLearningPlatform.Data;
using UnderservedCommunitiesLearningPlatform.Models;

namespace UnderservedCommunitiesLearningPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommendationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RecommendationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Recommendations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Module>>> GetRecommendations()
        {
            // Implement your recommendation logic here
           
            return await _context.Modules.ToListAsync();
        }
    }
}
