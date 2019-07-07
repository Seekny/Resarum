using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPI.Models;

namespace webAPI.DTO
{
    public class AgencyDTO
    {
        public int AgencyID { get; set; }
        public string AgencyName { get; set; }
        public string Address { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public string AgencyImage { get; set; }

        public virtual List<Room> Rooms { get; set; }
    }
}
