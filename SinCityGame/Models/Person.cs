namespace SinCityGame.Models;

public abstract class Person
{
    private string name;
    public string Name { get => name; set => name = value; }

    public Person(string name)
    {
        Name = name;
    }
    public abstract void ShowInfo();
}
