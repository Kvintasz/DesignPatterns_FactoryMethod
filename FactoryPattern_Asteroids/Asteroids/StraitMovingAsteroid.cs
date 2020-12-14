using FactoryPattern_Asteroids.Entities;

namespace FactoryPattern_Asteroids.Asteroids
{
    public class StraitMovingAsteroid : AbstractAsteroid
    {
        public StraitMovingAsteroid(Position positionIn, int paceIn = 100)
            : base(positionIn, paceIn)
        {
            
        }
    }
}
