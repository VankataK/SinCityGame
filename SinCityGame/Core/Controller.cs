using SinCityGame.Models;
namespace SinCityGame.Core;

public class Controller
{
    private static Random random = new Random();
    public static void AddNewMember()
    {
        Band curBand = Program.bands[Program.currentIndex];
        ColorChanger.ChangeColor(curBand.BandColor);
        Console.WriteLine("--------------------");
        Console.WriteLine("Изберете професия: \n 1. Lady - 3000$ \n 2. Killer - 7500$ \n 3.Racketeer - 2000$");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                List<Lady> ladies = new List<Lady>();
                for (int i = 1; i <= 10; i++)
                {
                    ladies.Add(new Lady(Women.GenerateRandomFemaleName()));
                    Console.WriteLine(i+") ");
                    ladies[i-1].ShowInfo();
                }
                Console.Write("Изберете номера на дамата, която искате да наемете:");
                curBand.AddMemeber(ladies[int.Parse(Console.ReadLine())-1]);
                curBand.Capital -= Lady.Price;
                Console.WriteLine("Дамата беше успешно добавена.");
                break;
            case 2:
                List<Killer> killer = new List<Killer>();
                for (int i = 1; i <= 10; i++)
                {
                    killer.Add(new Killer(Men.GenerateRandomMaleName()));
                    Console.WriteLine(i + ") ");
                    killer[i-1].ShowInfo();
                }
                Console.Write("Изберете номера на убиеца, който искате да наемете:");
                curBand.AddMemeber(killer[int.Parse(Console.ReadLine())-1]);
                curBand.Capital -= Killer.Price;
                Console.WriteLine("Убиецът беше успешно добавен.");
                break;
            case 3:
                List<Racketeer> racketeers = new List<Racketeer>();
                for (int i = 1; i <= 10; i++)
                {
                    racketeers.Add(new Racketeer(Men.GenerateRandomMaleName()));
                    Console.WriteLine(i + ") ");
                    racketeers[i-1].ShowInfo();
                }
                Console.Write("Изберете номера на рекетьора, който искате да наемете:");
                curBand.AddMemeber(racketeers[int.Parse(Console.ReadLine())-1]);
                curBand.Capital -= Racketeer.Price;
                Console.WriteLine("Рекетьорът беше успешно добавен.");
                break;
            default:
                return;
                break;
        }
        Console.WriteLine("--------------------");
    }

    public static void ShowBankInfo()
    {
        ColorChanger.ChangeColor("green");
        Program.bank.ShowInfo();
    }
    public void ShowBandInfo()
    {
        ColorChanger.ChangeColor(Program.bands[Program.currentIndex].BandColor);
        Program.bands[Program.currentIndex].ShowInfo();
    }

    public static void TryKillingBanker()
    {
        Band curBand = Program.bands[Program.currentIndex];
        ColorChanger.ChangeColor(curBand.BandColor);
        if (curBand.Capital < 10000)
        {
            Console.WriteLine("Няма пари за опит за убийство");
            return;
        }
        List<Member> killers = curBand.Members.Where(m => m is Killer).ToList();
        for (int i = 1; i <= killers.Count; i++)
        {
            Console.Write(i+") ");
            killers[i-1].ShowInfo();
        }
        Console.Write("Въведете номера на убиеца, който искате да използвате: ");
        int chocedKiller = int.Parse(Console.ReadLine());
        Killer killer = (Killer)killers[chocedKiller-1];
        Controller.ShowBankInfo();
        Console.Write("Въведете номерът на пазача, който искате да убиете: ");
        Guard guard = Program.bank.Guards[int.Parse(Console.ReadLine()) - 1];
        killer.Loyalty -= 12;
        guard.Health -= (killer.Skills + killer.Clever) / 5 + random.Next(0, 20);
        if (guard.Health < 1) guard.IsAlive = false;
    }

    public static void GiveBonuses()
    {
        Band curBand = Program.bands[Program.currentIndex];
        ColorChanger.ChangeColor(curBand.BandColor);
        Console.WriteLine("Сума за бонуса: ");
        int bonus = int.Parse(Console.ReadLine());
        if (bonus * curBand.Members.Count > curBand.Capital)
        {
            Console.WriteLine("Няма достатъчно средтва");
            return;
        }
        int loyaltyIncrease = (7 * bonus) / 1000;


        foreach (var member in curBand.Members)
        {
            if (member is Men men)
            {
                men.Loyalty += loyaltyIncrease;
            }
        }

        Console.WriteLine("Бонусът беше успешно раздаден.");


    }
}
