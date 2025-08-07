using System;
using UnityEngine;

public static partial class CloudAPI
{
    private static readonly DateTime startDate = new DateTime(2025, 6, 14);

    public static void CheckVersion(Action<LoginResponse> response)
    {
        DateTime now = DateTime.Now;
        DateTime midnight = now.Date.AddDays(1);
        TimeSpan timeUntilMidnight = midnight - now;

        int daysSinceStart = (now.Date - startDate).Days;
        int levelIndex = Mathf.Max(1, daysSinceStart + 1);

        LoginResponse loginResponse = new LoginResponse
        {
            VersionOkay = true,
            HoursUntilLevel = timeUntilMidnight.Hours,
            MinutesUntilLevel = timeUntilMidnight.Minutes,
            SecondsUntilLevel = timeUntilMidnight.Seconds,
            LevelIndex = levelIndex,
            Message = "Thanks for testing the PEAK beta. Watch out for bugs! (the current beta is the same as the live game, check back later for a new beta!)"
        };

        response?.Invoke(loginResponse);
    }
}
