namespace TwitterClone.Api.Dtos
{
    public class CreateLikeDto
    {
        public Guid UserId { get; set; }
        public Guid TweetId { get; set; }
    }
}
