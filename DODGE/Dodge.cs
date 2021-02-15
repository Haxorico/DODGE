using System;
using System.Collections.Generic;
using System.Diagnostics;

using WMPLib;

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
        private WindowsMediaPlayer bgMusicPlayer;

        private void play()
        {
            while (true)
            {
                bool shouldAddEnemy = false;
                foreach (EnemyUnit enemy in enemies)
                {
                    if (!enemy.Update((int)stopwatch.ElapsedMilliseconds))
                        shouldAddEnemy = true;
                    if (enemy.IsUnitHittingAnotherUnit(player))
                    {
                        if (gameOver())
                        {
                            this.resetGame();
                            break;
                        }
                        else return;
                    }
                }
                player.Update();
                if (shouldAddEnemy) addEnemy();

                stopwatch.Restart();
                System.Threading.Thread.Sleep(5);
            }
        }
        
        private void resetGame()
        {
            Console.Clear();
            U.DrawBorders();
            player.ResetPosition();
            U.WriteAt(player.Name, player.Position);
            this.enemies.Clear();
            this.enemies.Add(new EnemyUnit_LeftOnly(1000));
            updateScore();
            this.stopwatch.Start();
            bgMusicPlayer.controls.play();
        }

        private bool gameOver()
        {
            //sotp the background music
            bgMusicPlayer.controls.stop();
            System.Media.SoundPlayer sp = new System.Media.SoundPlayer(Properties.Resource.dodge);
            sp.Play();
            //wait 1 second so the user wont input any moves.. its anoying..
            System.Threading.Thread.Sleep(1000);
            this.stopwatch.Reset();
            Console.Clear();
            Console.Write("Why didn't you... DODGE!\n" +
                $"Score: {enemies.Count}\n" +
                "What would you like to do?\n" +
                "0)Exit\n" +
                "1)Play again\n\n" +
                "Choice: ");
            return Console.ReadLine() == "1";
        }

        private void addEnemy()
        {
            int r = U.GetRandomInt(1, 4);
            if (r == 1)
            {
                enemies.Add(new EnemyUnit_LeftOnly(800));
            }
            else if (r == 2)
            {
                enemies.Add(new EnemyUnit_RightOnly(800));
            }
            else if (r == 3)
            {
                enemies.Add(new EnemyUnit_UpOnly());
            }
            else
            {
                throw new Exception($"No such unit [{r}]");
            }
            updateScore();
            System.IO.UnmanagedMemoryStream fileToPlay = Properties.Resource.point1;
            if (enemies.Count % 10 == 0)
                fileToPlay = Properties.Resource.point10;

            System.Media.SoundPlayer sp = new System.Media.SoundPlayer(fileToPlay);
            sp.Play();
            
        }

        private void updateScore()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write($"Score: {enemies.Count} Position: <{player.Position.X},{player.Position.Y}>");
        }

        public Dodge()
        {
            this.player = new PlayerUnit("P",new Vector2(0,0));
            this.enemies = new List<EnemyUnit>();
            this.stopwatch = new Stopwatch();
            this.bgMusicPlayer = new WindowsMediaPlayer();
            this.bgMusicPlayer.URL = "External\\Sound\\bgE1M1.mp3";
            this.bgMusicPlayer.controls.stop();
            this.resetGame();
            this.play();   
        }
        
    }
}
