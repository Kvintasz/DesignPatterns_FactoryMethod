using FactoryPattern_Asteroids.Entities;
using System.Threading.Tasks;

namespace FactoryPattern_Asteroids.Asteroids
{
    public class StraitMovingExhaleAsteroid : AbstractAsteroid
    {
        public StraitMovingExhaleAsteroid(Position positionIn, int paceIn = 100)
            : base (positionIn, paceIn)
        {
            Task.Run(() => Exhale());
        }
    }
}
