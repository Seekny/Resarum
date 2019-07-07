using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using webAPI.Models;

namespace webAPI.DTO
{
    public class ReservationDTO
    {
        public int ReservationID { get; set; }


        [Required, DisplayFormat(DataFormatString = "{0:dd/MM/yyyy.}")]
        public DateTimeOffset StartDate { get; set; }


        [Required, DisplayFormat(DataFormatString = "{0:dd/MM/yyyy.}")]
        public DateTimeOffset EndDate { get; set; }

        public string Note { get; set; }

        public int UserID { get; set; }
        public int RoomID { get; set; }

        public Room Room { get; set; }

        public User User { get; set; }


    }
}
