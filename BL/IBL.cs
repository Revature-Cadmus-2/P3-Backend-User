﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace BL
{
    public interface IBL
    {
        /// <summary>
        /// Generic method to add a corresponding Object to the database
        /// </summary>
        /// <param name="objectToAdd"></param>
        /// <returns>corresponding object from the DB</returns>
        public Task<Object> AddObjectAsync(Object objectToAdd);
        /// <summary>
        /// Generic method to update a corresponding Object in the database
        /// </summary>
        /// <param name="objectToUpdate"></param>
        /// <returns></returns>
        public Task UpdateObjectAsync(Object objectToUpdate);
        /// <summary>
        /// Generic method to delete a corresponding Object from the database
        /// </summary>
        /// <param name="objectToDelete"></param>
        /// <returns></returns>
        public Task DeleteObjectAsync(Object objectToDelete);
        
        // ---------- Methods for User functionality ----------

        /// <summary>
        /// Gets all the users from the database 
        /// </summary>
        /// <returns>List of all users.</returns>
        public Task<List<User>> GetAllUsersAsync();

        /// <summary>
        /// Gets a user by their Id from the database
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>A user.</returns>
        public Task<User> GetUserByIdAsync(int userId);

        /// <summary>
        /// Gets a user by their name from the database
        /// </summary>
        /// <param name="username"></param>
        /// <returns>A User</returns>
        public Task<User> GetUserByNameAsync(string username);

        // ---------- Methods for FollowingPost functionality --------

        /// <summary>
        /// Gets all the followingposts from the database
        /// </summary>
        /// <returns>Lists of following posts.</returns>
        public Task<List<FollowingPost>> GetFollowingPostsAsync();

        public Task<FollowingPost> GetFollowingPostByIdAsync(int Id);

        /// <summary>
        /// Gets the following post by the root comment id from the database.
        /// </summary>
        /// <param name="rootId"></param>
        /// <returns>Following post</returns>

        public Task<FollowingPost> GetFollowingPostByRootIdAsync(int rootId);

        /// <summary>
        /// Gets following post by their name from the database.
        /// </summary>
        /// <param name="postname"></param>
        /// <returns>Following post</returns>
        public Task<FollowingPost> GetFollowingPostByPostnameAsync(string postname);
        /// <summary>
        /// Gets all the following post by User Id.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>List of following posts.</returns>
        public Task<List<FollowingPost>> GetFollowingPostByUserIdAsync(int userId);

        // ---------- Methods for Following functionality --------
        
        /// <summary>
        /// Gets all following from the database
        /// </summary>
        /// <returns></returns>
        public Task<List<Following>> GetAllFollowingAsync();

        /// <summary>
        /// Gets a following by it's Id
        /// </summary>
        /// <param name="followingId"></param>
        /// <returns>Following</returns>
        public Task<Following> GetFollowingByIdAsync(int followingId);

        /// <summary>
        /// Gets a list of following by user id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns> List of following</returns>
        public Task<List<Following>> GetFollowingByFollowerUserIdAsync(int userId);

        /// <summary>
        /// Gets a list of follower by user id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>List of following</returns>
        public Task<List<Following>> GetFollowerByUserIdAsync(int userId);

                // ---------- Methods for FollowedBy functionality ----------
        
        /// <summary>
        /// Gets a list of all Followers from the database
        /// </summary>
        /// <returns>All followers</returns>
        public Task<List<FollowedBy>> GetAllFollowersAsync();

        /// <summary>
        /// Gets follower by its Id
        /// </summary>
        /// <param name="followedById"></param>
        /// <returns>The follower</returns>
        public Task<FollowedBy> GetFollowersByIdAsync(int followedById);

        /// <summary>
        /// Gets List of current user's followers
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Current user's list of followers</returns>
        public Task<List<FollowedBy>> GetFollowersbyUserIdAsync(int userId);

        // ---------- Methods for Notifications functionality ----------

        /// <summary>
        /// Gets a list of notifications from the database
        /// </summary>
        /// <returns>All notifications</returns>
        public Task<List<Notifications>> GetAllNotificationsAsync();

        /// <summary>
        /// Gets notfication by its Id
        /// </summary>
        /// <param name="notificationsId"></param>
        /// <returns>The notification</returns>
        public Task<Notifications> GetNotificationsByIdAsync(int notificationsId);

        /// <summary>
        /// Gets list of current user's notifications
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Current user's list of notifications</returns>
        public Task<List<Notifications>> GetNotificationsbyUserIdAsync(int userId);

        /// <summary>
        /// Gets list of notifications by post
        /// </summary>
        /// <param name="postId"></param>
        /// <returns>post's notifications</returns>
        public Task<List<Notifications>> GetNotificationsByPostIdAsync(int postId);
        
        /// <summary>
        /// Gets list of notifications by comments
        /// </summary>
        /// <param name="commentId"></param>
        /// <returns>lcomment's notifications</returns>
        public Task<List<Notifications>> GetNotificationsByCommentIdAsync(int commentId);

        /// <summary>
        /// Gets list of notifications by follower
        /// </summary>
        /// <param name="followersId"></param>
        /// <returns>follower's notifications</returns>
        public Task<List<Notifications>> GetNotificationsByFollowerIdAsync(int followersId);
        // ---------- Methods for Grouping functionality ----------

        /// <summary>
        /// Get list of all groups
        /// </summary>
        /// <returns>List of groups</returns>
        public Task<List<Group>> GetAllGroupsAsync();
        
        /// <summary>
        /// Returns a group by its Id
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public Task<Group> GetGroupByIdAsync(int groupId);
        
        /// <summary>
        /// Get a list of groups containing search term
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <returns></returns>
        public Task<List<Group>> GetGroupsByGroupNameAsync(string searchTerm);

        // ---------- Methods for GroupMember functionality ----------

        /// <summary>
        /// Returns all groups a user is subscribed to
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Task<List<GroupMembers>> GetGroupsByUserIdAsync(int memberUserId);

        /// <summary>
        /// Remove member from group by GroupId and it's memberId
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="memberUserId"></param>
        /// <returns></returns>
        public Task RemoveMemberFromGroupAsync (int groupId, int memberUserId);
        public Task<User> AddPictureAsync(string username, string imgurl);
    }

}