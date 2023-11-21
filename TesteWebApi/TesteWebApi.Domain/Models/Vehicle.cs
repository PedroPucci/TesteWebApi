using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TesteWebApi.Domain.Models.Constants;

namespace TesteWebApi.Domain.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("ParkingId")]
        public int ParkingId { get; set; }
        public VehicleType VehicleType { get; set; }
        public string? VehicleBrand { get; set; }
        public string? VehicleModel { get; set; }
        public string? VehicleLicensePlate { get; set; }
        public string? VehicleOwner { get; set; }
        public int VehicleYear { get; set; }
        public DateTime DateEntry { get; set; }
        public DateTime DateExit { get; set; }
    }
}