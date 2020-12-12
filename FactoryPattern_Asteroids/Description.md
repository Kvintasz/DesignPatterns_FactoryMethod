# Factory method - Asteroids

## Let's practice factory method

### Requirement

Imagine that the team (where you work) working on creates a game in which the player sits in a spaceship and must avoid or shoot objects that appear in front of him/her.
You got the task of making the part of the game that randomly creates an object.
These objects are the following:
- Strait Moving Asteroid
- Strait Moving Asteroid, which randomly exhales a smaller asteroids
- Spirally Moving Asteroid
- Spirally Moving Asteroid, which randomly exhales a smaller asteroids
- Randomly Moving Asteroid 
- Randomly Moving Asteroid, which randomly exhales a smaller asteroids

### My solution

We can see that the different asteroids have the following traits
- Position
- Extent
- Direction
- Move
- ExhaleAsteroids

Based on this knowledge we can create the common interface: **IAsteroid**

	public interface IAsteroid
	{
		Position Position();
		Extent Extent();
		Direction Direction();
		void Move();
		void ExhaleAsteroid();
	}

Implement this interface in six different way.

	public class StraitMovingAsteroid : IAsteroid
	{

	}

	public class StraitMovingExhaleAsteroid : IAsteroid
	{

	}

	public class SpirallyMovingAsteroid : IAsteroid
	{

	}

	public class SpirallyMovingExhaleAsteroid : IAsteroid
	{

	}

	public class RandomlyMovingAsteroid : IAsteroid
	{

	}

	public class RandomlyMovingExhaleAsteroid : IAsteroid
	{

	}

We have the six different asteroid class. Now we need a factory.

	public interface IAsteroidCreator
	{
		IAsteroid CreateAsteroid();
	}

	public enum TypeOfAsteroid
	{
		StraitMovingAsteroid,
		StraitMovingExhaleAsteroid,
		SpirallyMovingAsteroid,
		SpirallyMovingExhaleAsteroid,
		RandomlyMovingAsteroid,
		RandomlyMovingExhaleAsteroid
	}

According to the requirement our factory creates one of these asteroids random way.

	public class RandomAsteroidCreator : IAsteroidCreator
	{
		private Random random = new Random();
	
		public IAsteroid CreateAsteroid()
		{
			TypeOfAsteroid typeOfAsteroid = (TypeOfAsteroid)random.Next(1,6);
		
			switch(typeOfAsteroid)
			{
				case TypeOfAsteroid.StraitMovingAsteroid:
					return new StraitMovingAsteroid();
				case TypeOfAsteroid.StraitMovingExhaleAsteroid:
					return new StraitMovingExhaleAsteroid();
				case TypeOfAsteroid.SpirallyMovingAsteroid:
					return new SpirallyMovingAsteroid();
				case TypeOfAsteroid.SpirallyMovingExhaleAsteroid:
					return new SpirallyMovingExhaleAsteroid();
				case TypeOfAsteroid.RandomlyMovingAsteroid:
					return new RandomlyMovingAsteroid();
				case TypeOfAsteroid.RandomlyMovingExhaleAsteroid:
					return new RandomlyMovingExhaleAsteroid();
			}
		}
	}