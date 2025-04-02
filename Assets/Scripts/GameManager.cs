using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviourPunCallbacks
{
    [SerializeField] byte eventCode = 0;
    private void Start()
    {
        if(PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.RaiseEvent(eventCode, null, RaiseEventOptions.Default, SendOptions.SendReliable);
        }
            // eventCode    : 이벤트 고유번호
            // custom Data  : 이벤트와 함께 전송할 데이터 (object)
            // options      : 이벤트를 전달하는 기능
            // -이벤트를 모든 클라이언트에게 보내거나 특정한 클라이언트에게 보낼 수 있는 기능

            // sendOptions : 이벤트를 전송하는 방식
            // -이벤트를 안전하게 보낼 수 있는지를 설정하는 기능
    }
    private void OnEnable()
    {
        PhotonNetwork.NetworkingClient.EventReceived += OnEventReceived;
    }
    private void OnEventReceived(EventData photonEvent)
    {
        Debug.Log(photonEvent.Code);
    }
    private void OnDisable()
    {
        PhotonNetwork.NetworkingClient.EventReceived -= OnEventReceived;
    }
}
