using Microsoft.AspNetCore.Mvc;
using CapStoneProject.Data;   
using CapStoneProject.Models; 
using System.Linq;

namespace CapStoneProject.Controllers
{
    public class ScanController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ScanController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult NewScan()
        {
            return View();
        }

        public IActionResult History()
        {
            // Simple check to see if we have data
            var logs = _context.ScanLogs.OrderByDescending(l => l.ScanTimestamp).ToList();
            return View(logs);
        }
    }
}