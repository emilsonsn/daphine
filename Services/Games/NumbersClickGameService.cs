using Daphine.Models;

namespace Daphine.Services.Games;

public class NumbersClickGameService
{
    private static readonly Dictionary<string, string> NumberLabels = new()
    {
        ["um"] = "1",
        ["dois"] = "2",
        ["tres"] = "3",
        ["quatro"] = "4",
        ["cinco"] = "5"
    };

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

    public NumberRound GenerateRound()
    {
        var keys = NumberLabels.Keys.ToList();
        var random = Random.Shared;

        var target = keys[random.Next(keys.Count)];

        var options = new List<string> { target };

        while (options.Count < 3)
        {
            var candidate = keys[random.Next(keys.Count)];

            if (!options.Contains(candidate))
                options.Add(candidate);
        }

        var shuffled = options
            .OrderBy(_ => random.Next())
            .Select(key => new NumberOption
            {
                Name = key,
                Label = NumberLabels[key],
                Image = $"images/numbers/{key}.svg",
                IsCorrect = key == target
            })
            .ToList();

        return new NumberRound
        {
            TargetNumberName = target,
            TargetNumberLabel = NumberLabels[target],
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

public class NumberRound
{
    public string TargetNumberName { get; set; } = string.Empty;
    public string TargetNumberLabel { get; set; } = string.Empty;
    public List<NumberOption> Options { get; set; } = new();
}
