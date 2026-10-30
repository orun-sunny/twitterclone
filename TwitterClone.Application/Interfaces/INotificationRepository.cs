using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Interfaces
{
    public interface INotificationRepository
    {
        Notification AddNotification(Notification notification);
        bool DeleteNotification(Notification notification);
        Notification? GetNotificationById(Guid id);
        List<Notification> GetNotifications();
        List<Notification> GetNotificationsByUserId(Guid userId);
    }
}
