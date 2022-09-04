using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlappyBirdV2.Models
{
    public class Pipe
    {
        public int DistanceFromLeft { get; set; } = 500;
        public int DistanceFromBottom { get; private set; } = new Random().Next(0, 100);
        public int Speed { get; set; } = 2;
        public int Gap { get; private set; } = 150;
        public int GapBottom => DistanceFromBottom + 300;
        public int GapTop => GapBottom + Gap;
        public bool IsOffScreen
        {
            get
            {
                return DistanceFromLeft <= -60;
            }
        }

        public void Move()
        {
            DistanceFromLeft -= Speed;
        }
        public bool IsCentered()
        {
            bool hasEnteredCenter = DistanceFromLeft <= (500 / 2) + (60 / 2);
            bool hasExitedCenter = DistanceFromLeft <= (500 / 2) - (60 / 2) - 60;

            return hasEnteredCenter && !hasExitedCenter;
        }
       
    }
}
