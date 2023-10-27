using CarRent.Areas.Admin.ViewModels.About;
using CarRent.Areas.Admin.ViewModels.Category;
using CarRent.Database;
using CarRent.Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/about")]
    public class AboutController : Controller
    {
        private readonly DataContext _dbContext;

        public AboutController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("list", Name = "admin-about-list")]
        public async Task<IActionResult> List()
        {
            var model = await _dbContext.Abouts.Select(c => new AboutViewModel(c.Id,c.SmallHeader,c.Header,c.Tittle)).ToListAsync();
            return View(model);
        }

        [HttpGet("add", Name = "admin-about-add")]
        public async Task<IActionResult> Add()
        {
            return View(new AboutViewModel());
        }

        [HttpPost("add", Name = "admin-about-add")]
        public async Task<IActionResult> Add(AboutViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var about = new About
            {
                SmallHeader=model.SmallHeader,
                Header=model.Header,
                Tittle=model.Tittle
            };

            await _dbContext.Abouts.AddAsync(about);
            await _dbContext.SaveChangesAsync();
            return RedirectToRoute("admin-about-list");

        }


        [HttpGet("update/{id}", Name = "admin-about-update")]
        public async Task<IActionResult> Update(int id)
        {
            var about = await _dbContext.Abouts.FirstOrDefaultAsync(x => x.Id == id);
            if (about == null) return NotFound();



            return View(about);
        }

        [HttpPost("update/{id}", Name = "admin-about-update")]
        public async Task<IActionResult> Update(int id, [FromForm] About newAbout)
        {
            var about = await _dbContext.Abouts.FirstOrDefaultAsync(x => x.Id == id);
            if (about == null) return NotFound();

                about.SmallHeader=newAbout.SmallHeader;
            about.Header = newAbout.Header;
            about.Tittle=newAbout.Tittle;



            await _dbContext.SaveChangesAsync();

            return RedirectToRoute("admin-about-list");
        }

        [HttpPost("delete/{id}", Name = "admin-about-delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            var about = await _dbContext.Abouts.FirstOrDefaultAsync(c => c.Id == id);
            if (about is null)
            {
                return NotFound();
            }
            _dbContext.Abouts.Remove(about);
            await _dbContext.SaveChangesAsync();
            return RedirectToRoute("admin-about-list");
        }
    }
}
