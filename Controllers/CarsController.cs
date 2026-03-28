using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarMaintenanceApi.Data;
using CarMaintenanceApi.Models;
using CarMaintenanceApi.DTOs;

namespace CarMaintenanceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CarsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetCars()
        {
            return await _context.Cars.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCar(int id)
        {
            var car = await _context.Cars.FindAsync(id);

            if (car == null)
                return NotFound();

            return car;
        }

        [HttpPost]
        public async Task<ActionResult<Car>> CreateCar(CreateCarDto dto)
        {
            var car = new Car
            {
                Brand = dto.Brand,
                Model = dto.Model,
                LicensePlate = dto.LicensePlate,
                Year = dto.Year
            };

            _context.Cars.Add(car);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCar), new { id = car.Id }, car);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var car = await _context.Cars.FindAsync(id);

            if (car == null)
                return NotFound();

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("{id}/details")]
        public async Task<ActionResult<CarWithMaintenancesDto>> GetCarWithMaintenances(int id)
        {
            var car = await _context.Cars
                .Include(c => c.Maintenances)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (car == null)
                return NotFound();

            var dto = new CarWithMaintenancesDto
            {
                Id = car.Id,
                Brand = car.Brand,
                Model = car.Model,
                LicensePlate = car.LicensePlate,
                Year = car.Year,
                Maintenances = car.Maintenances.Select(m => new MaintenanceDto
                {
                    Id = m.Id,
                    CarId = m.CarId,
                    Type = (int)m.Type,
                    Date = m.Date,
                    Cost = m.Cost,
                    Notes = m.Notes
                }).ToList()
            };

            return dto;
        }
    }
}