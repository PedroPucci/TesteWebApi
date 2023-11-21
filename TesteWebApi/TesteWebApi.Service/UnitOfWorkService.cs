using AutoMapper;
using Microsoft.Extensions.Configuration;
using TesteWebApi.Repository.Repository.Interfaces;
using TesteWebApi.Service.Interfaces;

namespace TesteWebApi.Service
{
    public class UnitOfWorkService : IUnitOfWorkService
    {
        private readonly IRepositoryUoW _repositoryUoW;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public UnitOfWorkService(IRepositoryUoW repositoryUoW, IMapper mapper, IConfiguration config)
        {
            _repositoryUoW = repositoryUoW;
            _mapper = mapper;
            _config = config;
        }

        private ParkingService? parkingService;
        public ParkingService ParkingService
        {
            get
            {
                if (parkingService == null)
                {
                    parkingService = new ParkingService(_repositoryUoW, _mapper);
                }
                return parkingService;
            }
        }

        private VehicleService? vehicleService;
        public VehicleService VehicleService
        {
            get
            {
                if (vehicleService == null)
                {
                    vehicleService = new VehicleService(_repositoryUoW);
                }
                return vehicleService;
            }
        }
    }
}