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
            // eventCode    : �̺�Ʈ ������ȣ
            // custom Data  : �̺�Ʈ�� �Բ� ������ ������ (object)
            // options      : �̺�Ʈ�� �����ϴ� ���
            // -�̺�Ʈ�� ��� Ŭ���̾�Ʈ���� �����ų� Ư���� Ŭ���̾�Ʈ���� ���� �� �ִ� ���

            // sendOptions : �̺�Ʈ�� �����ϴ� ���
            // -�̺�Ʈ�� �����ϰ� ���� �� �ִ����� �����ϴ� ���
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
