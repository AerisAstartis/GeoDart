using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GeoDart.Data;
using GeoDart.Models;

namespace GeoDart.Pages.DrillData
{
    public class CreateModel : PageModel
    {
        private readonly GeoDart.Data.GeoDartContext _context;

        public CreateModel(GeoDart.Data.GeoDartContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public DrillingData DrillingData { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.DrillingData == null || DrillingData == null)
            {
                return Page();
            }

            _context.DrillingData.Add(DrillingData);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
