namespace SinCityGame.Models;

public class Bank
{
    private string name;
    private List<Guard> guards;
    public Bank(string name)
    {
        this.Name = name;
        guards = new List<Guard>() { new Guard("Guard 1"), new Guard("Guard 2"), new Guard("Guard 3") };
    }
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public List<Guard> Guards => guards;

}
