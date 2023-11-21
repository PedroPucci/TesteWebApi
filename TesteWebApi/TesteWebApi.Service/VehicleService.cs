using TesteWebApi.Domain.Models;
using TesteWebApi.Repository.Repository.Interfaces;
using TesteWebApi.Service.Interfaces;

namespace TesteWebApi.Service
{
    public class VehicleService : IVehicleService
    {
        private readonly IRepositoryUoW _repositoryUoW;

        public VehicleService(IRepositoryUoW repositoryUoW)
        {
            _repositoryUoW = repositoryUoW;
        }

        public async Task<List<Vehicle>> GetAllVehicles()
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                List<Vehicle> vehicles = await _repositoryUoW.VehicleRepository.GetAllVehicles();
                _repositoryUoW.Commit();
                return vehicles;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new InvalidOperationException("Erro inesperado " + ex + "!");
            }
        }

        public async Task<List<Vehicle>> GetAllVanForParking(int parkingId)
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                List<Vehicle> vehicles = await _repositoryUoW.VehicleRepository.GetAllVanForParking(parkingId);
                _repositoryUoW.Commit();
                return vehicles;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new InvalidOperationException("Erro inesperado " + ex + "!");
            }
        }
    }
}