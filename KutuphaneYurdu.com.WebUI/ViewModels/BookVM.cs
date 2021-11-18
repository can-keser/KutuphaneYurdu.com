using KutuphaneYurdu.com.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphaneYurdu.com.WebUI.ViewModels
{
    public class BookVM
    {
        public Book Book { get; set; }
        public List<Book> Books { get; set; }
    }
}
