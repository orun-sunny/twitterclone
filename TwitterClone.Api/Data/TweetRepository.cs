using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Data
{
    public class TweetRepository
    {
        private readonly List<Tweet> _tweets = new List<Tweet>();


        public List<Tweet> GetTweets()
        {
            return _tweets;
        }

        public List<Tweet> GetTweetsByUserId(Guid UserId)
        {
            return _tweets.Where(x => x.UserId == UserId).ToList();
        }

        public Tweet? GetTweetById(Guid id)
        {
            return _tweets.SingleOrDefault(x => x.Id == id);
        }


        public Tweet AddTweet(Tweet tweet)
        {
            _tweets.Add(tweet);
            return tweet;
        }


        public Tweet UpdateTweet(Tweet tweet)
        {
            _tweets.RemoveAll(x => x.Id == tweet.Id);
            _tweets.Add(tweet);
            return tweet;
        }

        public bool DeleteTweet(Tweet tweet)
        {
            return _tweets.Remove(tweet);
        }
    }
}