using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField] Dropdown dropDown;

    public void Connect()
    {
        // ������ �����ϴ� �Լ�
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby
        (
            new TypedLobby
            (
                dropDown.options[dropDown.value].text,
                LobbyType.Default
            )
        );
    }

    public override void OnJoinedLobby()
    {
        PhotonNetwork.IsMessageQueueRunning = true;

        PhotonNetwork.LoadLevel("Room");
    }
}