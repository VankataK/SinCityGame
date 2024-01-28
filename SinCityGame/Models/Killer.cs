using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
