using CarMaintenanceApi.Data;
using CarMaintenanceApi.DTOs;
using CarMaintenanceApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarMaintenanceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaintenancesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MaintenancesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("car/{carId}")]
        public async Task<ActionResult<IEnumerable<Maintenance>>> GetMaintenances(int carId)
        {
            return await _context.Maintenances
                .Where(m => m.CarId == carId)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Maintenance>> CreateMaintenance(CreateMaintenanceDto dto)
        {
            var maintenance = new Maintenance
            {
                CarId = dto.CarId,
                Type = dto.Type,
                Date = dto.Date,
                Cost = dto.Cost,
                Notes = dto.Notes
            };

            _context.Maintenances.Add(maintenance);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(CreateMaintenance), new { id = maintenance.Id }, maintenance);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaintenance(int id)
        {
            var maintenance = await _context.Maintenances.FindAsync(id);

            if (maintenance == null)
                return NotFound();

            _context.Maintenances.Remove(maintenance);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}