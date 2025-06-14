using Microsoft.AspNetCore.Mvc;
using DevExtremeVSTemplateMVC.DAL;
using DevExtremeVSTemplateMVC.Models;
using DevExtremeVSTemplateMVC.Utils;

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
        public IActionResult UpdateOrder([FromBody] KanbanOrderDto dto)
        {
            // For demo, use a static user id. Replace with real user id in production.
            var userId = "demo-user";
            var order = _context.KanbanOrders.FirstOrDefault(x => x.UserId == userId);
            if (order == null)
            {
                order = new KanbanOrder { UserId = userId };
                _context.KanbanOrders.Add(order);
            }
            order.Statuses = dto.Statuses;
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("GetOrder")]
        public IActionResult GetOrder()
        {
            var userId = "demo-user";
            var order = _context.KanbanOrders.FirstOrDefault(x => x.UserId == userId);
            return Ok(order?.Statuses ?? new[] { "Open", "In Progress", "Deferred", "Completed" });
        }
    }

    public class KanbanOrderDto
    {
        public string[] Statuses { get; set; }
    }
}