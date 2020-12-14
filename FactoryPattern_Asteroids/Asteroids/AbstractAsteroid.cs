using FactoryPattern_Asteroids.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FactoryPattern_Asteroids.Asteroids
{
    public abstract class AbstractAsteroid : IAsteroid
    {
        public Position Position { get; private set; }
        public int Extent { get; private set; }
        public Task MoveTask { get; private set; }
        public List<IAsteroid> Children { get; } = new List<IAsteroid>();
        public Random Random { get; private set; } = new Random();

        public AbstractAsteroid(Position positionIn, int paceIn = 100)
        {
            SetDirection();
            Pace = paceIn;
            int horizontalPostion = positionIn.Horizontal;
            this.Position = positionIn;
            this.Extent = Random.Next(2, 20);

            MoveTask = Task.Run(() => Move());
        }

        public void Move()
        {
            while (this.Position.Vertical < WindowHeight && this.Position.Vertical >= 0
                && this.Position.Horizontal < WindowWidth && this.Position.Horizontal >= 0)
            {
                CalculateAndSetNextPosition();
            }

            Disappeared = true;

            Task[] childrenMoveTasks = new Task[Children.Count];
            for (int i = 0; i < Children.Count; i++)
            {
                childrenMoveTasks[i] = Children[i].MoveTask;
            }

            Task.WaitAll(childrenMoveTasks);
        }

        internal int WindowHeight = Console.WindowHeight;
        internal int WindowWidth = Console.WindowWidth;
        internal int Pace;
        internal bool Disappeared = false;

        internal virtual void CalculateAndSetNextPosition()
        {
            Thread.Sleep(Pace);
            this.Position.Vertical += verticalDirection;
            this.Position.Horizontal += horizontalDirection;
        }

        internal void Exhale()
        {
            while (!Disappeared)
            {
                Thread.Sleep(Random.Next(Pace, 10 * Pace));
                Children.Add(new StraitMovingAsteroid(Position, Pace));
            }
        }

        private int horizontalDirection;
        private int verticalDirection;

        private void SetDirection()
        {
            horizontalDirection = Random.Next(-2, 2);
            verticalDirection = Random.Next(-2, 2);
            if (horizontalDirection == 0 && verticalDirection == 0)
            {
                verticalDirection = 1;
            }
        }
    }
}
