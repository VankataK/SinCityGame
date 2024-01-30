namespace SinCityGame.Models;

public class Killer:Men
{
    public const int Price = 7500;
    public Killer(string name) : base(name)
    {
        
    }
    public override void ShowInfo()
    {
        Console.WriteLine($"{this.Name}, {this.Skills}, {this.Clever}, {this.Loyalty}");
    }
}
