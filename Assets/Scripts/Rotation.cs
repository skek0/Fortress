using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    float mouseX;
    float mouseY;
    [SerializeField] float speed;

    public void OnMouseX()
    {
        mouseX += Input.GetAxisRaw("Mouse X") * speed * Time.deltaTime;
    }

    public void OnMouseY()
    {
        mouseY += Input.GetAxisRaw("Mouse Y") * speed * Time.deltaTime;
    }
    public void RotateY(Rigidbody rigidBody)
    {
        rigidBody.transform.eulerAngles = new Vector3(0, mouseX, 0);
    }
    public void RotateX(GameObject clone)
    {
        mouseY = Mathf.Clamp(mouseY, -65, 65);

        clone.transform.localEulerAngles = new Vector3(-mouseY, 0f, 0f);
    }
}
