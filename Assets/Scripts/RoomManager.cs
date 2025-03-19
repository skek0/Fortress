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
            else // 룸의 정보가 변경되는 경우
            {
                if(!rooms.ContainsKey(roomInfo.Name)) // 이 방이 딕셔너리에 없다면 딕셔너리에 추가
                {
                    GameObject clone = Instantiate(Resources.Load<GameObject>("Room"), parentTransform);

                    clone.GetComponent<Information>().View(roomInfo.Name, roomInfo.PlayerCount, roomInfo.MaxPlayers);

                    rooms.Add(roomInfo.Name, clone);
                }
                else // 이 방이 딕셔너리에 있음. 즉 인원 수 변경 등
                {
                    rooms.TryGetValue(roomInfo.Name, out room);

                    room.GetComponent<Information>().View(roomInfo.Name, roomInfo.PlayerCount, roomInfo.MaxPlayers);
                }
            }
        }
    }
}