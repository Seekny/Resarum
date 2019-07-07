using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace webAPI.Models
{
    public class Agency
    {
       

        [Key]
        public int AgencyID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string AgencyName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(250)")]
        public string Address { get; set; }

        [Required]
        [MaxLength(10)]
        public string Latitude { get; set; }

        [Required]
        [MaxLength(10)]
        public string Longitude { get; set; }


        public string AgencyImage { get; set; }


        public virtual List<Room> Rooms { get; set; }
    }
}
