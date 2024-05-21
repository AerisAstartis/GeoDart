using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GeoDart.Data;
using GeoDart.Models;

namespace GeoDart.Pages.Machines
{
    public class EditModel : PageModel
    {
        private readonly GeoDart.Data.GeoDartContext _context;

        public EditModel(GeoDart.Data.GeoDartContext context)
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

            var machine =  await _context.Machine.FirstOrDefaultAsync(m => m.Id == id);
            if (machine == null)
            {
                return NotFound();
            }
            Machine = machine;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Machine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MachineExists(Machine.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MachineExists(int id)
        {
          return (_context.Machine?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
