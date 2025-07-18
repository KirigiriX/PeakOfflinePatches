# Peak Offline Patches

This project contains lightweight assembly patches for PEAK. It removes or disables online checks directly inside the compiled game files—no external tools or injectors needed.

---

## 🔧 What It Does

- Removes server check logic on PEAK
- Enables full offline play
- Works by editing compiled code (usually `Assembly-CSharp.dll & PhotonUnityNetworking.dll`)

---

## 📁 How to Use

1. **Backup your game folder** – Always keep an original copy.
2. **Navigate to the patched version** for your game in this repo.
3. **Replace the file** (usually `Assembly-CSharp.dll & PhotonUnityNetworking.dll` in `PEAK_Data/Managed/`)
4. **Launch the game** – No internet needed!

---

## 💬 Notes

- These patches are game-specific and version-specific.
- They are meant for archival, research, and offline preservation.

---

## ⚠️ Disclaimer

> These patches are provided for educational and preservation purposes only.  

---

                 ┌─────────────────────────────┐
                 │        Game Client           │
                 │ (Original code expects server) │
                 └─────────────┬───────────────┘
                               │
                 (Requests login/version & multiplayer connection)
                               │
                               ▼
                ┌─────────────────────────────┐
                │      Patched CloudAPI        │
                │  (Local stub replaces server)│
                │ - Returns mocked login data  │
                │ - Generates random LevelIndex│
                │ - Sends back static messages │
                └─────────────┬───────────────┘
                              │
                              ▼
                ┌─────────────────────────────┐
                │   Patched NetworkConnector   │
                │  (Photon forced OfflineMode) │
                │ - Sets PhotonNetwork.OfflineMode = true │
                │ - Skips real server connection           │
                └─────────────┬───────────────┘
                              │
                              ▼
                ┌─────────────────────────────┐
                │   Photon Networking Engine   │
                │   (Offline mode active)      │
                │ - Simulates multiplayer locally │
                │ - No actual network traffic    │
                └─────────────┬───────────────┘
                              │
                              ▼
               ┌─────────────────────────────┐
               │      Game Runs Fully Offline │
               │ - All server communication is emulated locally │
               │ - Multiplayer features run locally │
               └─────────────────────────────┘

