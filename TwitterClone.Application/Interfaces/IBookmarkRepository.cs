using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Interfaces
{
    public interface IBookmarkRepository
    {
        Bookmark AddBookmark(Bookmark bookmark);
        bool DeleteBookmark(Bookmark bookmark);
        Bookmark? GetBookmarkById(Guid id);
        List<Bookmark> GetBookmarks();
        List<Bookmark> GetBookmarksByUserId(Guid userId);
    }
}
