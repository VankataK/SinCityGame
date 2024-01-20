namespace SinCityGame.Models;

public abstract class Men : Member
{
    private int skills;
    private int clever;
    private int loyalty;
    public Men(string name) : base(name)
    {
        Random random = new Random();
        Skills = 80 + random.Next(-20, 20);
        Clever = 50 + random.Next(-30, 30);
        Loyalty = 180 - (skills + clever);
    }
    public int Skills
    {
        get { return skills; }
        set { skills = value; }
    }
    public int Clever
    {
        get { return clever; }
        set { clever = value; }
    }
    public int Loyalty
    {
        get { return loyalty; }
        set { loyalty = value; }
    }
}
