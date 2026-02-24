using CapStoneProject.Data;   
using CapStoneProject.Models; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IActionResult> History(string searchString)
        {
           
            var logs = from l in _context.ScanLogs
                       select l;

           
            if (!String.IsNullOrEmpty(searchString))
            {
                              
                logs = logs.Where(s => s.TargetIPAddress.Contains(searchString)
                                    || s.OpenPortsDetected.Contains(searchString));
            }
                       
            return View(await logs.OrderByDescending(s => s.ScanTimestamp).ToListAsync());
        }
    }
}