using TesteWebApi.Domain.Models.Constants;
using TesteWebApi.Domain.Models.Dto;
using TesteWebApi.Domain.Models;

namespace TesteWebApi.Teste
{
    public class VehicleDtoTest
    {
        [Fact(DisplayName = "Created the Vehicle object with success")]
        public void CreateVehicleDto_WithValidValues()
        {
            // Arrange
            var parking = 1;
            var vehicleType = VehicleType.Car;
            var vehicleBrand = "Carro teste 1";
            var vehicleModel = "Usuario carro teste 1";
            var vehicleLicensePlate = "ABC123";
            var vehicleOwner = "Usuario 1";
            var vehicleYear = 2022;
            var dateEntry = DateTime.Now;
            var dateExit = dateEntry.AddHours(2);

            // Act
            var vehicleDto = new VehicleDto(
                parking,
                vehicleType,
                vehicleBrand,
                vehicleModel,
                vehicleLicensePlate,
                vehicleOwner,
                vehicleYear,
                dateEntry,
                dateExit);

            // Assert
            Assert.NotNull(vehicleDto);
            Assert.Equal(parking, vehicleDto.ParkingId);
            Assert.Equal(vehicleType, vehicleDto.VehicleType);
            Assert.Equal(vehicleBrand, vehicleDto.VehicleBrand);
            Assert.Equal(vehicleModel, vehicleDto.VehicleModel);
            Assert.Equal(vehicleLicensePlate, vehicleDto.VehicleLicensePlate);
            Assert.Equal(vehicleOwner, vehicleDto.VehicleOwner);
            Assert.Equal(vehicleYear, vehicleDto.VehicleYear);
            Assert.Equal(dateEntry, vehicleDto.DateEntry);
            Assert.Equal(dateExit, vehicleDto.DateExit);
        }
    }
}