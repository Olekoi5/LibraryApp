using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp.Models
{
    public class Book
    {
        [Key]
        public int id { get; set; }

        [DisplayName("Tytuł")]
        public string Title { get; set; }

        [DisplayName("Autor")]
        public string Author { get; set; }

        [DisplayName("Data wydania")]
        [DataType(DataType.Date)]
        public DateTime DateRelease { get; set; }

        [DisplayName("Krótki opis")]
        [StringLength(50)]
        public string ShortDiscription { get; set; }
    }
}
