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
        set {
            
            if (value < 0) loyalty = 0;
            if(value>100) loyalty = 100;
            else loyalty = value;
        
        }
    }
    public static string GenerateRandomMaleName()
    {
        Random random = new Random();
        string[] names = 
            {
            "Liam", "Noah", "Ethan", "Oliver", "Mason",
            "Logan", "Lucas", "Jackson", "Aiden", "Caleb",
            "Jack", "Ryan", "Connor", "Elijah", "Daniel",
            "Isaac", "Matthew", "William", "James", "Benjamin",
            "Henry", "Joseph", "Samuel", "David", "Carter",
            "Wyatt", "John", "Owen", "Dylan", "Luke",
            "Gabriel", "Anthony", "Michael", "Andrew", "Nicholas",
            "Nathan", "Christopher", "Evan", "Isaiah", "Thomas",
            "Joshua", "Aiden", "Alex", "Brandon", "Tyler",
            "Joseph", "Aaron", "Adam", "Kyle", "Miles"
        };

        return names[random.Next(0, names.Length)];
    }
}
