using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Interfaces
{
    public interface IMessageRepository
    {
        Message AddMessage(Message message);
        Message UpdateMessage(Message message);
        bool DeleteMessage(Message message);
        Message? GetMessageById(Guid id);
        List<Message> GetMessages();
        List<Message> GetConversation(Guid userId, Guid otherUserId);
    }
}
