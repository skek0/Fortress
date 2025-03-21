using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Move))]
[RequireComponent (typeof(Rotation))]
public class Character : MonoBehaviourPun
{
    [SerializeField] Move move;
    [SerializeField] Rotation rotation;
    [SerializeField] Rigidbody rigid;
    [SerializeField] GameObject remoteCamera;

    public float speed;
    Vector3 direction;

    private void Awake()
    {
        move = GetComponent<Move>();
        rotation = GetComponent<Rotation>();
        rigid = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        DisableCamera();
    }

    private void Update()
    {
        if (!photonView.IsMine) return;
        
        move.OnKeyUpdate();
        rotation.OnMouseUpdate();
    }
    private void FixedUpdate()
    {
        move.OnMove(rigid);
        rotation.RotateY(rigid);
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
