using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinCityGame.Core
{
    public class ColorChanger
    {
        public void ChangeToRed()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        public void ChangeToBlue()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
        }
        public void ChangeToGreen()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        public void ChangeToWhite()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
