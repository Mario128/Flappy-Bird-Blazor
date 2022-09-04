using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlappyBirdV2.Models
{
    public class Bird
    {
        public int DistanceFromGround { get; set; } = 100;
        public int JumpStrength { get; set; } = 50;

        public bool IsOnGround
        {
            get
            {
                return DistanceFromGround <= 28;
            }
        }

        public void Fall(int gravity)
        {
            DistanceFromGround -= Math.Min(gravity, DistanceFromGround);
        }
        public void Jump()
        {
            if(DistanceFromGround <= 485)
            {
                DistanceFromGround += JumpStrength;
            }
        }
    }
}
