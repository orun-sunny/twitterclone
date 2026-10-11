namespace TwitterClone.Application.Dtos
{
    public class CreateLikeDto
    {
        public Guid UserId { get; set; }
        public Guid TweetId { get; set; }
    }
}
