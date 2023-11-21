using TesteWebApi.Domain.Models;

namespace TesteWebApi.Teste
{
    public class ParkingTest
    {
        [Fact(DisplayName = "Create object Parking with custom values")]
        public void CreateParking_WithCustomValues()
        {
            // Arrange
            var id = 1;
            var totalSpaceCar = 0;
            var totalSpaceMotorcycle = 0;
            var totalSpaceVan = 0;
            var name = "Teste 1";
            var qtdSpacesCar = 5;
            var qtdSpacesMotorcycle = 3;
            var qtdSpacesBig = 10;
            DateTime createdAt = DateTime.Now;

            // Act
            var parking = new Parking
            {
                Id = id,
                TotalSpaceCar = totalSpaceCar,
                TotalSpaceMotorcycle = totalSpaceMotorcycle,
                TotalSpaceVan = totalSpaceVan,
                CreatedAt = createdAt,
                Name = name,
                QtdSpacesCar = qtdSpacesCar,
                QtdSpacesMotorcycle = qtdSpacesMotorcycle,
                QtdSpacesBig = qtdSpacesBig
            };

            // Assert
            Assert.NotNull(parking);
            Assert.Equal(totalSpaceCar, parking.TotalSpaceCar);
            Assert.Equal(totalSpaceVan, parking.TotalSpaceVan);
            Assert.Equal(totalSpaceMotorcycle, parking.TotalSpaceMotorcycle);
            Assert.Equal(createdAt, parking.CreatedAt);
            Assert.Equal(name, parking.Name);
            Assert.Equal(qtdSpacesCar, parking.QtdSpacesCar);
            Assert.Equal(qtdSpacesMotorcycle, parking.QtdSpacesMotorcycle);
            Assert.Equal(qtdSpacesBig, parking.QtdSpacesBig);
        }

        [Fact(DisplayName = "Create object Parking - error value name")]
        public void CreateParking_ErrorValues()
        {
            // Arrange
            var qtdSpacesCar = 5;
            var qtdSpacesMotorcycle = 3;
            var qtdSpacesBig = 10;

            // Act
            var parking = new Parking
            {
                Name = null,
                QtdSpacesCar = qtdSpacesCar,
                QtdSpacesMotorcycle = qtdSpacesMotorcycle,
                QtdSpacesBig = qtdSpacesBig
            };

            // Assert
            Assert.False(false, parking.Name);
        }
    }
}