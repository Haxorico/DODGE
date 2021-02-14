using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DODGE.Structs;

namespace DODGE.Helpers
{
    public static class U
    {
        public static int GetRandomInt(int min, int max)
        {
            Random r = new Random();
            return r.Next(min, max);
        }

        public static int GetRandomInt(int max)
        {
            Random r = new Random();
            return r.Next(0, max);
        }

        public static void WriteAt(string data, Vector2 pos)
        {
            Console.SetCursorPosition(pos.X, pos.Y);
            Console.Write(data);
        }

        public static void ClearAt(Vector2 pos,int len=1)
        {
            if (pos.X < 0 || pos.X >= Program.ScreenSize.X ||
                pos.Y < 0 || pos.Y >= Program.ScreenSize.Y)
                return;
            string s = "";
            int i = 0;
            do
            {
                s += " ";
                i++;
            }
            while (i < len);
            Console.SetCursorPosition(pos.X, pos.Y);
            Console.Write(s);
        }
    
        public static void DrawPlayer(string name, Vector2 oldPos, Vector2 newPos)
        {
            ClearAt(oldPos);
            WriteAt(name, newPos);
        }
    }
}
