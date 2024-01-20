namespace SinCityGame.Models;

public class Boss : Person
{
    public Boss(string name) : base(name)
    {
    }
    public override void ShowInfo()
    {
        Console.WriteLine(Name);
    }
}
