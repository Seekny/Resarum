using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace webAPI.Models
{
    public class Reservation
    {
        [Key]
        public int ReservationID { get; set; }

        [Required, DisplayFormat(DataFormatString = "{0:dd/MM/yyyy.}")]
        public DateTimeOffset StartDate { get; set; }

        [Required, DisplayFormat(DataFormatString = "{0:dd/MM/yyyy.}")]
        public DateTimeOffset EndDate { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Note { get; set; }

        public int UserID { get; set; }

        public int RoomID { get; set; }

        public User User { get; set; }

        public Room Room { get; set; }


    }
}
