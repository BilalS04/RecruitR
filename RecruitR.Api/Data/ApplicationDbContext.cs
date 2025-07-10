
using Microsoft.EntityFrameworkCore;
using RecruitR.Api.Models;

namespace RecruitR.Api.Data
{
    public class  ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {
        }

        public DbSet<JobApplication> JobApplications { get; set; }

    }
}