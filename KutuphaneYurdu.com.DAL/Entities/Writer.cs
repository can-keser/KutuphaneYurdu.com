using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneYurdu.com.DAL.Entities
{
    [Table("Writer")]
    public class Writer
    {
        public int ID { get; set; }

        [StringLength(150), Column(TypeName = "varchar(150)"), Display(Name = "Yazar Adı")]
        public string NameSurname { get; set; }
        
        [Display(Name = "Görüntülenme Sırası")]
        public int DisplayIndex { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
