using AutoMapper;
using TesteWebApi.Domain.Models;
using TesteWebApi.Domain.Models.Dto;

namespace TesteWebApi.Repository
{
    public class Mappers : Profile
    {
        public Mappers()
        {

        }

        public MapperConfiguration Configuration()
        {
            return new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<Parking, ParkingDto>();
                cfg.CreateMap<ParkingDto, Parking>();

                cfg.CreateMap<Vehicle, VehicleDto>();
                cfg.CreateMap<VehicleDto, Vehicle>();
            });
        }
    }
}