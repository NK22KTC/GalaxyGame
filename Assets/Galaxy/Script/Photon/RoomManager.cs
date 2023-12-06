using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.Windows;
using Photon.Realtime;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public GameObject player;
    [Space]
    public Transform spawnPoint;

    const int maxPlayer = 2;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Connecting...");

        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        //base.OnConnectedToMaster();
        Debug.Log("Connected to Server");

        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        //base.OnJoinedLobby();
        var roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = maxPlayer;

        PhotonNetwork.JoinOrCreateRoom("test", roomOptions, null);

        Debug.Log("We're in the lobby");
        
    }

    public override void OnJoinedRoom()
    {
        //base.OnJoinedRoom();
        Debug.Log("We're connected and in a room!");

        GameObject _player = PhotonNetwork.Instantiate(GeneralSettings.Instance.m_Prehabs.Player.name, spawnPoint.position, Quaternion.identity);
        PlayerSetup playerSetup = _player.GetComponent<PlayerSetup>();
        playerSetup.IsLocalPlayer(playerSetup);
    }

}

