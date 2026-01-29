using UnityEngine;
using System.Collections;

public class FirstPersonLook : MonoBehaviour
{
    public GameObject player;
    public GameObject camera;
    private float mouseSensitivity = 200f;
    private float pitch = 0f;

    private void Start() 
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update() 
    {
       float mouseX = Input.GetAxis("Mouse X");
       float mouseY = Input.GetAxis("Mouse Y");

       float yaw = mouseX * mouseSensitivity * Time.deltaTime;
       pitch -= mouseY * mouseSensitivity * Time.deltaTime;

       pitch = Mathf.Clamp(pitch, -80f, 80f);

       player.transform.Rotate(0, yaw, 0);
       camera.transform.localRotation = Quaternion.Euler(pitch, 0f, 0f);
    }
}
