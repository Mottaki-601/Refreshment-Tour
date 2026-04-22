using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tour.Models;

namespace tour.Controllers
{
    public class EventsController : Controller
    {
        private readonly TourDbContext _context;

        public EventsController(TourDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var events = await _context.Events.ToListAsync();
            return View(events);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Event ev)
        {
            if (!ModelState.IsValid)
                return View(ev);

            _context.Events.Add(ev);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Details(int id)
        {
            var ev = await _context.Events
                .Include(e => e.Members)
                .Include(e => e.Costs)
                .FirstOrDefaultAsync(e => e.EventId == id);

            if (ev == null) return NotFound();

            // Members + Costs filter done here
            ViewBag.Costs = ev.Costs.OrderByDescending(c => c.CostDate).ToList();

            return View(ev);
        }
    }
}