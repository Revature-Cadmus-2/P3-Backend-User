namespace Models;

public class FollowedBy
{
    public int Id { get; set; }
    //UserId is the Id of the person who is logged in
    public int UserId { get; set; }
    //FollowersId is the id of the person who is following you
    public int FollowersId { get; set; }
    public string FollowersUserName { get; set; }
}