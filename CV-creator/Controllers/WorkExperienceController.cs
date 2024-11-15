using CV_creator.Database;
using CV_creator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CV_creator.Controllers
{
    public class WorkExperienceController : Controller
    {
        public readonly CvDbContext _context;

        public WorkExperienceController (CvDbContext context)
        {
            _context = context;
        }

        public IActionResult AddWorkExperience (int cvId)
        {
            var cv = _context.BasicInformations
                .Include(w => w.Jobs)
                .FirstOrDefault (w => w.Id == cvId);

            if (cv == null)
            { 
                return NotFound(); 
            }

            var workExperience = new WorkExperience { BasicInformationId = cvId };
            return View(workExperience);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddWorkExperience(WorkExperience workExperience)
        {
            ModelState.Remove("WorkAddress");

            var basicInfo = await _context.BasicInformations
                               .FirstOrDefaultAsync(w => w.Id == workExperience.BasicInformationId);

            if (basicInfo == null)
            {
                return NotFound();
            }

            ModelState.Remove("BasicInformation");
            ModelState.Remove("Skills");

            if (ModelState.IsValid)
            {
                _context.WorkExperiences.Add(workExperience);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "CVs", new { id = workExperience.BasicInformationId });
            }

            return View(workExperience);
        }

        public IActionResult Edit(int id)
        {
            var workExperience = _context.WorkExperiences
                                    .FirstOrDefault(e => e.Id == id);

            if (workExperience == null)
            {
                return NotFound();
            }

            return View(workExperience);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, WorkExperience workExperience)
        {
            if (id != workExperience.Id)
            {
                return NotFound();
            }
            ModelState.Remove("WorkAddress");
            ModelState.Remove("BasicInformation");
            ModelState.Remove("Skills");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workExperience);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.WorkExperiences.Any(e => e.Id == workExperience.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "CVs", new { id = workExperience.BasicInformationId });
            }
            return View(workExperience);
        }

        public IActionResult Delete(int id)
        {
            var workExperience = _context.WorkExperiences
                                    .FirstOrDefault(e => e.Id == id);
            if (workExperience == null)
            {
                return NotFound();
            }

            return View(workExperience);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workExperience = await _context.WorkExperiences.FindAsync(id);
            if (workExperience == null)
            {
                return NotFound();
            }

            _context.WorkExperiences.Remove(workExperience);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", "CVs", new { id = workExperience.BasicInformationId });
        }


        public async Task<IActionResult> Details (int id)
        {
            var workExperience = await _context.WorkExperiences.
                Include(we => we.Skills).
                FirstOrDefaultAsync(we => we.Id == id);

            if (workExperience == null) 
            {
                return NotFound();
            }
            var viewModel = new WorkExperienceWithSkills
            {
                WorkExperience = workExperience,
                Skills = workExperience.Skills.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSkill(WorkExperienceWithSkills viewModel)
        {
            var workExperience = await _context.WorkExperiences
                    .Include(we => we.Skills)
                    .FirstOrDefaultAsync(we => we.Id == viewModel.WorkExperience.Id);

                if (workExperience == null)
                {
                    return NotFound();
                }

                viewModel.WorkExperience = workExperience;

                viewModel.NewSkill.JobId = workExperience.Id;
                _context.Skills.Add(viewModel.NewSkill);
                await _context.SaveChangesAsync();

                return RedirectToAction("Details", new { id = workExperience.Id });
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteSkill(int SkillId, int workExperienceId)
        {
            var skill = await _context.Skills.FirstOrDefaultAsync(s => s.Id == SkillId);

            if (skill == null)
            {
                return NotFound();
            }

            _context.Skills.Remove(skill);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", new { id = workExperienceId });

        }




    }
}
