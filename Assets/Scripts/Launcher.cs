using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace br.unorp.ads
{

    public class Launcher : MonoBehaviourPunCallbacks
    {
        private byte maxPlayersPerRoom = 4;
        bool isConnecting;
        string gameVersion = "1";

        void Awake()
        {
            PhotonNetwork.AutomaticallySyncScene = true;
        }

        void Start()
        {
        }

        public override void OnConnectedToMaster()
        {
            Debug.Log("OnConnectedToMaster()");
            if (isConnecting)
            {
                PhotonNetwork.JoinRandomRoom();
                isConnecting = false;
            }
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            Debug.LogWarningFormat("OnDisconnected() - {0}", cause);
        }

        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            Debug.Log("OnJoinRandomFailed()");
            PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = maxPlayersPerRoom });

        }

        public override void OnJoinedRoom()
        {
            Debug.Log("OnJoinedRoom()");
            if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
            {
                Debug.Log("'Room for 1'");
                PhotonNetwork.LoadLevel("Room for 1");
            }
        }

        public void Connect()
        {
            if (PhotonNetwork.IsConnected)
            {
                PhotonNetwork.JoinRandomRoom();
            }
            else
            {
                isConnecting = PhotonNetwork.ConnectUsingSettings();
                PhotonNetwork.GameVersion = gameVersion;
            }
        }
    }
}