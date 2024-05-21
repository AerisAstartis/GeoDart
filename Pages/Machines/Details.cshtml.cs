using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GeoDart.Data;
using GeoDart.Models;

namespace GeoDart.Pages.Machines
{
    public class DetailsModel : PageModel
    {
        private readonly GeoDart.Data.GeoDartContext _context;

        public DetailsModel(GeoDart.Data.GeoDartContext context)
        {
            _context = context;
        }

      public Machine Machine { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Machine == null)
            {
                return NotFound();
            }

            var machine = await _context.Machine.FirstOrDefaultAsync(m => m.Id == id);
            if (machine == null)
            {
                return NotFound();
            }
            else 
            {
                Machine = machine;
            }
            return Page();
        }
    }
}
