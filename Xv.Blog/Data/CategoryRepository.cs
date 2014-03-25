namespace Xv.Blog.Data
{
    using System.Data.Entity;
    using Xv.Blog.Model;

    public class CategoryRepository : BaseRepository<Category>
    {
        public CategoryRepository()
            : this(new BlogContext())
        {
        }

        public CategoryRepository(BlogContext ctx)
            : base(ctx)
        {
        }

        protected override DbSet<Category> Set
        {
            get
            {
                return this.Context.Categories;
            }
        }
    }
}
