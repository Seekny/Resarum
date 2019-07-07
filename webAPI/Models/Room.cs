using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace webAPI.Models
{
    public class Room
    {
     

        [Key]
        public int RoomID { get; set; }

        public int Floor { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string Description { get; set; }

        [Required]
        [Column(TypeName ="nvarchar(50)")]
        public string RoomName { get; set; }

        [Required]
        [MaxLength(100)]
        public int Places { get; set; }


        public string RoomImage { get; set; }

        public IList<Reservation> Reservations { get; set; }
        public int AgencyID { get; set; }

        public virtual Agency Agency { get; set; }
        public IList<EquipmentRooms> EquipmentsRooms { get; set; }
    }

   
}
