using CV_creator.Database;
using CV_creator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
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
        public IActionResult AddEducation(int id)
        {
            var cv = _context.BasicInformations
                              .Include(b => b.Educations)
                              .FirstOrDefault(b => b.Id == id);

            if (cv == null)
            {
                return NotFound();
            }

            var education = new Education { BasicInformationId = id };  // Pre-fill with CV ID
            return View(education);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEducation(Education education)
        {
            if (ModelState.IsValid)
            {
                _context.Educations.Add(education);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details));  // Or redirect to CV details
            }
            return View(education);
        }
        //public IActionResult AddEducation(int id)
        //{
        //    var basicInformations = _context.BasicInformations.ToList();
        //    ViewBag.BasicInformationId = new SelectList(basicInformations, "Id", "FirstName");

        //    var education = new Education { BasicInformationId = id };
        //    return View(education);
        //}

        //// POST: Educations/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> AddEducation(Education education)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Educations.Add(education);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Details));
        //    }

        //    var basicInformations = _context.BasicInformations.ToList();
        //    ViewBag.BasicInformationId = new SelectList(basicInformations, "Id", "FirstName");

        //    return View(education);
        //}

        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var cv = await _context.BasicInformations.FindAsync(id);
        //    if (cv == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(cv);
        //}

        //// POST: CVs/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, BasicInformation basicInformation)
        //{
        //    if (id != basicInformation.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(basicInformation);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!CVExists(basicInformation.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Details));
        //    }
        //    return View(basicInformation);
        //}

        //private bool CVExists(int id)
        //{
        //    return _context.BasicInformations.Any(e => e.Id == id);
        //}

        //// GET: CVs/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var cv = await _context.BasicInformations
        //                            .FirstOrDefaultAsync(m => m.Id == id);
        //    if (cv == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(cv);
        //}
    }
}
