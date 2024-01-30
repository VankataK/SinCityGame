using SinCityGame.Core;
using SinCityGame.Models;
namespace SinCityGame;
public class Program
{
    public static List<Band> bands = new List<Band>();
    public static int currentIndex = 0;
    public static Bank bank = new Bank();
    public static string winner = null;
    static void Main()
    {
        ColorChanger.ChangeColor("red");
        Console.Write("Въведете име на шефа на банда 1: ");
        Boss redBoss = new Boss(Console.ReadLine());
        Console.Write("Въведете име на банда 1: ");
        Band redBand = new Band(Console.ReadLine(), redBoss, "red");
        bands.Add(redBand);
        ColorChanger.ChangeColor("blue");
        Console.Write("Въведете име на шефа на банда 2: ");
        Boss blueBoss = new Boss(Console.ReadLine());
        Console.Write("Въведете име на банда 2: ");
        Band blueBand = new Band(Console.ReadLine(), blueBoss, "blue");
        bands.Add(blueBand);
        while (winner==null)
        {
            Band band = bands[currentIndex];
            bank.ShowBankInfo();
            Controller.ShowBandInfo();
            ColorChanger.ChangeColor(band.BandColor);
            Console.WriteLine($"{band.Name} са на ход. \nИзберете действие: ");
            Console.WriteLine("1) Привличане на нов член към бандата.");
            Console.WriteLine("2) Подкупване на пазач.");
            Console.WriteLine("3) Опит за убийство на пазач.");
            Console.WriteLine("4) Провеждане на сплотяващо клубно парти.");
            Console.WriteLine("5) Раздаване на бонуси.");
            Console.WriteLine("6) Привличане на член от друга банда.");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Controller.AddNewMember();
                    break;
                case 2:
                    Controller.BribeGuard();
                    break;
                case 3:
                    Controller.TryToKillGuard();
                    break;
                case 4:
                    Controller.ClubParty();
                    break;
                case 5:
                    Controller.GiveBonuses();
                    break;
                case 6:
                    Controller.TryToGetEnemyMember();
                    break;
            }
            Controller.Racket();
            Controller.ShowBandInfo();
            Controller.CheckForWin();
            currentIndex = (currentIndex == 0 ? 1 : 0);
        }
        Band winnerBand = bands.FirstOrDefault(b => b.Name == winner);
        Console.WriteLine($"Поздравления {winnerBand.Boss.Name}! {winnerBand.Name} превзе греховния град и ти вече си най-влиятелният човек в него!");
    }
}
