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
    public class IndexModel : PageModel
    {
        private readonly GeoDart.Data.GeoDartContext _context;

        public IndexModel(GeoDart.Data.GeoDartContext context)
        {
            _context = context;
        }

        public IList<DrillingData> DrillingData { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.DrillingData != null)
            {
                DrillingData = await _context.DrillingData.ToListAsync();
            }
        }
    }
}
