using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creater : MonoBehaviourPunCallbacks
{
    [SerializeField] Transform[] transforms;

    private void Awake()
    {
        Create();
    }

    private void Create()
    {
        PhotonNetwork.Instantiate
        (
            "Character",
            transforms[Random.Range(0, transforms.Length)].position,
            Quaternion.identity
        );
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
    }
}
