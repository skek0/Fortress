using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    float mouseX;
    [SerializeField] float speed;

    public void OnMouseUpdate()
    {
        mouseX += Input.GetAxisRaw("Mouse X") * speed * Time.deltaTime;
    }
    public void RotateY(Rigidbody rigidBody)
    {
        rigidBody.transform.eulerAngles = new Vector3(0, mouseX, 0);
    }
}
