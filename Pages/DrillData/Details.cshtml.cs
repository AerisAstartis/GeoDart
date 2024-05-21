using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GeoDart.Data;
using GeoDart.Models;

namespace GeoDart.Pages.DrillData
{
    public class DetailsModel : PageModel
    {
        private readonly GeoDart.Data.GeoDartContext _context;

        public DetailsModel(GeoDart.Data.GeoDartContext context)
        {
            _context = context;
        }

      public DrillingData DrillingData { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.DrillingData == null)
            {
                return NotFound();
            }

            var drillingdata = await _context.DrillingData.FirstOrDefaultAsync(m => m.Id == id);
            if (drillingdata == null)
            {
                return NotFound();
            }
            else 
            {
                DrillingData = drillingdata;
            }
            return Page();
        }
    }
}
