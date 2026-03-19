using Daphine.Models;

namespace Daphine.Services.Games;

public class ColorClickGameService
{
    private static readonly Dictionary<string, string> ColorLabels = new()
    {
        ["amarelo"] = "Amarelo",
        ["azul"] = "Azul",
        ["laranja"] = "Laranja",
        ["rosa"] = "Rosa",
        ["verde"] = "Verde",
        ["vermelho"] = "Vermelho"
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

    public ColorRound GenerateRound()
    {
        var keys = ColorLabels.Keys.ToList();
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
            .Select(key => new ColorOption
            {
                Name = key,
                Label = ColorLabels[key],
                Image = $"images/colors/{key}.svg",
                IsCorrect = key == target
            })
            .ToList();

        return new ColorRound
        {
            TargetColorName = target,
            TargetColorLabel = ColorLabels[target],
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

public class ColorRound
{
    public string TargetColorName { get; set; } = string.Empty;
    public string TargetColorLabel { get; set; } = string.Empty;
    public List<ColorOption> Options { get; set; } = new();
}
