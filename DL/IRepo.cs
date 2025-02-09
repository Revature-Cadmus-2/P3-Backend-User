using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DL
{
    public interface IRepo
    {
        public Task<Object> AddObjectAsync(Object objectToAdd);
        
        public Task UpdateObjectAsync(Object objectToUpdate);

        public Task DeleteObjectAsync(Object objectToDelete);

        // ---------- Methods for User functionality ----------

        public Task<List<User>> GetAllUsersAsync();
        
        public Task<User> GetUserByIdAsync(int userId);
        
        public Task<User> GetUserByNameAsync(string username);

        // ---------- Methods for FollowingPost functionality ----------

        public Task<List<FollowingPost>> GetFollowingPostsAsync();

        public Task<FollowingPost> GetFollowingPostByIdAsync(int Id);
        
        public Task<FollowingPost> GetFollowingPostByRootIdAsync(int rootId);
        
        public Task<FollowingPost> GetFollowingPostByPostnameAsync(string postname);
        
        public Task<List<FollowingPost>> GetFollowingPostByUserIdAsync(int userId);

        // ---------- Methods for Following functionality ----------

        public Task<List<Following>> GetAllFollowingAsync();
        
        public Task<Following> GetFollowingByIdAsync(int followingId);
        
        public Task<List<Following>> GetFollowingByFollowerUserIdAsync(int userId);
        
        public Task<List<Following>> GetFollowerByUserIdAsync(int userId);

        // ---------- Methods for FollowedBy functionality ----------

        public Task<List<FollowedBy>> GetAllFollowersAsync();
        public Task<FollowedBy> GetFollowersByIdAsync(int followedById);
        public Task<List<FollowedBy>> GetFollowersbyUserIdAsync(int userId);

        // ---------- Methods for Notifications functionality ----------

        public Task<List<Notifications>> GetAllNotificationsAsync();
        public Task<Notifications> GetNotificationsByIdAsync(int notificationsId);
        public Task<List<Notifications>> GetNotificationsbyUserIdAsync(int userId);
        public Task<List<Notifications>> GetNotificationsByPostIdAsync(int postId);
        public Task<List<Notifications>> GetNotificationsByCommentIdAsync(int commentId);
        public Task<List<Notifications>> GetNotificationsByFollowerIdAsync(int followersId);
        // ---------- Methods for Grouping functionality ----------

        public Task<List<Group>> GetAllGroupsAsync();
        
        public Task<Group> GetGroupByIdAsync(int groupId);
        
        public Task<List<Group>> GetGroupsByGroupNameAsync(string searchTerm);

        // ---------- Methods for GroupMember functionality ----------

        public Task<List<GroupMembers>> GetGroupsByUserIdAsync(int memberUserId);

        public Task RemoveMemberFromGroupAsync (int groupId, int memberUserId);

        public Task<User> AddPictureAsync(string username, string imgurl);
    }
}