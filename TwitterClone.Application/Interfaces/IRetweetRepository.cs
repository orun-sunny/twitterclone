using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Interfaces
{
    public interface IRetweetRepository
    {
        Retweet AddRetweet(Retweet retweet);
        Retweet UpdateRetweet(Retweet retweet);
        bool DeleteRetweet(Retweet retweet);
        Retweet? GetRetweetById(Guid id);
        List<Retweet> GetRetweets();
        List<Retweet> GetRetweetsByUserId(Guid userId);
        List<Retweet> GetRetweetsByTweetId(Guid tweetId);
    }
}
