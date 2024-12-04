using Microsoft.AspNetCore.Mvc;

namespace DevExtreme.Asp.Template.Gallery.ViewComponents
{
    public class TasksViewComponent : ViewComponent
    {
        public TasksViewComponent() {
        }
        public IViewComponentResult Invoke() {
            return View();
        }
    }
}
