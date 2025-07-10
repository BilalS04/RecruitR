

using Microsoft.AspNetCore.Mvc;
using RecruitR.Api.Data;
using RecruitR.Api.Models;

namespace RecruitR.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobApplicationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public JobApplicationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/jobapplications
        [HttpGet]
        public IActionResult GetAll()
        {
            var applications = _context.JobApplications.ToList();
            return Ok(applications);
        }

        // POST: api/jobapplications
        [HttpPost]
        public IActionResult Create(JobApplication job)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            job.AppliedDate = DateTime.UtcNow;
            _context.JobApplications.Add(job);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetAll), new { id = job.Id }, job);
        }

    }
}
