using KutuphaneYurdu.com.BL.Repositories;
using KutuphaneYurdu.com.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphaneYurdu.com.WebUI.ViewComponents
{
    public class Header2ViewComponent:ViewComponent
    {
        MSSQLRepo<Category> repoCategory;
        public Header2ViewComponent(MSSQLRepo<Category> _repoCategory)
        {
            repoCategory = _repoCategory;
        }
        public IViewComponentResult Invoke()
        {
            return View(repoCategory.GetAll().OrderBy(o => o.DisplayIndex));
        }
    }
}
