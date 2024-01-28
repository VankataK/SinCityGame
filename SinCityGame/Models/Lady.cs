namespace SinCityGame.Models;

public class Lady : Women
{
    public const int Price = 3000;
    public Lady(string name) : base(name)
    {
    }
    public override void ShowInfo()
    {
        Console.WriteLine($"{this.Name}, {this.Sexappeal}, {this.Crafty}, {this.Loyalty}");
    }
}
