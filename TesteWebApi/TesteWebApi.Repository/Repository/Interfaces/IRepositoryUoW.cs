using Microsoft.EntityFrameworkCore.Storage;

namespace TesteWebApi.Repository.Repository.Interfaces
{
    public interface IRepositoryUoW
    {
        IParkingRepository ParkingRepository { get; }
        IVehicleRepository VehicleRepository { get; }

        Task SaveAsync();
        void Commit();
        IDbContextTransaction BeginTransaction();
    }
}
