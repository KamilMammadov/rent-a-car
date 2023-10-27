namespace CarRent.Areas.Admin.ViewModels.About
{
    public class AboutViewModel
    {
        public AboutViewModel(int id, string smallHeader, string header, string tittle)
        {
            Id = id;
            SmallHeader = smallHeader;
            Header = header;
            Tittle = tittle;
           
        }

        public AboutViewModel()
        {
            
        }

        public int Id { get; set; }
        public string SmallHeader { get; set; }
        public string Header { get; set; }
        public string Tittle { get; set; }
    }
}
