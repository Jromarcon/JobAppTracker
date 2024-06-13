using System.Security.Claims;
using JobAppTracker.Data;
using JobAppTracker.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JobAppTracker.Controllers;

public class AppController : Controller
{
    private readonly JobApplicationDbContext _db;


    public AppController(JobApplicationDbContext db)
    {
        _db = db;
    
    }

    public IActionResult Index()
    {
        string username = User.Identity.Name;
        IEnumerable<JobApp> job = _db.JobApps.Where(j => j.userId == username).OrderBy(j => j.Status).ToList();
        return View(job);
    }

}
