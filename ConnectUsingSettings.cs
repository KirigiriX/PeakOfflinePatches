using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using ExitGames.Client.Photon;
using Photon.Realtime;
using UnityEngine;

namespace Photon.Pun
{
	// Token: 0x02000015 RID: 21
	public static partial class PhotonNetwork
	{
		// Token: 0x0600006A RID: 106 RVA: 0x00004CFC File Offset: 0x00002EFC
		public static bool ConnectUsingSettings(AppSettings appSettings, bool startInOfflineMode = false)
		{
			if (PhotonNetwork.NetworkingClient.LoadBalancingPeer.PeerState != PeerStateValue.Disconnected)
			{
				Debug.LogWarning("ConnectUsingSettings() failed. Can only connect while in state 'Disconnected'. Current state: " + PhotonNetwork.NetworkingClient.LoadBalancingPeer.PeerState.ToString());
				return false;
			}
			if (ConnectionHandler.AppQuits)
			{
				Debug.LogWarning("Can't connect: Application is closing. Unity called OnApplicationQuit().");
				return false;
			}
			if (PhotonNetwork.PhotonServerSettings == null)
			{
				Debug.LogError("Can't connect: Loading settings failed. ServerSettings asset must be in any 'Resources' folder as: PhotonServerSettings");
				return false;
			}
			PhotonNetwork.SetupLogging();
			PhotonNetwork.NetworkingClient.LoadBalancingPeer.TransportProtocol = appSettings.Protocol;
			PhotonNetwork.NetworkingClient.ExpectedProtocol = null;
			PhotonNetwork.NetworkingClient.EnableProtocolFallback = appSettings.EnableProtocolFallback;
			PhotonNetwork.NetworkingClient.AuthMode = appSettings.AuthMode;
			PhotonNetwork.IsMessageQueueRunning = true;
			PhotonNetwork.NetworkingClient.AppId = appSettings.AppIdRealtime;
			PhotonNetwork.GameVersion = appSettings.AppVersion;
			if (startInOfflineMode)
			{
				PhotonNetwork.OfflineMode = true;
				return true;
			}
			if (PhotonNetwork.OfflineMode)
			{
				PhotonNetwork.OfflineMode = true;
				Debug.LogWarning("Offline mode is now enabled :D");
			}
			PhotonNetwork.NetworkingClient.EnableLobbyStatistics = appSettings.EnableLobbyStatistics;
			PhotonNetwork.NetworkingClient.ProxyServerAddress = appSettings.ProxyServer;
			if (appSettings.IsMasterServerAddress)
			{
				if (PhotonNetwork.AuthValues == null)
				{
					PhotonNetwork.AuthValues = new AuthenticationValues(Guid.NewGuid().ToString());
				}
				else if (string.IsNullOrEmpty(PhotonNetwork.AuthValues.UserId))
				{
					PhotonNetwork.AuthValues.UserId = Guid.NewGuid().ToString();
				}
				return PhotonNetwork.ConnectToMaster(appSettings.Server, appSettings.Port, appSettings.AppIdRealtime);
			}
			PhotonNetwork.NetworkingClient.NameServerPortInAppSettings = appSettings.Port;
			if (!appSettings.IsDefaultNameServer)
			{
				PhotonNetwork.NetworkingClient.NameServerHost = appSettings.Server;
			}
			if (appSettings.IsBestRegion)
			{
				return PhotonNetwork.ConnectToBestCloudServer();
			}
			return PhotonNetwork.ConnectToRegion(appSettings.FixedRegion);
		}
	}
}
