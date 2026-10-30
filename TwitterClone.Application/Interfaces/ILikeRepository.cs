using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Interfaces
{
    public interface ILikeRepository
    {
        Like AddLike(Like like);
        bool DeleteLike(Like like);
        Like? GetLikeById(Guid id);
        List<Like> GetLikes();
        List<Like> GetLikesByUserId(Guid userId);
        List<Like> GetLikesByTweetId(Guid tweetId);
    }
}
