using Microsoft.AspNetCore.Mvc;

namespace DevExtreme.Asp.Template.Gallery.ViewComponents
{
    public class AuthViewComponent : ViewComponent
    {
        public AuthViewComponent() {
        }
        public IViewComponentResult Invoke() {
            return View();
        }
    }
}
