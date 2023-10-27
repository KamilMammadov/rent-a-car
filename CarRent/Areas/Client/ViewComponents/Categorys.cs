using CarRent.Areas.Client.ViewModels;
using CarRent.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Areas.Client.ViewComponents
{
    [ViewComponent(Name = "Categorys")]
    public class Categorys : ViewComponent
    {

        private readonly DataContext _dataContext;

        public Categorys(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model =
                await _dataContext.Categories.OrderBy(c => c.OrderId)
                .Select(c => new CateCarViewModel(c.OrderId, c.Name)).ToListAsync();


            return View(model);
        }
    }
}
