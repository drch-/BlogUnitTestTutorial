namespace Xv.Blog
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Mail;

    using Xv.Blog.Data;
    using Xv.Blog.Model;


    public interface IMailer
    {
        void Send(string from, string to, string subject, string body);
    }

    public class SmtpMailer : IMailer
    {
        public void Send(string from, string to, string subject, string body)
        {
            using (var client = new SmtpClient())
            {
                client.Send(from, to, subject, body);
            }
        }
    }

    public class BlogService
    {
        private readonly IPostRepository postRepository;

        private readonly ISubscriberRepository subscriberRepository;

        private readonly CategoryRepository categoryRepository;

        private readonly IMailer mailer;

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

        public BlogService(
            IPostRepository postRepository,
            ISubscriberRepository subscriberRepository,
            CategoryRepository categoryRepository,
            IMailer mailer)
        {
            this.postRepository = postRepository;
            this.subscriberRepository = subscriberRepository;
            this.categoryRepository = categoryRepository;
            this.mailer = mailer;
        }

        public IEnumerable<Post> GetPosts(int take)
        {
            return this.postRepository.All().OrderByDescending(post => post.DatePublished).Take(take);
        }

        /// <summary>
        /// Returns all posts that are posted in the past, eg less than DateTime.Now
        /// </summary>
        public IEnumerable<Post> GetPublishedPosts(int take)
        {
            return this.postRepository.All().Where(post => post.DatePublished < DateTime.Now);
        }

        public bool IsPublished(Post p)
        {
            return p.DatePublished < DateTime.UtcNow;
        }

        public Post CreatePost(Post post)
        {
            if (post == null)
            {
                throw new ArgumentNullException("post");
            }

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
            foreach (var subscriber in this.subscriberRepository.All())
            {
                this.mailer.Send(
                    "dharrison@gmail.com",
                    subscriber.Email,
                    "New Blog Post",
                    "A new blog has been posted.  Title: " + post.Title);
            }
        }
    }
}

