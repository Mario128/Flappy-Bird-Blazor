using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace FlappyBirdV2.Models
{
    public class GameManager
    {
        private readonly int _gravity = 2;

        public event EventHandler MainLoopCompleted;

        public Bird MyBird { get; private set; } = new Bird();
        public List<Pipe> Pipes { get; private set; } = new List<Pipe>();
        public bool IsRunning { get; private set; } = false;

        public GameManager()
        {
        }
 
        public async void MainLoop()
        {
            IsRunning = true;
            while(IsRunning)
            {
                MoveObjects();
                CheckForCollissions();
                ManagePipes();

                MainLoopCompleted?.Invoke(this, EventArgs.Empty);
                await Task.Delay(20);
            }
        }
       
        public void StartGame()
        {
            if(!IsRunning)
            {
                MyBird = new Bird();
                Pipes = new List<Pipe>();
                MainLoop();
            }     
        }
        public void Jump()
        {
            if(IsRunning)
            {
                MyBird.Jump();
            }
        }

        private void MoveObjects()
        {
            MyBird.Fall(2);

            if (Pipes.Any())
            {
                foreach (Pipe p in Pipes)
                {
                    p.Move();
                }
            }     
        }

        private void CheckForCollissions()
        {
            if (MyBird.IsOnGround)
            {
                GameOver();
            }
            var centeredPipe = Pipes.FirstOrDefault(p => p.IsCentered());

            if(centeredPipe != null && 
                (MyBird.DistanceFromGround < centeredPipe.GapBottom -75 ||
                 MyBird.DistanceFromGround + 45 > centeredPipe.GapTop -75))
            {
                    GameOver();
            }
        }

        private void ManagePipes()
        {
            if(!Pipes.Any() || Pipes.Last().DistanceFromLeft <= 250)
            {
                Pipes.Add(new Pipe());
            }
            if(Pipes.First().IsOffScreen)
            {
                Pipes.Remove(Pipes.First());
            }
        }

        public void GameOver()
        {
            this.IsRunning = false;
        }

    }
}
