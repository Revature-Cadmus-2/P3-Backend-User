using DL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Models;

namespace Tests
{
    public class DLTests
    {
        private DbContextOptions<UserDB> options;

        public DLTests()
        {
            options = new DbContextOptionsBuilder<UserDB>().UseSqlite("Filename= Test.db").Options;
            Seed();
        }

        [Fact]
        public async void GetAllUsersShouldGetAllUsers()
        {
            using var context = new UserDB(options);

            IRepo repo = new DBRepo(context);

            List<User> users =  await repo.GetAllUsersAsync();

            Assert.NotNull(users);
            Assert.Equal(2, users.Count);
        }

        [Fact]
        public async void AddingUserShouldAddUser()
        {
            using(var context = new UserDB(options))
            {
                IRepo repo = new DBRepo(context);
                User userToAdd = new User()
                {
                    Id = 3,
                    Username = "Test3"
                };

                userToAdd = (User) await repo.AddObjectAsync(userToAdd);

            }
            using(var context = new UserDB(options))
            {
                User user = await context.Users.FirstOrDefaultAsync(u => u.Id == 3);

                Assert.NotNull(user);
                Assert.Equal("Test3", user.Username);
            }
        }

        [Fact]
        public async void DeletingUserShoulddeleteUser()
        {
            using (var context = new UserDB(options))
            {
                IRepo repo = new DBRepo(context);
                User userToAdd = new User()
                {
                    Id = 4,
                    Username = "Test4"
                };

                userToAdd = (User)await repo.AddObjectAsync(userToAdd);

                User userToDelete = new User()
                {
                    Id = 4,
                    Username = "Test4"
                };

                await repo.DeleteObjectAsync(userToDelete);

            }
            using (var context = new UserDB(options))
            {
                User user = await context.Users.FirstOrDefaultAsync(u => u.Id == 4);
                IRepo repo = new DBRepo(context);
                List<User> users = await repo.GetAllUsersAsync();
            
                Assert.Null(user);
                Assert.Equal(2, users.Count);
                
            }
        }

        [Fact]
        public async void UpdateUserShouldUpdateUser()
        {
            using (var context = new UserDB(options))
            {
                IRepo repo = new DBRepo(context);
                User userToAdd = new User()
                {
                    Id = 4,
                    Username = "Test4"
                };

                userToAdd = (User) await repo.AddObjectAsync(userToAdd);

                User userToUpdate = new User()
                {
                    Id = 4,
                    Username = "TestUpdate"
                };

                await repo.UpdateObjectAsync(userToUpdate);

            }

            using (var context = new UserDB(options))
            {
                User user = await context.Users.FirstOrDefaultAsync(u => u.Id == 4);

                Assert.NotNull(user);
                Assert.NotEqual("Test4", user.Username);
                Assert.Equal("TestUpdate", user.Username);

            }

        }

        [Fact]
        public async void GetUserByIdShouldGetTheUser()
        {

            using (var context = new UserDB(options))
            {
                IRepo repo = new DBRepo(context);
                User userToGet = await repo.GetUserByIdAsync(1);
                User user = await context.Users.FirstOrDefaultAsync(u => u.Id == 1);
                Assert.NotNull(user);
                Assert.Equal(user.Username, userToGet.Username);
            }

        }

        [Fact]
        public async void GetUserByNameShouldGetTheUser()
        {
            using (var context = new UserDB(options))
            {
                IRepo repo = new DBRepo(context);
                User userToGet = await repo.GetUserByNameAsync("Test");
                User user = await context.Users.FirstOrDefaultAsync(u => u.Username == "Test");
                Assert.NotNull(user);
                Assert.Equal(user.Username, userToGet.Username);
            }
        }

        [Fact]
        public async void GetFollowingPostAsyncShouldGetAllFollowingPosts()
        {
            using var context = new UserDB(options);

            IRepo repo = new DBRepo(context);

            List<FollowingPost> posts = await repo.GetFollowingPostsAsync();

            Assert.NotNull(posts);
            Assert.Equal(2, posts.Count);

        }

        [Fact]
        public async void GetFollowingPostByRootIdAsyncShouldReturnThatPost()
        {
            using var context = new UserDB(options);
            IRepo repo = new DBRepo(context);

            FollowingPost post = await repo.GetFollowingPostByRootIdAsync(1);

            Assert.NotNull(post);
            Assert.Equal("First Post for Testing", post.Postname);
            Assert.Equal(1, post.UserId);
        }

        [Fact]
        public async void GetFollowingPostByPostnameAsyncShouldReturnThatPost()
        {
            using var context = new UserDB(options);
            IRepo repo = new DBRepo(context);

            FollowingPost post = await repo.GetFollowingPostByPostnameAsync("Second Post for Testing");


            Assert.NotNull(post);
            Assert.Equal("Second Post for Testing", post.Postname);
        }

        [Fact]
        public async void GetFollowingPostByUserIdAsyncShouldReturnThatPost()
        {
            using var context = new UserDB(options);
            IRepo repo = new DBRepo(context);

            List<FollowingPost> posts = await repo.GetFollowingPostByUserIdAsync(2);

            Assert.NotNull(posts);
            Assert.True(1 == posts.Count);
        }

        [Fact]
        public async void GetFollowingPostByIdAsyncShouldReturnThatPost()
        {
            using var context = new UserDB(options);
            IRepo repo = new DBRepo(context);

            FollowingPost post = await repo.GetFollowingPostByIdAsync(2);

            Assert.NotNull(post);
            Assert.Equal(2, post.RootId);
        }

        [Fact]
        public async void AddingFollowingPostShouldAddFollowingPost()
        {
            using (var context = new UserDB(options))
            {
                IRepo repo = new DBRepo(context);
                FollowingPost postToAdd = new FollowingPost()
                {
                    Id = 3,
                    Postname = "Third Post for Testing",
                    RootId = 1,
                    UserId = 1
                };

                postToAdd = (FollowingPost) await repo.AddObjectAsync(postToAdd);

            }
            using (var context = new UserDB(options))
            {
                FollowingPost post = await context.FollowingPosts.FirstOrDefaultAsync(u => u.Id == 3);

                Assert.NotNull(post);
                Assert.Equal("Third Post for Testing", post.Postname);
                Assert.Equal(1, post.RootId);
                Assert.Equal(1, post.UserId);
            }
        }

        [Fact]
        public async void UpdatingFollowingPostsShouldUpdateTheFollowingPost()
        {
            using (var context = new UserDB(options))
            {
                IRepo repo = new DBRepo(context);
                FollowingPost postToAdd = new FollowingPost()
                {
                    Id = 3,
                    Postname = "Third Post for Testing",
                    RootId = 3,
                    UserId = 1
                };

                postToAdd = (FollowingPost) await repo.AddObjectAsync(postToAdd);

                FollowingPost postToUpdate = new FollowingPost()
                {
                    Id = 3,
                    Postname = "TestUpdatePost",
                    RootId = 3,
                    UserId = 1
                };

                await repo.UpdateObjectAsync(postToUpdate);

            }

            using (var context = new UserDB(options))
            {
                FollowingPost post = await context.FollowingPosts.FirstOrDefaultAsync(u => u.Id == 3);

                Assert.NotNull(post);
                Assert.NotEqual("Test", post.Postname);
                Assert.Equal("TestUpdatePost", post.Postname);

                Assert.Equal(3, post.RootId);

            }
        }


        [Fact]
        public async void GetAllFollowingAsyncShouldGetAllFollowings()
        {

            using var context = new UserDB(options);
            IRepo repo = new DBRepo(context);
            List<Following> followings = await repo.GetAllFollowingAsync();

            Assert.NotNull(followings);
            Assert.Equal(2, followings.Count);

        }

        [Fact]
        public async void GetFollowingByIdShouldReturnFollowing()
        {
            using(var context = new UserDB(options))
            {
                IRepo repo = new DBRepo(context);
                Following followingToGet = await repo.GetFollowingByIdAsync(1);
                Following following = await context.Following.FirstOrDefaultAsync(f => f.Id == 1);

                Assert.NotNull(following);
                Assert.Equal(following.FollowingUserName, followingToGet.FollowingUserName);
            }
        }

        [Fact]
        public async void GetFollowingByFollowingByFollowerUserIdAsyncShouldReturnFollowing()
        {
            using var context = new UserDB(options);
            IRepo repo = new DBRepo(context);

            List<Following> followings = await repo.GetFollowingByFollowerUserIdAsync(1);

            Assert.NotNull(followings);
            Assert.True(1 == followings.Count);
        }

        [Fact]
        public async void GetFollowerByUserIdAsyncShouldReturnAllFollowers()
        {
            using var context = new UserDB(options);
            IRepo repo = new DBRepo(context);

            List<Following> followers = await repo.GetFollowerByUserIdAsync(1);

            Assert.NotNull(followers);
            Assert.True(1 == followers.Count);
        }

        //testing default constructor
        [Fact]
        public void UserDBShouldCreate()
        {
            UserDB test = new UserDB();
            Assert.NotNull(test);
        }

        private void Seed()
        {
            using (var context = new UserDB(options))
            {
                //first, we are going to make sure
                //that the DB is in clean slate
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Users.AddRange(
                    new User()
                    {
                        Id = 1,
                        Username = "Test"
                    },
                    new User()
                    {
                        Id = 2,
                        Username = "Test2"
                    });

                context.FollowingPosts.AddRange(

                    new FollowingPost()
                    {
                        Id = 1,
                        Postname = "First Post for Testing",
                        RootId = 1,
                        UserId = 1
                    },
                    
                    new FollowingPost()
                    {
                        Id = 2,
                        Postname = "Second Post for Testing",
                        RootId =2,
                        UserId = 2
                    });

                context.Following.AddRange(
                    new Following()
                    {
                        Id  =1,
                        FollowerUserId = 1,
                        FollowingUserId = 2,
                        FollowingUserName = "Test"
                    },

                    new Following()
                    {
                        Id = 2,
                        FollowerUserId = 2,
                        FollowingUserId = 1,
                        FollowingUserName = "Test1"
                    });

                context.Followers.AddRange(
                    new FollowedBy()
                    {
                        Id = 1,
                        UserId = 1,
                        FollowersId = 2,
                        FollowersUserName = "Test"
                    },
                    new FollowedBy()
                    {
                        Id = 2,
                        UserId = 2,
                        FollowersId = 1,
                        FollowersUserName = "Test1"
                    });

                context.Notifications.AddRange(
                    new Notifications()
                    {
                        Id = 1,
                        UserId = 1,
                        FollowersId = 2,
                        PostId = 1,
                        CommentId = 1,
                        message = "Message"
                    },
                    new Notifications()
                    {
                        Id = 2,
                        UserId = 2,
                        FollowersId = 1,
                        PostId = 2,
                        CommentId = 2,
                        message = "Message1"
                    });
                context.SaveChanges();
                context.ChangeTracker.Clear();
            }
        }

        [Fact]
        public async void GetAllFollowersAsync()
        {
            using var context = new UserDB(options);

            IRepo repo = new DBRepo(context);

            List<FollowedBy> followers = await repo.GetAllFollowersAsync();

            Assert.NotNull(followers);
        }

        [Fact]
        public async void AddingFollowerUserShouldAddFollower()
        {
            using(var context = new UserDB(options))
            {
                IRepo repo = new DBRepo(context);
                FollowedBy followerToAdd = new FollowedBy()
                {
                    Id = 3,
                    UserId = 1,
                    FollowersId = 2,
                    FollowersUserName ="Follower1"
                };

                followerToAdd = (FollowedBy) await repo.AddObjectAsync(followerToAdd);

            }
            using(var context = new UserDB(options))
            {
                FollowedBy follower = await context.Followers.FirstOrDefaultAsync(f => f.Id == 3);

                Assert.NotNull(follower);
                Assert.Equal("Follower1", follower.FollowersUserName);
            }
        }

        [Fact]
        public async void DeletingFollowerShoulddeleteFollower()
        {
            using (var context = new UserDB(options))
            {
                IRepo repo = new DBRepo(context);
                FollowedBy followerToAdd = new FollowedBy()
                {
                    Id = 4,
                    FollowersUserName = "Test4",
                    UserId = 2,
                    FollowersId = 3
                };

                followerToAdd = (FollowedBy)await repo.AddObjectAsync(followerToAdd);

                FollowedBy followerToDelete = new FollowedBy()
                {
                    Id = 4,
                    FollowersUserName = "Test4",
                    UserId = 2,
                    FollowersId = 3
                };

                await repo.DeleteObjectAsync(followerToDelete);

            }
            using (var context = new UserDB(options))
            {
                FollowedBy follower = await context.Followers.FirstOrDefaultAsync(f => f.Id == 4);
                IRepo repo = new DBRepo(context);
                List<FollowedBy> followers = await repo.GetAllFollowersAsync();
            
                Assert.Null(follower);
                
            }
        }

        [Fact]
        public async void GetFollowersByIdShouldGetTheFollower()
        {

            using (var context = new UserDB(options))
            {
                IRepo repo = new DBRepo(context);
                FollowedBy followerToGet = await repo.GetFollowersByIdAsync(1);
                FollowedBy follower = await context.Followers.FirstOrDefaultAsync(f => f.Id == 1);
                Assert.NotNull(follower);
                Assert.Equal(follower.FollowersUserName, followerToGet.FollowersUserName);
            }
        }

        [Fact]
        public async void GetFollowersByUserIdAsyncShouldReturnFollowers()
        {
            using var context = new UserDB(options);
            IRepo repo = new DBRepo(context);

            List<FollowedBy> followers = await repo.GetFollowersbyUserIdAsync(1);

            Assert.NotNull(followers);
            Assert.True(1 == followers.Count);
        }

        [Fact]
        public async void GetAllNotificationsAsync()
        {
            using var context = new UserDB(options);

            IRepo repo = new DBRepo(context);

            List<Notifications> notifications = await repo.GetAllNotificationsAsync();

            Assert.NotNull(notifications);
        }

        [Fact]
        public async void AddingNotificationShouldAddNotification()
        {
            using(var context = new UserDB(options))
            {
                IRepo repo = new DBRepo(context);
                Notifications notificationToAdd = new Notifications()
                {
                    Id = 3,
                    UserId = 2
                };

                notificationToAdd = (Notifications) await repo.AddObjectAsync(notificationToAdd);

            }
            using(var context = new UserDB(options))
            {
                Notifications notifications = await context.Notifications.FirstOrDefaultAsync(n => n.Id == 3);

                Assert.NotNull(notifications);
                Assert.Equal(2, notifications.UserId);
            }
        }

        [Fact]
        public async void DeletingNotificationShoulddeleteNotification()
        {
            using (var context = new UserDB(options))
            {
                IRepo repo = new DBRepo(context);
                Notifications notificationToAdd = new Notifications()
                {
                    Id = 4,
                    UserId = 2,
                };

                notificationToAdd = (Notifications)await repo.AddObjectAsync(notificationToAdd);

                Notifications notificationToDelete = new Notifications()
                {
                    Id = 4,
                    UserId = 2,
                };

                await repo.DeleteObjectAsync(notificationToDelete);

            }
            using (var context = new UserDB(options))
            {
                Notifications notification = await context.Notifications.FirstOrDefaultAsync(f => f.Id == 4);
                IRepo repo = new DBRepo(context);
                List<Notifications> followers = await repo.GetAllNotificationsAsync();
            
                Assert.Null(notification);
                
            }
        }

        [Fact]
        public async void GetNotificationsByIdShouldGetTheNotification()
        {

            using (var context = new UserDB(options))
            {
                IRepo repo = new DBRepo(context);
                Notifications notificationToGet = await repo.GetNotificationsByIdAsync(1);
                Notifications notification = await context.Notifications.FirstOrDefaultAsync(n => n.Id == 1);
                Assert.NotNull(notification);
                Assert.Equal(notification.message, notificationToGet.message);
            }
        }

        [Fact]
        public async void GetNotificationsByUserIdAsyncShouldReturnNotifications()
        {
            using var context = new UserDB(options);
            IRepo repo = new DBRepo(context);

            List<Notifications> notifications = await repo.GetNotificationsbyUserIdAsync(1);

            Assert.NotNull(notifications);
            Assert.True(1 == notifications.Count);
        }

        [Fact]
        public async void GetNotificationsByPostIdAsyncShouldReturnNotifications()
        {
            using var context = new UserDB(options);
            IRepo repo = new DBRepo(context);

            List<Notifications> notifications = await repo.GetNotificationsByPostIdAsync(1);

            Assert.NotNull(notifications);
            Assert.True(1 == notifications.Count);
        }

        [Fact]
        public async void GetNotificationsByCommentIdAsyncShouldReturnNotifications()
        {
            using var context = new UserDB(options);
            IRepo repo = new DBRepo(context);

            List<Notifications> notifications = await repo.GetNotificationsByCommentIdAsync(1);

            Assert.NotNull(notifications);
            Assert.True(1 == notifications.Count);
        }

        [Fact]
        public async void GetNotificationsByFollowerIdAsyncShouldReturnNotifications()
        {
            using var context = new UserDB(options);
            IRepo repo = new DBRepo(context);

            List<Notifications> notifications = await repo.GetNotificationsByFollowerIdAsync(1);

            Assert.NotNull(notifications);
            Assert.True(1 == notifications.Count);
        }
    }
}
