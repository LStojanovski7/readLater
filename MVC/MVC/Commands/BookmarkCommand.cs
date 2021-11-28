using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ReadLater.Entities;

namespace MVC.Commands
{
    public class BookmarkCommand
    {
        public string CategoryName { get; set; }
        public Bookmark Bookmark { get; set; }
    }
}