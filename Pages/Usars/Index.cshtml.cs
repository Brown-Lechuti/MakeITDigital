using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MakeITDigital.Models;

namespace MakeITDigital.Pages.Usars
{
    public class IndexModel : PageModel
    {
        private readonly MakeITDigital.Models.MarketMediaContext _context;

        public IndexModel(MakeITDigital.Models.MarketMediaContext context)
        {
            _context = context;
        }

        public IList<User> User { get;set; }

        public async Task OnGetAsync()
        {
            User = await _context.Users.ToListAsync();
        }
    }
}
