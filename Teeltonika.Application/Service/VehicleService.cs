using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Teeltonika.Application.Dtos;
using Teltonika.Core.Data;

namespace Teeltonika.Application.Service
{
    public class VehicleService : IVehicleService
    {
        private readonly ApplicationContext _context;

        public VehicleService(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<VehicleDto[]> GetAllAsync()
        {
            var vehicles = await _context.Vehicles.Include(x => x.Customer).ToArrayAsync().ConfigureAwait(false);
            return vehicles.Select(x=> new VehicleDto(x)).ToArray();
        }
    }

    public interface IVehicleService
    {
        public Task<VehicleDto[]> GetAllAsync();
    }
}
