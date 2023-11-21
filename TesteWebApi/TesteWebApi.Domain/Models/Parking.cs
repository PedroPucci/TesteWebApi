using System.ComponentModel.DataAnnotations;

namespace TesteWebApi.Domain.Models
{
    public class Parking
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int TotalSpaceCar { get; set; }
        public int TotalSpaceMotorcycle { get; set; }
        public int TotalSpaceVan { get; set; }
        public int QtdSpacesCar { get; set; }
        public int QtdSpacesMotorcycle { get; set; }
        public int QtdSpacesBig{ get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}