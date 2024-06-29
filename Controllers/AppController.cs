using System.Security.Claims;
using JobAppTracker.Data;
using JobAppTracker.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;




namespace JobAppTracker.Controllers;

public class AppController : Controller
{
    private readonly JobApplicationDbContext _db;
    private readonly IWebHostEnvironment _webHostEnvironment;


    public AppController(JobApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
    {
        _db = db;
        _webHostEnvironment = webHostEnvironment;
    
    }
    [Authorize]
    public IActionResult Index()
    {
        string username = User.Identity.Name;
        IEnumerable<JobApp> job = _db.JobApps.Where(j => j.userId == username).OrderBy(j => j.Status).ToList();
       
        return View(job);
    }

    //GET ACTION method (Create)
    public IActionResult Create()
    {
        return View();
    }
    //POST ACTION method (Create)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(JobApp obj)
    {    
        obj.userId = User.Identity.Name;
        ModelState.Remove("userId");

        if(ModelState.IsValid)
        {   
            //Handling resume file uploads
            var file = Request.Form.Files["Resume"];
            if (file != null && file.Length > 0)
            {
                var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(file.FileName);
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                obj.Resume = "/uploads/" + uniqueFileName; // Store the file path
            }
            else
            {
                obj.Resume = null; // Handle case where no file is uploaded
            }
            //populating the database with the info inputted
            _db.JobApps.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(obj);
       
    }

    public IActionResult Edit(int? Id)
    {
        if(Id==null || Id==0)
        {
            return NotFound();
        }

        var applicationDatabase = _db.JobApps.Find(Id);

        if(applicationDatabase == null)
        {
            return NotFound();
        }
        return View(applicationDatabase);
    }
    //POST ACTION method (Edit)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(JobApp obj)
    {    
        obj.userId = User.Identity.Name;
        ModelState.Remove("userId");

        if(ModelState.IsValid)
        {   
            //Handling resume file uploads
            var file = Request.Form.Files["Resume"];
            if (file != null && file.Length > 0)
            {
                var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(file.FileName);
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                obj.Resume = "/uploads/" + uniqueFileName; // Store the file path
            }
            else
            {
                obj.Resume = null; // Handle case where no file is uploaded
            }
            //populating the database with the info inputted
            _db.JobApps.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(obj);
       
    }

    public IActionResult Delete(int? Id)
    {
        if(Id==null || Id==0)
        {
            return NotFound();
        }

        var applicationDatabase = _db.JobApps.Find(Id);

        if(applicationDatabase == null)
        {
            return NotFound();
        }
        return View(applicationDatabase);
    }
    //POST ACTION method (Delete)
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePost(int? Id)
    {    
        var obj = _db.JobApps.Find(Id);
        if(obj == null)
        {
            return NotFound();
        }
        _db.JobApps.Remove(obj);
        _db.SaveChanges();
        return RedirectToAction("Index");
       
    }

}
