using FactoryPattern_Asteroids.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FactoryPattern_Asteroids.Asteroids
{
    public interface IAsteroid
    {
        Task MoveTask { get; }
        Position Position { get; }
        List<IAsteroid> Children { get; }
        int Extent { get; }
    }
}