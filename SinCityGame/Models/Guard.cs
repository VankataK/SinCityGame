namespace SinCityGame.Models;

public class Guard:Person
{
    private double health;
    private double blueSympathy;
    private double redSympathy;
    private double naturalSympathy;
    public Dictionary<Lady, int> ladiesSimpaty = new Dictionary<Lady, int>();
    public string GuardBand = "none";

    public Guard(string name):base(name)
    {
        Health = 100;
    }

    public double Health { get => health; set => health = value; }
    public double BlueSympathy 
    { 
        get 
        {
            blueSympathy = 0;
            switch (GuardBand)
            {
                case "none":
                    if (ladiesSimpaty.Count == 0)
                    {
                        return 0;
                    }
                    foreach (Lady lady in Program.bands[0].Members.Where(m => m is Lady))
                    {
                        if(ladiesSimpaty.ContainsKey(lady)) blueSympathy += ladiesSimpaty[lady];
                    }
                    break;
                case "blue":
                    blueSympathy = 100;
                    ladiesSimpaty.Clear();
                    break;
                case "red":
                    blueSympathy = 0;
                    ladiesSimpaty.Clear();
                    break;
            }
            return blueSympathy;
        }
    }
    public double RedSympathy 
    {
        get
        {
            redSympathy = 0;
            switch (GuardBand)
            {
                case "none":
                    if (ladiesSimpaty.Count == 0)
                    {
                        return 0;
                    }
                    foreach (Lady lady in Program.bands[1].Members.Where(m => m is Lady))
                    {
                        if (ladiesSimpaty.ContainsKey(lady)) redSympathy += ladiesSimpaty[lady];
                    }
                    break;
                case "red":
                    redSympathy = 100;
                    ladiesSimpaty.Clear();
                    break;
                case "blue":
                    redSympathy = 0;
                    ladiesSimpaty.Clear();
                    break;
            }
            return redSympathy;
        }
    }
    public double NaturalSympathy 
    {
        get 
        {
            switch (GuardBand)
            {
                case "none":
                    naturalSympathy = 100 - (BlueSympathy+RedSympathy); 
                    break;
                default:
                    naturalSympathy = 0;
                    break;
            }
            return naturalSympathy;
        }
    }
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
    public void CheckGuardSympaty()
    {
        if (BlueSympathy>49)
        {
            GuardBand = "blue";
        }
        else if (RedSympathy > 49)
        {
            GuardBand = "red";   
        }
    }
    public override void ShowInfo()
    {
        Console.WriteLine($"Name: {this.Name}\nHealth: {this.Health}%");
        Console.WriteLine($"BS: {this.BlueSympathy}%");
        foreach (Lady lady in Program.bands[0].Members.Where(m => m is Lady))
        {
            if (ladiesSimpaty.ContainsKey(lady))
            {
                Console.Write($"{lady.Name}: {ladiesSimpaty[lady]} | ");
            }
        }
        Console.WriteLine();
        Console.WriteLine($"RS: {this.RedSympathy}%");
        foreach (Lady lady in Program.bands[1].Members.Where(m => m is Lady))
        {
            if (ladiesSimpaty.ContainsKey(lady))
            {
                Console.Write($"{lady.Name}: {ladiesSimpaty[lady]} | ");
            }
        }
        Console.WriteLine();
        Console.WriteLine($"NS: {this.NaturalSympathy}%");
    }
}
