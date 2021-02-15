using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DODGE.Structs;
using DODGE.Helpers;

namespace DODGE.Data
{
    public class EnemyUnit_LeftOnly : EnemyUnit
    {
        public EnemyUnit_LeftOnly(string name, Vector2 position, int speed) : base(name, EnemyType.LEFT_ONLY, position, speed){}

        public EnemyUnit_LeftOnly() : base("<", EnemyType.LEFT_ONLY, new Vector2(
            U.ARENA_SIZE_X,
            U.GetRandomY())) { }
        public EnemyUnit_LeftOnly(int speed) : base("<", EnemyType.LEFT_ONLY, new Vector2(
            U.ARENA_SIZE_X,
            U.GetRandomY())) 
        {
            this.Speed = speed;
        }

        public override bool Update(int deltaTime)
        {
            if (base.Update(deltaTime))
            {
                if (moveLeft())
                    return true;
                return false;
            }
            return true;
                
        }

        private bool moveLeft(uint len = 1)
        {

            Vector2 oldPosition = new Vector2(this.Position.X, this.Position.Y);
            //if move was valid. Draw the enemy on the new position.
            if (base.move(MoveType.Left, len))
                U.DrawPlayer(this.Name, oldPosition, this.Position);
            //Move is not valid. Teleport the enemy to right.
            //Increase its speed (difficulty)
            //Move to a random Y
            else
            {
                U.ClearAt(oldPosition);
                this.Position = new Vector2(U.ARENA_SIZE_X, U.GetRandomY());
                if (this.Speed < MAX_SPEED)
                    this.Speed += 20;
                return false;
            }
            return true;

        }
    }
}
