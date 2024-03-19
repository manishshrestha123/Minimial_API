using Microsoft.EntityFrameworkCore;


namespace RazorPageMinimialAPI.Model
{
    public class MyDbContext: DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public DbSet<Student> StudentRecords { get; set; }
        
    }
}
