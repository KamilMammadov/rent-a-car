namespace CarRent.Areas.Admin.ViewModels.Category
{
    public class CategoryListViewModel
    {
        public CategoryListViewModel(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }    
    }
}
