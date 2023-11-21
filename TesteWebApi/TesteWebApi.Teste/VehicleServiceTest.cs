using Moq;
using TesteWebApi.Domain.Models;
using TesteWebApi.Repository.Repository.Interfaces;
using TesteWebApi.Service;

namespace TesteWebApi.Teste
{
    public class VehicleServiceTest
    {
        [Fact(DisplayName = "Return All vehicles")]
        public async Task GetAllVehicle_ReturnAll_Success()
        {
            var vehiclesResult = new List<Vehicle>();
            var mockRepositoryUoW = new Mock<IRepositoryUoW>();

            mockRepositoryUoW.Setup(uow => uow.VehicleRepository.GetAllVehicles())
                             .ReturnsAsync(vehiclesResult);

            var vehicleService = new VehicleService(mockRepositoryUoW.Object);
            var result = await vehicleService.GetAllVehicles();

            Assert.Equal(vehiclesResult, result);
        }
    }
}