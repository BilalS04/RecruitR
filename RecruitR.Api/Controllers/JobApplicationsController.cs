

using Microsoft.AspNetCore.Mvc;
using RecruitR.Api.Data;
using RecruitR.Api.Dtos;
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
        public IActionResult Create(JobApplicationCreateDto dto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var job = new JobApplication
            {
                CompanyName = dto.CompanyName,
                Position = dto.Position,
                Status = dto.Status,
                AppliedDate = DateTime.UtcNow
            };

            _context.JobApplications.Add(job);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetAll), new { id = job.Id }, job);
        }

    }
}
