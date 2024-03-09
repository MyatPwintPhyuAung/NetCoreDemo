using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NetCoreDemo.Areas.Master.Pages.Counters
{
    public class IndexModel : PageModel
    {
        private readonly NetCoreDemoDbContext _context; // decalare variable

        public IndexModel(NetCoreDemoDbContext context)    //Declare parameter
        {
            _context = context;
        }

        public List<Counter> Counters { get; set; } // Declare Variable (Behind Code)

        public async Task OnGetAsync()
        {
            Counters = await _context.Counters.ToListAsync();
        }
    }
}
