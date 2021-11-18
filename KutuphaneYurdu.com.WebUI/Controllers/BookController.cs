using KutuphaneYurdu.com.BL.Repositories;
using KutuphaneYurdu.com.DAL.Entities;
using KutuphaneYurdu.com.Tools;
using KutuphaneYurdu.com.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace KutuphaneYurdu.com.WebUI.Controllers
{
    public class BookController : Controller
    {
        MSSQLRepo<Book> repoBook;
        public BookController(MSSQLRepo<Book> _repoBook)
        {
            repoBook = _repoBook;
        }
        [Route("kitaplar")]
        public IActionResult Index()
        {
            return View(repoBook.GetAll().Include(i=>i.Category).Include(i => i.Writer));
        }

        [Route("kitaplar/{name}/{id}")]
        public IActionResult Category(string name, int id)
        {

            IEnumerable<Book> book;
            book= repoBook.GetAll(g=>g.Category.ID==id).Include(i => i.Category).Include(i => i.Writer).ToList() ?? null;
            if (book != null)
            {
                return View(book);
            }
            else return Redirect("/");
        }

        [Route("kitap/{name}/{id}")]
        public IActionResult Detail(string name,int id)
        {
            Book book = repoBook.GetAll(g=>g.ID==id).Include(i=>i.Category).Include(i => i.Writer).FirstOrDefault() ?? null;
            if (book != null) 
            {
                BookVM bookVM = new BookVM();
                bookVM.Book = book;
                bookVM.Books= repoBook.GetAll(g => g.ID != book.ID).Include(i => i.Writer).Take(5).ToList();
                return View(bookVM);
            }
            else return Redirect("/");
           
        }
       
    }

}

