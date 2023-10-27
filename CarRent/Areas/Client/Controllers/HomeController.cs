using CarRent.Areas.Client.ViewModels;
using CarRent.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Areas.Client.Controllers
{
    [Area("client")]
    [Route("home")]
    public class HomeController : Controller
    {

        private DataContext _dataContext;

        public HomeController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet("~/")]
        [HttpGet("index", Name = "client-home-index")]
        public async  Task<IActionResult> Index()
        {
            var carslist = await _dataContext.Cars.Select(c => new CarCateViewModel(c.Brand, c.Model, c.Year, c.FuelType
                , c.SeatCount, c.GearBox, c.WeeklyPrice, c.DailyPrice, c.CreatedAt)).ToListAsync();

            var categorieslist = await _dataContext.Categories.Select(c => new CateCarViewModel(c.OrderId, c.Name)).ToListAsync();

            var model = new CarListViewModel
            {
                Cars = carslist,
                Categories = categorieslist,
            };

            
            return View(model);
        }
    }
}
