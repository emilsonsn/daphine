
using Daphine.Models;

namespace Daphine.Services;

public class GameService
{
    private static string _lastOrderSignature = string.Empty;

    public List<Game> GetGames()
    {
        var games = new List<Game>
        {
            new Game
            {
                Id = "animal-click",
                Name = "Clique no Animal",
                Description = "Aprenda os animais clicando neles",
                Image = "/images/animal-game.svg",
                Route = "/games/animal-click"
            },
            new Game
            {
                Id = "color-click",
                Name = "Clique na Cor",
                Description = "Aprenda as cores clicando nelas",
                Image = "/images/color-game.svg",
                Route = "/games/color-click"
            },
            new Game
            {
                Id = "numbers-click",
                Name = "Clique nos Números",
                Description = "Aprenda os números clicando nos porquinhos",
                Image = "/images/numbers-game.svg",
                Route = "/games/numbers-click"
            },
            new Game
            {
                Id = "princess-game",
                Name = "Jogo da princesa",
                Description = "Jogue o jogo da princesa",
                Image = "/images/princess-game.svg",
                Route = "/games/princess-click"
            },
            new Game
            {
                Id = "cat-game",
                Name = "Jogo do Gato",
                Description = "Jogue o jogo do gato",
                Image = "/images/cat-game.svg",
                Route = "/games/cat-click"
            },
            new Game
            {
                Id = "drag-game",
                Name = "Jogo de Arrastar",
                Description = "Jogue o jogo de arrastar",
                Image = "/images/drag-game.svg",
                Route = "/games/drag-click"
            }
        };

        ShuffleGames(games);
        EnsureDifferentFromPreviousOrder(games);

        return games;
    }

    private static void ShuffleGames(IList<Game> games)
    {
        for (var i = games.Count - 1; i > 0; i--)
        {
            var j = Random.Shared.Next(i + 1);
            (games[i], games[j]) = (games[j], games[i]);
        }
    }

    private static void EnsureDifferentFromPreviousOrder(IList<Game> games)
    {
        if (games.Count < 2)
        {
            return;
        }

        var currentSignature = BuildSignature(games);

        if (currentSignature == _lastOrderSignature)
        {
            (games[0], games[1]) = (games[1], games[0]);
            currentSignature = BuildSignature(games);
        }

        _lastOrderSignature = currentSignature;
    }

    private static string BuildSignature(IList<Game> games)
    {
        var ids = new string[games.Count];

        for (var i = 0; i < games.Count; i++)
        {
            ids[i] = games[i].Id;
        }

        return string.Join('|', ids);
    }
}