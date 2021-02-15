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
        private const int WALL_START_X = 0;
        private const int WALL_START_Y = 1;
        private const int WALL_END_X = 201;
        private const int WALL_END_Y = 41;
        private const int ARENA_MIN_X = 1;
        private const int ARENA_MIN_Y = 2;
        private const int ARENA_MAX_X = 200;
        private const int ARENA_MAX_Y = 40;

        public const int ARENA_SIZE_X = ARENA_MAX_X - ARENA_MIN_X;
        public const int ARENA_SIZE_Y = ARENA_MAX_Y - ARENA_MIN_Y;

        private static Random R = new Random();
        private const string WALL= "X";

        public static int GetRandomInt(int min, int max)
        {
            return R.Next(min, max);
        }

        public static int GetRandomInt(int max)
        {
            return R.Next(0, max);
        }


        public static int GetRandomX()
        {
            return R.Next(0, ARENA_SIZE_X);
        }
        public static int GetRandomY()
        {
            return R.Next(0, ARENA_SIZE_Y);
        }

        public static Vector2 PosToScreen(Vector2 pos)
        {
            pos.X = pos.X + ARENA_MIN_X;
            pos.Y = pos.Y + ARENA_MIN_Y;
            return pos;
        }

        public static bool IsMoveValid(Vector2 pos)
        {
            pos = PosToScreen(pos);
                return pos.Y >= ARENA_MIN_Y && pos.Y < U.ARENA_MAX_Y &&
                       pos.X >= ARENA_MIN_X && pos.X <= U.ARENA_MAX_X;
            
        }

        public static void WriteAt(string data, Vector2 pos)
        {
            pos = PosToScreen(pos);
            Console.SetCursorPosition(pos.X, pos.Y);
            Console.Write(data);
        }

        public static void ClearAt(Vector2 pos,int len=1)
        {
            pos = PosToScreen(pos);
            if (pos.X < U.ARENA_MIN_X || pos.X > U.ARENA_MAX_X ||
                pos.Y < U.ARENA_MIN_Y || pos.Y >= U.ARENA_MAX_Y)
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

        public static void DrawBorders()
        {
            //Draw the top border
            Console.SetCursorPosition(WALL_START_X, WALL_START_Y);
            string data = "";
            int i;
            for (i = WALL_START_X; i <= WALL_END_X; i++)
            {
                data += WALL;
            }
            Console.Write(data);
            //Draw the middle of the screen ("X" + MAX_X-2-MIN_X-+1 + "X")
            for (i = ARENA_MIN_Y; i < ARENA_MAX_Y; i++)
            {
                Console.SetCursorPosition(ARENA_MIN_X - 1, i);
                data = "X";
                for (int j = 0; j < ARENA_MAX_X; j++)
                {
                    data += " ";
                }
                data += "X";
                Console.Write(data);
            }
            //Draw the bottom of the screen (-1 to make sure the screen wont have the scroll thingy
            Console.SetCursorPosition(WALL_START_X, WALL_END_Y-1);
            data = "";
            for (i = WALL_START_X; i <= WALL_END_X; i++)
            {
                data += WALL;
            }
            Console.Write(data);
        }
    }
}
