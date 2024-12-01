using Microsoft.AspNetCore.Mvc;

namespace DevExtreme.Asp.Template.Gallery.ViewComponents
{
    public class AboutViewComponent : ViewComponent
    {
        public AboutViewComponent() {
        }
        public IViewComponentResult Invoke() {
            return View();
        }
    }
}
