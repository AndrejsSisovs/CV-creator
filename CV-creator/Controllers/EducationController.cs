using CV_creator.Database;
using CV_creator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CV_creator.Controllers
{
    public class EducationsController : Controller
    {
        private readonly CvDbContext _context;

        public EducationsController(CvDbContext context)
        {
            _context = context;
        }

        // GET: Educations/Create?cvId=5
        public IActionResult Create(int cvId)
        {
            ViewBag.CVId = cvId;
            return View();
        }

        // POST: Educations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InstitutionName,Faculty,FieldOfStudy,EducationLevel,Status,StartDate,EndDate,InstitutionAddress")] Education education, int cvId)
        {
            if (ModelState.IsValid)
            {
                education.BasicInformationId = cvId;
                _context.Add(education);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "CVs", new { id = cvId });
            }
            ViewBag.CVId = cvId;
            return View(education);
        }

        // Similarly, implement Edit, Delete actions
    }
}
