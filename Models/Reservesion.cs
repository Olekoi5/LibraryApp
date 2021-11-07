using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace LibraryApp.Models
{
    public class Reservesion
    {
        [Key]
        public int id { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateReservesion { get; set; }

        public Book bookId { get; set; }

        public string userLogin { get; set; }
    }
}
