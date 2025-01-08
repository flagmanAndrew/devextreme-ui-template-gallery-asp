using Microsoft.AspNetCore.Mvc;

namespace DevExtreme.Asp.Template.Gallery.ViewComponents
{
    public class NavigationRootViewComponent : ViewComponent
    {
        public NavigationRootViewComponent() {
        }
        public IViewComponentResult Invoke() {
            return View();
        }
    }
}
