using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;
using TwitterClone.Infrastructure.Persistence;

namespace TwitterClone.Infrastructure.Repositories
{
    public class LikeRepository : ILikeRepository
    {
        private readonly TwitterCloneDbContext _context;

        public LikeRepository(TwitterCloneDbContext context)
        {
            _context = context;
        }

        public Like AddLike(Like like)
        {
            _context.Likes.Add(like);
            _context.SaveChanges();
            return like;
        }

        public bool DeleteLike(Like like)
        {
            _context.Likes.Remove(like);
            return _context.SaveChanges() > 0;
        }

        public Like? GetLikeById(Guid id)
        {
            return _context.Likes.SingleOrDefault(l => l.Id == id);
        }

        public List<Like> GetLikes()
        {
            return _context.Likes.ToList();
        }

        public List<Like> GetLikesByUserId(Guid userId)
        {
            return _context.Likes.Where(l => l.UserId == userId).ToList();
        }

        public List<Like> GetLikesByTweetId(Guid tweetId)
        {
            return _context.Likes.Where(l => l.TweetId == tweetId).ToList();
        }
    }
}
