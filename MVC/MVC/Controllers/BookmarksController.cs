using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Commands;
using ReadLater.Entities;
using ReadLater.Services;

namespace MVC.Controllers
{
    [Authorize]
    public class BookmarksController : Controller
    {
        private readonly IBookmarkService _bookmarkService;
        private readonly ICategoryService _categoryService;

        public BookmarksController(IBookmarkService bookmarkService,
                                   ICategoryService categoryService)
        {
            _bookmarkService = bookmarkService;
            _categoryService = categoryService;
        }

        // GET: Bookmarks
        public ActionResult Index()
        {
            var query = _bookmarkService.GetBookmarks();

            return View(query);
        }

        public ActionResult Update(Bookmark bookmark)
        {
            _bookmarkService.UpdateBookmark(bookmark);

            return Index();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BookmarkCommand command)
        {
            Bookmark bookmark = command.Bookmark;

            if (_categoryService.GetCategory((int)bookmark.CategoryId) == null)
            {
                Category category = new Category()
                {
                    Name = command.CategoryName
                };

                var cat = _categoryService.CreateCategory(category);

                bookmark.CategoryId = cat.ID;

                _bookmarkService.CreateBookmark(bookmark);
            }
            else
            {
                _bookmarkService.CreateBookmark(bookmark);
            }

            return Index();
        }

        //[HttpPost]
        //public ActionResult Create(Bookmark bookmark)
        //{
        //    if(_categoryService.GetCategory((int)bookmark.CategoryId) == null)
        //    {
        //        Category category = new Category()
        //        {
        //            //Name = 
        //        };

        //        _categoryService.CreateCategory(category);

        //        bookmark.CategoryId = category.ID;

        //        _bookmarkService.CreateBookmark(bookmark);
        //    }
        //    else
        //    {
        //        _bookmarkService.CreateBookmark(bookmark);
        //    }

        //    return Index();
        //}
    }
}