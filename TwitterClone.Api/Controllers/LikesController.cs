using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TwitterClone.Api.Data;
using TwitterClone.Api.Dtos;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikesController : ControllerBase
    {
        private readonly TwitterCloneDbContext _db;

        public LikesController(TwitterCloneDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetLikes([FromQuery] Guid? userId, [FromQuery] Guid? tweetId)
        {
            var query = _db.Likes.AsQueryable();

            if (userId.HasValue)
            {
                query = query.Where(like => like.UserId == userId.Value);
            }

            if (tweetId.HasValue)
            {
                query = query.Where(like => like.TweetId == tweetId.Value);
            }

            var likes = await query.ToListAsync();
            return Ok(likes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLikeById([FromRoute] Guid id)
        {
            var like = await _db.Likes.FindAsync(id);
            if (like is null)
            {
                return NotFound();
            }

            return Ok(like);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLike([FromBody] CreateLikeDto dto)
        {
            var like = new Like
            {
                UserId = dto.UserId,
                TweetId = dto.TweetId
            };

            _db.Likes.Add(like);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLikeById), new { id = like.Id }, like);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLike([FromRoute] Guid id)
        {
            var like = await _db.Likes.FindAsync(id);
            if (like is null)
            {
                return NotFound();
            }

            _db.Likes.Remove(like);
            await _db.SaveChangesAsync();

            return Ok(new { LikeId = id, Message = "Like removed successfully." });
        }
    }
}
