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
		PhotonNetwork.OfflineMode = true;
	}
}
