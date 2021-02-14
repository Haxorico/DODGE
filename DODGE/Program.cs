using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DODGE.Structs;

namespace DODGE
{
    class Program
    {
        public static Vector2 ScreenSize = new Vector2(Console.WindowWidth, Console.WindowHeight); 
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            new Dodge();
        }
    }
}
