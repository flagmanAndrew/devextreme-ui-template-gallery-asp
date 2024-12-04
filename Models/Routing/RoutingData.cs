using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DevExtreme.Asp.Template.Gallery.Models.Routing
{
    static class RoutingData {
        static string GetUrlByName(string viewName) {
            return string.Format("/Navigation/Get{0}Component/", viewName);
        }
        public static List<NavigationPathModel> Routes = new List<NavigationPathModel>() {
            new NavigationPathModel() {
                ViewName = "Tasks", Path = GetUrlByName("Tasks"), Text = "Tasks", Icon = "taskcomplete"
            },
            new NavigationPathModel() {
                ViewName = "About", Path = GetUrlByName("About"), Text = "About", Icon = "info"
            },
            new NavigationPathModel() {
                ViewName = "Auth", Path = GetUrlByName("Auth"), HideNavigation = true
            },
        };
    }
}
