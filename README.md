# DesignPatterns_FactoryMethod
Factory method is one of the creational design patterns. With this pattern we can instantiate objects.

## When should we use Factory Method?
You should consider to use factory method when you answer yes for each of the following questions:

* Do we have more similare classes belongs to the same set (like cars, animals, toys, asteroids etc)?
* Do we have to instantiate one of them in run time but before runtime we don't know which of them?

We need a logic which will be responsable for the creation and this logic will give an instante of the desireable class to the caller.
We can write this logic into the main program but in this case we cannot use this logic again in another part of our logic. Unless we copy-paste it.
It is nicer and cleaner if we create a Creater class which has a creater method and this method gives back the instance.
We can use this class multiple times and we don't reapeat ourselves.
To do it we need a common ancestor of the classes.

## Example
We have ducks, dogs, snakes classes. Their common ancestor can be Animal.
We create an IAnimal interface as a contract:

	interface IAnimal
	{
		void Moving();
	}

The ducks, dogs and snakes derive from this common interface.
class Dog : IAnimal
{
	void Moving()
	{
		Console.WriteLine("Walk");
	}
}

class Duck : IAnimal
{
	void Moving()
	{
		Console.WriteLine("Fly");
	}
}

class Snake : IAnimal
{
	void Moving()
	{
		Console.WriteLine("Crawl");
	}
}

And now we have to create the creator/factory class and its interface

interface IAnimalFactory
{
	IAnimal CreateAnimal();
}

class AnimalFactory
{
	Random random = New Random()
	IAnimal CreateAnimal()
	{
		int number = random.Next(1, 100);
		if(number % 5 == 0) return new Dog();
		if(number % 2 == 0) return new Duck();
		return new Snake();	
	}
}

In the main program:

class MainProgram
{
	private IAnimalFactory animalFactory;

	MainProgram(IAnimalFactory animalFactoryIn)
	{
		animalFactory = animalFactoryIn
	}

	void Run()
	{
		.
		.
		.
		IAnimal ourAnimal = animalFactory.CreateAnimal();
		ourAnimal.Moving();
		.
		.
		.
	}
}

Now we can practicing with the following task:

Imagine that the team where you are working on creates a game in which the player sits in a spaceship and must avoid or shoot objects that appear in front of him/her.
You got the task of making the part of the game that randomly creates an object.
These objects are the following:
-Strait Moving Asteroid
-Strait Moving Asteroid, which randomly exhales a smaller asteroids
-Spirally Moving Asteroid
-Spirally Moving Asteroid, which randomly exhales a smaller asteroids
-Randomly Moving Asteroid 
-Randomly Moving Asteroid, which randomly exhales a smaller asteroids

Solution:

We can see that the different asteroids have the following treats
-Position
-Extent
-Moving
-Move
-ExhaleAsteroid

Now we can create the common interface: IAsteroid

public interface IAsteroid
{
	Position Position();
	Extent Extent();
	Direction Direction();
	void Move();
	void ExhaleAsteroid();
}

Now we can implement this interface in six different way.

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

public class BalancedAsteroidCreator : IAsteroidCreator
{
	private Dictionary<TypeOfAsteroid, int> asteroids = new Dictionary<TypeOfAsteroid, int>();

	public BalancedAsteroidCreator()
	{
		for(int i = 0; i < 6; i++)
		{
			asteroids.Add((TypeOfAsteroid)i, 0);
		}
	}
	
	public IAsteroid CreateAsteroid()
	{
		
		TypeOfAsteroid typeOfAsteroid = asteroids.Where(legkisebb az szám);
		
		IAsteroid createdAsteroid;
		switch(typeOfAsteroid)
		{
			case TypeOfAsteroid.StraitMovingAsteroid:
				createdAsteroid = new StraitMovingAsteroid();
			case TypeOfAsteroid.StraitMovingExhaleAsteroid:
				createdAsteroid = new StraitMovingExhaleAsteroid();
			case TypeOfAsteroid.SpirallyMovingAsteroid:
				createdAsteroid = new SpirallyMovingAsteroid();
			case TypeOfAsteroid.SpirallyMovingExhaleAsteroid:
				createdAsteroid = new SpirallyMovingExhaleAsteroid();
			case TypeOfAsteroid.RandomlyMovingAsteroid:
				createdAsteroid = new RandomlyMovingAsteroid();
			case TypeOfAsteroid.RandomlyMovingExhaleAsteroid:
				createdAsteroid = new RandomlyMovingExhaleAsteroid();
		}

		return createdAsteroid;
	}
}
