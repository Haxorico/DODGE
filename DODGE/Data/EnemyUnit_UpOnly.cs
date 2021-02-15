using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DODGE.Structs;
using DODGE.Helpers;

namespace DODGE.Data
{
    public class EnemyUnit_UpOnly : EnemyUnit
    {
        
        public EnemyUnit_UpOnly() : base("^", EnemyType.LEFT_ONLY, new Vector2(
            U.GetRandomX(),
            U.ARENA_SIZE_Y),
            U.GetRandomInt(300,400))
        { }

        public EnemyUnit_UpOnly(int speed) : base("^", EnemyType.LEFT_ONLY, new Vector2(
            U.GetRandomX(),
            U.ARENA_SIZE_Y))
        {
            this.Speed = speed;
        }
        public EnemyUnit_UpOnly(string name, Vector2 position, int speed) : base(name, EnemyType.LEFT_ONLY, position, speed) { }


        public override bool Update(int deltaTime)
        {
            if (base.Update(deltaTime))
            {
                if (moveUp())
                    return true;
                return false;
            }
            return true;

        }

        private bool moveUp(uint len = 1)
        {

            Vector2 oldPosition = new Vector2(this.Position.X, this.Position.Y);
            //if move was valid. Draw the enemy on the new position.
            if (base.move(MoveType.Up, len))
                U.DrawPlayer(this.Name, oldPosition, this.Position);
            //Move is not valid. Teleport the enemy to right.
            //Increase its speed (difficulty)
            //Move to a random Y
            else
            {
                U.ClearAt(oldPosition);
                this.Position = new Vector2(
                    U.GetRandomX(),
                    U.ARENA_SIZE_Y);
                if (this.Speed < MAX_SPEED)
                    this.Speed = (int)(this.Speed * 1.1);
                return false;
            }
            return true;

        }
    }
}
