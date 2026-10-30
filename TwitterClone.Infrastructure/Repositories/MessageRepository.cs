using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;
using TwitterClone.Infrastructure.Persistence;

namespace TwitterClone.Infrastructure.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly TwitterCloneDbContext _context;

        public MessageRepository(TwitterCloneDbContext context)
        {
            _context = context;
        }

        public Message AddMessage(Message message)
        {
            _context.Messages.Add(message);
            _context.SaveChanges();
            return message;
        }

        public Message UpdateMessage(Message message)
        {
            _context.Messages.Update(message);
            _context.SaveChanges();
            return message;
        }

        public bool DeleteMessage(Message message)
        {
            _context.Messages.Remove(message);
            return _context.SaveChanges() > 0;
        }

        public Message? GetMessageById(Guid id)
        {
            return _context.Messages.SingleOrDefault(m => m.Id == id);
        }

        public List<Message> GetMessages()
        {
            return _context.Messages.ToList();
        }

        public List<Message> GetConversation(Guid userId, Guid otherUserId)
        {
            return _context.Messages
                .Where(m =>
                    (m.SenderId == userId && m.ReceiverId == otherUserId) ||
                    (m.SenderId == otherUserId && m.ReceiverId == userId))
                .OrderBy(m => m.SentAt)
                .ToList();
        }
    }
}
