using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CivicAction.Data;
using CivicAction.Models;

namespace CivicAction.Pages.Updates
{
    public class IndexModel : PageModel
    {
        private readonly CivicAction.Data.CivicActionContext _context;

        public IndexModel(CivicAction.Data.CivicActionContext context)
        {
            _context = context;
        }

        public IList<Update> Update { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Update = await _context.Updates
                .Include(u => u.Project).ToListAsync();
        }
    }
}
