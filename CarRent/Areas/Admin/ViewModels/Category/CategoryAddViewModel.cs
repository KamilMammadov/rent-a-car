namespace CarRent.Areas.Admin.ViewModels.Category
{
    public class CategoryAddViewModel
    {
        public CategoryAddViewModel(int id, string name, int orderId)
        {
            Id = id;
            Name = name;
            OrderId = orderId;
        }

        public CategoryAddViewModel()
        {
            
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int OrderId { get; set; }
    }
}
