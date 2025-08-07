using System;
using UnityEngine;

public static partial class CloudAPI
{
    // Adjusted start date to align LevelIndex 55 with 07/08/2025
    private static readonly DateTime startDate = new DateTime(2025, 6, 14);

    public static void CheckVersion(Action<LoginResponse> response)
    {
        DateTime today = DateTime.UtcNow.Date; // Use UTC or local depending on your needs
        int daysSinceStart = (today - startDate).Days;

        int levelIndex = Mathf.Max(1, daysSinceStart + 1);

        LoginResponse loginResponse = new LoginResponse
        {
            VersionOkay = true,
            HoursUntilLevel = 24,
            MinutesUntilLevel = 0,
            SecondsUntilLevel = 0,
            LevelIndex = levelIndex,
            Message = "why did the chicken cross the caldera?"
        };

        response?.Invoke(loginResponse);
    }
}
