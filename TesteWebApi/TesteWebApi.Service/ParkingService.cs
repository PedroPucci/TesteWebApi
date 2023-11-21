using AutoMapper;
using TesteWebApi.Domain.Models;
using TesteWebApi.Domain.Models.Constants;
using TesteWebApi.Domain.Models.Dto;
using TesteWebApi.Repository.Repository.Interfaces;
using TesteWebApi.Service.Interfaces;

namespace TesteWebApi.Service
{
    public class ParkingService : IParkingService
    {
        private readonly IRepositoryUoW _repositoryUoW;
        private readonly IMapper _mapper;
        public Parking? result { get; private set; }

        public ParkingService(IRepositoryUoW repositoryUoW, IMapper mapper)
        {
            _repositoryUoW = repositoryUoW;
            _mapper = mapper;
        }

        public ParkingService(IRepositoryUoW repositoryUoW)
        {
            _repositoryUoW = repositoryUoW;
        }

        public async Task<Parking> AddParking(ParkingDto parkingDto)
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                Parking parking = _mapper.Map<ParkingDto, Parking>(parkingDto);
                parking.CreatedAt = DateTime.Now;
                var result = await _repositoryUoW.ParkingRepository.AddParking(parking);

                await _repositoryUoW.SaveAsync();
                await transaction.CommitAsync();
                return result;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new InvalidOperationException("Erro inesperado " + ex + "!");
            }
        }

        public async Task<List<Parking>> GetAllParkings()
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                List<Parking> parkings = await _repositoryUoW.ParkingRepository.GetAllParkings();
                _repositoryUoW.Commit();
                return parkings;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new InvalidOperationException("Erro inesperado " + ex + "!");
            }
        }

        public int GetAllSpacesParking(int id)
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                int allSpacesParking = _repositoryUoW.ParkingRepository.GetAllSpacesParking(id);
                _repositoryUoW.Commit();
                return allSpacesParking;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new InvalidOperationException("Erro inesperado " + ex + "!");
            }
        }

        public int GetEmptySpacesParking(int id)
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                int emptyAllSpacesParking = _repositoryUoW.ParkingRepository.GetEmptySpacesParking(id);
                _repositoryUoW.Commit();
                return emptyAllSpacesParking;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new InvalidOperationException("Erro inesperado " + ex + "!");
            }
        }

        public bool GetFullParking(int id)
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                int emptyAllSpacesParking = _repositoryUoW.ParkingRepository.GetEmptySpacesParking(id);

                if (emptyAllSpacesParking == 0)
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new InvalidOperationException("Erro inesperado " + ex + "!");
            }
        }

        public bool GetEmptyParking(int id)
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                int spacesParking = _repositoryUoW.ParkingRepository.GetEmptySpacesParking(id);
                int allSpacesParking = _repositoryUoW.ParkingRepository.GetAllSpacesParking(id);

                if (spacesParking == allSpacesParking)
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new InvalidOperationException("Erro inesperado " + ex + "!");
            }
        }

        public async Task<Parking?> UpdateSpacesParking(VehicleDto vehicleDto, int id)
        {
            using var transaction = _repositoryUoW.BeginTransaction();

            try
            {
                Parking? parking = await _repositoryUoW.ParkingRepository.GetParkingById(id);

                if (parking != null)
                {
                    if (vehicleDto.VehicleType == VehicleType.Motorcycle)
                    {
                        parking = await RoleVehicleMotorcycle(vehicleDto, parking, id);
                    }

                    if (vehicleDto.VehicleType == VehicleType.Car)
                    {
                        parking = await RoleVehicleCar(vehicleDto, parking, id);
                    }

                    if (vehicleDto.VehicleType == VehicleType.Van)
                    {
                        parking = await RoleVehicleVan(vehicleDto, parking, id);
                    }

                    _repositoryUoW.ParkingRepository.UpdateParking(parking);
                    await _repositoryUoW.SaveAsync();
                    await transaction.CommitAsync();

                    return parking;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new InvalidOperationException("Erro inesperado: " + ex.Message);
            }
        }

        public async Task<Parking?> RoleVehicleVan(VehicleDto vehicleDto, Parking parking, int id)
        {
            if (parking.TotalSpaceCar != parking.QtdSpacesCar)
            {
                parking.QtdSpacesCar = parking.QtdSpacesCar + 2;
            }
            else if (parking.TotalSpaceVan != parking.QtdSpacesBig)
            {
                parking.QtdSpacesBig++;
            }
            else
            {
                throw new InvalidOperationException("Não existem vagas suficientes para a van em todas as vagas!");
            }

            var result = _repositoryUoW.ParkingRepository.UpdateParking(parking);
            await CreateVehicle(vehicleDto, id);

            await _repositoryUoW.SaveAsync();

            return result;
        }

        public async Task<Parking?> RoleVehicleMotorcycle(VehicleDto vehicleDto, Parking parking, int id)
        {
            if (parking.TotalSpaceMotorcycle != parking.QtdSpacesMotorcycle)
            {
                parking.QtdSpacesMotorcycle++;
            }
            else if (parking.TotalSpaceCar != parking.QtdSpacesCar)
            {
                parking.QtdSpacesCar++;
            }
            else if (parking.TotalSpaceVan != parking.QtdSpacesBig)
            {
                parking.QtdSpacesBig++;
            }
            else
            {
                throw new InvalidOperationException("Não existem vagas suficientes para a moto em todas as vagas!");
            }

            var result = _repositoryUoW.ParkingRepository.UpdateParking(parking);
            await CreateVehicle(vehicleDto, id);

            await _repositoryUoW.SaveAsync();
            
            return result;
        }

        public async Task<Parking?> RoleVehicleCar(VehicleDto vehicleDto, Parking parking, int id)
        {
            if (parking.TotalSpaceCar != parking.QtdSpacesCar)
            {
                parking.QtdSpacesCar++;
            }
            else if (parking.TotalSpaceVan != parking.QtdSpacesBig)
            {
                parking.QtdSpacesBig++;
            }
            else
            {
                throw new InvalidOperationException("Não existem vagas suficientes para carros nas vagas de carro e de van!");
            }

            var result = _repositoryUoW.ParkingRepository.UpdateParking(parking);
            await CreateVehicle(vehicleDto, id);

            await _repositoryUoW.SaveAsync();
            
            return result;
        }

        public async Task<Vehicle> CreateVehicle(VehicleDto vehicleDto, int id)
        {
            Vehicle vehicle = _mapper.Map<VehicleDto, Vehicle>(vehicleDto);
            vehicle.ParkingId = id;
            vehicle.DateEntry = DateTime.UtcNow;
            return await _repositoryUoW.VehicleRepository.AddVechile(vehicle);
        }
    }
}