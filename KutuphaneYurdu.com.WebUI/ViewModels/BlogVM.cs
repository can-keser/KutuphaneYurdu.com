using KutuphaneYurdu.com.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphaneYurdu.com.WebUI.ViewModels
{
    public class BlogVM
    {
        public Blog Blog { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}
