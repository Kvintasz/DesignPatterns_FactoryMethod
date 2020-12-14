using FactoryPattern_Asteroids.Entities;
using System.Threading.Tasks;

namespace FactoryPattern_Asteroids.Asteroids
{
    public class RandomlyMovingExhaleAsteroid : RandomlyMovingAsteroid
    {
        public RandomlyMovingExhaleAsteroid(Position positionIn, int paceIn = 100)
            : base(positionIn, paceIn)
        {
            Task.Run(() => Exhale()).Wait();
        }
    }
}
