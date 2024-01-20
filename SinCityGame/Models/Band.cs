namespace SinCityGame.Models;

public class Band
{
    private string name;
    private Boss boss;
    private List<Member> members;

    public Band(string name, Boss boss)
    {
        Name = name;
        Boss = boss;
        members = new List<Member>();
        Capital = 30000;
    }

    public string Name { get => name; set => name = value; }
    public Boss Boss { get => boss; set => boss = value; }
    public List<Member> Members => members;
    public int Capital { get; set; }
    public void AddMemeber(Member m)
    {
        members.Add(m);
    }
    public Member GetMember(string name)
    {
        if (members.Any(m=>m.Name==name))
        {
            return members.FirstOrDefault(m => m.Name == name);
        }
        return null;
    }
    public void ShowInfo()
    {
        Console.WriteLine($"Име на бандата: {this.Name}, Шеф: {this.Boss.Name}, Капитал: {this.Capital}$");
        Console.WriteLine("Членове:");
        foreach (Member m in members)
        {
            m.ShowInfo();
        }
    }
}
