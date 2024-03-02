namespace NetCoreDemo.Areas.Master.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly NetCoreDemoDbContext _context;
        public IndexModel(NetCoreDemoDbContext context)
        {
            _context = context;
        }

        public List<Employee> EmployeeList { get; set; }

        public async Task OnGet()
        {
            EmployeeList = await _context.Employees.ToListAsync();
        }
    }
}
