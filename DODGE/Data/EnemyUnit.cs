using DODGE.Structs;
using DODGE.Helpers;

namespace DODGE.Data
{
    public abstract class EnemyUnit : Unit
    {
        protected const int MAX_SPEED = 1000;

        public int Speed { get; protected set; }
        protected int timePassed { get; set; }
        protected int timeToWait { get; set; }
        protected EnemyType type { get; set; }

        public EnemyUnit(string name, EnemyType type, Vector2 position, int speed) : base(name, position)
        {
            this.type = type;
            this.Speed = speed;
            this.timePassed = 0;
            this.timeToWait = 1000 - this.Speed;
        }

        public EnemyUnit(string name, EnemyType type, Vector2 position) : base (name,position)
        {
            this.Speed = U.GetRandomInt(800,900);
            this.timePassed = 0;
            this.timeToWait = 1000 - this.Speed;
            this.type = type;
        }

        public virtual bool Update(int deltaTime)
        {
            this.timeToWait = 1000 - this.Speed;
            timePassed += deltaTime;
            if (timePassed < timeToWait)
                return false;
            timePassed -= timeToWait;
            return true;
        }

       
    }
}
