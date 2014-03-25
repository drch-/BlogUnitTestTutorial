namespace Xv.Blog.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        private readonly BlogService blogService;
        
        public HomeController(BlogService blogService)
        {
            this.blogService = blogService;
        }

        public HomeController()
            : this(new BlogService())
        {
        }

        public ActionResult Index()
        {
            var posts = this.blogService.GetPosts(10).ToList();
            return this.View(posts);
        }

        public ActionResult Post(int id)
        {
            var post = this.blogService.GetPostById(id);
            
            if (post == null)
            {
                return this.HttpNotFound();
            }

            return this.View(post);
        }
    }
}