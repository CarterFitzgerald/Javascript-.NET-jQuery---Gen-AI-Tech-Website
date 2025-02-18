using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Final_Assignment_Carter_Fitzgerald.Data;
using Final_Assignment_Carter_Fitzgerald.Models;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Final_Assignment_Carter_Fitzgerald.Controllers
{
    public class GenAIsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostingEnv;

        public GenAIsController(ApplicationDbContext context, IHostingEnvironment hostingEnv)
        {
            _context = context;
            _hostingEnv = (IWebHostEnvironment?)hostingEnv;
        }

        // GET: GenAIs
        public async Task<IActionResult> Index()
        {
            return _context.GenAIs != null ? 
                          View(await _context.GenAIs.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.GenAIs'  is null.");
        }

        // GET: GenAIs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GenAIs == null)
            {
                return NotFound();
            }

            var genAIs = await _context.GenAIs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (genAIs == null)
            {
                return NotFound();
            }

            return View(genAIs);
        }

        // GET: GenAIs/Create
        [Authorize(Roles = "admin, user")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: GenAIs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin, user")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GenAIName,Summary,ImgFile,Likes")] GenAIs genAIs, IFormFile ImgFile)
        {
            try
            {
                if (ImgFile != null)
                {
                    var fileName = Path.GetFileName(ImgFile.FileName);
                    if (fileName.Length > 4)
                    {
                        var fileNameWithoutExtension = fileName.Substring(0, fileName.Length - 4); // Remove the last 4 characters (the extension)
                        var filePath = Path.Combine(_hostingEnv.WebRootPath, "images", fileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await ImgFile.CopyToAsync(fileStream);
                        }

                        genAIs.ImageFileName = fileNameWithoutExtension;
                        genAIs.AnchorLink = "/GenAIs/#" + fileNameWithoutExtension;
                    }
                }

                ModelState.Remove("ImageFileName");
                ModelState.Remove("AnchorLink");


                if (ModelState.IsValid)
                {
                    _context.Add(genAIs);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"An error occurred: {ex.Message}";
            }

            return View(genAIs);
        }

        // GET: GenAIs/Edit/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GenAIs == null)
            {
                return NotFound();
            }

            var genAIs = await _context.GenAIs.FindAsync(id);
            if (genAIs == null)
            {
                return NotFound();
            }
            return View(genAIs);
        }

        // POST: GenAIs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GenAIName,Summary,ImgFile,Likes")] GenAIs editedgenAIs)
        {
            if (id != editedgenAIs.Id)
            {
                return NotFound();
            }

            ModelState.Remove("ImageFileName");
            ModelState.Remove("AnchorLink");

            if (ModelState.IsValid)
            {
                try
                {
                    // Load the existing GenAI entity from the database
                    var existingGenAI = await _context.GenAIs.FindAsync(id);
                    if (existingGenAI == null)
                    {
                        return NotFound();
                    }

                    // Update the properties of the existing entity with the values from the edited form
                    existingGenAI.GenAIName = editedgenAIs.GenAIName;
                    existingGenAI.Summary = editedgenAIs.Summary;

                    // Update the entity in the database
                    _context.Update(existingGenAI);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GenAIsExists(editedgenAIs.Id))
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
            return View(editedgenAIs);
        }

        // GET: GenAIs/Delete/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GenAIs == null)
            {
                return NotFound();
            }

            var genAIs = await _context.GenAIs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (genAIs == null)
            {
                return NotFound();
            }

            return View(genAIs);
        }

        // POST: GenAIs/Delete/5
        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GenAIs == null)
            {
                return Problem("Entity set 'ApplicationDbContext.GenAIs'  is null.");
            }
            var genAIs = await _context.GenAIs.FindAsync(id);
            if (genAIs != null)
            {
                _context.GenAIs.Remove(genAIs);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IncrementLikes(int itemId)
        {
            ModelState.Remove("ImageFileName");
            ModelState.Remove("AnchorLink");

            if (ModelState.IsValid)
            {
                // Load the entity from the database based on the ID
                var entity = await _context.GenAIs.FindAsync(itemId);
                if (entity != null)
                {
                    // Update the likes count
                    entity.Likes++;
                    await _context.SaveChangesAsync();
                }

                // Retrieve the updated likes count and store it in ViewData
                ViewData["UpdatedLikesCount"] = entity.Likes;
            }

            // Load the existing data and store it in ViewData
            var existingData = await _context.GenAIs.ToListAsync();
            ViewData["ExistingData"] = existingData;

            return RedirectToAction("Index");
        }

        private bool GenAIsExists(int id)
        {
          return (_context.GenAIs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
