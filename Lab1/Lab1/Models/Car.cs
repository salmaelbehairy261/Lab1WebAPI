namespace Lab1.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; } = "";
        [Validations.DateIsInPast]
        public DateTime ProductionDate { get; set; }
        public string Type { get; set; } = "";
    }
}
