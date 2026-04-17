using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CivicAction.Data;
using CivicAction.Models;

namespace CivicAction.Pages.Updates
{
    public class CreateModel : PageModel
    {
        private readonly CivicAction.Data.CivicActionContext _context;

        public CreateModel(CivicAction.Data.CivicActionContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ProjectID"] = new SelectList(_context.Projects, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Update Update { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Updates.Add(Update);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
