using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPI.Models;

namespace webAPI.DTO
{
    public class RoomDTO
    {
        public int RoomID { get; set; }

        public int Floor { get; set; }

        public string Description { get; set; }

        public int Places { get; set; }


        public string RoomImage { get; set; }

        public string RoomName { get; set; }

        public IList<Reservation> Reservations { get; set; }
        public int AgencyID { get; set; }

        public virtual Agency Agency { get; set; }
        public IList<EquipmentRooms> EquipmentsRooms { get; set; }
    }
}
