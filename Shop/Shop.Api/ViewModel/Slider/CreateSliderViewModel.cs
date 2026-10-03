namespace Shop.Api.ViewModel.Slider
{
    public class CreateSliderViewModel
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public IFormFile ImageFile { get; set; }
    }
    public class EditSliderViewModel
    {
        public long SliderId { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public IFormFile? ImageFile { get; set; }
    }
}
