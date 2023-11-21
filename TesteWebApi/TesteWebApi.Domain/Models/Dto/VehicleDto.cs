using System.ComponentModel.DataAnnotations;
using TesteWebApi.Domain.Models.Constants;

namespace TesteWebApi.Domain.Models.Dto
{
    public class VehicleDto
    {
        [Required]
        public int ParkingId { get; set; }

        [Required]
        public VehicleType VehicleType { get; set; }

        [Required]
        public string? VehicleBrand { get; set; }

        [Required]
        public string? VehicleModel { get; set; }

        [Required]
        public string? VehicleLicensePlate { get; set; }

        [Required]
        public string? VehicleOwner { get; set; }

        [Range(1900, 2025)]
        public int VehicleYear { get; set; }

        [Required]
        public DateTime DateEntry { get; set; }

        [Required]
        public DateTime DateExit { get; set; }

        public VehicleDto(
            int parkingId,
            VehicleType vehicleType, 
            string? vehicleBrand, 
            string? vehicleModel, 
            string? vehicleLicensePlate, 
            string? vehicleOwner, 
            int vehicleYear, 
            DateTime dateEntry, 
            DateTime dateExit)
        {
            ParkingId = parkingId;
            VehicleType = vehicleType;
            VehicleBrand = vehicleBrand;
            VehicleModel = vehicleModel;
            VehicleLicensePlate = vehicleLicensePlate;
            VehicleOwner = vehicleOwner;
            VehicleYear = vehicleYear;
            DateEntry = dateEntry;
            DateExit = dateExit;
        }
    }
}