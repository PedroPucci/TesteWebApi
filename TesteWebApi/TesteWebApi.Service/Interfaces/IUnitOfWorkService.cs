namespace TesteWebApi.Service.Interfaces
{
    public interface IUnitOfWorkService
    {
        ParkingService ParkingService { get; }
        VehicleService VehicleService { get; }
    }
}