using TwitterClone.Domain.Entities;

var Allnotification = new LikeNotification(Guid.NewGuid());
var message = Allnotification.GetMessage();
Console.WriteLine(message);

Console.WriteLine("Task 1 done");

var likedNotification = new LikeNotification(Guid.NewGuid());
Console.WriteLine(likedNotification.GetMessage());

var commentNotification = new CommentNotification(Guid.NewGuid());
Console.WriteLine(commentNotification.GetMessage());

var friendRequest = new FriendRequestNotification(Guid.NewGuid());
Console.WriteLine(friendRequest.GetMessage());
