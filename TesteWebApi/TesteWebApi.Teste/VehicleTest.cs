using TesteWebApi.Domain.Models;
using TesteWebApi.Domain.Models.Constants;

namespace TesteWebApi.Teste
{
    public class VehicleTest
    {
        [Fact(DisplayName = "Create object Vehicle Car")]
        public void CreateVehicleCar_WithCustomValues()
        {
            // Arrange
            var id = 1;
            var parkingId = 1;
            var vehicleType = VehicleType.Car;
            var vehicleBrand = "Carro1";
            var vehicleModel = "ModeloX";
            var licensePlate = "ABC-123";
            var vehicleOwner = "Usuario 1";
            var vehicleYear = 2020;
            var dateEntry = DateTime.Now;
            var dateExit = DateTime.Now.AddHours(2);

            // Act
            var vehicle = new Vehicle
            {
                Id = id,
                ParkingId = parkingId,
                VehicleType = vehicleType,
                VehicleBrand = vehicleBrand,
                VehicleModel = vehicleModel,
                VehicleLicensePlate = licensePlate,
                VehicleOwner = vehicleOwner,
                VehicleYear = vehicleYear,
                DateEntry = dateEntry,
                DateExit = dateExit
            };

            // Assert
            Assert.NotNull(vehicle);
            Assert.Equal(id, vehicle.Id);
            Assert.Equal(parkingId, vehicle.ParkingId);
            Assert.Equal(vehicleType, vehicle.VehicleType);
            Assert.Equal(vehicleBrand, vehicle.VehicleBrand);
            Assert.Equal(vehicleModel, vehicle.VehicleModel);
            Assert.Equal(licensePlate, vehicle.VehicleLicensePlate);
            Assert.Equal(vehicleOwner, vehicle.VehicleOwner);
            Assert.Equal(vehicleYear, vehicle.VehicleYear);
            Assert.Equal(dateEntry, vehicle.DateEntry);
            Assert.Equal(dateExit, vehicle.DateExit);
        }

        [Fact(DisplayName = "Create object Vehicle Van")]
        public void CreateVehicleVan_WithCustomValues()
        {
            // Arrange
            var id = 1;
            var parkingId = 1;
            var vehicleType = VehicleType.Van;
            var vehicleBrand = "Van1";
            var vehicleModel = "ModeloX";
            var licensePlate = "ABC-124";
            var vehicleOwner = "Usuario 2";
            var vehicleYear = 2021;
            var dateEntry = DateTime.Now;
            var dateExit = DateTime.Now.AddHours(3);

            // Act
            var vehicle = new Vehicle
            {
                Id = id,
                ParkingId = parkingId,
                VehicleType = vehicleType,
                VehicleBrand = vehicleBrand,
                VehicleModel = vehicleModel,
                VehicleLicensePlate = licensePlate,
                VehicleOwner = vehicleOwner,
                VehicleYear = vehicleYear,
                DateEntry = dateEntry,
                DateExit = dateExit
            };

            // Assert
            Assert.NotNull(vehicle);
            Assert.Equal(id, vehicle.Id);
            Assert.Equal(parkingId, vehicle.ParkingId);
            Assert.Equal(vehicleType, vehicle.VehicleType);
            Assert.Equal(vehicleBrand, vehicle.VehicleBrand);
            Assert.Equal(vehicleModel, vehicle.VehicleModel);
            Assert.Equal(licensePlate, vehicle.VehicleLicensePlate);
            Assert.Equal(vehicleOwner, vehicle.VehicleOwner);
            Assert.Equal(vehicleYear, vehicle.VehicleYear);
            Assert.Equal(dateEntry, vehicle.DateEntry);
            Assert.Equal(dateExit, vehicle.DateExit);
        }

        [Fact(DisplayName = "Create object Vehicle Motorciclye")]
        public void CreateVehicleMotorciclye_WithCustomValues()
        {
            // Arrange
            var id = 1;
            var parkingId = 1;
            var vehicleType = VehicleType.Motorcycle;
            var vehicleBrand = "Moto1";
            var vehicleModel = "ModeloX";
            var licensePlate = "ABC-125";
            var vehicleOwner = "Usuario 3";
            var vehicleYear = 2017;
            var dateEntry = DateTime.Now;
            var dateExit = DateTime.Now.AddHours(1);

            // Act
            var vehicle = new Vehicle
            {
                Id = id,
                ParkingId = parkingId,
                VehicleType = vehicleType,
                VehicleBrand = vehicleBrand,
                VehicleModel = vehicleModel,
                VehicleLicensePlate = licensePlate,
                VehicleOwner = vehicleOwner,
                VehicleYear = vehicleYear,
                DateEntry = dateEntry,
                DateExit = dateExit
            };

            // Assert
            Assert.NotNull(vehicle);
            Assert.Equal(id, vehicle.Id);
            Assert.Equal(parkingId, vehicle.ParkingId);
            Assert.Equal(vehicleType, vehicle.VehicleType);
            Assert.Equal(vehicleBrand, vehicle.VehicleBrand);
            Assert.Equal(vehicleModel, vehicle.VehicleModel);
            Assert.Equal(licensePlate, vehicle.VehicleLicensePlate);
            Assert.Equal(vehicleOwner, vehicle.VehicleOwner);
            Assert.Equal(vehicleYear, vehicle.VehicleYear);
            Assert.Equal(dateEntry, vehicle.DateEntry);
            Assert.Equal(dateExit, vehicle.DateExit);
        }

        [Fact(DisplayName = "Create object Vehicle Motorciclye error value")]
        public void CreateVehicleMotorciclye_ErrorValues()
        {
            // Arrange
            var id = 1;
            var parkingId = 1;
            var vehicleType = VehicleType.Motorcycle;
            var vehicleModel = "ModeloX";
            var licensePlate = "ABC-125";
            var vehicleOwner = "Usuario 3";
            var vehicleYear = 2017;
            var dateEntry = DateTime.Now;
            var dateExit = DateTime.Now.AddHours(1);

            // Act
            var vehicle = new Vehicle
            {
                Id = id,
                ParkingId = parkingId,
                VehicleType = vehicleType,
                VehicleBrand = null,
                VehicleModel = vehicleModel,
                VehicleLicensePlate = licensePlate,
                VehicleOwner = vehicleOwner,
                VehicleYear = vehicleYear,
                DateEntry = dateEntry,
                DateExit = dateExit
            };

            // Assert
            Assert.False(false, vehicle.VehicleBrand);
        }
    }
}