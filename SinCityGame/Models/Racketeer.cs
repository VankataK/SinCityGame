namespace SinCityGame.Models;

public class Racketeer:Men
{
    public const int Price = 2000;
    public Racketeer(string name) : base(name)
    {
    }
    public override void ShowInfo()
    {
        Console.WriteLine($"{this.Name}, {this.Skills}, {this.Clever}, {this.Loyalty}");
    }
}
