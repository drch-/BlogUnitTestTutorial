﻿namespace Xv.Blog.Web.Controllers
{
    using System.Collections.Generic;

    public class PostViewModel
    {
        public PostViewModel()
        {
            this.Form = new PostForm();
        }
    
        public PostForm Form { get; set; }
        
        public List<Category> Categories { get; set; }
    }
}