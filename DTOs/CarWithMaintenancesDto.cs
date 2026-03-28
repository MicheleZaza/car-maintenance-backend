namespace CarMaintenanceApi.DTOs
{
    public class MaintenanceDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int Type { get; set; } // enum come intero
        public DateTime Date { get; set; }
        public decimal Cost { get; set; }
        public string? Notes { get; set; }
    }

    public class CarWithMaintenancesDto
    {
        public int Id { get; set; }
        public string Brand { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string LicensePlate { get; set; } = null!;
        public int Year { get; set; }
        public List<MaintenanceDto> Maintenances { get; set; } = new();
    }
}