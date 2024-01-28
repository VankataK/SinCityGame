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
                if (!curBand.CheckBandMoney(3000)) return;
                List<Lady> ladies = new List<Lady>();
                for (int i = 1; i <= 10; i++)
                {
                    ladies.Add(new Lady(Women.GenerateRandomFemaleName()));
                    Console.WriteLine(i+") ");
                    ladies[i-1].ShowInfo();
                }
                Console.Write("Изберете номера на дамата, която искате да наемете:");
                curBand.AddMember(ladies[int.Parse(Console.ReadLine())-1]);
                curBand.Capital -= Lady.Price;
                Console.WriteLine("Дамата беше успешно добавена.");
                break;
            case 2:
                if (!curBand.CheckBandMoney(7500)) return;
                List<Killer> killer = new List<Killer>();
                for (int i = 1; i <= 10; i++)
                {
                    killer.Add(new Killer(Men.GenerateRandomMaleName()));
                    Console.WriteLine(i + ") ");
                    killer[i-1].ShowInfo();
                }
                Console.Write("Изберете номера на убиеца, който искате да наемете:");
                curBand.AddMember(killer[int.Parse(Console.ReadLine())-1]);
                curBand.Capital -= Killer.Price;
                Console.WriteLine("Убиецът беше успешно добавен.");
                break;
            case 3:
                if (!curBand.CheckBandMoney(2000)) return;
                List<Racketeer> racketeers = new List<Racketeer>();
                for (int i = 1; i <= 10; i++)
                {
                    racketeers.Add(new Racketeer(Men.GenerateRandomMaleName()));
                    Console.WriteLine(i + ") ");
                    racketeers[i-1].ShowInfo();
                }
                Console.Write("Изберете номера на рекетьора, който искате да наемете:");
                curBand.AddMember(racketeers[int.Parse(Console.ReadLine())-1]);
                curBand.Capital -= Racketeer.Price;
                Console.WriteLine("Рекетьорът беше успешно добавен.");
                break;
            default:
                return;
                break;
        }
        Console.WriteLine("--------------------");
    }
    public static void BribeGuard()
    {
        Band curBand = Program.bands[Program.currentIndex];
        ColorChanger.ChangeColor(curBand.BandColor);
        Console.WriteLine("--------------------");
        Console.Write("Въведете подкупа, който искате да дадете: ");
        int bribe = int.Parse(Console.ReadLine());
        if (!curBand.CheckBandMoney(bribe+1500)) return;
        List<Member> ladies = curBand.Members.Where(m => m is Lady).ToList();
        for (int i = 1; i <= ladies.Count; i++)
        {
            Console.Write(i + ") ");
            ladies[i - 1].ShowInfo();
        }
        Console.Write("Въведете номера на дамата, която искате да занесе подкупа: ");
        int chocedLady = int.Parse(Console.ReadLine());
        Lady lady = (Lady)ladies[chocedLady - 1];
        Controller.ShowBankInfo();
        Console.Write("Въведете номерът на пазача, който искате да подкупите: ");
        Guard guard = Program.bank.Guards[int.Parse(Console.ReadLine()) - 1];
        lady.Loyalty -= 7;
        int addedSympathy = (bribe / 1000) * ((lady.Sexappeal + lady.Crafty) / 50);
        if (guard.ladiesSimpaty.ContainsKey(lady))
        {
            guard.ladiesSimpaty[lady] += addedSympathy;
        }
        else guard.ladiesSimpaty.Add(lady, addedSympathy);
        guard.RecoverHealth();
        int chanceToBeCaugth = (80 - lady.Crafty) / 5;
        if (random.Next(100) <= chanceToBeCaugth)
        {
            curBand.RemoveMember(lady);
            Console.WriteLine($"{lady.Name} беше заловенa.");
        }
        else Console.WriteLine($"{lady.Name} се измъкна успешно.");
        Console.WriteLine("--------------------");
    }
    public static void ShowBankInfo()
    {
        ColorChanger.ChangeColor("green");
        Program.bank.ShowInfo();
    }
    public static void ShowBandInfo()
    {
        Band curBand = Program.bands[Program.currentIndex];
        ColorChanger.ChangeColor(curBand.BandColor);
        Console.WriteLine("--------------------");
        Console.WriteLine($"Име на бандата: {curBand.Name}, Шеф: {curBand.Boss.Name}, Капитал: {curBand.Capital}$");
        Console.WriteLine("Дами:");
        foreach (Lady lady in curBand.Members.Where(m=>m is Lady))
        {
            lady.ShowInfo();
        }
        Console.WriteLine("Убийци:");
        foreach (Killer killer in curBand.Members.Where(m => m is Killer))
        {
            killer.ShowInfo();
        }
        Console.WriteLine("Рекетьори:");
        foreach (Racketeer racketeer in curBand.Members.Where(m => m is Racketeer))
        {
            racketeer.ShowInfo();
        }
        Console.WriteLine("--------------------");
    }

    public static void TryKillingBanker()
    {
        Band curBand = Program.bands[Program.currentIndex];
        ColorChanger.ChangeColor(curBand.BandColor);
        Console.WriteLine("--------------------");
        if (!curBand.CheckBandMoney(10000)) return;
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
        if (guard.Health < 1)
        {
            guard.IsAlive = false;
            Console.WriteLine($"{guard.Name} беше убит.");
        }
        int chanceToBeCaugth = (80 - killer.Clever) / 2;
        if (random.Next(100)<=chanceToBeCaugth)
        {
            curBand.RemoveMember(killer);
            Console.WriteLine($"{killer.Name} беше заловен.");
        }
        else Console.WriteLine($"{killer.Name} се измъкна успешно.");
        Console.WriteLine("--------------------");
    }

    public static void GiveBonuses()
    {
        Band curBand = Program.bands[Program.currentIndex];
        ColorChanger.ChangeColor(curBand.BandColor);
        Console.WriteLine("--------------------");
        Console.Write("Сума за бонуса: ");
        int bonus = int.Parse(Console.ReadLine());
        if (!curBand.CheckBandMoney(bonus)) return;
        int loyaltyIncrease = (7 * bonus) / 1000;


        foreach (var member in curBand.Members)
        {
            if (member is Men men)
            {
                men.Loyalty += loyaltyIncrease;
            }
            else if (member is Women women)
            {
                women.Loyalty += loyaltyIncrease;
            }
        }

        curBand.Capital -= bonus;

        Console.WriteLine("Бонусът беше успешно раздаден.");
        Console.WriteLine("--------------------");
    }

    public static void TryToGetEnemyMember()
    {
        Band curBand = Program.bands[Program.currentIndex];
        Band enemyBand = Program.bands[(Program.currentIndex == 0 ? 1 : 0)];
        int bribeMoney, chanceToAccept;
        ColorChanger.ChangeColor(curBand.BandColor);
        Console.WriteLine("--------------------");
        Console.WriteLine("Изберете какъв тип член искате да откраднете: \n 1. Lady\n 2. Killer\n 3.Racketeer");
        int choice = int.Parse(Console.ReadLine());
        switch (choice)
        {
            case 1:
                List<Member> ladies = enemyBand.Members.Where(m => m is Lady).ToList();
                for (int i = 1; i <= ladies.Count; i++)
                {
                    Console.Write(i+") ");
                    ladies[i].ShowInfo();
                }
                Console.Write("Изберете номера на дамата, която искате да откраднете:");
                Lady chosenLady = (Lady)ladies[int.Parse(Console.ReadLine()) - 1];
                Console.Write("Въведете сумата,която искате да предложите: ");
                bribeMoney = int.Parse(Console.ReadLine());
                if (!curBand.CheckBandMoney(bribeMoney)) return;
                chanceToAccept = (bribeMoney / 250) * (chosenLady.Crafty / chosenLady.Loyalty) - random.Next(10, 40);
                if (random.Next(100)<=chanceToAccept)
                {
                    curBand.AddMember(chosenLady);
                    enemyBand.RemoveMember(chosenLady);
                    Console.WriteLine($"{chosenLady.Name} прие офертата.");
                }
                else Console.WriteLine($"{chosenLady.Name} отказа офертата.");
                break;
            case 2:
                List<Member> killers = enemyBand.Members.Where(m => m is Killer).ToList();
                for (int i = 1; i <= killers.Count; i++)
                {
                    Console.Write(i + ") ");
                    killers[i].ShowInfo();
                }
                Console.Write("Изберете номера на убиеца, която искате да откраднете:");
                Killer chosenKiller = (Killer)killers[int.Parse(Console.ReadLine()) - 1];
                Console.Write("Въведете сумата,която искате да предложите: ");
                bribeMoney = int.Parse(Console.ReadLine());
                if (!curBand.CheckBandMoney(bribeMoney)) return;
                chanceToAccept = (bribeMoney / 250) * (chosenKiller.Clever / chosenKiller.Loyalty) - random.Next(10, 40);
                if (random.Next(100) <= chanceToAccept)
                {
                    curBand.AddMember(chosenKiller);
                    enemyBand.RemoveMember(chosenKiller);
                    Console.WriteLine($"{chosenKiller.Name} прие офертата.");
                }
                else Console.WriteLine($"{chosenKiller.Name} отказа офертата.");
                break;
            case 3:
                List<Member> racketeers = enemyBand.Members.Where(m => m is Racketeer).ToList();
                for (int i = 1; i <= racketeers.Count; i++)
                {
                    Console.Write(i + ") ");
                    racketeers[i].ShowInfo();
                }
                Console.Write("Изберете номера на рекетьора, която искате да откраднете:");
                Killer chosenRacketeer = (Killer)racketeers[int.Parse(Console.ReadLine()) - 1];
                Console.Write("Въведете сумата,която искате да предложите: ");
                bribeMoney = int.Parse(Console.ReadLine());
                if (!curBand.CheckBandMoney(bribeMoney)) return;
                chanceToAccept = (bribeMoney / 250) * (chosenRacketeer.Clever / chosenRacketeer.Loyalty) - random.Next(10, 40);
                if (random.Next(100) <= chanceToAccept)
                {
                    curBand.AddMember(chosenRacketeer);
                    enemyBand.RemoveMember(chosenRacketeer);
                    Console.WriteLine($"{chosenRacketeer.Name} прие офертата.");
                }
                else Console.WriteLine($"{chosenRacketeer.Name} отказа офертата.");
                break;
        }
        Console.WriteLine("--------------------");

    }

    public static void ClubParty()
    {
        int partyCost = 12500;
        Band curBand = Program.bands[Program.currentIndex];
        ColorChanger.ChangeColor(curBand.BandColor);
        Console.WriteLine("--------------------");
        if (!curBand.CheckBandMoney(partyCost)) return;
        int minMen = curBand.Members.Count(member => member is Men) - 1;
        int minWomen = curBand.Members.Count(member => member is Women);
        int loyaltyIncrease = 5 * Math.Min(minMen, minWomen);
       
        foreach (var member in curBand.Members)
        {

            if (member is Men men)
            {
                men.Loyalty += loyaltyIncrease;
            }
            else if (member is Women women)
            {
                women.Loyalty += loyaltyIncrease;
            }
        }
        curBand.Capital -= partyCost;
        Console.WriteLine("Успешно парти!");
        Console.WriteLine("--------------------");
    }
    
    public static void Racket()
    {
        Band curBand = Program.bands[Program.currentIndex];
        ColorChanger.ChangeColor(curBand.BandColor);
        Console.WriteLine("--------------------");
        foreach (Racketeer racketeer in curBand.Members.Where(m=>m is Racketeer))
        {
            int earnedMoney = (racketeer.Skills + racketeer.Clever) * 5 + random.Next(300);
            Console.WriteLine($"{racketeer.Name} събра {earnedMoney}$");
            curBand.Capital += earnedMoney;
        }
        Console.WriteLine("--------------------");
    }
}
