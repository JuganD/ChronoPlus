namespace ChronoPlus.Controller.Models
{
    public enum Result
    {
        // TODO: test this
        Unknown = 0, // 0 because sometimes tryparse fails and returns unexpected result (for testing purpose)
        Rolled = 200,
        InvalidToken = 401,
        Cooldown = 420
    }
}