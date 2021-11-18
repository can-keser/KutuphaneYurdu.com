using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneYurdu.com.DAL.Entities
{
    [Table("Blog")]
    public class Blog
    {
        public int ID { get; set; }

        [StringLength(100), Column(TypeName = "varchar(100)"), Display(Name = "blog Başlığı")]
        public string Title { get; set; }

        [StringLength(500), Column(TypeName = "varchar(500)"), Display(Name = "blog Açıklaması")]
        public string Description { get; set; }

        [Column(TypeName = "Text"), Display(Name = "blog detayı")]
        public string BlogDetails { get; set; }

        [StringLength(150), Column(TypeName = "varchar(150)"), Display(Name = "Resim Dosyası")]
        public string Picture { get; set; }

        [Column(TypeName ="date"), Display(Name = "Kayıt tarih")]
        public DateTime RecDate { get; set; }
    }
}
