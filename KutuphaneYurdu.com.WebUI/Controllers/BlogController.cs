using KutuphaneYurdu.com.BL.Repositories;
using KutuphaneYurdu.com.DAL.Entities;
using KutuphaneYurdu.com.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphaneYurdu.com.WebUI.Controllers
{
    public class BlogController : Controller
    {
        MSSQLRepo<Blog> repoBlog;
        public BlogController(MSSQLRepo<Blog> _repoBlog)
        {
            repoBlog = _repoBlog;
        }
        
        public IActionResult Index()
        {
            return View(repoBlog.GetAll().OrderBy(o=>o.RecDate));
        }

        [Route("blog/{name}/{id}")]
        public IActionResult Detail(string name,int id)
        {
            Blog blog = repoBlog.GetAll(g => g.ID == id).FirstOrDefault() ?? null;
            if (blog != null)
            {
                BlogVM blogVM = new BlogVM();
                blogVM.Blog = blog;
                blogVM.Blogs = repoBlog.GetAll(g=>g.ID!=id).OrderByDescending(o=>o.RecDate).Take(4).ToList();
                return View(blogVM);
            }
            else return Redirect("/");
        }
    }
}
