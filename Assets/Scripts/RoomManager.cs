using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class RoomManager : MonoBehaviourPunCallbacks
{
    [SerializeField] InputField titleInputField;
    [SerializeField] InputField capacityInputField;

    [SerializeField] Transform parentTransform;

    [SerializeField] Dictionary<string, GameObject> rooms = new Dictionary<string, GameObject> ();

    private void Start()
    {
        if (PhotonNetwork.InLobby == false)
        {
            PhotonNetwork.JoinLobby();
        }
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }

    public void OnCreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();

        roomOptions.MaxPlayers = byte.Parse(capacityInputField.text);

        roomOptions.IsOpen = true;

        roomOptions.IsVisible = true;

        PhotonNetwork.CreateRoom(titleInputField.text, roomOptions);
    }


    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        GameObject room = null;
        foreach (RoomInfo roomInfo in roomList)
        {
            if(roomInfo.RemovedFromList)
            {
                rooms.TryGetValue(roomInfo.Name, out room);
                rooms.Remove(roomInfo.Name);
                Destroy(room);
            }
            else // ���� ������ ����Ǵ� ���
            {
                if(!rooms.ContainsKey(roomInfo.Name)) // �� ���� ��ųʸ��� ���ٸ� ��ųʸ��� �߰�
                {
                    GameObject clone = Instantiate(Resources.Load<GameObject>("Room"), parentTransform);

                    clone.GetComponent<Information>().View(roomInfo.Name, roomInfo.PlayerCount, roomInfo.MaxPlayers);

                    rooms.Add(roomInfo.Name, clone);
                }
                else // �� ���� ��ųʸ��� ����. �� �ο� �� ���� ��
                {
                    rooms.TryGetValue(roomInfo.Name, out room);

                    room.GetComponent<Information>().View(roomInfo.Name, roomInfo.PlayerCount, roomInfo.MaxPlayers);
                }
            }
        }
    }
}