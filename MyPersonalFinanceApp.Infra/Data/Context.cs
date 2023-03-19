using Microsoft.EntityFrameworkCore;
using MyPersonalFinanceApp.Domain.Entities;

namespace MyPersonalFinanceApp.Infra.Data
{
    public class Context : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Tarefa> Tasks { get; set; }

        public Context() : base() { }

        private static DbContextOptions GetOptions(string connectionString) => SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), "Server=localhost,1433;Database=MyPersonalFinanceApp;User Id=sa;Password=Biel1236@.").Options;

        public Context(string connectionString) : base(GetOptions(connectionString)) { }


        public Context(DbContextOptions<Context> dbContextOptions) : base(dbContextOptions) { }




        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlServer("Server=localhost,1433;Database=MyPersonalFinanceApp;User Id=sa;Password=Biel1236@.");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


        }
    }
}
