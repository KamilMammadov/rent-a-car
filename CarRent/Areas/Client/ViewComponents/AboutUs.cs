using CarRent.Areas.Client.ViewModels;
using CarRent.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Areas.Client.ViewComponents
{
    [ViewComponent(Name = "AboutUs")]

    public class AboutUs : ViewComponent
    {
        private readonly DataContext _dataContext;

        public AboutUs(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model =
                await _dataContext.Abouts.Select(s=>new SliderListViewMOdel(s.SmallHeader,s.Header,s.Tittle)).FirstOrDefaultAsync();


            return View(model);
        }
    }
}
