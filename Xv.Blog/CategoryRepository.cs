namespace Xv.Blog
{
    using System.Data.Entity;

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
