using FactoryPattern_Asteroids.Asteroids;
using FactoryPattern_Asteroids.Entities;
using System;

namespace FactoryPattern_Asteroids.Factory
{
    public class RandomAsteroidFactory : IAsteroidFactory
    {
        private Random random = new Random();

		public IAsteroid CreateAsteroid(int paceIn = 100)
        {
			TypeOfAsteroid typeOfAsteroid = (TypeOfAsteroid)random.Next(1, 6);
			Position startPosition = new Position(0, random.Next(Console.WindowWidth));

            if (typeOfAsteroid == TypeOfAsteroid.StraitMovingAsteroid)
            {
				return new StraitMovingAsteroid(startPosition, paceIn);
			}
			else if (typeOfAsteroid == TypeOfAsteroid.StraitMovingExhaleAsteroid)
			{
				return new StraitMovingExhaleAsteroid(startPosition, paceIn);
			}
			else if (typeOfAsteroid == TypeOfAsteroid.SpirallyMovingAsteroid)
			{
				return new SpirallyMovingAsteroid(startPosition, paceIn);
			}
			else if (typeOfAsteroid == TypeOfAsteroid.SpirallyMovingExhaleAsteroid)
			{
				return new SpirallyMovingExhaleAsteroid(startPosition, paceIn);
			}
			else if (typeOfAsteroid == TypeOfAsteroid.RandomlyMovingAsteroid)
			{
				return new RandomlyMovingAsteroid(startPosition, paceIn);
			}
			else
			{
				return new RandomlyMovingExhaleAsteroid(startPosition, paceIn);
			}
		}
    }
}
