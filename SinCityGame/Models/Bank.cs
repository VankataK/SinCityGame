namespace SinCityGame.Models;

public class Bank
{
    private string name;
    private List<Guard> guards;
    public Bank()
    {
        Name = "GPT - Global Prosperity Trust Bank";
        guards = new List<Guard>() { new Guard("Guard 1"), new Guard("Guard 2"), new Guard("Guard 3") };
    }
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public List<Guard> Guards => guards;
    public void ShowInfo()
    {
        Console.WriteLine($"-----{this.Name}-----");
        foreach (Guard guard in guards)
        {
            guard.ShowInfo();
            Console.WriteLine("-------------------");
        }
    }
}
