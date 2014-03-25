namespace Xv.Blog.Data
{
    using System.Data.Entity;
    using Xv.Blog.Model;

    public class SubscriberRepository : BaseRepository<Subscriber>
    {
        public SubscriberRepository()
            : this(new BlogContext())
        {
        }

        public SubscriberRepository(BlogContext ctx)
            : base(ctx)
        {
        }

        protected override DbSet<Subscriber> Set
        {
            get
            {
                return Context.Set<Subscriber>();
            }
        }
    }
}
