
using Daphine.Models;

namespace Daphine.Services;

public class GameService
{
    public List<Game> GetGames()
    {
        return new List<Game>
        {
            new Game
            {
                Id = "animal-click",
                Name = "Clique no Animal",
                Description = "Aprenda os animais clicando neles",
                Image = "/images/animal-game.svg",
                Route = "/games/animal-click"
            }
        };
    }
}