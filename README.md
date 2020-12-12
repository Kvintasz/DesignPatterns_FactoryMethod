# Factory Method
[Factory method](https://en.wikipedia.org/wiki/Factory_method_pattern) is one of the [creational design patterns](https://en.wikipedia.org/wiki/Creational_pattern). With this pattern we can instantiate objects.

## When should we use Factory Method?
You should consider to use factory method when you answer yes for each of the following questions:

* Do we have more similare classes belongs to the same set (like cars, animals, toys, asteroids etc)?
* Do we have to instantiate one of them in run time but before running we don't know which of them?

We need a logic which will be responsable for the creation and this logic will give an instance of the desireable class to the caller.
We can write this logic into the main program but in this case we cannot use this logic again in another part of our program. Unless we copy-paste it.
It is nicer and cleaner if we create a "Creater" class which has a creater method and this method gives back the instance.
We can use this class multiple times and we [don't reapeat ourselves](https://en.wikipedia.org/wiki/Don%27t_repeat_yourself).
To do it we need a common ancestor of the classes.

## Example
We have ducks, dogs, snakes classes. Their common ancestor can be Animal.
We create an IAnimal interface as a contract:

	interface IAnimal
	{
		void Moving();
	}

The ducks, dogs and snakes derive from this common interface and implement it.

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
		Random random = New Random();
		IAnimal CreateAnimal()
		{
			int number = random.Next(1, 100); //In this implementation we randomly create one kind of animal
			if(number % 5 == 0) return new Dog();
			if(number % 2 == 0) return new Duck();
			return new Snake();
		}
	}

In the main program:

	class MainProgram
	{
		private IAnimalFactory animalFactory;

		//Constructor for the dependency injection
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

Why do we create an interface for the factoy class? Because in this case we can use [dependency injection](https://en.wikipedia.org/wiki/Dependency_injection) and we comply to the [D(ependency Inversion)](https://en.wikipedia.org/wiki/Dependency_inversion_principle) of the [SOLID](https://en.wikipedia.org/wiki/SOLID) principles and we can create unit test for the MainProgram with a mocked factory class.
