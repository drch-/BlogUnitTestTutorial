namespace Xv.Blog.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Xv.Blog.Data;
    using Xv.Blog.Model;

    public sealed class Configuration : DbMigrationsConfiguration<BlogContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BlogContext context)
        {
            if (!context.Posts.Any())
            {
                this.InitialSeed(context);
            }
        }

        private void InitialSeed(BlogContext context)
        {
            context.Subscribers.AddRange(
                new[]
                    {
                        new Subscriber() { Email = "dharrison@gmail.com", Name = "Daryl Harrison" },
                        new Subscriber() { Email = "d.harrison@gmail.com", Name = "Daryl R. C. Harrison" },
                        new Subscriber() { Email = "dh.arrison@gmail.com", Name = "D. Robert Harrison" },
                        new Subscriber() { Email = "dhar.rison@gmail.com", Name = "D. R. Clark Harrison" }
                    });

            var codeCategory = new Category() { Name = "Code" };
            var beerCategory = new Category() { Name = "Beer" };
            var languageCategory = new Category() { Name = "Deutsch lernen" };
            context.Categories.AddRange(new[] { codeCategory, beerCategory, languageCategory });

            context.Posts.AddRange(
                new[]
                    {
                        new Post()
                            {
                                Title = "German Beer vs Canadian Beer",
                                Body = DataHelper.GetLipsumHtml(),
                                Category = beerCategory,
                                DatePublished = DateTime.UtcNow.AddDays(-10),
                            },
                        new Post()
                            {
                                Title = "Unit Testing 101",
                                Body = DataHelper.GetLipsumHtml(),
                                Category = codeCategory,
                                DatePublished = DateTime.UtcNow.AddDays(-11),
                            },
                        new Post()
                            {
                                Title = "Wer fragt nicht bleibt dumm",
                                Body = DataHelper.GetLipsumHtml(),
                                Category = languageCategory,
                                DatePublished = DateTime.UtcNow.AddDays(-12),
                            }
                    });
            context.SaveChanges();
        }
    }
}