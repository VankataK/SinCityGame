using System;
namespace SinCityGame.Models;

public abstract class Women : Member
{
    private int sexappeal;
    private int crafty;
    private int loyalty;
    public Women(string name) : base(name)
    {
        Random random = new Random();
        Sexappeal = 80 + random.Next(-20, 20);
        Crafty = 50 + random.Next(-30, 30);
        Loyalty = 180 - (sexappeal + crafty);
    }
    public int Sexappeal
    {
        get { return sexappeal; }
        set { sexappeal = value; }
    }
    public int Crafty
    {
        get { return crafty; }
        set { crafty = value; }
    }
    public int Loyalty
    {
        get { return loyalty; }
        set { loyalty = value; }
    }
}
