using System.Collections.Generic;
using ReadLater.Entities;

namespace ReadLater.Services
{
    public interface IBookmarkService
    {
        Bookmark CreateBookmark(Bookmark bookmark);
        void UpdateBookmark(Bookmark bookmark);
        void DeleteBookmark(Bookmark bookmark);
        void DeleteBookmark(int id);
        List<Bookmark> GetBookmarks(string category = null);
    }
}