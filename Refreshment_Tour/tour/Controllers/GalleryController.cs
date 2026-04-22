using Microsoft.AspNetCore.Mvc;

namespace tour.Controllers
{
    public class GalleryController : Controller
    {
        private readonly IWebHostEnvironment _he;

        public GalleryController(IWebHostEnvironment _he)
        {
            this._he = _he;
        }

        public IActionResult Index()
        {
            string folderPath = Path.Combine(_he.WebRootPath, "Gallery");

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            var images = Directory.GetFiles(folderPath)
                                  .Select(Path.GetFileName)
                                  .ToList();

            return View(images);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(IFormFile ImageFile)
        {
            if (ImageFile != null && ImageFile.Length > 0)
            {
                string folder = Path.Combine(_he.WebRootPath, "Gallery");
                if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImageFile.FileName);
                string fullPath = Path.Combine(folder, fileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(stream);
                }
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
