using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace webAPI.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string UserName { get; set; }

        public IList<Reservation> Reservations { get; set; }

    }
}
