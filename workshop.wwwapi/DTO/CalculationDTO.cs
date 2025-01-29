namespace workshop.wwwapi.DTO
{
    public class CalculationDTO
    {
        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }
        public int? Result { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
