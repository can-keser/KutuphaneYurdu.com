using KutuphaneYurdu.com.BL.Repositories;
using KutuphaneYurdu.com.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphaneYurdu.com.WebUI.Controllers
{
    public class PDFController : Controller
    {
        MSSQLRepo<Book> repoBook;
        public PDFController(MSSQLRepo<Book> _repoBook)
        {
            repoBook = _repoBook;
        }
        [Route("oku/{name}/{id?}")]
        public IActionResult Index(string name,int id)
        {
            Book book = repoBook.GetAll(g => g.ID == id).Include(i => i.Category).FirstOrDefault() ?? null;
            return View(book);
        }

    }
}
