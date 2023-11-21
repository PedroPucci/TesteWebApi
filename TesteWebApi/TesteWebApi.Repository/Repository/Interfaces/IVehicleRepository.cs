using TesteWebApi.Domain.Models;

namespace TesteWebApi.Repository.Repository.Interfaces
{
    public interface IVehicleRepository
    {
        public Task<Vehicle> AddVechile(Vehicle vehicle);

        public Task<List<Vehicle>> GetAllVehicles();
        public Task<List<Vehicle>> GetAllVanForParking(int parkingId);
    }
}