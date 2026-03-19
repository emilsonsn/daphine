using Daphine.Models;

namespace Daphine.Services.Games;

public class AnimalClickGameService
{
    private static readonly List<string> SuccessAudios = new()
    {
        "audio/success.mp3",
        "audio/success2.mp3"
    };

    private static readonly List<string> ErrorAudios = new()
    {
        "audio/error.mp3",
        "audio/error2.mp3"
    };

    private static readonly List<string> Animals = new()
    {
        "cachorro",
        "gato",
        "vaca",
        "leao",
        "elefante",
        "macaco",
        "pato",
        "cavalo",
        "coelho",
        "galinha",
        "borboleta",
        "formiga",
        "tartaruga",
        "peixe",
    };

    public AnimalRound GenerateRound()
    {
        var random = Random.Shared;

        var target = Animals[random.Next(Animals.Count)];

        var options = new List<string> { target };

        while (options.Count < 3)
        {
            var animal = Animals[random.Next(Animals.Count)];

            if (!options.Contains(animal))
                options.Add(animal);
        }

        var shuffled = options
            .OrderBy(x => random.Next())
            .Select(x => new AnimalOption
            {
                Name = x,
                Image = $"images/animals/{x}.png",
                IsCorrect = x == target
            })
            .ToList();

        return new AnimalRound
        {
            TargetAnimal = target,
            Options = shuffled
        };
    }

    public string GetRandomSuccessAudio()
    {
        return SuccessAudios[Random.Shared.Next(SuccessAudios.Count)];
    }

    public string GetRandomErrorAudio()
    {
        return ErrorAudios[Random.Shared.Next(ErrorAudios.Count)];
    }
}

public class AnimalRound
{
    public string TargetAnimal { get; set; } = string.Empty;
    public List<AnimalOption> Options { get; set; } = new();
}