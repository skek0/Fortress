using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creater : MonoBehaviourPunCallbacks
{
    [SerializeField] Transform[] transforms;
    static int count = 0;

    private void Awake()
    {
        Create();
    }

    private void Create()
    {
        PhotonNetwork.Instantiate
        (
            "Character",
            transforms[count++].position,
            Quaternion.identity
        );
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        count--;
    }
}
