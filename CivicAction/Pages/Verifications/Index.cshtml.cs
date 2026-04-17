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
    public class IndexModel : PageModel
    {
        private readonly CivicAction.Data.CivicActionContext _context;

        public IndexModel(CivicAction.Data.CivicActionContext context)
        {
            _context = context;
        }

        public IList<Verification> Verification { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Verification = await _context.Verifications
                .Include(v => v.Admin)
                .Include(v => v.Project).ToListAsync();
        }
    }
}
