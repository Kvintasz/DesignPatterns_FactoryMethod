using FactoryPattern_Asteroids.Asteroids;
using FactoryPattern_Asteroids.Factory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FactoryPattern_Asteroids
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomAsteroidFactory factory = new RandomAsteroidFactory();

            Console.WriteLine("Our Asteroid Factory will create randomly some asteroids");

            int numberOfAsteroids = 0;

            Task[] asteroidTasks = new Task[20];

            List<IAsteroid> asteroids = new List<IAsteroid>();

            while(numberOfAsteroids < 20)
            {
                IAsteroid newAsteroid = factory.CreateAsteroid();
                asteroids.Add(newAsteroid);
                asteroidTasks[numberOfAsteroids] = newAsteroid.MoveTask;
                numberOfAsteroids++;                
            }

            Task.WaitAll(asteroidTasks);
            foreach (IAsteroid asteroid in asteroids)
            {
                Console.WriteLine($"Asteroid_{numberOfAsteroids}:" +
                    $"\n\tType: {asteroid.GetType().Name}" +
                    $"\n\t\tChildren:");
                int numberOfChild = 0;
                if (asteroid.Children.Count > 0)
                {
                    foreach (IAsteroid child in asteroid.Children)
                    {
                        Console.WriteLine($"\t\t\t* Child_{++numberOfChild}: {child.GetType().Name}");
                    }
                }
            }
        }
    }
}
