using CarMaintenanceApi.Enums;

namespace CarMaintenanceApi.Models
{
    public class Maintenance
    {
        public int Id { get; set; }

        public int CarId { get; set; }

        public Car Car { get; set; }

        public MaintenanceType Type { get; set; }

        public DateTime Date { get; set; }

        public decimal Cost { get; set; }

        public string? Notes { get; set; }
    }
}