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
    public class DeleteModel : PageModel
    {
        private readonly GeoDart.Data.GeoDartContext _context;

        public DeleteModel(GeoDart.Data.GeoDartContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Machine == null)
            {
                return NotFound();
            }
            var machine = await _context.Machine.FindAsync(id);

            if (machine != null)
            {
                Machine = machine;
                _context.Machine.Remove(Machine);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
