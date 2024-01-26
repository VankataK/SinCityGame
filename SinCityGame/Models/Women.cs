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
        set
        {

            if (value < 0) loyalty = 0;
            else loyalty = value;

        }
    }

    public static string GenerateRandomFemaleName()
    {
        Random random = new Random();
        string[] femaleNames = new string[]
       {
            "Emma", "Olivia", "Ava", "Isabella", "Sophia",
            "Mia", "Amelia", "Harper", "Evelyn", "Abigail",
            "Emily", "Ella", "Scarlett", "Grace", "Chloe",
            "Aria", "Lily", "Isabelle", "Aurora", "Zoe",
            "Sofia", "Mila", "Luna", "Camila", "Avery",
            "Layla", "Hannah", "Lillian", "Addison", "Eleanor",
            "Natalie", "Lily", "Penelope", "Aubrey", "Stella",
            "Savannah", "Leah", "Hazel", "Violet", "Aaliyah",
            "Alice", "Josephine", "Madison", "Nora", "Lily",
            "Eva", "Ruby", "Emilia", "Elizabeth", "Scarlet"
       };

        return femaleNames[random.Next(0, femaleNames.Length)];
    }
}


