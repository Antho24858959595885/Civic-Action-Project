using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CivicAction.Data;
using CivicAction.Models;

namespace CivicAction.Pages.Projects
{
    public class DetailsModel : PageModel
    {
        private readonly CivicAction.Data.CivicActionContext _context;

        public DetailsModel(CivicAction.Data.CivicActionContext context)
        {
            _context = context;
        }

        public Project Project { get; set; } = default!;
        public List<Update> Updates { get; set; } = new();

        [BindProperty]
        public Update NewUpdate { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .Include(p => p.Updates)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (project is not null)
            {
                Project = project;
                Updates = project.Updates.ToList();
                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .Include(p => p.Updates)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (project is null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                Project = project;
                Updates = project.Updates.ToList();
                return Page();
            }

            try
            {
                NewUpdate.ProjectID = project.Id;
                NewUpdate.StudentID = project.StudentID;
                _context.Updates.Add(NewUpdate);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding update: {ex.Message}");
                ModelState.AddModelError("", $"Error adding update: {ex.Message}");
                Project = project;
                Updates = project.Updates.ToList();
                return Page();
            }

            return RedirectToPage(new { id });
        }
    }
}
