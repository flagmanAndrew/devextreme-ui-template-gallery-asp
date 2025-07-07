using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtremeVSTemplateMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevExtremeVSTemplateMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About() {
            return View();
        }

        [Route("Home/PlanningTasks/{viewType}")]
        public IActionResult PlanningTasks(string viewType) {
            switch (viewType.ToLower()) {
                case "grid":
                    return View("../PlanningTasks/PlanningTasksGrid");
                case "kanban":
                    return View("../PlanningTasks/PlanningTasksKanban");
                case "gantt":
                    return View("../PlanningTasks/PlanningTasksGantt");
                case "":
                    return View("../PlanningTasks/PlanningTasksGrid");
                default:
                    return NotFound();
            }
        }

        //public IActionResult PlanningTasks() {
        //    return View("../PlanningTasks/PlanningTasksGrid");
        //}

        //public IActionResult PlanningTasksGrid() {
        //    return View("../PlanningTasks/PlanningTasksGrid");
        //}

        //public IActionResult PlanningTasksKanban() {
        //    return View("../PlanningTasks/PlanningTasksKanban");
        //}

        //public IActionResult PlanningTasksGantt() {
        //    return View("../PlanningTasks/PlanningTasksGantt");
        //}

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
