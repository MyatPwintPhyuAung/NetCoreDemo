using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NetCoreDemo.Areas.Master.Pages.Counters
{
    public class CreateModel : PageModel
    {
        private readonly NetCoreDemoDbContext _context;
        private readonly ILogger<CreateModel> _logger;

        public CreateModel(NetCoreDemoDbContext context, ILogger<CreateModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public Counter InputModel { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Please Enter ID & Name");
                return Page();
            }
            else
            {
                try
                {
                    _context.Counters.Add(InputModel);
                    int res = await _context.SaveChangesAsync();
                    if (res == 0)
                    {
                        ModelState.AddModelError(string.Empty, "Successfully Failed");
                    }

                    return RedirectToPage("./Index");
                }
                catch (Exception ex)
                {
                    _logger.LogError("Error message: {message}", ex.Message);
                    ModelState.AddModelError(string.Empty, ex.Message);

                    return Page();
                }

            }
        }
    }

}
