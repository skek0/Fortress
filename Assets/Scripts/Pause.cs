using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject pausePanel;

    public void Resume()
    {
        pausePanel.SetActive(false);

        MouseManager.Instance.SetMouse(false);
    }
    public void Exit()
    {
        PhotonNetwork.LeaveRoom();
    }
    public override void OnLeftRoom()
    {
        pausePanel.SetActive(false);

        PhotonNetwork.LoadLevel("Room");
    }
}
