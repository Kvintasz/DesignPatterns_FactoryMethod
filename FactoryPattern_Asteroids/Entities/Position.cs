namespace FactoryPattern_Asteroids.Entities
{
    public class Position
    {
        public int Vertical { get; set; }
        public int Horizontal { get; set; }

        public Position(int verticalIn, int horizontalIn)
        {
            Vertical = verticalIn;
            Horizontal = horizontalIn;
        }
    }
}
