using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prod.CarParking.Data;
using Prod.CarParking.Models;

namespace Prod.CarParking.Controllers
{
    public class QueueController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<QueueController> _logger;

        public QueueController(ApplicationDbContext context, ILogger<QueueController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(QueueNumber obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Id == 0)
                {
                    _context.Add(obj);
                    _logger.LogInformation("QueueController Form: Added");
                }
                else
                {
                    _context.Update(obj);
                    _logger.LogInformation("QueueController Form: Update");
                }
                _context.SaveChanges();
                _logger.LogInformation("QueueController Form: Saved");

                return View();
            }
            return View(obj);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation("QueueController API: Try to Delete ID " + id);
            var model = _context.Queues.AsNoTracking().FirstOrDefault(u => u.Id == id);
            if (model == null)
            {
                return Json(new { status = "error", message = "Not found" });
            }
            _context.Queues.Remove(model);
            _context.SaveChanges();
            _logger.LogInformation($"QueueController API: ID {id} has been Deleted");
            return Json(new { status = "success" });
        }

    }
}
