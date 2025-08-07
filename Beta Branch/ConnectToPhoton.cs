using System;
using System.Collections;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using Zorro.Core;

// Token: 0x02000178 RID: 376
public partial class NetworkConnector : MonoBehaviourPunCallbacks
{
	// Token: 0x06000964 RID: 2404 RVA: 0x00044ADC File Offset: 0x00042CDC
	public static void ConnectToPhoton()
	{
		PhotonNetwork.OfflineMode = true;
		BuildVersion version = new BuildVersion(Application.version);
		PhotonNetwork.AutomaticallySyncScene = true;
		PhotonNetwork.GameVersion = version.ToString();
		PhotonNetwork.PhotonServerSettings.AppSettings.AppVersion = version.ToMatchmaking();
		NetworkConnector.PrepareSteamAuthTicket(delegate
		{
			PhotonNetwork.ConnectUsingSettings();
			Debug.Log("Photon Start" + PhotonNetwork.NetworkClientState.ToString() + " using app version: " + version.ToMatchmaking());
		});
	}
}
