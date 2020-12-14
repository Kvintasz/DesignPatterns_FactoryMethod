using FactoryPattern_Asteroids.Asteroids;

namespace FactoryPattern_Asteroids.Factory
{
	public enum TypeOfAsteroid
	{
		StraitMovingAsteroid,
		StraitMovingExhaleAsteroid,
		SpirallyMovingAsteroid,
		SpirallyMovingExhaleAsteroid,
		RandomlyMovingAsteroid,
		RandomlyMovingExhaleAsteroid
	}

	public interface IAsteroidFactory
    {
        IAsteroid CreateAsteroid(int paceIn);
    }
}
