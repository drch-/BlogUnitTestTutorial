namespace Xv.Blog.Model
{
    using System;
    
    public class Post : BaseEntity
    {
        public string Title { get; set; }

        public string Body { get; set; }

        public DateTime DatePublished { get; set; }

        public virtual Category Category { get; set; }
    }
}