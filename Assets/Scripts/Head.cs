using UnityEngine;
using Photon;
using Photon.Pun;

[RequireComponent(typeof(Rotation))]
public class Head : MonoBehaviourPunCallbacks
{
    Rotation rotation;
    private void Awake()
    {
        rotation = GetComponent<Rotation>();
    }

    private void Update()
    {
        if (!photonView.IsMine) return;

        rotation.OnMouseY();

        rotation.RotateX(gameObject);
    }
}
