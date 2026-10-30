using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;
using TwitterClone.Infrastructure.Persistence;

namespace TwitterClone.Infrastructure.Repositories
{
    public class RetweetRepository : IRetweetRepository
    {
        private readonly TwitterCloneDbContext _context;

        public RetweetRepository(TwitterCloneDbContext context)
        {
            _context = context;
        }

        public Retweet AddRetweet(Retweet retweet)
        {
            _context.Retweets.Add(retweet);
            _context.SaveChanges();
            return retweet;
        }

        public Retweet UpdateRetweet(Retweet retweet)
        {
            _context.Retweets.Update(retweet);
            _context.SaveChanges();
            return retweet;
        }

        public bool DeleteRetweet(Retweet retweet)
        {
            _context.Retweets.Remove(retweet);
            return _context.SaveChanges() > 0;
        }

        public Retweet? GetRetweetById(Guid id)
        {
            return _context.Retweets.SingleOrDefault(r => r.Id == id);
        }

        public List<Retweet> GetRetweets()
        {
            return _context.Retweets.ToList();
        }

        public List<Retweet> GetRetweetsByUserId(Guid userId)
        {
            return _context.Retweets.Where(r => r.UserId == userId).ToList();
        }

        public List<Retweet> GetRetweetsByTweetId(Guid tweetId)
        {
            return _context.Retweets.Where(r => r.TweetId == tweetId).ToList();
        }
    }
}
