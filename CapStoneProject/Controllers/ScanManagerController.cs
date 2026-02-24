using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CapStoneProject.Data;
using CapStoneProject.Models;

namespace CapStoneProject.Controllers
{
    public class ScanManagerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ScanManagerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ScanManager
        public async Task<IActionResult> Index()
        {
            return View(await _context.ScanLogs.ToListAsync());
        }

        // GET: ScanManager/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scanLog = await _context.ScanLogs
                .FirstOrDefaultAsync(m => m.LogID == id);
            if (scanLog == null)
            {
                return NotFound();
            }

            return View(scanLog);
        }

        // GET: ScanManager/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ScanManager/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LogID,TargetIPAddress,ScanTimestamp,OpenPortsDetected,ScanDurationMs")] ScanLog scanLog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(scanLog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(scanLog);
        }

        // GET: ScanManager/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scanLog = await _context.ScanLogs.FindAsync(id);
            if (scanLog == null)
            {
                return NotFound();
            }
            return View(scanLog);
        }

        // POST: ScanManager/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LogID,TargetIPAddress,ScanTimestamp,OpenPortsDetected,ScanDurationMs")] ScanLog scanLog)
        {
            if (id != scanLog.LogID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(scanLog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScanLogExists(scanLog.LogID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(scanLog);
        }

        // GET: ScanManager/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scanLog = await _context.ScanLogs
                .FirstOrDefaultAsync(m => m.LogID == id);
            if (scanLog == null)
            {
                return NotFound();
            }

            return View(scanLog);
        }

        // POST: ScanManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var scanLog = await _context.ScanLogs.FindAsync(id);
            if (scanLog != null)
            {
                _context.ScanLogs.Remove(scanLog);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScanLogExists(int id)
        {
            return _context.ScanLogs.Any(e => e.LogID == id);
        }
    }
}
