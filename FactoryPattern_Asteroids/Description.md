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
- Move
- Position
- Children (exhaled smaller asteroids)
- Extent

Based on this knowledge we can create the common interface: **IAsteroid**

	public interface IAsteroid
	{
        Task MoveTask { get; }
        Position Position { get; }
        List<IAsteroid> Children { get; }
        int Extent { get; }
	}

We can implement this interface in six different way, but we can see they are very similar to each other just tiny differences are between the implementations.
Beacuse of these tiny differences I would create an abstract ancestor. In this way we don't repeat ourselves.

	public class AbstractAsteroid : IAsteroid
	{
		public Position Position { get; private set; }
        public int Extent { get; private set; }
        public Task MoveTask { get; private set; }
        public List<IAsteroid> Children { get; } = new List<IAsteroid>();
        public Random Random { get; private set; } = new Random();

        public AbstractAsteroid(Position positionIn, int paceIn = 100)
        {
            .
            .
			.
        }

        public void Move()
        {
            .
            .
			.
        }

        internal int WindowHeight = Console.WindowHeight;
        internal int WindowWidth = Console.WindowWidth;
        internal int Pace;
        internal bool Disappeared = false;

        internal virtual void CalculateAndSetNextPosition()
        {
            .
            .
			.
        }

        internal void Exhale()
        {
            .
			.
            .
        }

        private int horizontalDirection;
        private int verticalDirection;

        private void SetDirection()
        {
            .
            .
			.
        }
	}

The final implementation derives from the AbstractAsteroid and override some part of it.
Because the AbstractAsteroid perfectly defines everything for StraitMovingAsteroid class so we only have to create an empty constructor.

	public class StraitMovingAsteroid : AbstractAsteroid
    {
        public StraitMovingAsteroid(Position positionIn, int paceIn = 100)
            : base(positionIn, paceIn)
        {
            
        }
    }

The situation is really similar with StraitMovingExhaleAsteroid class. The difference is this class starts a new task with the exhale method

	public class StraitMovingExhaleAsteroid : AbstractAsteroid
    {
        public StraitMovingExhaleAsteroid(Position positionIn, int paceIn = 100)
            : base (positionIn, paceIn)
        {
            Task.Run(() => Exhale());
        }
    }

The spirally way moving asteroid has more differences because it moves a different way and the calculation of the next position is different from the strait moving asteroid
I override the CalculateAndSetNextPosition() method and we have to perform some other additional calculation in the constructor.

	public class SpirallyMovingAsteroid : AbstractAsteroid
    {
        public SpirallyMovingAsteroid(Position positionIn, int paceIn = 100)
            : base(positionIn, paceIn)
        {
            horizontalStartPostion = positionIn.Horizontal;
            directionLeft = horizontalStartPostion > Extent ? true : false;
            spiralRadius = Random.Next(3, 20);
            
        }

        internal override void CalculateAndSetNextPosition()
        {
            .
            .
            .
        }

        private int horizontalStartPostion;
        private bool directionLeft;
        private int spiralRadius;
    }

The SpirallyMovingExhaleAsteroid class is same as the previous but it starts the exhaling task.

    public class SpirallyMovingExhaleAsteroid : SpirallyMovingAsteroid
    {
        public SpirallyMovingExhaleAsteroid(Position positionIn, int paceIn = 100)
            : base(positionIn, paceIn)
        {
            Task.Run(() => Exhale()).Wait();
        }
    }

We have to override the next position method for the RandomlyMovingAsteroid class as well.

	public class RandomlyMovingAsteroid : AbstractAsteroid
    {
        public RandomlyMovingAsteroid(Position positionIn, int paceIn = 100)
            : base(positionIn, paceIn)
        {
        }

        internal override void CalculateAndSetNextPosition()
        {
            .
            .
            .
        }
    }

And the exhaling version won't surprise you

    public class RandomlyMovingExhaleAsteroid : RandomlyMovingAsteroid
    {
        public RandomlyMovingExhaleAsteroid(Position positionIn, int paceIn = 100)
            : base(positionIn, paceIn)
        {
            Task.Run(() => Exhale()).Wait();
        }
    }

No we have the six different asteroid class.
Let's create the factory interface and its implementation.

	public interface IAsteroidFactory
    {
        IAsteroid CreateAsteroid(int paceIn);
    }

The parameter for those case when the caller wants to change the speed of the asteroid.
I created an enum for the implementation and I will use it when I drawing the creatable asteroid.

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

If you care why do I created interface for the factory please read the main ReadMe.md file.

I created a console application and tried the pattern with it. Check the code for more information.