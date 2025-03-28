using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField] Dropdown dropDown;

    public void Connect()
    {
        // 서버에 접속하는 함수
        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings();
        }
        else
        {
            Debug.Log("Already Connected to Photon. Current state : " + PhotonNetwork.NetworkClientState);
        }

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
        StartCoroutine(LoadRoom());
    }

    IEnumerator LoadRoom()
    {
        while (!PhotonNetwork.IsConnectedAndReady)
        {
            yield return null;
        }
        PhotonNetwork.LoadLevel("Room");
    }
}