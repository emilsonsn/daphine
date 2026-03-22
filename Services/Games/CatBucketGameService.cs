namespace Daphine.Services.Games;

public class CatBucketGameService
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

    public int PickCatBucketId()
    {
        return Random.Shared.Next(1, 4);
    }

    public List<int> ShuffleBucketOrder(IReadOnlyList<int> currentOrder)
    {
        var shuffled = currentOrder
            .OrderBy(_ => Random.Shared.Next())
            .ToList();

        if (currentOrder.SequenceEqual(shuffled) && shuffled.Count > 1)
        {
            (shuffled[0], shuffled[1]) = (shuffled[1], shuffled[0]);
        }

        return shuffled;
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
