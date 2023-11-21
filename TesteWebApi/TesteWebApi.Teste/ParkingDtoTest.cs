using TesteWebApi.Domain.Models.Dto;

namespace TesteWebApi.Teste
{
    public class ParkingDtoTest
    {
        [Fact(DisplayName = "Created the Parking object with success")]
        public void CreateParkingDto_WithValidValues()
        {
            // Arrange
            var name = "Teste 1";
            int totalSpaceCar = 20;
            int totalSpaceVan = 30;
            int totalSpaceMotorcycle = 40;

            // Act
            var parkingDto = new ParkingDto(
                name,
                totalSpaceCar,
                totalSpaceVan,
                totalSpaceMotorcycle);

            // Assert
            Assert.NotNull(parkingDto);
            Assert.Equal(totalSpaceCar, parkingDto.TotalSpaceCar);
            Assert.Equal(totalSpaceVan, parkingDto.TotalSpaceVan);
            Assert.Equal(totalSpaceMotorcycle, parkingDto.TotalSpaceMotorcycle);
            Assert.Equal(name, parkingDto.Name);
        }
    }
}