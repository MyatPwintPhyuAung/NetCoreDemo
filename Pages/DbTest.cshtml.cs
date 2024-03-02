namespace NetCoreDemo.Pages
{
    public class DbTestModel : PageModel
    {
        //Dependency injection
        private readonly NetCoreDemoDbContext _context;
        public DbTestModel(NetCoreDemoDbContext context)
        {
            _context = context;
        }

        public List<Employee> Employees { get; set; }

        public async Task OnGet()
        {
            Employees = await _context.Employees.ToListAsync();
        }
    }
}
