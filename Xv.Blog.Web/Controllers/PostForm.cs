namespace Xv.Blog.Web.Controllers
{
    using System;

    public class PostForm
    {
        public string Title { get; set; }

        public DateTime? PublishedDate { get; set; }
        
        public string Body { get; set; }
        
        public int CategoryId { get; set; }
    }
}