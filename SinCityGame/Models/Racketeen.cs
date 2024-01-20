using System;
using System.Collections.Generic;
namespace SinCityGame.Models;

public class Racketeen:Men
{
    public Racketeen(string name) : base(name)
    {
    }
    public override void ShowInfo()
    {
        Console.WriteLine($"Рекетьор - Име: {this.Name}, {this.Skills}, {this.Clever}, {this.Loyalty}");
    }
}
