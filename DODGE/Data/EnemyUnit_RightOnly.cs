using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DODGE.Structs;
using DODGE.Helpers;

namespace DODGE.Data
{
    public class EnemyUnit_RightOnly : EnemyUnit
    {
        public EnemyUnit_RightOnly(string name, Vector2 position, int speed) : base(name, EnemyType.LEFT_ONLY, position, speed) { }

        public EnemyUnit_RightOnly() : base(">", EnemyType.LEFT_ONLY, new Vector2(
            2,
            U.GetRandomInt(1, Program.ScreenSize.Y)))
        { }
        public EnemyUnit_RightOnly(int speed) : base(">", EnemyType.LEFT_ONLY, new Vector2(
            2,
            U.GetRandomInt(1, Program.ScreenSize.Y)))
        {
            this.Speed = speed;
        }

        public override bool Update(int deltaTime)
        {
            if (base.Update(deltaTime))
            {
                if (moveRight())
                    return true;
                return false;
            }
            return true;

        }

        private bool moveRight(uint len = 1)
        {

            Vector2 oldPosition = new Vector2(this.Position.X, this.Position.Y);
            //if move was valid. Draw the enemy on the new position.
            if (base.move(MoveType.Right, len))
                U.DrawPlayer(this.Name, oldPosition, this.Position);
            //Move is not valid. Teleport the enemy to right.
            //Increase its speed (difficulty)
            //Move to a random Y
            else
            {
                U.ClearAt(oldPosition);
                this.Position = new Vector2(1, U.GetRandomInt(0, Program.ScreenSize.Y - 2));
                if (this.Speed < MAX_SPEED)
                    this.Speed = (int)(this.Speed * 1.1);
                return false;
            }
            return true;

        }
    }
}
