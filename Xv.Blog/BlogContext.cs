namespace Xv.Blog
{
    using System.Data.Entity;

    public class BlogContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Subscriber> Subscribers { get; set; }
    }
}