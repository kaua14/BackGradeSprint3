namespace BackGrade
{
    using BackGrade.Models;
    using Microsoft.EntityFrameworkCore;

    public class dbContext : DbContext
    {
        public dbContext(DbContextOptions<dbContext> options) : base(options) { }

        public DbSet<Feedback> T_FEEDBACK { get; set; }
        public DbSet<Cliente> T_CLIENTE { get; set; }
    }

}
