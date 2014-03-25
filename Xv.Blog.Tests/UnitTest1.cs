namespace Xv.Blog.Tests
{
    using System;
    using System.Linq;

    using Moq;

    using NUnit.Framework;

    using Xv.Blog.Data;
    using Xv.Blog.Model;


    [TestFixture]
    public class BlogServiceTests
    {
        private Mock<ISubscriberRepository> mockSubscriberRepository;
        private Mock<IPostRepository> mockPostRepository;
        private Mock<IMailer> mockMailer;

        [SetUp]
        public void Setup()
        {
            mockSubscriberRepository = new Mock<ISubscriberRepository>();
            mockPostRepository = new Mock<IPostRepository>();
            mockMailer = new Mock<IMailer>();
        }

        [Test]
        public void GetPublishedPosts_NoPublishedPosts_ReturnsEmptyList()
        {
            // arrange
            var thePosts = new[]
                               {
                                   new Post() { DatePublished = DateTime.Now.AddDays(1) },
                                   new Post() { DatePublished = DateTime.Now.AddDays(2) }
                               };

            mockPostRepository.Setup(x => x.All()).Returns(thePosts.AsQueryable);

            var blogService = new BlogService(mockPostRepository.Object, mockSubscriberRepository.Object, null, mockMailer.Object);

            int expectedPosts = 0;

            // act
            var posts = blogService.GetPublishedPosts(10);

            // assert
            Assert.AreEqual(expectedPosts, posts.Count());
        }

        [Test]
        public void GetPublishedPosts_PublishedPosts_ReturnsOnlyPublishedPosts()
        {
            // arrange
            var thePosts = new[]
                               {
                                   new Post() { DatePublished = DateTime.Now.AddDays(-1) },
                                   new Post() { DatePublished = DateTime.Now.AddDays(2) }
                               };


            var mockRepository = new Mock<IPostRepository>();
            mockRepository.Setup(x => x.All()).Returns(thePosts.AsQueryable);

            var blogService = new BlogService(mockRepository.Object, null, null, null);

            int expectedPosts = 1;

            // act
            var posts = blogService.GetPublishedPosts(10);

            // assert
            Assert.AreEqual(expectedPosts, posts.Count());
        }


        [Test]
        public void CreatePost_PostToday_StoresInDatabase()
        {
            // arrange
            var mockRepository = new Mock<IPostRepository>();
            var mockSubscriberRepository = new Mock<ISubscriberRepository>();
            mockSubscriberRepository.Setup(x => x.All()).Returns(new Subscriber[] { }.AsQueryable());

            var blogService = new BlogService(mockRepository.Object, mockSubscriberRepository.Object, null, null);


            var newPost = new Post()
                              {
                                  Body = "Hello",
                                  Category = null,
                                  DatePublished = DateTime.Today,
                                  Title = "Hello Title"
                              };
            // act
            blogService.CreatePost(newPost);

            // asset
            mockRepository.Verify(x => x.Add(newPost), Times.Once);
            mockRepository.Verify(x => x.SaveChanges(), Times.Once);
        }

        [Test]
        public void CreatePost_PostInFuture_DoesNotNotifySubscribers()
        {
            // arrange

            // act

            // asset
            Assert.Fail();
        }

        [Test]
        public void CreatePost_PostInPast_NotifiesSubscribers()
        {
            // arrange

            var mockSubscriberRepository = new Mock<ISubscriberRepository>();
            var mockRepository = new Mock<IPostRepository>(MockBehavior.Strict);
            mockRepository.Setup(x => x.Add(It.IsAny<Post>()));
            mockRepository.Setup(x => x.SaveChanges()).Returns(1);
            var mockMailer = new Mock<IMailer>();

            mockSubscriberRepository.Setup(x => x.All())
                .Returns(
                    () =>
                    new[] { new Subscriber() { Email = "sandro@crossvertise.com", Name = "Sandro" } }.AsQueryable());


            var blogService = new BlogService(
                mockRepository.Object,
                mockSubscriberRepository.Object,
                null,
                mockMailer.Object);


            var newPost = new Post()
                              {
                                  Body = "Hello",
                                  Category = null,
                                  DatePublished = DateTime.Today,
                                  Title = "Hello Title"
                              };

            // act
            blogService.CreatePost(newPost);

            // assert

            mockMailer.Verify(x => x.Send("dharrison@gmail.com", "sandro@crossvertise.com", It.IsAny<string>(), It.IsAny<string>()),Times.Once);
        }
    }
}