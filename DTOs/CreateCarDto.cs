namespace CarMaintenanceApi.DTOs
{
    public class CreateCarDto
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public string LicensePlate { get; set; }

        public int Year { get; set; }
    }
}