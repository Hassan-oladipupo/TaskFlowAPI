using Microsoft.EntityFrameworkCore;
using TaskFlowAPI.Model;
using TaskFlowAPI.Model;

namespace TaskFlowAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //Creating a dbset for the columns in our table
        public DbSet<MyTask> myTasks { get; set; }
        public DbSet<Login> login { get; set; }   
        public DbSet<Registration> register { get; set; }
    }
}
