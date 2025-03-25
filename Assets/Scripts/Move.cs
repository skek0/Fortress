using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] float speed;
    Vector3 direction;

    public void OnKeyUpdate()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");

        direction.Normalize();
    }

    public void OnMove(Rigidbody rigidBody)
    {
        rigidBody.position += rigidBody.transform.TransformDirection(speed * Time.fixedDeltaTime * direction);
    }
}
