namespace Daphine.Models;

public class AnimalOption
{
    public string Name { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public bool IsCorrect { get; set; }
    public bool IsShaking { get; set; }
}