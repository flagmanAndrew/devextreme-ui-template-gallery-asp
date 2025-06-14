using DevExtremeVSTemplateMVC.DAL;
using DevExtremeVSTemplateMVC.Models;
using DevExtremeVSTemplateMVC.Utils;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DevExtremeVSTemplateMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly DemoDbContext _context;

        public HomeController(DemoDbContext context, IHttpContextAccessor accessor)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return RedirectToAction("PlanningTasks", "Home");
        }

        public IActionResult PlanningTasks() {
            return View("../PlanningTasks/PlanningTasks");
        }

        public IActionResult UserProfile()
        {
            return View("../CommonUserProfile/UserProfile", ProfileData.Profiles[0]);
        }

        public IActionResult Login() {
            return View("../Auth/Login");
        }

        public IActionResult SignUp() {
            return View("../Auth/SignUp");
        }

        public IActionResult ForgotPassword() {
            return View("../Auth/ForgotPassword");
        }

        [HttpPost]
        public IActionResult TaskMainSortable()
        {
            var tasks = _context.Tasks.ToList();


            Console.WriteLine(
                "Loaded: " + string.Join(
                    ", ",
                    _context.Tasks
                        .Where(t => t.Status == "Deferred")
                        .Select(t => $"TaskId: {t.TaskId}, Text: {t.Text}, Status: {t.Status}")
                )
            );

            var userId = "demo-user";
            var order = _context.KanbanOrders.FirstOrDefault(x => x.UserId == userId);
            ViewBag.StatusOrder = order?.Statuses ?? new[] { "Open", "In Progress", "Deferred", "Completed" };

            return PartialView("../PlanningTasks/Kanban/_TaskMainSortable", tasks);
        }

        #region Partial Views
        public ActionResult GetPlanningTasksGrid() {
            return PartialView("../PlanningTasks/_PlanningTasksGrid");
        }
        public ActionResult GetPlanningTasksGantt() {
            return PartialView("../PlanningTasks/_PlanningTasksGantt");
        }
        public ActionResult GetPlanningTasksKanban() {
            return PartialView("../PlanningTasks/_PlanningTasksKanban");
        }
        #endregion

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View();
        }
    }
}
