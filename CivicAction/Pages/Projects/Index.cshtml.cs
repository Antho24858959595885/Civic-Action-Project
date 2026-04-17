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
    public class IndexModel : PageModel
    {
        private readonly CivicAction.Data.CivicActionContext _context;

        public IndexModel(CivicAction.Data.CivicActionContext context)
        {
            _context = context;
        }

        public IList<Project> Project { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Project = await _context.Projects
                .Include(p => p.Student).ToListAsync();
        }
    }
}
