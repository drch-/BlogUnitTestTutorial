namespace Xv.Blog.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    public class AdminController : Controller
    {
        private readonly BlogService blogService;
        
        public AdminController(BlogService blogService)
        {
            this.blogService = blogService;
        }

        public AdminController()
            : this(new BlogService())
        {
        }

        public ActionResult Index([Bind(Prefix = "Form")] PostForm model)
        {
            var categories = this.blogService.GetCategories();
            var viewModel = new PostViewModel()
                                {
                                    Categories = categories.ToList(),
                                    Form = model ?? new PostForm()
                                };
            if (model != null)
            {
                var newPost = this.blogService.CreatePost(
                    model.Title,
                    model.Body,
                    model.CategoryId,
                    model.PublishedDate.Value);

                ViewBag.StatusMessage = string.Format("Post #{0} ({1}) Created", newPost.Id, newPost.Title);
            }

            return this.View(viewModel);
        }
    }
}