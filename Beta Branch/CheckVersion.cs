using System;
using UnityEngine;

public static partial class CloudAPI
{
    // Adjusted start date to align LevelIndex 55 with 07/08/2025
    private static readonly DateTime startDate = new DateTime(2025, 6, 14);

    public static void CheckVersion(Action<LoginResponse> response)
    {
        DateTime now = DateTime.Now;                  // current system local time
        DateTime midnight = now.Date.AddDays(1);      // next midnight (12:00 AM)
        TimeSpan timeUntilMidnight = midnight - now; // time left until midnight

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
