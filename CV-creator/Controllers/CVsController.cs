using CV_creator.Database;
using CV_creator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CV_creator.Controllers
{
    public class CVsController : Controller
    {
        private readonly CvDbContext _context;

        public CVsController(CvDbContext context)
        {
            _context = context;
        }

        // GET: CVs
        public async Task<IActionResult> Index()
        {
            var cvs = await _context.BasicInformations
                                     .Include(b => b.Educations)
                                     .Include(b => b.Jobs)
                                     .ToListAsync();
            return View(cvs);
        }

        // GET: CVs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cv = await _context.BasicInformations
                                    .Include(b => b.Educations)
                                    .Include(b => b.Jobs)
                                        .ThenInclude(j => j.Skills)
                                    .Include(b => b.ResidenceAddress)
                                    .FirstOrDefaultAsync(m => m.Id == id);
            if (cv == null)
            {
                return NotFound();
            }

            return View(cv);
        }

        // GET: CVs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CVs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Email,PhoneNumber,BirthDate")] BasicInformation basicInformation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(basicInformation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(basicInformation);
        }

        // GET: CVs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cv = await _context.BasicInformations.FindAsync(id);
            if (cv == null)
            {
                return NotFound();
            }
            return View(cv);
        }

        // POST: CVs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,PhoneNumber,BirthDate")] BasicInformation basicInformation)
        {
            if (id != basicInformation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(basicInformation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CVExists(basicInformation.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(basicInformation);
        }

        // GET: CVs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cv = await _context.BasicInformations
                                    .FirstOrDefaultAsync(m => m.Id == id);
            if (cv == null)
            {
                return NotFound();
            }

            return View(cv);
        }

        // POST: CVs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cv = await _context.BasicInformations.FindAsync(id);
            _context.BasicInformations.Remove(cv);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CVExists(int id)
        {
            return _context.BasicInformations.Any(e => e.Id == id);
        }

        // GET: CVs/Preview/5
        public async Task<IActionResult> Preview(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cv = await _context.BasicInformations
                                    .Include(b => b.Educations)
                                    .Include(b => b.Jobs)
                                        .ThenInclude(j => j.Skills)
                                    .Include(b => b.ResidenceAddress)
                                    .FirstOrDefaultAsync(m => m.Id == id);
            if (cv == null)
            {
                return NotFound();
            }

            return View(cv);
        }
    }
}
