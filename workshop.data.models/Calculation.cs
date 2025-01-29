namespace workshop.data.models;

public class Calculation
{
    public int Id { get; set; }
    public int FirstNumber { get; set; }
    public int SecondNumber { get; set; }
    public int? Result { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

}
