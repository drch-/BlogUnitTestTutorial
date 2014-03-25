namespace Xv.Blog.Data
{
    using System.Data.Entity;
    using Xv.Blog.Model;

    public class BlogContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Subscriber> Subscribers { get; set; }
    }
}