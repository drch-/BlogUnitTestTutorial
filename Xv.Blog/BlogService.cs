namespace Xv.Blog
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Mail;

    using Xv.Blog.Data;
    using Xv.Blog.Model;

    public class BlogService
    {
        private readonly PostRepository postRepository;

        private readonly SubscriberRepository subscriberRepository;

        private readonly CategoryRepository categoryRepository;

        ////public BlogService()
        ////    : this(new PostRepository(), new SubscriberRepository(), new CategoryRepository())
        ////{
        ////}

        public BlogService()
        {
            var ctx = new BlogContext();
            this.postRepository = new PostRepository(ctx);
            this.categoryRepository = new CategoryRepository(ctx);
            this.subscriberRepository = new SubscriberRepository(ctx);
        }

        public BlogService(PostRepository postRepository, SubscriberRepository subscriberRepository, CategoryRepository categoryRepository)
        {
            this.postRepository = postRepository;
            this.subscriberRepository = subscriberRepository;
            this.categoryRepository = categoryRepository;
        }

        public IEnumerable<Post> GetPosts(int take)
        {
            return this.postRepository.All().OrderByDescending(x => x.DatePublished).Take(take);
        }

        public Post CreatePost(Post post)
        {
            this.postRepository.Add(post);
            this.postRepository.SaveChanges();
        
            if (post.DatePublished <= DateTime.UtcNow)
            {
                this.NotifySubscribers(post);
            }

            return post;
        }

        public Post GetPostById(int id)
        {
            return this.postRepository.GetById(id);
        }

        public Post CreatePost(string title, string body, int categoryId, DateTime dateTime)
        {
            var category = this.categoryRepository.GetById(categoryId);
            var post = new Post() { Title = title, Body = body, Category = category, DatePublished = dateTime };
            return this.CreatePost(post);
        }
        
        public IEnumerable<Category> GetCategories()
        {
            return this.categoryRepository.All().ToList();
        }
        
        private void NotifySubscribers(Post post)
        {
            using (var client = new SmtpClient())
            {
                foreach (var subscriber in this.subscriberRepository.All())
                {
                    client.Send(
                        "dharrison@gmail.com",
                        subscriber.Email,
                        "New Blog Post",
                        "A new blog has been posted.  Title: " + post.Title);
                }
            }
        }
    }
}
