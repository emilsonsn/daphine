namespace Daphine.Services.Characters;

public enum DaphineMood
{
    Idle,
    Speaking,
    Happy,
    Sad
}

public class DaphineCharacterService
{
    public DaphineMood Mood { get; private set; } = DaphineMood.Idle;

    public void SetIdle() => Mood = DaphineMood.Idle;

    public void SetSpeaking() => Mood = DaphineMood.Speaking;

    public void SetHappy() => Mood = DaphineMood.Happy;

    public void SetSad() => Mood = DaphineMood.Sad;

    public string GetImagePath()
    {
        return Mood switch
        {
            DaphineMood.Speaking => "images/daphine/daphine-speaking.png",
            DaphineMood.Happy => "images/daphine/daphine-happy.png",
            DaphineMood.Sad => "images/daphine/daphine-sad.png",
            _ => "images/daphine/daphine-idle.png"
        };
    }
}