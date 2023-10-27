using CarRent.Areas.Admin.ViewModels.Category;
using CarRent.Areas.Admin.ViewModels.Product;
using CarRent.Database;
using CarRent.Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/product")]
    public class ProductController : Controller
    {
        private DataContext _dataContext;
  
        private readonly ILogger<ProductController> _logger;
        public ProductController(DataContext dataContext)
        {
            _dataContext = dataContext;

        }

        //[HttpGet("~/")]
        [HttpGet("list", Name = "admin-product-list")]
        public async Task<IActionResult> List()
        {
            var categories = await _dataContext.Categories.ToListAsync();
            var products = await _dataContext.Cars
                .Select(p => new ProductListViewModel(p.Id,p.Brand,p.Model,p.Year,p.FuelType,p.SeatCount,
                p.GearBox,p.WeeklyPrice,p.DailyPrice))
                .ToListAsync();

            return View(products);
        }
        [HttpGet("add", Name = "admin-product-add")]
        public async Task<IActionResult> Add()
        {
            var model = new ProductAddViewModel
            {
                Categories = await _dataContext.Categories
                    .Select(c => new CategoryListViewModel(c.Id, c.Name))
                    .ToListAsync(),
            };
            return View(model);
        }

        [HttpPost("add", Name = "admin-product-add")]
        public async Task<IActionResult> Add(ProductAddViewModel product)
        {
            try
            {
                if (product == null) { return View(new ProductAddViewModel()); }

            

              
                var newProduct = new Car
                {
                    Brand = product.Brand,
                    Model = product.Model,
                    Year = product.Year,
                    FuelType = product.FuelType,
                    SeatCount = product.SeatCount,
                    GearBox = product.GearBox,
                    WeeklyPrice = product.WeeklyPrice,
                    DailyPrice = product.DailyPrice,
                    CategoryId = product.CategoryIds,
                    CreatedAt = DateTime.Now
                };

                await _dataContext.AddAsync(newProduct);
                await _dataContext.SaveChangesAsync();

                return RedirectToRoute("admin-product-list");
            }
            catch (Exception ex)
            {
                return RedirectToRoute("admin-product-add");
            }


        }

        [HttpGet("update/{id}", Name = "admin-product-update")]
        public async Task<IActionResult> Update(int id)
        {
            var product = await _dataContext.Cars.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null) return NotFound();



            return View(product);
        }

        [HttpPost("update/{id}", Name = "admin-product-update")]
        public async Task<IActionResult> Update(int id, [FromForm] Car newCar)
        {
            var car = await _dataContext.Cars.FirstOrDefaultAsync(x => x.Id == id);
            if (car == null) return NotFound();





            car.Brand = newCar.Brand;
            car.Model = newCar.Model;
            car.Year = newCar.Year;
            car.FuelType = newCar.FuelType;
            car.SeatCount = newCar.SeatCount;
            car.GearBox = newCar.GearBox;
            car.WeeklyPrice = newCar.WeeklyPrice;
            car.DailyPrice = newCar.DailyPrice;

            car.CreatedAt = DateTime.Now;

            await _dataContext.SaveChangesAsync();

            return RedirectToRoute("admin-product-list");
        }


        [HttpPost("delete/{id}", Name = "admin-product-delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var food = await _dataContext.Cars.FirstOrDefaultAsync(x => x.Id == id);
            if (food == null) return NotFound();




            try
            {
                await _dataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                return RedirectToRoute("admin-product-list");
            }


            return RedirectToRoute("admin-product-list");
        }
    }
}
