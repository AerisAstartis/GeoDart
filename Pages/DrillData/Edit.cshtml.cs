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

namespace GeoDart.Pages.DrillData
{
    public class EditModel : PageModel
    {
        private readonly GeoDart.Data.GeoDartContext _context;

        public EditModel(GeoDart.Data.GeoDartContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DrillingData DrillingData { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.DrillingData == null)
            {
                return NotFound();
            }

            var drillingdata =  await _context.DrillingData.FirstOrDefaultAsync(m => m.Id == id);
            if (drillingdata == null)
            {
                return NotFound();
            }
            DrillingData = drillingdata;
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

            _context.Attach(DrillingData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrillingDataExists(DrillingData.Id))
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

        private bool DrillingDataExists(int id)
        {
          return (_context.DrillingData?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
