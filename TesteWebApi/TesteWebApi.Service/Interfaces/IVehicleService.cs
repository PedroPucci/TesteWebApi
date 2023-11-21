using TesteWebApi.Domain.Models;

namespace TesteWebApi.Service.Interfaces
{
    public interface IVehicleService
    {
        public Task<List<Vehicle>> GetAllVehicles();
        public Task<List<Vehicle>> GetAllVanForParking(int parkingId);
    }
}