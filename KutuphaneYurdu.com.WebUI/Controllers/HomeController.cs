using KutuphaneYurdu.com.BL.Repositories;
using KutuphaneYurdu.com.DAL.Entities;
using KutuphaneYurdu.com.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphaneYurdu.com.WebUI.Controllers
{
    public class HomeController : Controller
    {
        MSSQLRepo<Book> repoBook;
        MSSQLRepo<Blog> repoBlog;
        public HomeController(MSSQLRepo<Book> _repoBook, MSSQLRepo<Blog> _repoBlog)
        {
            repoBook = _repoBook;
            repoBlog = _repoBlog;
        }
        public IActionResult Index()
        {
        
                HomeVM homeVM = new HomeVM();
            homeVM.Books = repoBook.GetAll().Include(i=>i.Writer).OrderBy(o => o.DisplayIndex);
            homeVM.Blogs = repoBlog.GetAll().OrderByDescending(o => o.RecDate);
            return View(homeVM);
        }
    }
}
