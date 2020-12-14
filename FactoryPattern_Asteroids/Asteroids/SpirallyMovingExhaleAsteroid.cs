using FactoryPattern_Asteroids.Entities;
using System.Threading.Tasks;

namespace FactoryPattern_Asteroids.Asteroids
{
    public class SpirallyMovingExhaleAsteroid : SpirallyMovingAsteroid
    {
        public SpirallyMovingExhaleAsteroid(Position positionIn, int paceIn = 100)
            : base(positionIn, paceIn)
        {
            Task.Run(() => Exhale()).Wait();
        }
    }
}
