using CarMaintenanceApi.Enums;

namespace CarMaintenanceApi.DTOs
{
    public class CreateMaintenanceDto
    {
        public int CarId { get; set; }

        public MaintenanceType Type { get; set; }

        public DateTime Date { get; set; }

        public decimal Cost { get; set; }

        public string? Notes { get; set; }
    }
}