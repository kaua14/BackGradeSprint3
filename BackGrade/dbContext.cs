namespace BackGrade
{
    using BackGrade.Models;
    using Microsoft.EntityFrameworkCore;

    public class dbContext : DbContext
    {
        public dbContext(DbContextOptions<dbContext> options) : base(options) { }

        public DbSet<ReclameAquiReview> ReclameAquiReviews { get; set; }
        public DbSet<ProdutoModel> Produtos { get; set; }

    }

}
