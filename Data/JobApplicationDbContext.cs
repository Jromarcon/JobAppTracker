using JobAppTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace JobAppTracker.Data;

public class JobApplicationDbContext :DbContext
{
    public JobApplicationDbContext(DbContextOptions<JobApplicationDbContext> options) : base(options)
    {
    }


    public DbSet<JobApp> JobApps {get; set;}
}
