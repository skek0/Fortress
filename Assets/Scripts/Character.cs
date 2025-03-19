using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviourPun
{
    [SerializeField] GameObject remoteCamera;

    private void Start()
    {
        DisableCamera();
    }

    public void DisableCamera()
    {
        if(photonView.IsMine)
        {
            Camera.main.gameObject.SetActive(false);
        }
        else
        {
            remoteCamera.SetActive(false);
        }
    }
}
