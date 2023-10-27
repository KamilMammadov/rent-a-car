﻿using CarRent.Database.Models;
using CarRent.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CarRent.Areas.Admin.ViewModels.Category;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Areas.Admin.Controllers
{


    [Area("admin")]
    [Route("admin/category")]
    public class CategoryController : Controller
    {
        private readonly DataContext _dbContext;

        public CategoryController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("list", Name = "admin-cate-list")]
        public async Task<IActionResult> List()
        {
            var model = await _dbContext.Categories.Select(c => new CategoryListViewModel(c.Id, c.Name)).ToListAsync();
            return View(model);
        }

        [HttpGet("add", Name = "admin-cate-add")]
        public async Task<IActionResult> Add()
        {
            return View(new CategoryAddViewModel());
        }

        [HttpPost("add", Name = "admin-cate-add")]
        public async Task<IActionResult> Add(CategoryAddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var category = new Category
            {
                Name = model.Name,
                OrderId = model.OrderId,
                CreatedAt = DateTime.Now,
            };

            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();
            return RedirectToRoute("admin-cate-list");

        }

        [HttpPost("delete/{id}", Name = "admin-cate-delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category is null)
            {
                return NotFound();
            }
            _dbContext.Categories.Remove(category);
            await _dbContext.SaveChangesAsync();
            return RedirectToRoute("admin-cate-list");
        }
    }
}
