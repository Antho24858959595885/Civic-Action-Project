using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CivicAction.Data;
using CivicAction.Models;

namespace CivicAction.Pages.Verifications
{
    public class DeleteModel : PageModel
    {
        private readonly CivicAction.Data.CivicActionContext _context;

        public DeleteModel(CivicAction.Data.CivicActionContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Verification Verification { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var verification = await _context.Verifications.FirstOrDefaultAsync(m => m.Id == id);

            if (verification is not null)
            {
                Verification = verification;

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

            var verification = await _context.Verifications.FindAsync(id);
            if (verification != null)
            {
                Verification = verification;
                _context.Verifications.Remove(Verification);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
