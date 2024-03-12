using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NetCoreDemo.Areas.Master.Pages.Employees
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
        public Employee InputModel { get; set; }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Please Fill the form!");
                return Page();
            }
            else
            {
                InputModel.CreatedOn = DateTime.Now;
                InputModel.CreatedBy = "mppa";
                _context.Employees.Add(InputModel);
                int res = await _context.SaveChangesAsync();
                if (res > 0)
                {
                    return RedirectToPage("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error During Saved!");
                    return Page();
                }

            }

        }
    }
}
