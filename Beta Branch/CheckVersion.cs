using System;
using UnityEngine;

// Token: 0x02000074 RID: 116
public static partial class CloudAPI
{
	private static int? cachedLevelIndex;
	// Token: 0x0600042B RID: 1067 RVA: 0x00030930 File Offset: 0x0002EB30
	public static void CheckVersion(Action<LoginResponse> response)
	{
		if (CloudAPI.cachedLevelIndex == null)
		{
			CloudAPI.cachedLevelIndex = new int?(global::UnityEngine.Random.Range(1, 1001));
		}
		LoginResponse loginResponse = new LoginResponse
		{
			VersionOkay = true,
			HoursUntilLevel = 24,
			MinutesUntilLevel = 00,
			SecondsUntilLevel = 00,
			LevelIndex = CloudAPI.cachedLevelIndex.Value,
			Message = "Thanks for testing the PEAK beta. Watch out for bugs! (the current beta is the same as the live game, check back later for a new beta!)"
		};
		if (response != null)
		{
			response(loginResponse);
		}
	}
}
