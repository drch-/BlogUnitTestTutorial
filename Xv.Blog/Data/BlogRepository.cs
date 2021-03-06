﻿namespace Xv.Blog.Data
{
    using System;
    using System.Linq;
    using Xv.Blog.Model;

    public class PostRepository : BaseRepository<Post>
    {
        public PostRepository()
            : this(new BlogContext())
        {
        }

        public PostRepository(BlogContext ctx)
            : base(ctx)
        {
        }

        protected override System.Data.Entity.DbSet<Post> Set
        {
            get
            {
                return Context.Posts;
            }
        }

        public IQueryable<Post> GetPublishedPosts()
        {
            return this.Find(x => x.DatePublished >= DateTime.UtcNow);
        }
    }
}
