using CarRent.Areas.Client.ViewModels;
using CarRent.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace CarRent.Areas.Client.ViewComponents
{
    [ViewComponent(Name = "Sliders")]
    public class Sliders : ViewComponent
    {

        private readonly DataContext _dataContext;

        public Sliders(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _dataContext.Sliders.Select(s => new SliderListViewMOdel(s.SmallHeader,
                s.Header, s.Tittle)).FirstOrDefaultAsync();

            return View(model);
        }
    }
}
