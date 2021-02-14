using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DODGE.Structs;
using DODGE.Helpers;

namespace DODGE.Data
{
    public abstract class Unit
    {
        public Vector2 Position { get; protected set; }
        public string Name { get; protected set; }
        
        public Unit(string name, Vector2 position)
        {
            this.Position = position;
            this.Name = name;
        }

        public bool IsUnitHittingAnotherUnit(Unit u)
        {
            //#TODO overide the Equal function of the struct..
            return this.Position.X == u.Position.X && this.Position.Y == u.Position.Y;
        }

        private bool isMoveValid(Vector2 newPosition)
        {
            return newPosition.Y >= 0 && newPosition.Y < Program.ScreenSize.Y && 
                   newPosition.X >= 0 && newPosition.X < Program.ScreenSize.X;
        }

        protected bool move(MoveType mt, uint len)
        {
            if (len == 0)
                return true;
            int disX = 0, disY = 0;

            switch (mt) 
            {
                case MoveType.Up:
                    disY = -1;
                    break;
                case MoveType.Down:
                    disY = 1;
                    break;
                case MoveType.Left:
                    disX = -1;
                    break;
                case MoveType.Right:
                    disX = 1;
                    break;
                default:
                    return false;
            }


            int i = 0;
            do
            {
                Vector2 newPosition = new Vector2(this.Position.X + disX, this.Position.Y + disY);
                if (isMoveValid(newPosition))
                    this.Position = newPosition;
                else
                    return false;
                i++;
            }
            while (i < len);
            return true;
        }

       
       
        public override string ToString()
        {
            return this.Name;
        }

    }
}
