using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GeoDart.Data;
using GeoDart.Models;

namespace GeoDart.Pages.Machines
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
        public Machine Machine { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Machine == null || Machine == null)
            {
                return Page();
            }

            _context.Machine.Add(Machine);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
