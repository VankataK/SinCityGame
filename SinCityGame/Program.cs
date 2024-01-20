using SinCityGame.Core;
using SinCityGame.Models;
namespace SinCityGame;
public class Program
{
    public static List<Band> bands = new List<Band>();
    static void Main()
    {
        ColorChanger clrChanger = new ColorChanger();
        //Controller controller = new Controller();
        clrChanger.ChangeToRed();
        Console.Write("Въведете име на шефа на банда 1: ");
        Boss redBoss = new Boss(Console.ReadLine());
        Console.Write("Въведете име на банда 1: ");
        Band redBand = new Band(Console.ReadLine(), redBoss);
        bands.Add(redBand);
        clrChanger.ChangeToBlue();
        Console.Write("Въведете име на шефа на банда 2: ");
        Boss blueBoss = new Boss(Console.ReadLine());
        Console.Write("Въведете име на банда 2: ");
        Band blueBand = new Band(Console.ReadLine(), redBoss);
        bands.Add(blueBand);
        string winner = null;
        while (winner!=null)
        {
            clrChanger.ChangeToRed();
            Console.WriteLine($"{redBand.Name} са на ход. Изберете действие: ");

        }
       

    }
}
