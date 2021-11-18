using KutuphaneYurdu.com.BL.Repositories;
using KutuphaneYurdu.com.DAL.Entities;
using KutuphaneYurdu.com.WebUI.areas.admin.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;

namespace KutuphaneYurdu.com.WebUI.Areas.admin.Controllers
{
    [Area("admin"), Authorize, Route("/admin/[controller]/[action]/{id?}")]
    public class BookController : Controller
    {
        MSSQLRepo<Book> repoBook;
        MSSQLRepo<Category> repoCategory;
        MSSQLRepo<Writer> repoWriter;
        public BookController(MSSQLRepo<Book> _repoBook, MSSQLRepo<Category> _repoCategory, MSSQLRepo<Writer> _repoWriter)
        {
            repoBook = _repoBook;
            repoCategory = _repoCategory;
            repoWriter = _repoWriter;
        }

        public IActionResult Index()
        {
            return View(repoBook.GetAll().Include(i => i.Category).Include(i => i.Writer));
        }

        public IActionResult New()
        {
            BookVM productVM = new BookVM
            {
                Categories = repoCategory.GetAll().OrderBy(o => o.Name).ToList(),
                Writers = repoWriter.GetAll().OrderBy(o => o.NameSurname).ToList()
            };
        
            return View(productVM);
        }

        [HttpPost]
        public IActionResult New(BookVM model)
        {
            if (Request.Form.Files.Any())
            {
                string PicturePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "book");
                string PdfPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "pdf");
                if (!Directory.Exists(PicturePath)) Directory.CreateDirectory(PicturePath);
                using (var stream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "book", Request.Form.Files["Book.Picture"].FileName), FileMode.Create))
                {
                    Request.Form.Files["Book.Picture"].CopyTo(stream);
                }
                model.Book.Picture = "/book/" + Request.Form.Files["Book.Picture"].FileName;

                if (!Directory.Exists(PicturePath)) Directory.CreateDirectory(PicturePath);
                using (var stream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "pdf", Request.Form.Files["Book.Link"].FileName), FileMode.Create))
                {
                    Request.Form.Files["Book.Link"].CopyTo(stream);
                }
                model.Book.Picture = "/pdf/" + Request.Form.Files["Book.Link"].FileName;
            }
            repoBook.Add(model.Book);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            BookVM productVM = new BookVM
            {
                Book = repoBook.GetBy(g => g.ID == id),
                Categories = repoCategory.GetAll().OrderBy(o => o.Name).ToList(),
                Writers = repoWriter.GetAll().OrderBy(o => o.NameSurname).ToList()
            };
            return View(productVM);
        }
        

        public IActionResult Update(BookVM model)
        {
            if (Request.Form.Files.Any())
            {
                string PicturePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "book");
                string PdfPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "pdf");
                if (!Directory.Exists(PicturePath)) Directory.CreateDirectory(PicturePath);
                using (var stream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "book", Request.Form.Files["Book.Picture"].FileName), FileMode.Create))
                {
                    Request.Form.Files["Book.Picture"].CopyTo(stream);
                }
                model.Book.Picture = "/book/" + Request.Form.Files["Book.Picture"].FileName;

                if (!Directory.Exists(PicturePath)) Directory.CreateDirectory(PicturePath);
                using (var stream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "pdf", Request.Form.Files["Book.Link"].FileName), FileMode.Create))
                {
                    Request.Form.Files["Book.Link"].CopyTo(stream);
                }
                model.Book.Link = "/pdf/" + Request.Form.Files["Book.Link"].FileName;
            }
            repoBook.Update(model.Book);
            return RedirectToAction("Index");
        }

        public IActionResult Cancel()
        {
            return RedirectToAction("Index");
        }

        public string Delete(int _id)
        {
            string rtn = "";

            Book product = repoBook.GetBy(g => g.ID == _id) ?? null;
            if (product != null)
            {
                repoBook.Delete(product);
                rtn = "OK";
            }

            return rtn;
        }
    }
}
