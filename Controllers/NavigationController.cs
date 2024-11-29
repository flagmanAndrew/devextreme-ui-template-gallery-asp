using Microsoft.AspNetCore.Mvc;
using DevExtreme.Asp.Template.Gallery.Models.Routing;

namespace DevExtreme.Asp.Template.Gallery.Controllers
{
    public class NavigationController : Controller
    {
        public object GetNavigationData() {
            return RoutingData.Routes;
        }
        public IActionResult GetTasksComponent() {
            return ViewComponent("Tasks");
        }
        public IActionResult GetAboutComponent() {
            return ViewComponent("About");
        }
        public IActionResult GetNavigationRootComponent() {
            return ViewComponent("NavigationRoot");
        }
        public IActionResult GetAuthComponent() {
            return ViewComponent("Auth");
        }
    }
}
