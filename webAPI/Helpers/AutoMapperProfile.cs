using AutoMapper;
using AutoMapper.EquivalencyExpression;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPI.DTO;
using webAPI.Models;

namespace webAPI.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Agency, AgencyDTO>();
            CreateMap<Room, RoomDTO>();
            CreateMap<RoomDTO, Room>();
            CreateMap<User, UserDTO>();
            CreateMap<ReservationDTO, Reservation>();
            CreateMap<Reservation, ReservationDTO>();
            CreateMap<Equipment, EquipmentDTO>();
            CreateMap<EquipmentRoomDTO, EquipmentRoomDTO>();

        }
    }
}
