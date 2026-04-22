using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using tour.Models;
using tour.Models.ViewModel;

namespace tour.Controllers
{
    public class MembersController : Controller
    {
        private readonly TourDbContext _context;
        private readonly IWebHostEnvironment _he;

        public MembersController(TourDbContext context, IWebHostEnvironment he)
        {
            _context = context;
            _he = he;
        }

        // GET: Members
        public async Task<IActionResult> Index(int? eventId)
        {
            var membersQuery = _context.Members.Include(m => m.Course).AsQueryable();

            if (eventId.HasValue)
            {
                membersQuery = membersQuery.Where(m => m.EventId == eventId.Value);
                ViewBag.CurrentEvent = await _context.Events.FindAsync(eventId.Value);
            }

            var members = await membersQuery.ToListAsync();
            var costs = await _context.Costs.ToListAsync();

            ViewBag.TotalCost = costs.Sum(c => c.CostAmount);
            ViewBag.Costs = costs;

            return View(members);
        }

        // GET: Members/Create
        public IActionResult Create(int? eventId)
        {
            ViewBag.Events = _context.Events.ToList();
            ViewBag.courses = _context.Courses.ToList();

            var vm = new MemberVM
            {
                EventId = eventId ?? 0 
            };

            return View(vm);
        }

        // POST: Members/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MemberVM memberVM, int[] CourseId)
        {
            if (memberVM.EventId <= 0)
            {
                ModelState.AddModelError("EventId", "Please select an event.");
            }

            if (!ModelState.IsValid)
            {
                ViewBag.courses = _context.Courses.ToList();
                ViewBag.Events = _context.Events.ToList();
                return View(memberVM);
            }

            string imagePath = null;
            if (memberVM.ImageFile != null)
            {
                string webroot = _he.WebRootPath;
                string uniqueFileName = Guid.NewGuid() + "_" + Path.GetFileName(memberVM.ImageFile.FileName);
                string fileToSave = Path.Combine(webroot, "Images", uniqueFileName);
                using var stream = new FileStream(fileToSave, FileMode.Create);
                await memberVM.ImageFile.CopyToAsync(stream);
                imagePath = "/Images/" + uniqueFileName;
            }

            foreach (var cid in CourseId)
            {
                var parameters = new[]
                {
            new SqlParameter("@Name", memberVM.Name),
            new SqlParameter("@RollNo", memberVM.RollNo),
            new SqlParameter("@CourseId", cid),
            new SqlParameter("@Amount", memberVM.Amount),
            new SqlParameter("@PaymentDone", memberVM.PaymentDone),
            new SqlParameter("@Image", (object?)imagePath ?? DBNull.Value),
            new SqlParameter("@EventId", memberVM.EventId) 
        };

                await _context.Database.ExecuteSqlRawAsync(
                    "EXEC sp_InsertMember @Name, @RollNo, @CourseId, @Amount, @PaymentDone, @Image, @EventId",
                    parameters
                );
            }

            return RedirectToAction("Details", "Events", new { id = memberVM.EventId });
        }

        // GET: Members/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var member = await _context.Members.FindAsync(id);
            if (member == null) return NotFound();

            var memberVM = new MemberVM
            {
                MemberId = member.MemberId,
                Name = member.Name,
                RollNo = member.RollNo,
                Amount = member.Amount,
                Image = member.Image,
                CourseId = member.CourseId,
                PaymentDone = member.PaymentDone,
                EventId = member.EventId
            };

            ViewBag.courses = _context.Courses.ToList();
            ViewBag.Events = _context.Events.ToList();
            return View(memberVM);
        }

        // POST: Members/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MemberVM memberVM)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.courses = _context.Courses.ToList();
                ViewBag.Events = _context.Events.ToList();
                return View(memberVM);
            }

            string imagePath = memberVM.Image;
            if (memberVM.ImageFile != null)
            {
                string webroot = _he.WebRootPath;
                string folder = "Images";
                string uniqueFileName = Guid.NewGuid() + "_" + Path.GetFileName(memberVM.ImageFile.FileName);
                string fileToSave = Path.Combine(webroot, folder, uniqueFileName);

                using var stream = new FileStream(fileToSave, FileMode.Create);
                await memberVM.ImageFile.CopyToAsync(stream);
                imagePath = "/" + folder + "/" + uniqueFileName;
            }

            var parameters = new[]
            {
                new SqlParameter("@MemberId", memberVM.MemberId),
                new SqlParameter("@Name", memberVM.Name),
                new SqlParameter("@RollNo", memberVM.RollNo),
                new SqlParameter("@CourseId", memberVM.CourseId),
                new SqlParameter("@Amount", memberVM.Amount),
                new SqlParameter("@PaymentDone", memberVM.PaymentDone),
                new SqlParameter("@Image", (object?)imagePath ?? DBNull.Value),
                new SqlParameter("@EventId", memberVM.EventId)
            };

            await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_UpdateMember @MemberId, @Name, @RollNo, @CourseId, @Amount, @PaymentDone, @Image, @EventId",
                parameters
            );

            return RedirectToAction("Details", "Events", new { id = memberVM.EventId });
        }

        // POST: Members/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var member = await _context.Members.FindAsync(id);

                if (member == null)
                {
                    return NotFound();
                }

                int eventId = member.EventId;

                var param = new SqlParameter("@MemberId", id);
                await _context.Database.ExecuteSqlRawAsync(
                    "EXEC sp_DeleteMember @MemberId", param);

                TempData["SuccessMessage"] = "Member deleted successfully!";

                return RedirectToAction("Details", "Events", new { id = eventId });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Delete failed: " + ex.Message;

                return RedirectToAction(nameof(Index));
            }
        }

        // GET: AddCost
        public async Task<IActionResult> AddCost()
        {
            ViewBag.Costs = await _context.Costs.OrderByDescending(c => c.CostDate).ToListAsync();
            ViewBag.Events = await _context.Events.ToListAsync();
            return View();
        }

        // POST: AddCost
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCost(Cost cost)
        {
            if (cost.EventId == 0)
            {
                ModelState.AddModelError("EventId", "Please select a valid event.");
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Costs = await _context.Costs.OrderByDescending(c => c.CostDate).ToListAsync();
                ViewBag.Events = await _context.Events.ToListAsync();
                return View(cost);
            }

            _context.Costs.Add(cost);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Cost item added successfully!";

            return RedirectToAction("Details", "Events", new { id = cost.EventId });
        }

        // POST: DeleteCost
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCost(int id)
        {
            var cost = await _context.Costs.FindAsync(id);

            if (cost == null)
            {
                return NotFound();
            }

            int? eventId = cost.EventId; 

            _context.Costs.Remove(cost);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", "Events", new { id = eventId });
        }
    }
}