using CarRent.Database.Models;

namespace CarRent.Areas.Client.ViewModels
{
    public class CarListViewModel
    {
        public CarListViewModel()
        {
            
        }
        public CarListViewModel(List<CarCateViewModel> cars, List<CateCarViewModel> categories)
        {
            Cars = cars;
            Categories = categories;
        }

        public List<CarCateViewModel> Cars { get; set; }
        public List<CateCarViewModel> Categories { get; set; }


    }


    public class CarCateViewModel
    {
        public CarCateViewModel(string brand, string model, int year, string fuelType,
            int seatCount, string gearBox, float weeklyPrice, float dailyPrice, DateTime createdAt)
        {
            Brand = brand;
            Model = model;
            Year = year;
            FuelType = fuelType;
            SeatCount = seatCount;
            GearBox = gearBox;
            WeeklyPrice = weeklyPrice;
            DailyPrice = dailyPrice;
            CreatedAt = createdAt;
        }

        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string FuelType { get; set; }
        public int SeatCount { get; set; }
        public string GearBox { get; set; }
        public float WeeklyPrice { get; set; }
        public float DailyPrice { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class CateCarViewModel
    {
        public CateCarViewModel(int orderId, string name)
        {
            OrderId = orderId;
            Name = name;
        }

        public int OrderId { get; set; }
        public string Name { get; set; }
    }
}



