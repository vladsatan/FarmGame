using UnityEngine;

public class FirstPersonMove : MonoBehaviour
{
    public float moveSpeed = 5f;

    public float runSpeed = 8f;

    public float walkSpeed = 5f;
    private CharacterController controller;
    public void Start ()
    {
        controller = GetComponent<CharacterController>();
    }

    public void Update ()
    {
        float z = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");

        bool run = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        if(run && z > 0){moveSpeed = runSpeed;}
        else{moveSpeed = walkSpeed;}

        Vector3 directionForward = transform.forward * z;

        Vector3 directionRight = transform.right * x;

        Vector3 direction = directionForward + directionRight;

        if(direction.magnitude > 1f){direction = direction.normalized;}
        
        controller.Move(direction * moveSpeed * Time.deltaTime);

    }
}
