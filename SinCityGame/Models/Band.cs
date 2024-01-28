namespace SinCityGame.Models;

public class Band
{
    private string name;
    private Boss boss;
    private List<Member> members;

    public Band(string name, Boss boss, string bandColor)
    {
        Name = name;
        Boss = boss;
        BandColor = bandColor;
        members = new List<Member>();
        Capital = 30000;
    }

    public string Name { get => name; set => name = value; }
    public Boss Boss { get => boss; set => boss = value; }
    public string BandColor { get; set; }
    public List<Member> Members => members;
    public int Capital { get; set; }
    public void AddMember(Member m)
    {
        members.Add(m);
    }
    public bool RemoveMember(Member member)
    {
        members.Remove(member);
        if (!members.Contains(member))
        {
            return true;
        }
        return false;
    }
    public bool CheckBandMoney(int money)
    {
        if (this.Capital >= money)
        {
            return true;
        }
        Console.WriteLine("Нямате достатъчно пари!");
        return false;
    }
}
