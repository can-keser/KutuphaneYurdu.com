using KutuphaneYurdu.com.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphaneYurdu.com.WebUI.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Book> Books { get; set; }
        public IEnumerable<Blog> Blogs { get; set; }
    }
}
