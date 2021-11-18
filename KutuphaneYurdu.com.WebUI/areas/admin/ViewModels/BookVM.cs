using KutuphaneYurdu.com.DAL.Entities;
using System.Collections.Generic;

namespace KutuphaneYurdu.com.WebUI.areas.admin.ViewModels
{
    public class BookVM
    {
        public Book Book { get; set; }
        public List<Category> Categories { get; set; }
        public List<Writer> Writers { get; set; }
    }
}
