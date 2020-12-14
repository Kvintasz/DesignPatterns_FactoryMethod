using FactoryPattern_Asteroids.Entities;
using System;
using System.Threading;

namespace FactoryPattern_Asteroids.Asteroids
{
    public class RandomlyMovingAsteroid : AbstractAsteroid
    {
        public RandomlyMovingAsteroid(Position positionIn, int paceIn = 100)
            : base(positionIn, paceIn)
        {
        }

        internal override void CalculateAndSetNextPosition()
        {
            Thread.Sleep(Pace);
            int randomNumber = Random.Next(1, 100);
            if (randomNumber % 5 == 0)
            {
                Position.Vertical--;
            }
            else
            {
                Position.Vertical++;
            }

            if (randomNumber % 2 == 0)
            {
                Position.Horizontal++;
            }
            else
            {
                Position.Horizontal--;
            }
        }
    }
}
