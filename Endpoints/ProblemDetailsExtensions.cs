using Flunt.Notifications;

namespace IWantApp.Endpoints;

public static class ProblemDetailsExtensions
{
    public static Dictionary<string, string[]> ConvertToProblemDatails(this IReadOnlyCollection<Notification> notifications)
    {
        return notifications
                .GroupBy(c => c.Key)
                .ToDictionary(c => c.Key, c => c.Select(x => x.Message).ToArray());
    }
}
