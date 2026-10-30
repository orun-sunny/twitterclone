using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;
using TwitterClone.Infrastructure.Persistence;

namespace TwitterClone.Infrastructure.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly TwitterCloneDbContext _context;

        public NotificationRepository(TwitterCloneDbContext context)
        {
            _context = context;
        }

        public Notification AddNotification(Notification notification)
        {
            _context.Notifications.Add(notification);
            _context.SaveChanges();
            return notification;
        }

        public bool DeleteNotification(Notification notification)
        {
            _context.Notifications.Remove(notification);
            return _context.SaveChanges() > 0;
        }

        public Notification? GetNotificationById(Guid id)
        {
            return _context.Notifications.SingleOrDefault(n => n.Id == id);
        }

        public List<Notification> GetNotifications()
        {
            return _context.Notifications.ToList();
        }

        public List<Notification> GetNotificationsByUserId(Guid userId)
        {
            return _context.Notifications.Where(n => n.UserId == userId).ToList();
        }
    }
}
