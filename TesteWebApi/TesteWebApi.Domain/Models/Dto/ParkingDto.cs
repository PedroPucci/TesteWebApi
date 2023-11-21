using System.ComponentModel.DataAnnotations;

namespace TesteWebApi.Domain.Models.Dto
{
    public class ParkingDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int TotalSpaceCar { get; set; }

        [Required]
        public int TotalSpaceMotorcycle { get; set; }

        [Required]
        public int TotalSpaceVan { get; set; }

        [Required]
        public int QtdSpacesCar { get; set; }

        [Required]
        public int QtdSpacesMotorcycle { get; set; }

        [Required]
        public int QtdSpacesBig { get; set; }

        [Required]
        public DateTime? CreatedAt { get; set; }

        public ParkingDto() { }

        public ParkingDto(
            string name, 
            int totalSpaceCar, 
            int totalSpaceMotorcycle, 
            int totalSpaceVan, 
            int qtdSpacesCar, 
            int qtdSpacesMotorcycle, 
            int qtdSpacesBig, 
            DateTime? createdAt)
        {
            Name = name;
            TotalSpaceCar = totalSpaceCar;
            TotalSpaceMotorcycle = totalSpaceMotorcycle;
            TotalSpaceVan = totalSpaceVan;
            QtdSpacesCar = qtdSpacesCar;
            QtdSpacesMotorcycle = qtdSpacesMotorcycle;
            QtdSpacesBig = qtdSpacesBig;
            CreatedAt = createdAt;
        }

        public ParkingDto(
            string name, 
            int totalSpaceCar, 
            int totalSpaceVan, 
            int totalSpaceMotorcycle)
        {
            Name = name;
            TotalSpaceCar = totalSpaceCar;
            TotalSpaceVan = totalSpaceVan;
            TotalSpaceMotorcycle = totalSpaceMotorcycle;
        }
    }
}