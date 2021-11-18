using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneYurdu.com.DAL.Entities
{
    [Table("Book")]
    public class Book
    {
        public int ID { get; set; }

        [StringLength(100), Column(TypeName = "varchar(100)"), Display(Name = "Kitap Adı")]
        public string Name { get; set; }

        [Column(TypeName = "text"), Display(Name = "Kitap Açıklaması")]
        public string Description { get; set; }

        [StringLength(150), Column(TypeName = "varchar(150)"), Display(Name = "Resim Dosyası")]
        public string Picture { get; set; }

        [StringLength(150), Column(TypeName = "varchar(150)"), Display(Name = "Pdf adresi")]
        public string Link { get; set; }

        [Display(Name = "Görüntülenme Sırası")]
        public int DisplayIndex { get; set; }

        [Display(Name = "kategori")]
        public int? CategoryID { get; set; }
        public Category Category { get; set; }

        [Display(Name = "Yazar")]
        public int? WriterID { get; set; }
        public Writer Writer { get; set; }
    }
}
