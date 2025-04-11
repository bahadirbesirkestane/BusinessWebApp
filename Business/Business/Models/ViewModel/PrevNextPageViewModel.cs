using Business.EntityLayer.Concrete;

namespace Business.Models.ViewModel
{
    public class PrevNextPageViewModel
    {
        public Product PreviousProduct { get; set; }
        public Product NextProduct { get; set; }
    }
}
