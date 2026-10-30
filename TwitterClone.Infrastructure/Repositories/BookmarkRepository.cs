using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;
using TwitterClone.Infrastructure.Persistence;

namespace TwitterClone.Infrastructure.Repositories
{
    public class BookmarkRepository : IBookmarkRepository
    {
        private readonly TwitterCloneDbContext _context;

        public BookmarkRepository(TwitterCloneDbContext context)
        {
            _context = context;
        }

        public Bookmark AddBookmark(Bookmark bookmark)
        {
            _context.Bookmarks.Add(bookmark);
            _context.SaveChanges();
            return bookmark;
        }

        public bool DeleteBookmark(Bookmark bookmark)
        {
            _context.Bookmarks.Remove(bookmark);
            return _context.SaveChanges() > 0;
        }

        public Bookmark? GetBookmarkById(Guid id)
        {
            return _context.Bookmarks.SingleOrDefault(b => b.Id == id);
        }

        public List<Bookmark> GetBookmarks()
        {
            return _context.Bookmarks.ToList();
        }

        public List<Bookmark> GetBookmarksByUserId(Guid userId)
        {
            return _context.Bookmarks.Where(b => b.UserId == userId).ToList();
        }
    }
}
