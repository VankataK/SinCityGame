namespace SinCityGame.Models;

public class Lady : Women
{
    public Lady(string name) : base(name)
    {
    }
    public override void ShowInfo()
    {
        Console.WriteLine($"Дама - Име: {this.Name}, {this.Sexappeal}, {this.Crafty}, {this.Loyalty}");
    }
}
