using CarRent.Areas.Admin.ViewModels.Category;

namespace CarRent.Areas.Admin.ViewModels.Product
{
    public class ProductAddViewModel
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string FuelType { get; set; }
        public int SeatCount { get; set; }
        public string GearBox { get; set; }
        public float WeeklyPrice { get; set; }
        public float DailyPrice { get; set; }
        public int CategoryIds { get; set; }
        public List<CategoryListViewModel> Categories { get; set; }


    }
}
