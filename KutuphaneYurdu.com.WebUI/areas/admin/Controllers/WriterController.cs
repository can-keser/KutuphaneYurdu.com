using KutuphaneYurdu.com.BL.Repositories;
using KutuphaneYurdu.com.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphaneYurdu.com.WebUI.Areas.admin.Controllers
{
    [Area("admin"), Authorize, Route("/admin/[controller]/[action]/{id?}")]
    public class WriterController : Controller
    {
        MSSQLRepo<Writer> repoWriter;
        public WriterController(MSSQLRepo<Writer> _repoWriter)
        {
            repoWriter = _repoWriter;
        }

        public IActionResult Index()
        {
            return View(repoWriter.GetAll());
        }

        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult New(Writer model)
        {
            repoWriter.Add(model);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            return View(repoWriter.GetBy(g => g.ID == id));
        }

        public IActionResult Update(Writer model)
        {
            repoWriter.Update(model);
            return RedirectToAction("Index");
        }

        public IActionResult Cancel()
        {
            return RedirectToAction("Index");
        }

        public string Delete(int _id)
        {
            string rtn = "";

            Writer writer = repoWriter.GetBy(g => g.ID == _id) ?? null;
            if (writer != null)
            {
                repoWriter.Delete(writer);
                rtn = "OK";
            }

            return rtn;
        }
    }
}
