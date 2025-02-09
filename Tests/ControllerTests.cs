using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using WebAPI.Controllers;
using Models;
using System.Text;
using Xunit;
using BL;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Tests
{
    public class ControllerTests
    {
        //UserController
        [Fact]
        public async Task GetUserShouldReturnListofUserAsync()
        {
            List<User> mockUser = new List<User>()
            {
                new User()
                {
                    Id = 1,
                    Username = "test1"

                },
                new User()
                {
                    Id = 2,
                    Username = "test2"
                }
            };
            var mockBL = new Mock<IBL>();

            mockBL.Setup(x => x.GetAllUsersAsync()).ReturnsAsync(mockUser);
                
            UserController service = new UserController(mockBL.Object);

            var result = await service.Get() as ObjectResult;
            var actualResult = (List<User>)result.Value;

            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)result.StatusCode);
            Assert.Equal(2, actualResult.Count);
        }

        [Fact]
        public async Task GetUserNullShouldReturnNullAsync()
        {
            List<User> mockUser = null;
            var mockBL = new Mock<IBL>();

            mockBL.Setup(x => x.GetAllUsersAsync()).ReturnsAsync(mockUser);
                
            UserController service = new UserController(mockBL.Object);

            var result = await service.Get() as ObjectResult;
            

            Assert.Null(result);
        }

        [Fact]
        public async Task GetUserByIdShouldReturnUser()
        {
            User mockUser =  new User()
            {
                Id = 1,
                Username = "test1"
            };

            var mockBL = new Mock<IBL>();

            mockBL.Setup(x => x.GetUserByIdAsync(1)).ReturnsAsync(mockUser);

            UserController service = new UserController(mockBL.Object);

            var result = await service.Get(1) as ObjectResult;
            var noresult = await service.Get(-1) as ObjectResult;
            var actualResult = result.Value;

            Assert.IsType<OkObjectResult>(result);
            Assert.Null(noresult);
        }

        [Fact]
        public async Task GetUserByNameShouldReturnUser()
        {
            User mockUser = new User()
            {
                Id = 1,

                Username = "Test1"
            };

            var mockBL = new Mock<IBL>();

            mockBL.Setup(x => x.GetUserByNameAsync("Test1")).ReturnsAsync(mockUser);

            UserController service = new UserController(mockBL.Object);

            var result = await service.Get("Test1") as ObjectResult;
            var noresult = await service.Get("thisuserdoesnotexist") as ObjectResult;
            var actualResult = result.Value;

            Assert.IsType<OkObjectResult>(result);
            Assert.Null(noresult);
        }

        [Fact]
        public async Task AddShouldAddUser()
        {
            User mockUser = new User()
            {
                Id = 1,

                Username = "Test1"
            };

            var mockBL = new Mock<IBL>();

            mockBL.Setup(x => x.AddObjectAsync(mockUser)).ReturnsAsync(mockUser);

            UserController service = new UserController(mockBL.Object);

            var result = await service.Post(mockUser) as ObjectResult;
            var actualResult = (User)result.Value;

            Assert.IsType<CreatedResult>(result);
            Assert.Equal(HttpStatusCode.Created, (HttpStatusCode)result.StatusCode);
            Assert.Equal(mockUser, actualResult);
        }

        [Fact]
        public async Task UpdateShouldUpdateUser()
        {
            User mockUser = new User()
            {
                Id = 1,

                Username = "Test1"
            };

            var mockBL = new Mock<IBL>();

            mockBL.Setup(x => x.UpdateObjectAsync(mockUser));

            UserController service = new UserController(mockBL.Object);

            var result = await service.Put(mockUser) as ObjectResult;
            var actualResult = result.Value;

            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)result.StatusCode);
            Assert.Equal(mockUser, actualResult);
        }

        [Fact]
        public async Task DeleteByIdShouldDeleteUser()
        {
            User mockUser = new User()
            {
                Id = 1,

                Username = "Test1"
            };

            var mockBL = new Mock<IBL>();

            mockBL.Setup(x => x.DeleteObjectAsync(mockUser));

            UserController service = new UserController(mockBL.Object);

            var result = await service.Delete(mockUser.Id) as ObjectResult;
            var actualResult = result.Value;

            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)result.StatusCode);
            //Assert.Null(actualResult);
        }

        [Fact]
        public async Task DeleteByNameShouldDeleteUser()
        {
            User mockUser = new User()
            {
                Id = 1,

                Username = "Test1"
            };

            var mockBL = new Mock<IBL>();

            mockBL.Setup(x => x.DeleteObjectAsync(mockUser));

            UserController service = new UserController(mockBL.Object);

            var result = await service.Delete(mockUser.Username) as ObjectResult;
            var actualResult = result.Value;

            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)result.StatusCode);
            //Assert.Null(actualResult);
        }

        //FollowingPostController
        [Fact]
        public async Task GetFollowingPostShouldReturnListofFollowingPostAsync()
        {
            List<FollowingPost> mockFollowingPost = new List<FollowingPost>()
            {
                new FollowingPost()
                {
                    Id = 1,
                    Postname = "test1"

                },
                new FollowingPost()
                {
                    Id = 2,
                    Postname = "test2"
                }
            };
            var mockBL = new Mock<IBL>();

            mockBL.Setup(x => x.GetFollowingPostsAsync()).ReturnsAsync(mockFollowingPost);
                
            FollowingPostController service = new FollowingPostController(mockBL.Object);

            var result = await service.Get() as ObjectResult;
            var actualResult = (List<FollowingPost>)result.Value;

            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)result.StatusCode);
            Assert.Equal(2, actualResult.Count);
        }

        [Fact]
        public async Task GetFollowingPostNullShouldReturnNullAsync()
        {
            List<FollowingPost> mockFollowingPost = null;
            var mockBL = new Mock<IBL>();

            mockBL.Setup(x => x.GetFollowingPostsAsync()).ReturnsAsync(mockFollowingPost);
                
            FollowingPostController service = new FollowingPostController(mockBL.Object);

            var result = await service.Get() as ObjectResult;

            Assert.Null(result);
        }

        [Fact]
        public async Task GetFollowingPostByIdShouldReturnFollowingPost()
        {
            FollowingPost mockFollowingPost =  new FollowingPost()
            {
                Id = 1,
                Postname = "test1",
                RootId = 1,
                UserId = 4
            };
            
            var mockBL = new Mock<IBL>();

            mockBL.Setup(x => x.GetFollowingPostByIdAsync(1)).ReturnsAsync(mockFollowingPost);

            FollowingPostController service = new FollowingPostController(mockBL.Object);

            var result = await service.GetByid(1) as ObjectResult;
            var actualResult = result.Value;
            var noresult = await service.GetByid(-1) as ObjectResult;

            Assert.IsType<OkObjectResult>(result);
            Assert.Null(noresult);
        }

        [Fact]
        public async Task GetFollowingPostByRootIdShouldReturnFollowingPost()
        {
            FollowingPost mockFollowingPost =  new FollowingPost()
            {
                Id = 1,
                Postname = "test1",
                RootId = 1
            };

            var mockBL = new Mock<IBL>();

            mockBL.Setup(x => x.GetFollowingPostByRootIdAsync(1)).ReturnsAsync(mockFollowingPost);

            FollowingPostController service = new FollowingPostController(mockBL.Object);

            var result = await service.GetByRootid(1) as ObjectResult;
            var actualResult = result.Value;
            var noresult = await service.GetByRootid(-1) as ObjectResult;
            Assert.IsType<OkObjectResult>(result);
            Assert.Null(noresult);
        }

        [Fact]
        public async Task GetFollowingPostByuserIdShouldReturnFollowingPost()
        {
            FollowingPost mockFollowingPost =  new FollowingPost()
            {
                Id = 1,
                Postname = "test1",
                RootId = 1,
                UserId = 4
            };
            List<FollowingPost> followingPosts = new List<FollowingPost>();
            followingPosts.Add(mockFollowingPost);
            var mockBL = new Mock<IBL>();

            mockBL.Setup(x => x.GetFollowingPostByUserIdAsync(4)).ReturnsAsync(followingPosts);

            FollowingPostController service = new FollowingPostController(mockBL.Object);

            var result = await service.GetByUserid(4) as ObjectResult;
            var actualResult = result.Value;
            var noresult = await service.GetByUserid(-1) as ObjectResult;

            Assert.IsType<OkObjectResult>(result);
            Assert.Null(noresult);
        }

        [Fact]
        public async Task GetFollowingPostByNameShouldReturnFollowingPost()
        {
            FollowingPost mockFollowingPost = new FollowingPost()
            {
                Id = 1,

                Postname = "Test1"
            };

            var mockBL = new Mock<IBL>();
            
            mockBL.Setup(x => x.GetFollowingPostByPostnameAsync("Test1")).ReturnsAsync(mockFollowingPost);

            FollowingPostController service = new FollowingPostController(mockBL.Object);

            var result = await service.GetByPostname("Test1") as ObjectResult;
            var actualResult = result.Value;
            var noresult = await service.GetByPostname("-Test") as ObjectResult;

            Assert.IsType<OkObjectResult>(result);
            Assert.Null(noresult);
        }

        [Fact]
        public async Task AddShouldAddFollowingPost()
        {
            FollowingPost mockFollowingPost = new FollowingPost()
            {
                Id = 1,

                Postname = "Test1"
            };

            var mockBL = new Mock<IBL>();

            mockBL.Setup(x => x.AddObjectAsync(mockFollowingPost)).ReturnsAsync(mockFollowingPost);

            FollowingPostController service = new FollowingPostController(mockBL.Object);

            var result = await service.Post(mockFollowingPost) as ObjectResult;
            var actualResult = result.Value;

            Assert.IsType<CreatedResult>(result);
            Assert.Equal(HttpStatusCode.Created, (HttpStatusCode)result.StatusCode);
            Assert.Equal(mockFollowingPost, actualResult);
        }

        [Fact]
        public async Task UpdateShouldUpdateFollowingPost()
        {
            FollowingPost mockFollowingPost = new FollowingPost()
            {
                Id = 1,

                Postname = "Test1"
            };

            var mockBL = new Mock<IBL>();

            mockBL.Setup(x => x.UpdateObjectAsync(mockFollowingPost));

            FollowingPostController service = new FollowingPostController(mockBL.Object);

            var result = await service.Put(mockFollowingPost) as ObjectResult;
            var actualResult = result.Value;

            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)result.StatusCode);
            Assert.Equal(mockFollowingPost, actualResult);
        }

        [Fact]
        public async Task DeleteByIdShouldDeleteFollowingPost()
        {
            FollowingPost mockFollowingPost = new FollowingPost()
            {
                Id = 1,

                Postname = "Test1",
                RootId = 3
            };

            var mockBL = new Mock<IBL>();

            mockBL.Setup(x => x.DeleteObjectAsync(mockFollowingPost));

            FollowingPostController service = new FollowingPostController(mockBL.Object);

            var result = await service.Delete(mockFollowingPost.Id) as ObjectResult;
            var actualResult = result.Value;

            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)result.StatusCode);
            Assert.NotNull(result);
        }

        //FollowingController
        // [Fact]
        // public async Task GetFollowingShouldReturnListofFollowingAsync()
        // {
        //     List<Following> mockFollowing = new List<Following>()
        //     {
        //         new Following()
        //         {
        //             Id = 1,
        //             FollowingUserName = "test1"

        //         },
        //         new Following()
        //         {
        //             Id = 2,
        //             FollowingUserName = "test2"
        //         }
        //     };
        //     var mockBL = new Mock<IBL>();

        //     mockBL.Setup(x => x.GetAllFollowingAsync()).ReturnsAsync(mockFollowing);
                
        //     WebAPI.FollowingController service = new WebAPI.FollowingController(mockBL.Object);

        //     var result = await service.Get() as ObjectResult;
        //     var actualResult = (List<Following>)result.Value;
        
        //     Assert.IsType<OkObjectResult>(result);
        //     Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)result.StatusCode);
        //     Assert.Equal(2, actualResult.Count);
            
        // }

        [Fact]
        public async Task GetFollowingnullShouldReturnNullAsync()
        {
            List<Following> mockFollowing = null;
        
            var mockBL = new Mock<IBL>();

            mockBL.Setup(x => x.GetAllFollowingAsync()).ReturnsAsync(mockFollowing);
                
            WebAPI.FollowingController service = new WebAPI.FollowingController(mockBL.Object);

            var result = await service.Get() as ObjectResult;
            
        
            Assert.Null(result);
            
            
        }

        [Fact]
        public async Task GetFollowingByIdShouldReturnFollowing()
        {
            Following mockFollowing =  new Following()
            {
                Id = 1,
                FollowingUserName = "test1",
                FollowingUserId = 1
            };

            var mockBL = new Mock<IBL>();

            mockBL.Setup(x => x.GetFollowingByIdAsync(1)).ReturnsAsync(mockFollowing);

            WebAPI.FollowingController service = new WebAPI.FollowingController(mockBL.Object);

            var result = await service.GetById(1) as ObjectResult;
            var actualResult = result.Value;
            var noresult = await service.GetById(-1) as ObjectResult;
            Assert.IsType<OkObjectResult>(result);
            Assert.Null(noresult);
        }

        [Fact]
        public async Task GetFollowingByFollowerUserIdShouldReturnListofFollowingAsync()
        {
            List<Following> mockFollowing = new List<Following>()
            {
                new Following()
                {
                    Id = 2,
                    FollowingUserName = "test2",
                    FollowerUserId = 2,

                },
                new Following()
                {
                    Id = 3,
                    FollowingUserName = "test3",
                    FollowerUserId = 2,

                },
                new Following()
                {
                    Id = 4,
                    FollowingUserName = "test4",
                    FollowerUserId = 2,

                }
            };
            var mockBL = new Mock<IBL>();
        }

        //     mockBL.Setup(x => x.GetFollowerByUserIdAsync(2)).ReturnsAsync(mockFollowing);
                
        //     WebAPI.FollowingController service = new WebAPI.FollowingController(mockBL.Object);

        //     var result = await service.GetFollowerByUserId(2) as ObjectResult;
        //     var noresult = await service.GetFollowerByUserId(-1) as ObjectResult;
        //     List<Following> actualResult = (List<Following>)result.Value;
            
        //     Assert.IsType<OkObjectResult>(result);
        //     Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)result.StatusCode);
        //     Assert.Equal(3, actualResult.Count);
        //     Assert.Equal(2, actualResult[0].Id);
        //     Assert.Null(noresult);
        // }

        // [Fact]
        // public async Task GetFollowingByUserIdShouldReturnListofFollowingAsync()
        // {
        //     List<Following> mockFollowing = new List<Following>()
        //     {
        //         new Following()
        //         {
        //             Id = 2,
        //             FollowingUserName = "test2",
        //             FollowerUserId = 2,
        //             FollowingUserId = 7
        //         },
        //         new Following()
        //         {
        //             Id = 3,
        //             FollowingUserName = "test3",
        //             FollowerUserId = 2,
        //             FollowingUserId = 7
        //         },
        //         new Following()
        //         {
        //             Id = 4,
        //             FollowingUserName = "test4",
        //             FollowerUserId = 2,
        //             FollowingUserId = 7
        //         }
        //     };
        //     var mockBL = new Mock<IBL>();

        //     mockBL.Setup(x => x.GetFollowingByFollowerUserIdAsync(7)).ReturnsAsync(mockFollowing);
                
        //     WebAPI.FollowingController service = new WebAPI.FollowingController(mockBL.Object);

        //     var result = await service.GetFollowingByUserId(7) as ObjectResult;
        //     var noresult = await service.GetFollowingByUserId(-7) as ObjectResult;

        //     List<Following> actualResult = (List<Following>)result.Value;
            
        //     Assert.IsType<OkObjectResult>(result);
        //     Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)result.StatusCode);
        //     Assert.Equal(3, actualResult.Count);
        //     Assert.Equal(2, actualResult[0].Id);
        //     Assert.Null(noresult);
        // }

        [Fact]
        public async Task AddShouldAddFollowing()
        {
            Following mockFollowing = new Following()
            {
                Id = 1,

                FollowingUserName = "Test1"
            };

            var mockBL = new Mock<IBL>();

            mockBL.Setup(x => x.AddObjectAsync(mockFollowing)).ReturnsAsync(mockFollowing);

            WebAPI.FollowingController service = new WebAPI.FollowingController(mockBL.Object);

            var result = await service.Post(mockFollowing) as ObjectResult;
            var actualResult = (Following)result.Value;

            Assert.IsType<CreatedResult>(result);
            Assert.Equal(HttpStatusCode.Created, (HttpStatusCode)result.StatusCode);
            Assert.Equal(mockFollowing, actualResult);
        }

        [Fact]
        public async Task DeleteByIdShouldDeleteFollowing()
        {
            Following mockFollowing = new Following()
            {
                Id = 1,

                FollowingUserName = "Test1",
                FollowingUserId = 2,
                FollowerUserId = 3
            };

            var mockBL = new Mock<IBL>();

            mockBL.Setup(x => x.DeleteObjectAsync(mockFollowing));

            WebAPI.FollowingController service = new WebAPI.FollowingController(mockBL.Object);

            var result = await service.Delete(mockFollowing.Id) as ObjectResult;
            var actualResult = result.Value;

            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)result.StatusCode);
            Assert.NotNull(result);
        }
        
        [Fact]
        public async Task GetFollowedByShouldReturnListofFollowedByAsync()
        {
            List<FollowedBy> mockFollowedBy = new List<FollowedBy>()
            {
                new FollowedBy()
                {
                    Id = 1,
                    UserId = 1,
                    FollowersId = 2,
                    FollowersUserName = "follower1"
                },
                new FollowedBy()
                {
                    Id = 2,
                    UserId = 2,
                    FollowersId = 1,
                    FollowersUserName = "follower2"
                }
            };
            var mockBL = new Mock<IBL>();

            mockBL.Setup(x => x.GetAllFollowersAsync()).ReturnsAsync(mockFollowedBy);

            FollowedByController service = new FollowedByController(mockBL.Object);

            var result = await service.Get() as ObjectResult;
            var actualResult = (List<FollowedBy>)result.Value;

            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)result.StatusCode);
            Assert.Equal(2, actualResult.Count);
        }

        [Fact]
        public async Task GetFollowersNullShouldReturnNullAsync()
        {
            List<FollowedBy> mockFollowedBy = null;
            var mockBL = new Mock<IBL>();

            mockBL.Setup(x => x.GetAllFollowersAsync()).ReturnsAsync(mockFollowedBy);

            FollowedByController service = new FollowedByController(mockBL.Object);

            var result = await service.Get() as ObjectResult;

            Assert.Null(result);
        }

        [Fact]
        public async Task GetFollowedByByIdShouldReturnFollowedBy()
        {
            FollowedBy mockFollowedBy =  new FollowedBy()
            {
                Id = 1,
                UserId = 1,
                FollowersId = 2,
                FollowersUserName = "follower1"
            };
            
            var mockBL = new Mock<IBL>();

            mockBL.Setup(x => x.GetFollowersByIdAsync(1)).ReturnsAsync(mockFollowedBy);

            FollowedByController service = new FollowedByController(mockBL.Object);

            var result = await service.GetbyId(1) as ObjectResult;
            var actualResult = result.Value;
            var noresult = await service.GetbyId(-1) as ObjectResult;

            Assert.IsType<OkObjectResult>(result);
            Assert.Null(noresult);
        }

        [Fact]
        public async Task GetFollowersByUserIdShouldReturnListofFollowersAsync()
        {
            List<FollowedBy> mockFollowedBy = new List<FollowedBy>()
            {
                new FollowedBy()
                {
                    Id = 2,
                    UserId = 2,
                    FollowersId = 3,
                    FollowersUserName = "follower1"

                },
                new FollowedBy()
                {
                    Id = 3,
                    UserId = 3,
                    FollowersId = 4,
                    FollowersUserName = "follower2"

                },
                new FollowedBy()
                {
                    Id = 4,
                    UserId = 4,
                    FollowersId = 5,
                    FollowersUserName = "follower4"

                }
            };
            var mockBL = new Mock<IBL>();

            mockBL.Setup(x => x.GetFollowersbyUserIdAsync(2)).ReturnsAsync(mockFollowedBy);
            
            WebAPI.Controllers.FollowedByController service = new WebAPI.Controllers.FollowedByController(mockBL.Object);

            var result = await service.GetFollowersByUserId(2) as ObjectResult;
            var noresult = await service.GetFollowersByUserId(-1) as ObjectResult;
            List<FollowedBy> actualResult = (List<FollowedBy>)result.Value;
            
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)result.StatusCode);
            Assert.Equal(3, actualResult.Count);
            Assert.Equal(2, actualResult[0].Id);
            Assert.Null(noresult);
        }

        [Fact]
        public async Task AddShouldAddFollowers()
        {
            FollowedBy mockFollowedBy = new FollowedBy()
            {
                Id = 2,
                UserId = 2,
                FollowersId = 3,
                FollowersUserName = "follower1"
            };

            var mockBL = new Mock<IBL>();

            mockBL.Setup(x => x.AddObjectAsync(mockFollowedBy)).ReturnsAsync(mockFollowedBy);

            WebAPI.Controllers.FollowedByController service = new WebAPI.Controllers.FollowedByController(mockBL.Object);

            var result = await service.Post(mockFollowedBy) as ObjectResult;
            var actualResult = (FollowedBy)result.Value;

            Assert.IsType<CreatedResult>(result);
            Assert.Equal(HttpStatusCode.Created, (HttpStatusCode)result.StatusCode);
            Assert.Equal(mockFollowedBy, actualResult);
        }

        [Fact]
        public async Task DeleteByIdShouldDeleteFollowedBy()
        {
            FollowedBy mockFollowedBy = new FollowedBy()
            {
                Id = 1,
                UserId = 1,
                FollowersId = 2,
                FollowersUserName = "follower1"
            };

            var mockBL = new Mock<IBL>();

            mockBL.Setup(x => x.DeleteObjectAsync(mockFollowedBy));

            WebAPI.Controllers.FollowedByController service = new WebAPI.Controllers.FollowedByController(mockBL.Object);

            var result = await service.Delete(mockFollowedBy.Id) as ObjectResult;
            var actualResult = result.Value;

            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)result.StatusCode);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetAllNotificationsShouldReturnListofFollowedByAsync()
        {
            List<Notifications> mockNotifications = new List<Notifications>()
            {
                new Notifications()
                {
                    Id = 1,
                    UserId = 1
                },
                new Notifications()
                {
                    Id = 2,
                    UserId = 2
                }
            };
            var mockBL = new Mock<IBL>();

            mockBL.Setup(x => x.GetAllNotificationsAsync()).ReturnsAsync(mockNotifications);

            NotificationsController service = new NotificationsController(mockBL.Object);

            var result = await service.Get() as ObjectResult;
            var actualResult = (List<Notifications>)result.Value;

            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)result.StatusCode);
            Assert.Equal(2, actualResult.Count);
        }

        [Fact]
        public async Task GetNotificationsNullShouldReturnNullAsync()
        {
            List<Notifications> mockNotifications = null;
            var mockBL = new Mock<IBL>();

            mockBL.Setup(x => x.GetAllNotificationsAsync()).ReturnsAsync(mockNotifications);

            NotificationsController service = new NotificationsController(mockBL.Object);

            var result = await service.Get() as ObjectResult;

            Assert.Null(result);
        }

        [Fact]
        public async Task GetNotificationsByIdShouldReturnNotifications()
        {
            Notifications mockNotifications =  new Notifications()
            {
                Id = 1,
                FollowersId = 1,
                PostId = 1,
                CommentId = 1,
                message = "message1",
                UserId = 4
            };
            
            var mockBL = new Mock<IBL>();

            mockBL.Setup(x => x.GetNotificationsByIdAsync(1)).ReturnsAsync(mockNotifications);

            NotificationsController service = new NotificationsController(mockBL.Object);

            var result = await service.GetbyId(1) as ObjectResult;
            var actualResult = result.Value;
            var noresult = await service.GetbyId(-1) as ObjectResult;

            Assert.IsType<OkObjectResult>(result);
            Assert.Null(noresult);
        }

                [Fact]
        public async Task GetNotificationsByUserIdShouldReturnListofNotificationsAsync()
        {
            List<Notifications> mockNotifications = new List<Notifications>()
            {
                new Notifications()
                {
                    Id = 2,
                    UserId = 2,
                },
                new Notifications()
                {
                    Id = 3,
                    UserId = 3,
                },
                new Notifications()
                {
                    Id = 4,
                    UserId = 4,
                }
            };
            var mockBL = new Mock<IBL>();

            mockBL.Setup(x => x.GetNotificationsbyUserIdAsync(2)).ReturnsAsync(mockNotifications);
            
            WebAPI.Controllers.NotificationsController service = new WebAPI.Controllers.NotificationsController(mockBL.Object);

            var result = await service.GetNotificationsByUserId(2) as ObjectResult;
            var noresult = await service.GetNotificationsByUserId(-1) as ObjectResult;
            List<Notifications> actualResult = (List<Notifications>)result.Value;
            
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)result.StatusCode);
            Assert.Equal(3, actualResult.Count);
            Assert.Equal(2, actualResult[0].Id);
            Assert.Null(noresult);
        }

        [Fact]
        public async Task AddShouldAddNotifications()
        {
            Notifications mockNotifications = new Notifications()
            {
                Id = 2,
                UserId = 2,
                FollowersId = 3,
            };

            var mockBL = new Mock<IBL>();

            mockBL.Setup(x => x.AddObjectAsync(mockNotifications)).ReturnsAsync(mockNotifications);

            WebAPI.Controllers.NotificationsController service = new WebAPI.Controllers.NotificationsController(mockBL.Object);

            var result = await service.Post(mockNotifications) as ObjectResult;
            var actualResult = (Notifications)result.Value;

            Assert.IsType<CreatedResult>(result);
            Assert.Equal(HttpStatusCode.Created, (HttpStatusCode)result.StatusCode);
            Assert.Equal(mockNotifications, actualResult);
        }

        [Fact]
        public async Task DeleteByIdShouldDeleteNotifications()
        {
            Notifications mockNotifications = new Notifications()
            {
                Id = 1,
                UserId = 1,
            };

            var mockBL = new Mock<IBL>();

            mockBL.Setup(x => x.DeleteObjectAsync(mockNotifications));

            WebAPI.Controllers.NotificationsController service = new WebAPI.Controllers.NotificationsController(mockBL.Object);

            var result = await service.Delete(mockNotifications.Id) as ObjectResult;
            var actualResult = result.Value;

            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)result.StatusCode);
            Assert.NotNull(result);
        }
    }
}
