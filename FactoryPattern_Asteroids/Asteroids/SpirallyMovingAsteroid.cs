using FactoryPattern_Asteroids.Entities;
using System;

namespace FactoryPattern_Asteroids.Asteroids
{
    public class SpirallyMovingAsteroid : AbstractAsteroid
    {
        public SpirallyMovingAsteroid(Position positionIn, int paceIn = 100)
            : base(positionIn, paceIn)
        {
            horizontalStartPostion = positionIn.Horizontal;
            directionLeft = horizontalStartPostion > Extent ? true : false;
            spiralRadius = Random.Next(3, 20);
            
        }

        internal override void CalculateAndSetNextPosition()
        {
            if(directionLeft)
            {
                Position.Horizontal--;
                if (Position.Horizontal >= horizontalStartPostion)
                {
                    Position.Vertical += 2;
                }
                else
                {
                    Position.Vertical--;
                }

                if (Position.Horizontal <= horizontalStartPostion - spiralRadius)
                {
                    directionLeft = false;
                }
            }
            else
            {
                Position.Horizontal++;
                if (Position.Horizontal >= horizontalStartPostion + spiralRadius)
                {
                    directionLeft = true;
                }

                if (Position.Horizontal < horizontalStartPostion)
                {
                    Position.Vertical--;
                }
                else
                {
                    Position.Horizontal += 2;
                }
            }
        }

        private int horizontalStartPostion;
        private bool directionLeft;
        private int spiralRadius;
    }
}
