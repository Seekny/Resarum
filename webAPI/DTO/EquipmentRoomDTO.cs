using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPI.Models;

namespace webAPI.DTO
{
    public class EquipmentRoomDTO
    {

        public int RoomID { get; set; }

        public Room Room { get; set; }
        
        public int EquipmentID { get; set; }

        public Equipment Equipment { get; set; }
    }
}
