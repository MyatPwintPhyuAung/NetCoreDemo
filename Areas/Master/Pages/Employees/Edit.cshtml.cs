using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NetCoreDemo.Areas.Master.Pages.Employees
{
    public class EditModel : PageModel
    {
        private readonly NetCoreDemoDbContext _context;
        private readonly ILogger<CreateModel> _logger;

        public EditModel(NetCoreDemoDbContext context, ILogger<CreateModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public Employee InputModel { get; set; }
        public async Task<IActionResult> OnGet(string id)
        {
            //InputModel = new();
            //InputModel.EmployeeId = id;

            //Employee? existingEmployee = await _context.Employees.Where(x => x.EmployeeId == id).FirstOrDefaultAsync();
            Employee? existingEmployee = await _context.Employees.FirstOrDefaultAsync(x => x.EmployeeId == id);
            if (existingEmployee == null)
            {
                return NotFound();
            }

            InputModel = new()
            {
                EmployeeId = existingEmployee.EmployeeId,
                EmployeeName = existingEmployee.EmployeeName,
                JoinDate = existingEmployee.JoinDate,
                PhoneNumber = existingEmployee.PhoneNumber,
                DetailAddress = existingEmployee.DetailAddress,
                Gender = existingEmployee.Gender,
                CreatedOn = existingEmployee.CreatedOn,
                CreatedBy = existingEmployee.CreatedBy
            };

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            await Task.Delay(500);

            InputModel.UpdatedOn = DateTime.Now;
            InputModel.UpdatedBy = "mppa";
            _context.Employees.Update(InputModel);
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
