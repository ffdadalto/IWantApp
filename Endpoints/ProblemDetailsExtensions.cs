using Flunt.Notifications;
using Microsoft.AspNetCore.Identity;

namespace IWantApp.Endpoints;

public static class ProblemDetailsExtensions
{
    public static Dictionary<string, string[]> ConvertToProblemDatails(this IReadOnlyCollection<Notification> notifications)
    {
        return notifications
                .GroupBy(c => c.Key)
                .ToDictionary(c => c.Key, c => c.Select(x => x.Message).ToArray());
    }

    public static Dictionary<string, string[]> ConvertToProblemDatails(this IEnumerable<IdentityError> error)
    {
        return error
                .GroupBy(c => c.Code)
                .ToDictionary(c => c.Key, c => c.Select(x => x.Description).ToArray());
    }
}
