namespace Models;

public class Notifications
{
    public int Id { get; set; }
    public int UserId { get; set; }

    //not required
    public int? FollowersId { get; set; }

    //keep postid for when someone likes your post, not required
    public int? PostId { get; set; }
    //not required
    public int? CommentId { get; set; }

    public string? message { get; set; }
}