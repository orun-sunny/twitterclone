using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Interfaces
{
    public interface IFollowRepository
    {
        Follow AddFollow(Follow follow);
        bool DeleteFollow(Follow follow);
        Follow? GetFollowById(Guid id);
        List<Follow> GetFollows();
        List<Follow> GetFollowers(Guid userId);
        List<Follow> GetFollowing(Guid userId);
    }
}
