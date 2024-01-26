namespace SinCityGame.Models;

public class Guard:Person
{
    private double health;
    private double blueSympathy;
    private double redSympathy;
    public Dictionary<Lady, int> ladiesSimpaty = new Dictionary<Lady, int>();
    public bool IsAlive = true;

    public Guard(string name):base(name)
    {
        Health = 100;
    }

    public double Health { get => health; set => health = value; }
    public double BlueSympathy 
    { 
        get 
        {
            if (ladiesSimpaty.Count == 0)
            {
                return 0;
            }
            foreach (Lady lady in Program.bands[0].Members.Where(m => m is Lady))
            {
                blueSympathy += ladiesSimpaty[lady];
            }
            return blueSympathy;
        } 
    }
    public double RedSympathy 
    {
        get
        {
            if (ladiesSimpaty.Count == 0)
            {
                return 0;
            }
            foreach (Lady lady in Program.bands[1].Members.Where(m => m is Lady))
            {
                redSympathy += ladiesSimpaty[lady];
            }
            return redSympathy;
        }
    }
    public double NaturalSympathy { get => 100 - (BlueSympathy + RedSympathy);}
    public void RecoverHealth()
    {
        if (health<=90)
        {
            health += 10;
        }
        else
        {
            health = 100;
        }
    }

    public override void ShowInfo()
    {
        string isAvailably = IsAlive ? "Наличен" : "Неналичен";
        Console.WriteLine($"Name: {this.Name}\nHealth: {this.Health}%\nBS: {this.BlueSympathy}%\nRS: {this.RedSympathy}%\nNS: {this.NaturalSympathy}% \n {isAvailably}");
    }
}
