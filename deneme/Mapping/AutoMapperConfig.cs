using AutoMapper;
using HotelProject.DtoLayer.DTOs.RoomDto;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.WebApi.Mapping
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<RoomAddDto, Room>();
            CreateMap<Room,RoomAddDto>();

            CreateMap<UpdateRoomDto, Room>().ReverseMap();  // ReverseMap ile tersinede otomatik ekliyor

        }
    }
}
