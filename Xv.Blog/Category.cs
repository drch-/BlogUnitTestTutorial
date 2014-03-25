namespace Xv.Blog
{
    using System.Collections.Generic;

    public class Category : BaseEntity
    {
        private ISet<Post> posts; 

        public Category()
        {
            this.posts = new HashSet<Post>();
        }

        public string Name { get; set; }

        public virtual ISet<Post> Posts
        {
            get
            {
                return this.posts;
            }

            set
            {
                this.posts = value;
            }
        }
    }
}