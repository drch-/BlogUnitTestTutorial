namespace Xv.Blog.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using Xv.Blog.Model;

    public interface IBaseRepository<T>
        where T : BaseEntity
    {
        T GetById(int id);

        IQueryable<T> All();

        IQueryable<T> Find(Expression<Func<T, bool>> predicate);

        void Add(T entity);

        int SaveChanges();
    }

    public abstract class BaseRepository<T> : IBaseRepository<T>
        where T : BaseEntity
    {
        protected BaseRepository(BlogContext ctx)
        {
            this.Context = ctx;
        }

        protected BlogContext Context { get; private set; }

        protected abstract DbSet<T> Set { get; }

        public T GetById(int id)
        {
            return this.Set.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<T> All()
        {
            return this.Set;
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return this.Set.Where(predicate);
        }

        public void Add(T entity)
        {
            this.Set.Add(entity);
        }

        public int SaveChanges()
        {
            return this.Context.SaveChanges();
        }
    }
}