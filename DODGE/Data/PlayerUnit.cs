using System;
using DODGE.Structs;
using DODGE.Helpers;

namespace DODGE.Data
{
    public class PlayerUnit : Unit
    {
        public int Score { get; private set; }
        public PlayerUnit(string name, Vector2 position) : base(name, position)
        {
            this.Score = 0;
        }

        public void ResetPosition()
        {
            this.Position = new Vector2(1, 1);
        }

        public bool Update()
        {
            
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressed = Console.ReadKey(true);
                switch (pressed.Key)
                {
                    case ConsoleKey.W:
                        MoveUp();
                        break;
                    case ConsoleKey.S:
                        MoveDown();
                        break;
                    case ConsoleKey.A:
                        MoveLeft();
                        break;
                    case ConsoleKey.D:
                        MoveRight();
                        break;
                }
                if (pressed.Key == ConsoleKey.D)
                {
                    MoveRight();
                    return true;
                }
            }
            return false;
            //#TODO check for death?
        }

        public bool MoveUp(uint len = 1)
        {
            Vector2 oldPosition = new Vector2(this.Position.X, this.Position.Y);
            bool ret = base.move(MoveType.Up, len);
            if (ret)
                U.DrawPlayer(this.Name, oldPosition, this.Position);
            return ret;
        }
        public bool MoveDown(uint len = 1)
        {
            Vector2 oldPosition = new Vector2(this.Position.X, this.Position.Y);
            bool ret = base.move(MoveType.Down, len);
            if (ret)
                U.DrawPlayer(this.Name, oldPosition, this.Position);
            return ret;
        }
        public bool MoveLeft(uint len = 1)
        {
            Vector2 oldPosition = new Vector2(this.Position.X, this.Position.Y);
            bool ret = base.move(MoveType.Left, len);
            if (ret)
                U.DrawPlayer(this.Name, oldPosition, this.Position);
            return ret;
        }
        public bool MoveRight(uint len = 1)
        {
            Vector2 oldPosition = new Vector2(this.Position.X, this.Position.Y);
            bool ret = base.move(MoveType.Right, len);
            if (ret)
                U.DrawPlayer(this.Name, oldPosition, this.Position);
            return ret;
        }
    }
}