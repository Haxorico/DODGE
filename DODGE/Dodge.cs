using System;
using System.Collections.Generic;
using System.Diagnostics;
using DODGE.Structs;
using DODGE.Helpers;
using DODGE.Data;

namespace DODGE
{
    class Dodge
    {
        private PlayerUnit player { get; set; }
        private List<EnemyUnit> enemies { get; set; }
        private Stopwatch stopwatch { get; set; }
        private bool gameOver()
        {
            this.stopwatch.Reset();
            Console.Clear();
            Console.Write("You died :(\n" +
                $"Score: {enemies.Count}\n" +
                "What would you like to do?\n" +
                "0)Exit\n" +
                "1)Play again\n\n" +
                "Choice: ");
            return Console.ReadLine() == "1";
        }
        private void resetGame()
        {
            Console.Clear();
            player.ResetPosition();
            U.WriteAt(player.Name, player.Position);
            this.enemies.Clear();
            this.enemies.Add(new EnemyUnit_LeftOnly(1000));
            this.stopwatch.Start();
        }
        public Dodge()
        {
            this.player = new PlayerUnit("P",new Vector2(0,0));
            this.enemies = new List<EnemyUnit>();
            this.stopwatch = new Stopwatch();

            this.resetGame();
            while (true)
            {
                bool addEnemy = false;
                foreach(EnemyUnit enemy in enemies)
                {
                    if (!enemy.Update((int)stopwatch.ElapsedMilliseconds))
                        addEnemy = true;
                    if (enemy.IsUnitHittingAnotherUnit(player))
                    {
                        if (gameOver())
                        {
                            this.resetGame();
                            break;
                        }
                        else
                            return;
                    }
                }
                player.Update();
                if (addEnemy)
                {
                    int r = U.GetRandomInt(1, 4);
                    if (r==1)
                    {
                        enemies.Add(new EnemyUnit_LeftOnly());
                    }
                    else if (r == 2)
                    {
                        enemies.Add(new EnemyUnit_RightOnly());
                    }
                    else if (r == 3)
                    {
                        enemies.Add(new EnemyUnit_UpOnly());
                    }
                    else
                    {
                        throw new Exception($"No such unit [{r}]");
                    }
                }
                stopwatch.Restart();
                System.Threading.Thread.Sleep(5);
            }
            
            
        }
        
    }
}
