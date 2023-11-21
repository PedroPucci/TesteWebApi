using Microsoft.EntityFrameworkCore;
using TesteWebApi.Domain.Models;
using TesteWebApi.Domain.Models.Constants;
using TesteWebApi.Repository.Repository.Interfaces;

namespace TesteWebApi.Repository.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly DataBaseContext _context;

        public VehicleRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<Vehicle> AddVechile(Vehicle vehicle)
        {
            var result = await _context.Vehicle.AddAsync(vehicle);
            return result.Entity;
        }

        public async Task<List<Vehicle>> GetAllVehicles()
        {
            return await _context.Vehicle.ToListAsync();
        }

        public async Task<List<Vehicle>> GetAllVanForParking(int parkingId)
        {
            return await _context.Vehicle.Where(vehicle => vehicle.ParkingId == parkingId && vehicle.VehicleType == VehicleType.Van).ToListAsync();
        }
    }
}