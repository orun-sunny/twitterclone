using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;
using TwitterClone.Infrastructure.Persistence;

namespace TwitterClone.Infrastructure.Repositories
{
    public class FollowRepository : IFollowRepository
    {
        private readonly TwitterCloneDbContext _context;

        public FollowRepository(TwitterCloneDbContext context)
        {
            _context = context;
        }

        public Follow AddFollow(Follow follow)
        {
            _context.Follows.Add(follow);
            _context.SaveChanges();
            return follow;
        }

        public bool DeleteFollow(Follow follow)
        {
            _context.Follows.Remove(follow);
            return _context.SaveChanges() > 0;
        }

        public Follow? GetFollowById(Guid id)
        {
            return _context.Follows.SingleOrDefault(f => f.Id == id);
        }

        public List<Follow> GetFollows()
        {
            return _context.Follows.ToList();
        }

        public List<Follow> GetFollowers(Guid userId)
        {
            return _context.Follows.Where(f => f.FollowingId == userId).ToList();
        }

        public List<Follow> GetFollowing(Guid userId)
        {
            return _context.Follows.Where(f => f.FollowerId == userId).ToList();
        }
    }
}
