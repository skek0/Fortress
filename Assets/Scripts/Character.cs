using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Move))]
public class Character : MonoBehaviourPun
{
    [SerializeField] Move move;
    [SerializeField] Rigidbody rigid;
    [SerializeField] GameObject remoteCamera;

    public float speed;
    Vector3 direction;

    private void Awake()
    {
        move = GetComponent<Move>();
        rigid = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        DisableCamera();
    }

    private void Update()
    {
        move.OnKeyUpdate();
    }
    private void FixedUpdate()
    {
        move.OnMove(rigid);
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
