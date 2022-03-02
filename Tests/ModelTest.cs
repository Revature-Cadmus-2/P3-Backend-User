using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Models;

namespace Tests
{
    public class ModelTest
    {
        [Fact]
        public void UserShouldCreate()
        {
            User test = new User();
            Assert.NotNull(test);
        }

        [Fact]
        public void UserShouldSetValidData()
        {
            List<FollowingPost> posts = new List<FollowingPost>();
            User test = new User() {
                Id = 1,
                Username = "testing",
                FollowingPosts = posts
            };

            Assert.Equal("testing", test.Username);
        }

        [Fact]
        public void FollowingPostShouldCreate()
        {
            FollowingPost test = new FollowingPost();
            Assert.NotNull(test);
        }

        [Fact]
        public void FollowingPostShouldSetValidData()
        {
            FollowingPost test = new FollowingPost(){
                Id = 1,
                Postname = "testing",
                RootId = 4,
                UserId =12
            };

            Assert.Equal("testing", test.Postname);
            Assert.Equal(4, test.RootId);
        }
        [Fact]
        public void ToStringShouldReturnTheCorrectFormat()
        {
            List<FollowingPost> posts = new List<FollowingPost>();
            FollowingPost post = new FollowingPost();
            post.Postname = "testpost";
            post.RootId = 1;
            post.UserId = 1;
            posts.Add(post);
            User test = new User()
            {
                Id = 1,
                Username = "testing",
                FollowingPosts = posts
            };

            string result = test.ToString();

            Assert.Equal("Username: testing Following 1 Posts", result);
        }
        
        [Fact]
        public void FollowingShouldCreate()
        {
            Following test = new Following();
            Assert.NotNull(test);
        }

        [Fact]
        public void FollowingShouldSetValidData()
        {
            
            Following test = new Following() {
                Id = 1,
                FollowingUserName = "testing",
                FollowingUserId = 2
            };

            Assert.Equal("testing", test.FollowingUserName);
        }
        
        [Fact]
        public void FollowedByShouldCreate()
        {
            FollowedBy test = new FollowedBy();
            Assert.NotNull(test);
        }

        [Fact]
        public void FollowedByShouldSetValidData()
        {
            FollowedBy test = new FollowedBy(){
                Id = 1,
                FollowersId = 2,
                FollowersUserName = "testing",
                UserId =12
            };

            Assert.Equal("testing", test.FollowersUserName);
            Assert.Equal(12, test.UserId);
            Assert.Equal(1, test.Id);
        }

        [Fact]
        public void NotificationsShouldCreate()
        {
            Notifications test = new Notifications();
            Assert.NotNull(test);
        }

        [Fact]
        public void NotificationsShouldSetValidData()
        {
            Notifications test = new Notifications(){
                Id = 1,
                FollowersId = 2,
                PostId = 3,
                UserId =12,
                CommentId = 4,
                message = "testing"
            };

            Assert.Equal("testing", test.message);
            Assert.Equal(12, test.UserId);
            Assert.Equal(1, test.Id);
        }

        [Fact]
        public void UserFollowersShouldBeAbleToSet()
        {
            User testUser = new User ();
            List<FollowedBy> testFollowers = new List<FollowedBy>();
            int testFollowersCount = 0;

            testUser.FollowingYou = testFollowers;

            Assert.NotNull(testUser.FollowingYou);
            Assert.Equal(testFollowersCount, testUser.FollowingYou.Count);
        }

        [Fact]
        public void UserNotificationsShouldBeAbleToSet()
        {
            User testUser = new User ();
            List<Notifications> testNotifications = new List<Notifications>();
            int testNotificationsCount = 0;

            testUser.NotificationList = testNotifications;

            Assert.NotNull(testUser.NotificationList);
            Assert.Equal(testNotificationsCount, testUser.NotificationList.Count);
        }

        [Fact]
        public void UserFollowingsShouldBeAbleToSet()
        {
            User testUser = new User ();
            List<Following> testFollowings = new List<Following>();
            int testFollowingsCount = 0;

            testUser.Followings = testFollowings;

            Assert.NotNull(testUser.Followings);
            Assert.Equal(testFollowingsCount, testUser.Followings.Count);
        }
    }
}