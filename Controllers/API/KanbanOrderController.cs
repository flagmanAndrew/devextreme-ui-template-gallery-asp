using DevExtremeVSTemplateMVC.DAL;
using Microsoft.AspNetCore.Mvc;

namespace DevExtremeVSTemplateMVC.Controllers { 

    [ApiController]
    [Route("api/[controller]")]
    public class KanbanOrderController : Controller
    {
        private readonly DemoDbContext _context;

        public KanbanOrderController(DemoDbContext context)
        {
            _context = context;
        }

        [HttpPost("UpdateOrder")]
        public IActionResult UpdateOrder([FromBody] string[] statuses) {
            if (statuses == null || statuses.Length == 0)
                return BadRequest("Statuses are missing");

            var taskLists = _context.TaskLists
                .Where(tl => statuses.Contains(tl.ListName))
                .ToList();

            for (int i = 0; i < statuses.Length; i++) {
                var status = statuses[i];
                var taskList = taskLists.FirstOrDefault(tl => tl.ListName == status);
                if (taskList != null) {
                    taskList.OrderIndex = i + 1;
                }
            }
            _context.SaveChanges();
            return Ok();
        }
    }
}