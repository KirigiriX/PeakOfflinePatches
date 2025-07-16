using System;
using System.Collections;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using Zorro.Core;

// Token: 0x0200016B RID: 363
public partial class NetworkConnector : MonoBehaviourPunCallbacks
{
	// Token: 0x060008F5 RID: 2293 RVA: 0x000421EC File Offset: 0x000403EC
	public static void ConnectToPhoton()
	{
		PhotonNetwork.PhotonServerSettings.AppSettings.AppIdRealtime = "";
		PhotonNetwork.PhotonServerSettings.AppSettings.AppIdVoice = "";
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
