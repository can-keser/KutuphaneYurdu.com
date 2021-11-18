using KutuphaneYurdu.com.BL.Repositories;
using KutuphaneYurdu.com.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;

namespace KutuphaneYurdu.com.WebUI.Areas.admin.Controllers
{
    [Area("admin"), Authorize, Route("/admin/[controller]/[action]/{id?}")]
    public class BlogController : Controller
    {
        MSSQLRepo<Blog> repoBlog;
        public BlogController(MSSQLRepo<Blog> _repoBlog)
        {
            repoBlog = _repoBlog;
        }

        public IActionResult Index()
        {
            return View(repoBlog.GetAll());
        }

        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult New(Blog model)
        {
            if (Request.Form.Files.Any())
            {
                string picturePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "blog");
                if (!Directory.Exists(picturePath)) Directory.CreateDirectory(picturePath);
                using (var stream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "blog", Request.Form.Files["Picture"].FileName), FileMode.Create))
                {
                    Request.Form.Files["Picture"].CopyTo(stream);
                }
                model.Picture = "/blog/" + Request.Form.Files["Picture"].FileName;
            }

            repoBlog.Add(model);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            return View(repoBlog.GetBy(g => g.ID == id));
        }

        public IActionResult Update(Blog model)
        {
            if (Request.Form.Files.Any())
            {
                string picturePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "blog");
                if (!Directory.Exists(picturePath)) Directory.CreateDirectory(picturePath);
                using (var stream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "blog", Request.Form.Files["Picture"].FileName), FileMode.Create))
                {
                    Request.Form.Files["Picture"].CopyTo(stream);
                }
                model.Picture = "/blog/" + Request.Form.Files["Picture"].FileName;
                model.RecDate = DateTime.Now;
            }

            repoBlog.Update(model);
            return RedirectToAction("Index");
        }

        public IActionResult Cancel()
        {
            return RedirectToAction("Index");
        }

        public string Delete(int _id)
        {
            string rtn = "";

            Blog blog = repoBlog.GetBy(g => g.ID == _id) ?? null;
            if (blog != null)
            {
                repoBlog.Delete(blog);
                rtn = "OK";
            }

            return rtn;
        }
    }
}
