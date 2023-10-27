namespace CarRent.Areas.Client.ViewModels
{
    public class SliderListViewMOdel
    {
        public SliderListViewMOdel(string smallHeader, string header, string tittle)
        {
            SmallHeader = smallHeader;
            Header = header;
            Tittle = tittle;
        }

        public string SmallHeader { get; set; }
        public string Header { get; set; }
        public string Tittle { get; set; }
    }
}
