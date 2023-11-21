using Microsoft.EntityFrameworkCore.Storage;
using TesteWebApi.Repository.Repository.Interfaces;

namespace TesteWebApi.Repository.Repository
{
    public class RepositoryUoW : IRepositoryUoW
    {
        private readonly DataBaseContext _context;
        private bool _disposed = false;
        private IParkingRepository? _parkingRepository = null;
        private IVehicleRepository? _vehicleRepository = null;

        public RepositoryUoW(DataBaseContext context)
        {
            _context = context;
        }

        public IParkingRepository ParkingRepository
        {
            get
            {
                if (_parkingRepository == null)
                {
                    _parkingRepository = new ParkingRepository(_context);
                }
                return _parkingRepository;
            }
        }

        public IVehicleRepository VehicleRepository
        {
            get
            {
                if (_vehicleRepository == null)
                {
                    _vehicleRepository = new VehicleRepository(_context);
                }
                return _vehicleRepository;
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}