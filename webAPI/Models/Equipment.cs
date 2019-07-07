using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace webAPI.Models
{
    public class Equipment
    {
       

        [Key]
        public int EquipmentID { get; set; }
        
        [Required, Column(TypeName = "nvarchar(255)")]
        public string EquipmentName { get; set; }

        public IList<EquipmentRooms> EquipmentsRooms { get; set; }




    }
}
