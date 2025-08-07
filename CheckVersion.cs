using System;
using UnityEngine;

public static void CheckVersion(Action<LoginResponse> response)
{
    DateTime now = DateTime.Now;
    DateTime midnight = now.Date.AddDays(1)
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
        Message = "why did the chicken cross the caldera?"
    };

    response?.Invoke(loginResponse);
}
