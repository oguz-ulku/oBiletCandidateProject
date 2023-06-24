using Microsoft.AspNetCore.Mvc.Rendering;


namespace DataModels.Model
{
    public class BusLocationViewModel
    {
        public int SelectedItemId { get; set; }
        public string Destination { get; set; }
        public string Origin { get; set; }

        public BusJourneyRequest JourneyModel { get; set; }
        public IEnumerable<SelectListItem> BusLocationItems { get; set; }
    }
}
